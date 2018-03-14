//<Snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace SampleRootDesigner
{	
    // This sample demonstrates how to provide the root designer view, or
    // design mode background view, by overriding IRootDesigner.GetView().

    // This sample component inherits from RootDesignedComponent which 
    // uses the SampleRootDesigner.
    public class RootViewSampleComponent : RootDesignedComponent
    {
        public RootViewSampleComponent()
        {
        }
    }

    // The following attribute associates the SampleRootDesigner designer 
    // with the SampleComponent component.
    [Designer(typeof(SampleRootDesigner), typeof(IRootDesigner))]
    public class RootDesignedComponent : Component
    {
        public RootDesignedComponent()
        {
        }
    }

    public class SampleRootDesigner : ComponentDesigner, IRootDesigner
    {
        // Member field of custom type RootDesignerView, a control that 
        // will be shown in the Forms designer view. This member is 
        // cached to reduce processing needed to recreate the 
        // view control on each call to GetView().
        private RootDesignerView m_view;			

        // This method returns an instance of the view for this root
        // designer. The "view" is the user interface that is presented
        // in a document window for the user to manipulate. 
        object IRootDesigner.GetView(ViewTechnology technology) 
        {
            if (technology != ViewTechnology.Default)
            {
                throw new ArgumentException("Not a supported view technology", "technology");
            }
            if (m_view == null)
            {
                   // Some type of displayable Form or control is required 
                   // for a root designer that overrides GetView(). In this 
                   // example, a Control of type RootDesignerView is used.
                   // Any class that inherits from Control will work.
                m_view = new RootDesignerView(this);
            }
            return m_view;
        }

        // IRootDesigner.SupportedTechnologies is a required override for an
        // IRootDesigner. Default is the view technology used by this designer.  
        ViewTechnology[] IRootDesigner.SupportedTechnologies 
        {
            get
            {
                return new ViewTechnology[] {ViewTechnology.Default};
            }
        }

        // RootDesignerView is a simple control that will be displayed 
        // in the designer window.
        private class RootDesignerView : Control 
        {
            private SampleRootDesigner m_designer;

            public RootDesignerView(SampleRootDesigner designer)
            {
                m_designer = designer;
                BackColor = Color.Blue;
                Font = new Font(Font.FontFamily.Name, 24.0f);
            }

            protected override void OnPaint(PaintEventArgs pe)
            {
                base.OnPaint(pe);

                // Draws the name of the component in large letters.
                pe.Graphics.DrawString(m_designer.Component.Site.Name, Font, Brushes.Yellow, ClientRectangle);
            }
        }		
    }
}
//</Snippet1>