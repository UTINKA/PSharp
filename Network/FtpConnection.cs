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
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

using PSharp.Win32;

namespace PSharp.Network
{
    public class FtpConnection
    {
        private IntPtr m_hInternet;
        private IntPtr m_hConnect;

        private Int32 m_port = WinINet.INTERNET_DEFAULT_FTP_PORT;

        private String m_host;
        private String m_username = "";
        private String m_password = "";     

        private Boolean m_disposed = false;
        
        public Int32 Port
        {
            get
            {
                return m_port;
            }
        }

        public String Host
        {
            get
            {
                return m_host;
            }
        }

        public FtpConnection(String host)
        {
            m_host = host;
        }

        public FtpConnection(String host, Int32 port)
        {
            m_host = host;
            m_port = port;
        }

        public FtpConnection(String host, String username, String password)
        {
            m_host = host;
            m_username = username;
            m_password = password;
        }

        public FtpConnection(String host, Int32 port, String username, String password)
        {
            m_host = host;
            m_port = port;
            m_username = username;
            m_password = password;
        }

        public void Dispose()
        {
            if (!m_disposed)
            {
                if (m_hConnect != IntPtr.Zero)
                {
                    WinINet.InternetCloseHandle(m_hConnect);
                }

                if (m_hInternet != IntPtr.Zero)
                {
                    WinINet.InternetCloseHandle(m_hInternet);
                }
                m_hInternet = IntPtr.Zero;
                m_hConnect = IntPtr.Zero;

                m_disposed = true;
                GC.SuppressFinalize(this);
            }
        }

        public void Open()
        {
            if (String.IsNullOrEmpty(m_host))
            {
                throw new ArgumentException("Host");
            }

            m_hInternet = WinINet.InternetOpen(Environment.UserName, WinINet.INTERNET_OPEN_TYPE_PRECONFIG, null, null, WinINet.INTERNET_FLAG_ASYNC);
            if (m_hInternet == IntPtr.Zero)
            {

            }
        }
       
        public void Login(String username, String password)
        {
            if (username == null) throw new ArgumentNullException("username");
            if (password == null) throw new ArgumentNullException("password");

            m_hConnect = WinINet.InternetConnect(m_hInternet, m_host, m_port, username, password, WinINet.INTERNET_SERVICE_FTP, WinINet.INTERNET_FLAG_PASSIVE, IntPtr.Zero);
        }

        public void SetCurrentDirectory(String directory)
        {
            Int32 result = WinINet.FtpSetCurrentDirectory(m_hConnect, directory);
            if (result == 0)
            {

            }
        }

        public void SetLocalDirectory(String directory)
        {
            if (Directory.Exists(directory))
            {
                Environment.CurrentDirectory = directory;
            }
            else
            {
                throw new InvalidDataException(String.Format("{0} is not a directory!", directory));
            }
        }

        public String GetCurrentDirectory()
        {
            Int32 bufferLength = WinApi.MAX_PATH + 1;
            StringBuilder stringBuilder = new StringBuilder(bufferLength);

            Int32 result = WinINet.FtpGetCurrentDirectory(m_hConnect, stringBuilder, ref bufferLength);
            if (result == 0)
            {
                return null;
            }
            return stringBuilder.ToString();
        }

        public long GetFileSize(String file)
        {
            IntPtr remoteFile = new IntPtr(WinINet.FtpOpenFile(m_hConnect, file, WinApi.GENERIC_READ, WinINet.FTP_TRANSFER_TYPE_BINARY, IntPtr.Zero));

            if (remoteFile == IntPtr.Zero)
            {

            }
            else
            {
                try
                {
                    Int32 sizeHigh = 0;
                    Int32 sizeLo = WinINet.FtpGetFileSize(remoteFile, ref sizeHigh);

                    long fileSize = ((long)sizeHigh << 32) | sizeLo;
                    return fileSize;
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    WinINet.InternetCloseHandle(remoteFile);
                }
            }
            return 0;
        }

        public void GetFile(String remoteFile, Boolean overrideIfExists)
        {
            GetFile(remoteFile, remoteFile, overrideIfExists);
        }

        public void GetFile(String remoteFile, String localFile, Boolean overrideIfExists)
        {
            Int32 result = WinINet.FtpGetFile(m_hConnect, remoteFile, localFile, overrideIfExists, WinApi.FILE_ATTRIBUTE_NORMAL, WinINet.FTP_TRANSFER_TYPE_BINARY, IntPtr.Zero);
            if (result == 0)
            {

            }
        }

        public void PutFile(String file)
        {
            PutFile(file, Path.GetFileName(file));
        }

        public void PutFile(String localFile, String remoteFile)
        {
            Int32 result = WinINet.FtpPutFile(m_hConnect, localFile, remoteFile, WinINet.FTP_TRANSFER_TYPE_BINARY, IntPtr.Zero);
            if (result == 0)
            {

            }
        }

