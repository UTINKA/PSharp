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

namespace PSharp.Scripting
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CellPtr
    {
        private readonly IntPtr m_value;

        public IntPtr Value
        {
            get
            {
                return m_value;
            }
        }

        public CellPtr(IntPtr value)
        {
            m_value = value;
        }

        public Cell this[Int32 offset]
        {
            get
            {
                return Get(offset);
            }
            set
            {
                Set(offset, value);
            }
        }

        public Cell Get()
        {
            return Cell.FromIntPtr(m_value);
        }

        public Cell Get(Int32 offset)
        {
            return Cell.FromIntPtr(IntPtr.Add(m_value, offset * Marshal.SizeOf(typeof(Cell))));
        }

        public void Set(Int32 offset, Int32 value)
        {
            Marshal.WriteInt32(IntPtr.Add(m_value, offset * Marshal.SizeOf(typeof(Cell))), value);
        }

        public void Set(Int32 value)
        {
            Marshal.WriteInt32(m_value, value);
        }

        public void Set(Int32 offset, Cell value)
        {
            Marshal.WriteInt32(IntPtr.Add(m_value, offset * Marshal.SizeOf(typeof(Cell))), value.AsInt32());
        }

        public void Set(Cell value)
        {
            Set(value.AsInt32());
        }

        public Cell AsCell()
        {
            return new Cell(m_value.ToInt32());
        }

        public static CellPtr operator +(CellPtr cellPtr, Int32 offset)
        {
            return new CellPtr(IntPtr.Add(cellPtr.Value, offset * Marshal.SizeOf(typeof(Cell))));
        }

        public static implicit operator CellPtr(Cell cell)
        {
            return cell.AsCellPtr();
        }
    }
}
