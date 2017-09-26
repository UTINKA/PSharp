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
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSharp.UI.Controls
{
    [ToolboxBitmap(typeof(Button))]
    [DefaultEvent("Click")]
    class PSharpButton : Button
    {
        private ButtonStyle m_buttonStyle;
        private ControlState m_buttonState;

        private Boolean m_isDefault;
        private Boolean m_spacePressed;

        private Int32 m_padding;
        private Int32 m_imagePadding;

        public new String Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        public new Boolean Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                base.Enabled = value;
                Invalidate();
            }
        }

        public ControlState ButtonState
        {
            get
            {
                return m_buttonState;
            }
        }

        public ButtonStyle ButtonStyle
        {
            get
            {
                return m_buttonStyle;
            }
            set
            {
                m_buttonStyle = value;
                Invalidate();
            }
        }

        public Int32 ImagePadding
        {
            get
            {
                return m_imagePadding;
            }
            set
            {
                m_imagePadding = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Boolean AutoEllipse
        {
            get
            {
                return false;
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ContentAlignment ImageAlign
        {
            get
            {
                return base.ImageAlign;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Boolean UseCompatibleTextRendering
        {
            get
            {
                return false;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Boolean UseVisualStyleBackColor
        {
            get
            {
                return false;
            }
        }

        public PSharpButton()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            base.UseVisualStyleBackColor = false;
            base.UseCompatibleTextRendering = false;        
        }

        private void SetButtonState(ControlState buttonState)
        {
            if (m_buttonState != buttonState)
            {
                m_buttonState = buttonState;
                Invalidate();
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            var form = FindForm();

            if (form != null)
            {
                if (form.AcceptButton == this)
                {
                    m_isDefault = true;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics graphics = pevent.Graphics;
            Rectangle rectangle = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);

            Color textColor;
            Color borderColor;
            Color fillColor;

            if (Enabled)
            {
                if (ButtonStyle == ButtonStyle.Normal)
                {
                    if (Focused && TabStop)
                    {

                    }

                    switch (ButtonState)
                    {
                        case ControlState.Hover:
                        {
                            break;
                        }
                        case ControlState.Pressed:
                        {
                            break;
                        }
                    }
                }
                else if (ButtonStyle == ButtonStyle.Flat)
                {

                }
            }
        }
    }
}
