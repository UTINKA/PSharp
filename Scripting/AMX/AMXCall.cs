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
    internal static class AMXCall
    {
        private const string Library = "amx32.dll";


        [DllImport(Library, EntryPoint = "amx_Flags")]
        public static extern Int32 Flags(ref AMXStruct amx, out UInt16 flags);

        //[DllImport(library, EntryPoint = "amx_Callback")]
        //public static extern Int32 Callback(ref AMXStruct amx, Int32 index, IntPtr result, AMXArgumentList parms);

        [DllImport(Library, EntryPoint = "amx_Init")]
        public static extern Int32 Init(ref AMXStruct amx, IntPtr program);

        [DllImport(Library, EntryPoint = "amx_Cleanup")]
        public static extern Int32 Cleanup(ref AMXStruct amx);

        [DllImport(Library, EntryPoint = "amx_Clone")]
        public static extern Int32 Clone(ref AMXStruct amxClone, AMXStruct amxSource, IntPtr data);

        [DllImport(Library, EntryPoint = "amx_MemInfo")]
        public static extern Int32 MemoryInfo(ref AMXStruct amx, out long codesize, out long datasize, out long stackheap);

        [DllImport(Library, EntryPoint = "amx_NameLength")]
        public static extern Int32 NameLength(ref AMXStruct amx, out Int32 length);

        [DllImport(Library, EntryPoint = "amx_NumNatives")]
        public static extern Int32 NumberOfNatives(ref AMXStruct amx, out Int32 number);

        [DllImport(Library, EntryPoint = "amx_GetNative")]
        public static extern Int32 GetNative(ref AMXStruct amx, Int32 index, StringBuilder name);

        [DllImport(Library, EntryPoint = "amx_FindNative")]
        public static extern Int32 FindNative(ref AMXStruct amx, string name, out Int32 index);

        [DllImport(Library, EntryPoint = "amx_NumPublics")]
        public static extern Int32 NumberOfPublics(ref AMXStruct amx, out Int32 number);

        [DllImport(Library, EntryPoint = "amx_GetPublic")]
        public static extern Int32 GetPublic(ref AMXStruct amx, Int32 index, StringBuilder name, out IntPtr address);

        [DllImport(Library, EntryPoint = "amx_FindPublic")]
        public static extern Int32 FindPublic(ref AMXStruct amx, string name, out Int32 index);

        [DllImport(Library, EntryPoint = "amx_NumPubVars")]
        public static extern Int32 NumberOfPublicVars(ref AMXStruct amx, out Int32 number);

        [DllImport(Library, EntryPoint = "amx_GetPubVar")]
        public static extern Int32 GetPublicVar(ref AMXStruct amx, Int32 index, StringBuilder name, out IntPtr address);

        [DllImport(Library, EntryPoint = "amx_FindPubVar")]
        public static extern Int32 FindPublicVar(ref AMXStruct amx, string name, out IntPtr address);

        [DllImport(Library, EntryPoint = "amx_NumTags")]
        public static extern Int32 NumberOfTags(ref AMXStruct amx, out Int32 number);

        [DllImport(Library, EntryPoint = "amx_GetTag")]
        public static extern Int32 GetTag(ref AMXStruct amx, Int32 index, StringBuilder tagname, out Int32 tagID);

        [DllImport(Library, EntryPoint = "amx_FindTagId")]
        public static extern Int32 FindTagId(ref AMXStruct amx, Int32 tagID, StringBuilder tagname);

        //private static extern Int32 amx_GetUserData(ref AMX amx, long tag, void **ptr);

        //private static extern Int32 amx_SetUserData(ref AMX amx, long tag, void *ptr);

        [DllImport(Library, EntryPoint = "amx_Register")]
        public static extern Int32 Register(ref AMXStruct amx, [MarshalAs(UnmanagedType.LPArray)] AMXNativeInfo[] list,
            Int32 count);

        [DllImport(Library, EntryPoint = "amx_Push")]
        public static extern Int32 Push(ref AMXStruct amx, Int32 value);

        [DllImport(Library, EntryPoint = "amx_PushAddress")]
        public static extern Int32 PushAddress(ref AMXStruct amx, IntPtr address);

        [DllImport(Library, EntryPoint = "amx_PushAddress")]
        public static extern Int32 PushAddress(ref AMXStruct amx, ref Cell cell);

        [DllImport(Library, EntryPoint = "amx_PushArray")]
        public static extern Int32 PushArray(ref AMXStruct amx, out CellPtr address, Int32[] array, Int32 numcells);

        [DllImport(Library, EntryPoint = "amx_PushString")]
        public static extern Int32 PushString(ref AMXStruct amx, out IntPtr address, string str, Int32 pack, Int32 useWchar);

        [DllImport(Library, EntryPoint = "amx_Exec")]
        public static extern Int32 Exec(ref AMXStruct amx, out Int32 retval, Int32 index);

        //[DllImport(library, EntryPoint = "amx_SetCallback")]
        //private static extern Int32 AmxSetCallback(ref AMXStruct amx, AmxCallback callback);

        //[DllImport(library, EntryPoint = "amx_SetDebugHook")]
        //private static extern Int32 AmxSetDebugHook(ref AMX amx,AmxDebug debug);

        [DllImport(Library, EntryPoint = "amx_RaiseError")]
        public static extern Int32 RaiseError(ref AMXStruct amx, Int32 error);

        [DllImport(Library, EntryPoint = "amx_Allot")]
        public static extern Int32 Allot(ref AMXStruct amx, Int32 cells, out IntPtr address);

        [DllImport(Library, EntryPoint = "amx_Release")]
        public static extern Int32 Release(ref AMXStruct amx, IntPtr address);

        [DllImport(Library, EntryPoint = "amx_StrLen")]
        public static extern Int32 StrLen(IntPtr cstr, out Int32 length);

        [DllImport(Library, EntryPoint = "amx_SetString")]
        public static extern Int32 SetString(IntPtr dest, string source, Int32 pack, Int32 useWchar, Int32 size);

        [DllImport(Library, EntryPoint = "amx_GetString")]
        public static extern Int32 GetString(StringBuilder dest, IntPtr source, Int32 useWchar, Int32 size);

        //public static extern Int32 amx_UTF8Get(const char *string, const char **endptr, cell *value)

        //public static extern Int32 amx_UTF8Put(char *string, char **endptr, Int32 maxchars, cell value)

        //public static extern Int32 amx_UTF8Check(const char *string, Int32 *length)

        //public static extern Int32 amx_UTF8Len(const cell *cstr, Int32 *length)


        [DllImport(Library, EntryPoint = "amx_ConsoleInit")]
        public static extern Int32 ConsoleInit(ref AMXStruct amx);

        [DllImport(Library, EntryPoint = "amx_ConsoleCleanup")]
        public static extern Int32 ConsoleCleanup(ref AMXStruct amx);

        [DllImport(Library, EntryPoint = "amx_CoreInit")]
        public static extern Int32 CoreInit(ref AMXStruct amx);

        [DllImport(Library, EntryPoint = "amx_CoreCleanup")]
        public static extern Int32 CoreCleanup(ref AMXStruct amx);

        [DllImport(Library, EntryPoint = "amx_DGramInit")]
        public static extern Int32 DGramInit(ref AMXStruct amx);

        [DllImport(Library, EntryPoint = "amx_DGramCleanup")]
        public static extern Int32 DGramCleanup(ref AMXStruct amx);

        [DllImport(Library, EntryPoint = "amx_StringInit")]
        public static extern Int32 StringInit(ref AMXStruct amx);

        [DllImport(Library, EntryPoint = "amx_StringCleanup")]
        public static extern Int32 StringCleanup(ref AMXStruct amx);

        [DllImport(Library, EntryPoint = "amx_TimeInit")]
        public static extern Int32 TimeInit(ref AMXStruct amx);

        [DllImport(Library, EntryPoint = "amx_TimeCleanup")]
        public static extern Int32 TimeClean(ref AMXStruct amx);

        [DllImport(Library, EntryPoint = "amx_FixedInit")]
        public static extern Int32 FixedInit(ref AMXStruct amx);

        [DllImport(Library, EntryPoint = "amx_FixedCleanup")]
        public static extern Int32 FixedCleanup(ref AMXStruct amx);

        [DllImport(Library, EntryPoint = "amx_FloatInit")]
        public static extern Int32 FloatInit(ref AMXStruct amx);

        [DllImport(Library, EntryPoint = "amx_FloatCleanup")]
        public static extern Int32 FloatCleanup(ref AMXStruct amx);


    }
}
