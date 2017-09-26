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
    internal struct AMXStruct
    {
        private readonly Int32 alt;
        private readonly IntPtr _base;
        private readonly IntPtr callback;
        private readonly Int32 currentInstructionPointer;
        private readonly IntPtr code;
        private readonly Int64 codeSize;
        private readonly IntPtr data;
        private readonly IntPtr debug;
        private readonly Int32 error;
        private readonly Int32 flags;
        private readonly Int32 userdata0; 
        private readonly Int32 userdata1;
        private readonly Int32 userdata2;
        private readonly Int32 userdata3;
        private readonly Int32 userdata4;
        private readonly Int32 userdata5;
        private readonly Int32 frame;
        private readonly Int32 heap;
        private readonly Int32 heapLow;
        private readonly IntPtr overlay;
        private readonly Int32 overlayIndex;
        private readonly Int32 paramCount;
        private readonly Int32 primary;
        private readonly Int32 resetHeap;
        private readonly Int32 resetStack;
        private readonly Int32 stack;
        private readonly Int32 stackTop;
        private readonly Int32 sysReqD;
    }
}
