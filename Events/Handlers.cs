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
    // server cfg
    public delegate void GamemodeChangeEventHandler(Object sender, GameModeChangeEventArgs e);
    public delegate void FiltercriptChangeEventHandler(Object sender, FilterscriptChangeEventArgs e);
    public delegate void PluginsChangeEventHandler(Object sender, PlugInChangeEventArgs e);

    // mysql
    public delegate void DatabaseCreateEventHandler(Object sender, DatabaseCreateEventArgs e);
    public delegate void DatabaseDropEventHandler(Object sender, DatabaseDropEventArgs e);
    public delegate void TableCreateEventHandler(Object sender, TableCreateEventArgs e);
    public delegate void TableDropEventHandler(Object sender, TableDropEventArgs e);
}
