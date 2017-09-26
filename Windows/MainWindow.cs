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
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

using PSharp.UI;
using PSharp.Events;

namespace PSharp.Windows
{
    public partial class MainWindow : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        public MainWindow()
        {
            InitializeComponent();
            
            menuStrip1.Renderer = new LightMenuRenderer();
            toolStrip1.Renderer = new LightMenuRenderer();
            statusStrip1.Renderer = new LightMenuRenderer();
            
        }

        private void OnPluginChanged(object sender, PlugInChangeEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnFilterscriptChanged(object sender, FilterscriptChangeEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnGamemodeChanged(object sender, GameModeChangeEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnLoad(object sender, EventArgs e)
        {
        }
    }
}
