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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using PSharp.Interface;

namespace PSharp.Scripting
{
    class Parser
    {
        private Int32 m_variableCount;
        private Int32 m_functionCount;
        private Int32 m_nativeCount;
        private Int32 m_defineCount;

        public List<Functions> Functions { get; private set; }
        public List<Natives> Natives { get; private set; }
        public List<Variables> Variables { get; private set; }
        public List<Defines> Defines { get; set; }

        public Parser()
        {
            Functions = new List<Scripting.Functions>();
            Natives = new List<Scripting.Natives>();
            Variables = new List<Scripting.Variables>();
            Defines = new List<Scripting.Defines>();
        }

        public void ParseScript(String script)
        {
            Byte[] bytes = Encoding.UTF8.GetBytes(script ?? "");
            MemoryStream memoryStream = new MemoryStream(bytes);
            StreamReader streamReader = new StreamReader(memoryStream);

            streamReader.Read();
            while (streamReader.EndOfStream)
            {
                String line = streamReader.ReadLine();
                if (line.StartsWith("#define"))
                {
                    try
                    {
                        String[] split = line.Split(' ');
                        
                        if (split.Length >= 3)
                        {
                            String defineName = split[1];
                            String defineValue = split[2];

                            if (defineValue.StartsWith("(") && defineValue.EndsWith(")"))
                            {
                                defineValue.Replace("(", null).Replace(")", null);
                            }
                            else if (defineValue.StartsWith("\"") && defineValue.EndsWith("\""))
                            {
                                defineValue.Replace("\"", null);
                            }
                            Defines.Add(new Scripting.Defines()
                            {
                                DefineName = defineName,
                                Value = defineValue
                            });
                            m_defineCount++;
                        }
                        
                    }
                    catch (IndexOutOfRangeException ex)
                    {

                    }
                }

                if (line.StartsWith("new"))
                {
                    String[] split = line.Split(' ');
                    if (split.Length == 2)
                    {
                        DataType variableDataType;
                        String variableName = split[1];
                        if (variableName.StartsWith("bool:"))
                        {
                            variableDataType = DataType.Boolean;
                            variableName.Replace("bool:", null).Replace(";", null).Replace(",", null);
                            Variables.Add(new Scripting.Variables()
                            {
                                VariableName = variableName,
                                DefaultValue = null,
                                DataType = variableDataType
                            });
                        }
                        else if (variableName.StartsWith("Float:"))
                        {
                            variableDataType = DataType.Float;
                            variableName.Replace("Float:", null).Replace(";", null);
                            Variables.Add(new Scripting.Variables()
                            {
                                VariableName = variableName,
                                DefaultValue = null,
                                DataType = variableDataType
                            });
                        }
                        else if (variableName.Contains("[") && variableName.Contains("]"))
                        {
                            variableDataType = DataType.String;
                            variableName.Remove(variableName.IndexOf('['), variableName.Length - variableName.IndexOf(';'));
                            Variables.Add(new Scripting.Variables()
                            {
                                VariableName = variableName,
                                DefaultValue = null,
                                DataType = variableDataType
                            });
                        }
                        else
                        {
                            variableDataType = DataType.Integer;
                            Variables.Add(new Scripting.Variables()
                            {
                                VariableName = variableName,
                                DefaultValue = null,
                                DataType = variableDataType
                            });
                        }
                    }
                }
            }
        }
    }
}
