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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PSharp.Exceptions;

namespace PSharp.Network
{
    public class FtpDirectoryInfo : FileSystemInfo
    {
        private FtpConnection m_ftp;
        private DateTime? m_lastAccessTime;
        private DateTime? m_creationTime;
        private DateTime? m_lastWriteTime;
        private FileAttributes m_attribues;

        public FtpDirectoryInfo(FtpConnection ftp, String path)
        {
            m_ftp = ftp;
            base.FullPath = path;
        }

        public FtpConnection FtpConnection
        {
            get
            {
                return m_ftp;
            }
        }

        public new DateTime? LastAccessTime
        {
            get
            {
                return m_lastAccessTime.HasValue ? (DateTime?)m_lastAccessTime.Value : null;
            }
            internal set
            {
                m_lastAccessTime = value;
            }
        }
        public 
            new DateTime? CreationTime
        {
            get
            {
                return m_creationTime.HasValue ? (DateTime?)m_creationTime.Value : null;
            }
            internal set
            {
                m_creationTime = value;
            }
        }

        public new DateTime? LastWriteTime
        {
            get
            {
                return m_lastWriteTime.HasValue ? (DateTime?)m_lastWriteTime.Value : null;
            }
            internal set
            {
                m_lastWriteTime = value;
            }
        }

        public new DateTime? LastAccessTimeUtc
        {
            get
            {
                return m_lastAccessTime.HasValue ? (DateTime?)m_lastAccessTime.Value.ToUniversalTime() : null;
            }
        }
        public new DateTime? CreationTimeUtc
        {
            get
            {
                return m_creationTime.HasValue ? (DateTime?)m_creationTime.Value.ToUniversalTime() : null;
            }
        }
        public new DateTime? LastWriteTimeUtc
        {
            get
            {
                return m_lastWriteTime.HasValue ? (DateTime?)m_lastWriteTime.Value.ToUniversalTime() : null;
            }
        }

        public new FileAttributes Attributes
        {
            get
            {
                return m_attribues;
            }
            internal set
            {
                m_attribues = value;
            }
        }

        public override Boolean Exists
        {
            get
            {
                return this.FtpConnection.DirectoryExists(FullName);
            }
        }

        public override String Name
        {
            get
            {
                return Path.GetFileName(FullPath);
            }
        }

        public FtpDirectoryInfo[] GetDirectories()
        {
            return FtpConnection.GetDirectories(FullPath);
        }
        public FtpDirectoryInfo[] GetDirectories(String path)
        {
            path = Path.Combine(this.FullPath, path);
            return FtpConnection.GetDirectories(path);
        }

        public FtpFileInfo[] GetFiles()
        {
            return GetFiles(FtpConnection.GetCurrentDirectory());
        }

        public FtpFileInfo[] GetFiles(string mask)
        {
            return FtpConnection.GetFiles(mask);
        }

        public override void Delete()
        {
            try
            {
                m_ftp.RemoveDirectory(Name);
            }
            catch (FtpException ex)
            {
                throw new Exception("Unable to delete directory.", ex);
            }
        }
    }
}
