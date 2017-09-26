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

namespace PSharp.Events
{
    public class PlugInChangeEventArgs : EventArgs
    {
        private String m_oldPlugin;
        private String m_newPlugin;

        public String OldPlugin
        {
            get
            {
                return m_oldPlugin;
            }
            set
            {
                if (m_oldPlugin == value)
                {
                    return;
                }
                m_oldPlugin = value;
            }
        }

        public String NewPlugin
        {
            get
            {
                return m_newPlugin;
            }
            set
            {
                if (m_newPlugin == value)
                {
                    return;
                }
                m_newPlugin = value;
            }
        }

        public PlugInChangeEventArgs(String oldHost, String newHost)
        {
            OldPlugin = oldHost;
            NewPlugin = newHost;
        }
    }
}
