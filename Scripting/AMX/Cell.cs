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
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PSharp.Scripting
{
    public struct Cell
    {
        private readonly Int32 m_value;

        public Cell(Int32 value)
        {
            m_value = value;
        }

        public static Cell FromInt32(Int32 value)
        {
            return new Cell(value);
        }

        public static Cell FromIntPtr(IntPtr pointer)
        {
            return new Cell(Marshal.ReadInt32(pointer));
        }

        public static Cell FromFloat(float value)
        {
            return new Cell(BitConverter.ToInt32(BitConverter.GetBytes(value), 0));
        }

        public Int32 AsInt32()
        {
            return m_value;
        }

        public UInt32 AsUInt32()
        {
            return (UInt32)m_value;
        }

        public IntPtr AsIntPtr()
        {
            return new IntPtr(m_value);
        }

        public CellPtr AsCellPtr()
        {
            return new CellPtr(AsIntPtr());
        }

        public float AsFloat()
        {
            return BitConverter.ToSingle(BitConverter.GetBytes(m_value), 0);
        }

        public String AsString()
        {
            Int32 length;
            AMXCall.StrLen(AsIntPtr(), out length);

            var sb = new StringBuilder(length);
            AMXCall.GetString(sb, AsIntPtr(), 0, length + 1);
            return sb.ToString();
        }

        public static implicit operator Cell(IntPtr ptr)
        {
            return FromIntPtr(ptr);
        }

        public static implicit operator Cell(Int32 value)
        {
            return FromInt32(value);
        }

        public override String ToString()
        {
            return m_value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
