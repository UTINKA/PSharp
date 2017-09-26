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
    public class GameModeChangeEventArgs : EventArgs
    {
        private Boolean m_changes;

        private String m_oldGamemode;
        private String m_newGamemode;

        public String OldGamemode
        {
            get
            {
                return m_oldGamemode;
            }
            set
            {
                if (m_newGamemode == value)
                {
                    m_changes = false;
                    return;
                }
                m_oldGamemode = value;
                m_changes = true;
            }
        }

        public String NewGamemode
        {
            get
            {
                return m_newGamemode;
            }
            set
            {
                if (m_newGamemode == value)
                {
                    m_changes = false;
                    return;
                }
                m_newGamemode = value;
            }
        }

        public Boolean Changes
        {
            get
            {
                return m_changes;
            }
            set
            {
                m_changes = value;
            }
        }

        public GameModeChangeEventArgs(String old, String newMode)
        {
            Changes = false;
            OldGamemode = old;
            NewGamemode = newMode;
        }

        public void ReverseChanges()
        {
            if (Changes)
            {
                NewGamemode = OldGamemode;
                OldGamemode = null;
                Changes = false;
            }
            else
            {
                return;
            }
        }
    }
}