        public void RenameFile(String file, String newFileName)
        {
            Int32 result = WinINet.FtpRenameFile(m_hConnect, file, newFileName);
            if (result == 0)
            {

            }
        }

        public void RemoveFile(String file)
        {
            Int32 result = WinINet.FtpDeleteFile(m_hConnect, file);
            if (result == 0)
            {

            }
        }

        public void RemoveDirectory(String directory)
        {
            Int32 result = WinINet.FtpRemoveDirectory(m_hConnect, directory);
            if (result == 0)
            {

            }
        }

        public List<String> List()
        {
            return List(null, false);
        }

        public List<String> List(String mask)
        {
            return List(mask, false);
        }

        private List<String> List(Boolean onlyDirectories)
        {
            return List(null, onlyDirectories);
        }

        private List<String> List(String mask, Boolean onlyDirectories)
        {
            WIN32_FIND_DATA findData = new WIN32_FIND_DATA();
            IntPtr findFile = WinINet.FtpFindFirstFile(m_hConnect, mask, ref findData, WinINet.INTERNET_FLAG_NO_CACHE_WRITE, IntPtr.Zero);

            try
            {
                List<String> files = new List<String>();
                if (findFile == IntPtr.Zero)
                {
                    if (Marshal.GetLastWin32Error() == WinApi.ERROR_NO_MORE_FILES)
                    {
                        return files;
                    }
                    else
                    {
                        
                        return files;
                    }
                }

                if (onlyDirectories && (findData.dfFileAttributes & WinApi.FILE_ATTRIBUTE_DIRECTORY) == WinApi.FILE_ATTRIBUTE_DIRECTORY)
                {
                    files.Add(new String(findData.fileName).TrimEnd('\0'));
                }
                else if (!onlyDirectories)
                {
                    files.Add(new String(findData.fileName).TrimEnd('\0'));
                }

                findData = new WIN32_FIND_DATA();
                while (WinINet.InternetFindNextFile(findFile, ref findData) != 0)
                {
                    if (onlyDirectories && (findData.dfFileAttributes & WinApi.FILE_ATTRIBUTE_DIRECTORY) == WinApi.FILE_ATTRIBUTE_DIRECTORY)
                    {
                        files.Add(new String(findData.fileName).TrimEnd('\0'));
                    }
                    else if (!onlyDirectories)
                    {
                        files.Add(new String(findData.fileName).TrimEnd('\0'));
                    }
                    findData = new WIN32_FIND_DATA();
                }

                if (Marshal.GetLastWin32Error() != WinApi.ERROR_NO_MORE_FILES)
                {

                }
                return files;
            }
            finally
            {
                if (findFile != IntPtr.Zero)
                {
                    WinINet.InternetCloseHandle(findFile);
                }
            }
        }

        public FtpFileInfo[] GetFiles()
        {
            return GetFiles(GetCurrentDirectory());
        }

        public FtpFileInfo[] GetFiles(String mask)
        {
            WIN32_FIND_DATA findData = new WIN32_FIND_DATA();
            IntPtr findFile = WinINet.FtpFindFirstFile(m_hConnect, mask, ref findData, WinINet.INTERNET_FLAG_NO_CACHE_WRITE, IntPtr.Zero);

            try
            {
                List<FtpFileInfo> files = new List<FtpFileInfo>();
                if (findFile == IntPtr.Zero)
                {
                    if (Marshal.GetLastWin32Error() == WinApi.ERROR_NO_MORE_FILES)
                    {
                        return files.ToArray();
                    }
                    else
                    {
                        return files.ToArray();
                    }
                }

                if ((findData.dfFileAttributes & WinApi.FILE_ATTRIBUTE_DIRECTORY) != WinApi.FILE_ATTRIBUTE_DIRECTORY)
                {
                    FtpFileInfo fileInfo = new FtpFileInfo(this, new String(findData.fileName).TrimEnd('\0'));
                    fileInfo.LastAccessTime = findData.ftLastAccessTime.ToDateTime();
                    fileInfo.LastWriteTime = findData.ftLastWriteTime.ToDateTime();
                    fileInfo.CreationTime = findData.ftCreationTime.ToDateTime();
                    fileInfo.Attributes = (FileAttributes)findData.dfFileAttributes;
                    files.Add(fileInfo);
                }

                findData = new WIN32_FIND_DATA();
                while (WinINet.InternetFindNextFile(findFile, ref findData) != 0)
                {
                    if ((findData.dfFileAttributes & WinApi.FILE_ATTRIBUTE_DIRECTORY) != WinApi.FILE_ATTRIBUTE_DIRECTORY)
                    {
                        FtpFileInfo fileInfo = new FtpFileInfo(this, new String(findData.fileName).TrimEnd('\0'));
                        fileInfo.LastAccessTime = findData.ftLastAccessTime.ToDateTime();
                        fileInfo.LastWriteTime = findData.ftLastWriteTime.ToDateTime();
                        fileInfo.CreationTime = findData.ftCreationTime.ToDateTime();
                        fileInfo.Attributes = (FileAttributes)findData.dfFileAttributes;
                        files.Add(fileInfo);
                    }
                    findData = new WIN32_FIND_DATA();
                }

                if (Marshal.GetLastWin32Error() != WinApi.ERROR_NO_MORE_FILES)
                {

                }
                return files.ToArray();
            }
            finally
            {
                if (findFile != IntPtr.Zero)
                {
                    WinINet.InternetCloseHandle(findFile);
                }
            }
        }

