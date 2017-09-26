﻿/*
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
    internal struct AMXNativeInfo
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public String Name;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public AMXNativeCall Function;

        public AMXNativeInfo(String name, AMXNativeCall func)
        {
            Name = name;
            Function = func;
        }
    }
}
