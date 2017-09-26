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
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PSharp.Win32
{
    public static class WinApi
    {
        private const UInt32 FORMAT_MESSAGE_IGNORE_INSERTS = 512;
        private const UInt32 FORMAT_MESSAGE_FROM_HMODULE = 2048;
        private const UInt32 FORMAT_MESSAGE_FROM_SYSTEM = 4096;

        public const Int32 MAX_PATH = 260;
        public const Int32 NO_ERROR = 0;
        public const Int32 FILE_ATTRIBUTE_NORMAL = 128;
        public const Int32 FILE_ATTRIBUTE_DIRECTORY = 16;
        public const Int32 ERROR_NO_MORE_FILES = 18;
        public const UInt32 GENERIC_READ = 0x80000000;

        [DllImportAttribute("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern Int32 FreeLibrary(IntPtr hModule);

        [DllImportAttribute("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern UInt32 FormatMessage(UInt32 dwFlags, IntPtr lpSource, UInt32 dwMessageId, UInt32 dwLanguageId, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpBuffer, UInt32 nSize, IntPtr Arguments);

        [DllImportAttribute("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr LoadLibrary([In()] [MarshalAs(UnmanagedType.LPTStr)] String lpLibFileName);

        public static String TranslateInternetError(UInt32 errorCode)
        {
            IntPtr hModule = IntPtr.Zero;
            try
            {
                StringBuilder buf = new StringBuilder(255);
                hModule = LoadLibrary("wininet.dll");
                if (FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS, hModule, errorCode, 0U, buf, (UInt32)buf.Capacity + 1, IntPtr.Zero) != 0)
                {
                    return buf.ToString();
                }
                else
                {
                    Debug.Write("Error:: " + Marshal.GetLastWin32Error());
                    return String.Empty;
                }
            }
            catch
            {
                return "Unknown Error";
            }
            finally
            {
                FreeLibrary(hModule);
            }
        }

    }
}
