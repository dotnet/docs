// <snippet210>
// <snippet220>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
// </snippet220>

namespace MarqueeControlLibrary
{
    // <snippet240>
	[Designer( typeof( MarqueeControlLibrary.Design.MarqueeControlRootDesigner ), typeof( IRootDesigner ) )]
    public class MarqueeControl : UserControl
    {
		// </snippet240>

		// Required designer variable.
        private System.ComponentModel.Container components = null;

        // <snippet250>
        public MarqueeControl()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // Minimize flickering during animation by enabling 
            // double buffering.
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        // </snippet250>

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        // <snippet260>
        public void Start()
        {
            // The MarqueeControl may contain any number of 
            // controls that implement IMarqueeWidget, so 
            // find each IMarqueeWidget child and call its
            // StartMarquee method.
            foreach( Control cntrl in this.Controls )
            {
                if( cntrl is IMarqueeWidget )
                {
                    IMarqueeWidget widget = cntrl as IMarqueeWidget;
                    widget.StartMarquee();
                }
            }
        }

        public void Stop()
        {
            // The MarqueeControl may contain any number of 
            // controls that implement IMarqueeWidget, so find
            // each IMarqueeWidget child and call its StopMarquee
            // method.
            foreach( Control cntrl in this.Controls )
            {
                if( cntrl is IMarqueeWidget )
                {
                    IMarqueeWidget widget = cntrl as IMarqueeWidget;
                    widget.StopMarquee();
                }
            }
        }
        // </snippet260>

        // <snippet270>
        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout (levent);

            // Repaint all IMarqueeWidget children if the layout 
            // has changed.
            foreach( Control cntrl in this.Controls )
            {
                if( cntrl is IMarqueeWidget )
                {
                    Control control = cntrl as Control; 

                    control.PerformLayout();
                }
            }
        }
        // </snippet270>

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }
        #endregion
    }
}
// </snippet210>