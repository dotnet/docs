// <snippet1>
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CustomWinControls
{
    // <snippet2>
    public class FirstControl : Control
    {
        // </snippet2>

        public FirstControl()
        {

        }

        // <snippet3>
        // ContentAlignment is an enumeration defined in the System.Drawing
        // namespace that specifies the alignment of content on a drawing 
        // surface.
        private ContentAlignment alignmentValue = ContentAlignment.MiddleLeft;
        // </snippet3>

        // <snippet5>
        [
        Category("Alignment"),
        Description("Specifies the alignment of text.")
        ]
        // </snippet5>
        // <snippet6>
        // <snippet7>
        public ContentAlignment TextAlignment 
        {
            // </snippet7>
            
            get 
            {
                return alignmentValue;
            }
            set 
            {
                alignmentValue = value;

                // The Invalidate method invokes the OnPaint method described 
                // in step 3.
                Invalidate(); 
            }
        }
        // </snippet6>
        

        // <snippet4>
        protected override void OnPaint(PaintEventArgs e) 
        {   
            base.OnPaint(e);
            StringFormat style = new StringFormat();
            style.Alignment = StringAlignment.Near;
            switch (alignmentValue) 
            {
                case ContentAlignment.MiddleLeft:
                    style.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleRight:
                    style.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.MiddleCenter:
                    style.Alignment = StringAlignment.Center;
                    break;
            }
            
            // Call the DrawString method of the System.Drawing class to write   
            // text. Text and ClientRectangle are properties inherited from
            // Control.
            e.Graphics.DrawString(
                Text, 
                Font, 
                new SolidBrush(ForeColor), 
                ClientRectangle, style);

        } 
        // </snippet4>
    }
}
// </snippet1>