        public FtpDirectoryInfo[] GetDirectories()
        {
            return GetDirectories(GetCurrentDirectory());
        }

        public FtpDirectoryInfo[] GetDirectories(String path)
        {
            WIN32_FIND_DATA findData = new WIN32_FIND_DATA();
            IntPtr findFile = WinINet.FtpFindFirstFile(m_hConnect, path, ref findData, WinINet.INTERNET_FLAG_NO_CACHE_WRITE, IntPtr.Zero);

            try
            {
                List<FtpDirectoryInfo> directories = new List<FtpDirectoryInfo>();
                if (findFile == IntPtr.Zero)
                {
                    if (Marshal.GetLastWin32Error() == WinApi.ERROR_NO_MORE_FILES)
                    {
                        return directories.ToArray();
                    }
                    else
                    {
                        return directories.ToArray();
                    }
                }

                if ((findData.dfFileAttributes & WinApi.FILE_ATTRIBUTE_DIRECTORY) == WinApi.FILE_ATTRIBUTE_DIRECTORY)
                {
                    FtpDirectoryInfo directoryInfo = new FtpDirectoryInfo(this, new String(findData.fileName).TrimEnd('\0'));
                    directoryInfo.LastAccessTime = findData.ftLastAccessTime.ToDateTime();
                    directoryInfo.LastWriteTime = findData.ftLastWriteTime.ToDateTime();
                    directoryInfo.CreationTime = findData.ftCreationTime.ToDateTime();
                    directoryInfo.Attributes = (FileAttributes)findData.dfFileAttributes;
                    directories.Add(directoryInfo);
                }
                findData = new WIN32_FIND_DATA();

                while (WinINet.InternetFindNextFile(findFile, ref findData) != 0)
                {
                    if ((findData.dfFileAttributes & WinApi.FILE_ATTRIBUTE_DIRECTORY) == WinApi.FILE_ATTRIBUTE_DIRECTORY)
                    {
                        FtpDirectoryInfo directoryInfo = new FtpDirectoryInfo(this, new String(findData.fileName).TrimEnd('\0'));
                        directoryInfo.LastAccessTime = findData.ftLastAccessTime.ToDateTime();
                        directoryInfo.LastWriteTime = findData.ftLastWriteTime.ToDateTime();
                        directoryInfo.CreationTime = findData.ftCreationTime.ToDateTime();
                        directoryInfo.Attributes = (FileAttributes)findData.dfFileAttributes;
                        directories.Add(directoryInfo);
                    }
                    findData = new WIN32_FIND_DATA();
                }

                if (Marshal.GetLastWin32Error() != WinApi.ERROR_NO_MORE_FILES)
                {

                }
                return directories.ToArray();
            }
            finally
            {
                if (findFile != IntPtr.Zero)
                {
                    WinINet.InternetCloseHandle(findFile);
                }
            }
        }

        public void CreateDirectory(String path)
        {
            if (WinINet.FtpCreateDirectory(m_hConnect, path) == 0)
            {
                
            }
        }

        public Boolean DirectoryExists(String path)
        {
            WIN32_FIND_DATA findData = new WIN32_FIND_DATA();
            IntPtr findFile = WinINet.FtpFindFirstFile(m_hConnect, path, ref findData, WinINet.INTERNET_FLAG_NO_CACHE_WRITE, IntPtr.Zero);

            try
            {
                if (findFile == IntPtr.Zero)
                {
                    return false;
                }
                return true;
            }
            finally
            {
                if (findFile != IntPtr.Zero)
                {
                    WinINet.InternetCloseHandle(findFile);
                }
            }
        }

        public Boolean FileExists(String path)
        {
            WIN32_FIND_DATA findData = new WIN32_FIND_DATA();

            IntPtr findFile = WinINet.FtpFindFirstFile(m_hConnect, path, ref findData, WinINet.INTERNET_FLAG_NO_CACHE_WRITE, IntPtr.Zero);
            try
            {
                if (findFile == IntPtr.Zero)
                {
                    return false;
                }
                return true;
            }
            finally
            {
                if (findFile != IntPtr.Zero)
                {
                    WinINet.InternetCloseHandle(findFile);
                }
            }
        }

        public void Close()
        {
            Dispose();
        }

        ~FtpConnection()
        {
            Dispose();
        }
    }
}
