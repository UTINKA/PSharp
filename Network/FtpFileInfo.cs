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

namespace PSharp.Network
{
    public class FtpFileInfo : FileSystemInfo
    {
        private FtpConnection m_ftp;
        private String m_filePath;
        private String m_name;

        private DateTime? m_lastAccessTime;
        private DateTime? m_creationTime;
        private DateTime? m_lastWriteTime;
        private FileAttributes m_attribues;

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

        public new DateTime? CreationTime
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
            get { return m_lastAccessTime.HasValue ? (DateTime?)m_lastAccessTime.Value.ToUniversalTime() : null; }
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
            { return m_lastWriteTime.HasValue ? (DateTime?)m_lastWriteTime.Value.ToUniversalTime() : null;
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

        public override string Name
        {
            get
            {
                return m_name;
            }
        }

        public override bool Exists
        {
            get
            {
                return FtpConnection.FileExists(FullName);
            }
        }

        public FtpFileInfo(FtpConnection ftp, String filePath)
        {
            base.OriginalPath = filePath;
            base.FullPath = filePath;

            m_filePath = filePath;
            m_ftp = ftp;
            m_name = Path.GetFileName(filePath);
        }

        public override void Delete()
        {
            FtpConnection.RemoveFile(FullName);
        }
    }
}
