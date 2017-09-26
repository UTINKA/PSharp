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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PSharp.Win32
{
    public static class WinINet
    {
        public const Int32 INTERNET_SERVICE_FTP = 1;

        public const Int32 INTERNET_OPEN_TYPE_PRECONFIG = 0;
        public const Int32 INTERNET_OPEN_TYPE_DIRECT = 1;

        public const Int32 INTERNET_DEFAULT_FTP_PORT = 21;

        public const Int32 INTERNET_NO_CALLBACK = 0;

        public const Int32 FTP_TRANSFER_TYPE_UNKNOWN = 0x00000000;
        public const Int32 FTP_TRANSFER_TYPE_ASCII = 0x00000001;
        public const Int32 FTP_TRANSFER_TYPE_BINARY = 0x00000002;

        public const Int32 INTERNET_FLAG_HYPERLINK = 0x00000400;
        public const Int32 INTERNET_FLAG_NEED_FILE = 0x00000010;
        public const Int32 INTERNET_FLAG_NO_CACHE_WRITE = 0x04000000;
        public const Int32 INTERNET_FLAG_RELOAD = 8;
        public const Int32 INTERNET_FLAG_RESYNCHRONIZE = 0x00000800;

        public const Int32 INTERNET_FLAG_ASYNC = 0x10000000;
        public const Int32 INTERNET_FLAG_SYNC = 0x00000004;
        public const Int32 INTERNET_FLAG_FROM_CACHE = 0x01000000;
        public const Int32 INTERNET_FLAG_OFFLINE = 0x01000000;

        public const Int32 INTERNET_FLAG_PASSIVE = 0x08000000;

        public const Int32 INTERNET_ERROR_BASE = 12000;
        public const Int32 ERROR_INTERNET_EXTENDED_ERROR = (INTERNET_ERROR_BASE + 3);

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern public static IntPtr InternetOpen(
            [In] String agent,
            [In] Int32 dwAccessType,
            [In] String proxyName,
            [In] String proxyBypass,
            [In] Int32 dwFlags);

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern public static IntPtr InternetConnect(
            [In] IntPtr hInternet,
            [In] String serverName,
            [In] Int32 serverPort,
            [In] String userName,
            [In] String password,
            [In] Int32 dwService,
            [In] Int32 dwFlags,
            [In] IntPtr dwContext);

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern public static Int32 InternetCloseHandle([In] IntPtr hInternet);

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern public static Int32 FtpCommand(
            [In] IntPtr hConnect,
            [In] Boolean fExpectResponse,
            [In] Int32 dwFlags,
            [In] String command,
            [In] IntPtr dwContext,
            [In][Out] ref IntPtr ftpCommand);

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern public static Int32 FtpCreateDirectory([In] IntPtr hConnect, [In] String directory);

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern public static Int32 FtpDeleteFile([In] IntPtr hConnect, [In] String fileName);

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern public static IntPtr FtpFindFirstFile(
            [In] IntPtr hConnect,
            [In] String searchFile,
            [In][Out] ref WIN32_FIND_DATA findFileData,
            [In] Int32 dwFlags,
            [In] IntPtr dwContext);

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern public static Int32 FtpGetCurrentDirectory(
            [In] IntPtr hConnect,
            [In][Out] StringBuilder currentDirectory,
            [In][Out] ref Int32 dwCurrentDirectory); //specifies buffer length

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern public static Int32 FtpGetFile(
            [In] IntPtr hConnect,
            [In] String remoteFile,
            [In] String newFile,
            [In] Boolean failIfExists,
            [In] Int32 dwFlagsAndAttributes,
            [In] Int32 dwFlags,
            [In] IntPtr dwContext);

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern public static Int32 FtpGetFileSize([In] IntPtr hConnect, [In][Out] ref Int32 dwFileSizeHigh);

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern public static Int32 FtpOpenFile(
            [In] IntPtr hConnect,
            [In] String fileName,
            [In] uint dwAccess,
            [In] Int32 dwFlags,
            [In] IntPtr dwContext);

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern public static Int32 FtpPutFile(
            [In] IntPtr hConnect,
            [In] String localFile,
            [In] String newRemoteFile,
            [In] Int32 dwFlags,
            [In] IntPtr dwContext);

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern public static Int32 FtpRemoveDirectory([In] IntPtr hConnect, [In] String directory);

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern public static Int32 FtpRenameFile(
            [In] IntPtr hConnect,
            [In] String existingName,
            [In] String newName);

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern public static Int32 FtpSetCurrentDirectory([In] IntPtr hConnect, [In] String directory);

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern public static Int32 InternetFindNextFile([In] IntPtr hInternet, [In][Out] ref WIN32_FIND_DATA findData);

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern public static Int32 InternetGetLastResponseInfo(
            [In][Out] ref Int32 dwError,
            [MarshalAs(UnmanagedType.LPTStr)]
            [Out] StringBuilder buffer,
            [In][Out] ref Int32 bufferLength);

        [DllImport("wininet.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        extern public static Int32 InternetReadFile(
            [In] IntPtr hConnect,
            [MarshalAs(UnmanagedType.LPTStr)]
            [In][Out] StringBuilder buffer,
            [In] Int32 buffCount,
            [In][Out] ref Int32 bytesRead);

        [DllImport("wininet.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        extern public static Int32 InternetReadFileEx(
            [In] IntPtr hFile,
            [In][Out] ref INTERNET_BUFFERS lpBuffersOut,
            [In] Int32 dwFlags,
            [In][Out] Int32 dwContext);
    }
}
