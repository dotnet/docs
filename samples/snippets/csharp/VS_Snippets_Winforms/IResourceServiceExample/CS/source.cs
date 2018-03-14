//<Snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace IResourceServiceExample
{
    // Associates the ResourceTestControlDesigner with the 
    // ResourceTestControl class.
    [Designer(typeof(ResourceTestControlDesigner))]
    public class ResourceTestControl : System.Windows.Forms.UserControl
    {
        // Initializes a string array used to store strings that 
        // this control displays.
        public string[] resource_strings = new string[] { "Initial Default String #1", "Initial Default String #2" };

        public ResourceTestControl()
        {
            this.BackColor = Color.White;
            this.Size = new Size(408, 160);
        }

        // Draws the strings contained in the string array.
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawString("IResourceService Example Designer Control", new Font(FontFamily.GenericMonospace, 10), new SolidBrush(Color.Blue), 2, 2);
            e.Graphics.DrawString("String list:  (use shortcut menu in design mode)", new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.Black), 2, 20);
            
            for(int i=0; i<resource_strings.Length; i++)
            {
                e.Graphics.DrawString(resource_strings[i], new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.SeaGreen), 2, 38+(i*18));
            }
        }
    }

    // This designer offers several menu commands for the 
    // shortcut menu for the associated control.
    // These commands can be used to reset the control's string 
    // list, to generate a default resources file, or to load the string 
    // list for the control from the default resources file.
    public class ResourceTestControlDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        public ResourceTestControlDesigner()
        {}

        public override System.ComponentModel.Design.DesignerVerbCollection Verbs
        {
            get
            {
                // Creates a collection of designer verb menu commands 
                // that link to event handlers in this designer.
                return new DesignerVerbCollection( new DesignerVerb[] { 
                    new DesignerVerb("Load Strings from Default Resources File", new EventHandler(this.LoadResources)),
                    new DesignerVerb("Create Default Resources File", new EventHandler(this.CreateResources)),
                    new DesignerVerb("Clear ResourceTestControl String List", new EventHandler(this.ClearStrings)) });
            }
        }

        // Sets the string list for the control to the strings 
        // loaded from a resource file.
        private void LoadResources(object sender, EventArgs e)
        {
            IResourceService rs = (IResourceService)this.Component.Site.GetService(typeof(IResourceService));
            if( rs == null )
                throw new Exception("Could not obtain IResourceService.");

            IResourceReader rr = rs.GetResourceReader(CultureInfo.CurrentUICulture);
            if( rr == null )
                throw new Exception("Resource file could not be obtained. You may need to create one first.");

            IDictionaryEnumerator de = rr.GetEnumerator();
            
            if(this.Control.GetType() == typeof(ResourceTestControl))
            {
                ResourceTestControl rtc = (ResourceTestControl)this.Control;
                string s1, s2, s3;		
                de.MoveNext();		
                s1 = (string)((DictionaryEntry)de.Current).Value;
                de.MoveNext();
                s2 = (string)((DictionaryEntry)de.Current).Value;
                de.MoveNext();
                s3 = (string)((DictionaryEntry)de.Current).Value;
                de.MoveNext();
                rtc.resource_strings = new string[] {s1, s2, s3};
                this.Control.Refresh();
            }
            
        }

        // Creates a default resource file for the current 
        // CultureInfo and adds 3 strings to it.
        private void CreateResources(object sender, EventArgs e)
        {
            IResourceService rs = (IResourceService)this.Component.Site.GetService(typeof(IResourceService));
            if( rs == null )
                throw new Exception("Could not obtain IResourceService.");

            IResourceWriter rw = rs.GetResourceWriter(CultureInfo.CurrentUICulture);
            rw.AddResource("string1", "Persisted resource string #1");
            rw.AddResource("string2", "Persisted resource string #2");
            rw.AddResource("string3", "Persisted resource string #3");
            rw.Generate();
            rw.Close();
        }

        // Clears the string list of the associated ResourceTestControl.
        private void ClearStrings(object sender, EventArgs e)
        {
            if(this.Control.GetType() == typeof(ResourceTestControl))
            {
                ResourceTestControl rtc = (ResourceTestControl)this.Control;
                rtc.resource_strings = new string[] { "Test String #1", "Test String #2" };
                this.Control.Refresh();
            }
        }
    }
}
//</Snippet1>