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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSharp.Events
{
    class ColorSelectedEventArgs : EventArgs
    {
        private Int32 m_red;
        private Int32 m_green;
        private Int32 m_blue;
        private Int32 m_alpha;

        public Int32 Alpha
        {
            get
            {
                return m_alpha;
            }
            set
            {
                m_alpha = value;
            }
        }

        public Int32 R
        {
            get
            {
                return m_red;
            }
            set
            {
                m_red = value;
            }
        }

        public Int32 G
        {
            get
            {
                return m_green;
            }
            set
            {
                m_green = value;
            }
        }

        public Int32 B
        {
            get
            {
                return m_blue;
            }
            set
            {
                m_blue = value;
            }
        }

        /// <summary>
        ///     Returns RGB colors
        /// </summary>
        /// <returns></returns>
        public Color GetColor()
        {
            return Color.FromArgb(R, G, B);
        }

        public Color GetColorDetail()
        {
            Color c = GetColor();
            return c;
        }
    }
}
