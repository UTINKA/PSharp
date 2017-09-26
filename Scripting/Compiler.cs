/*
 * Copyright (C) 2017-2018 Alimşah YILDIRIM <alimsahy@gmail.com>
 *
 * PSharp is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * PSharp is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
*/

using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

using PSharp.Interface;
using PSharp.Exceptions;
using PSharp.Events;

namespace PSharp.Scripting
{
    class Compiler : ICompiler
    {
        private String m_compilerPath;
        private ListView m_outputObject;
        private Boolean m_useProjectCompiler;
        private Int32 m_warningCount;
        private Int32 m_errorCount;

        public Boolean UseDefaultCompiler
        {
            get
            {
                return m_useProjectCompiler;
            }
            set
            {
                m_useProjectCompiler = value;
                m_compilerPath = null;
            }
        }

        public String CompilerPath
        {
            get
            {
                return m_compilerPath;
            }
            set
            {
                m_compilerPath = value;
            }
        }

        public ListView CompileDetailOutput
        {
            get
            {
                return m_outputObject;
            }
            set
            {
                try
                {
                    Type objectType = value.GetType();

                    if (objectType == typeof(ListView))
                    {
                        m_outputObject = value;
                    }
                    else
                    {
                        throw new UnsupportedOutputObjectException(objectType + " is not a supported output object");
                    }
                }
                catch (UnsupportedOutputObjectException ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        public void Compile(params Document[] file)
        {
            String compilerPath = null;
            if (UseDefaultCompiler)
            {
                compilerPath = PSharp.CompilerPath;
            }
            else
            {
                compilerPath = CompilerPath;
            }

            for (Int32 index = 0; index < file.Length; index++)
            {
                String scriptFile = Path.GetFileName(file[index].Name);
                String rawOutput = null;
                Process compiler = new Process();

                compiler.StartInfo.UseShellExecute = false;
                compiler.StartInfo.RedirectStandardOutput = true;
                compiler.StartInfo.RedirectStandardError = true;
                compiler.StartInfo.FileName = compilerPath;
                compiler.StartInfo.Arguments = "\"" + scriptFile + "\"" + " -r -;+ -(+";
                compiler.StartInfo.CreateNoWindow = true;
                compiler.Start();
                
                while (!compiler.HasExited)
                {
                    rawOutput = compiler.StandardError.ReadToEnd();
                    rawOutput += compiler.StandardOutput.ReadToEnd();
                    Application.DoEvents();

                    try
                    {
                        if (CompileDetailOutput != null)
                        {
                            if (rawOutput == String.Empty || rawOutput.Contains("warning") || rawOutput.Contains("error"))
                            {
                                dynamic inLine = rawOutput.Split(new String[] { "\r\n", "\n" }, StringSplitOptions.None);

                                for (Int32 i = 0; i < inLine.Length; i++)
                                {
                                    if (inLine[i] == String.Empty) break;
                                    if (inLine[i].Contains("Pawn compiler 3.")) continue;

                                    inLine[i] = inLine[i].Replace(scriptFile, "");

                                    String line = inLine[i].Substring(inLine[i].IndexOf('(') + 1, inLine[i].IndexOf(')') - inLine[i].IndexOf('(') - 1);
                                    if (line.Contains("warning"))
                                    {
                                        ListViewItem warningMessage = new ListViewItem("", 0);
                                        warningMessage.SubItems.Add(inLine[i].Replace("(" + line + ") :", null).Trim());
                                        warningMessage.SubItems.Add(line);
                                        CompileDetailOutput.Items.Add(warningMessage);
                                        m_warningCount++;
                                    }
                                    else if (line.Contains("error"))
                                    {
                                        ListViewItem errorMessage = new ListViewItem("", 0);
                                        errorMessage.SubItems.Add(inLine[i].Replace("(" + line + ") :", null).Trim());
                                        errorMessage.SubItems.Add(line);
                                        CompileDetailOutput.Items.Add(errorMessage);
                                        m_errorCount++;
                                    }
                                }
                            }
                        }
                        else
                        {
                            throw new ArgumentNullException(null);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        public Int32 GetWarningCount()
        {
            return m_warningCount;
        }

        public Int32 GetErrorCount()
        {
            return m_errorCount;
        }
    }
}
