//<Snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace EventDesignerTest
{
    // This designer provides a "Connect testEvent" designer verb shortcut 
    // menu command. When invoked, the command attaches a new event-handler 
    // method named "testEventHandler" to the "testEvent" event of an 
    // associated control.
    // If a "testEvent" event of the associated control does not exist, 
    // the IEventBindingService declares it.
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")] 
    public class EventDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        public EventDesigner()
        {
        }
        
        // When the "Connect testEvent" designer verb shortcut menu 
        // command is invoked, this method uses the 
        // IEventBindingService to attach an event handler to a 
        // "textEvent" event of the associated control.
        private void ConnectEvent(object sender, EventArgs e)
        {
            IEventBindingService eventservice = (IEventBindingService)this.Component.Site.GetService(typeof(System.ComponentModel.Design.IEventBindingService));
            if( eventservice != null )
            {
                // Attempt to obtain a PropertyDescriptor for a 
                // component event named "testEvent".
                EventDescriptorCollection edc = TypeDescriptor.GetEvents(this.Component);				
                if( edc == null || edc.Count == 0 )
                    return;
                                
                EventDescriptor ed = null;
                // Search for an event named "testEvent".
                foreach(EventDescriptor edi in edc)
                    if(edi.Name == "testEvent")
                    {
                        ed = edi;
                        break;
                    }
                if( ed == null )
                    return;

                // Use the IEventBindingService to get a 
                // PropertyDescriptor for the event.
                PropertyDescriptor pd = eventservice.GetEventProperty(ed);
                if( pd == null )
                    return;				
                
                // Set the value of the event to "testEventHandler".
                pd.SetValue(this.Component, "testEventHandler");
            }
        }

                // Provides a designer verb command for the designer's 
                // shortcut menu.
        public override System.ComponentModel.Design.DesignerVerbCollection Verbs
        {
            get
            {
                DesignerVerbCollection dvc = new DesignerVerbCollection();
                dvc.Add(new DesignerVerb("Connect testEvent", new EventHandler(ConnectEvent)));
                return dvc;
            }
        }
    }

    // EventControl is associated with the EventDesigner and displays 
    // instructions for demonstrating the service.
    [Designer(typeof(EventDesigner))]
    public class EventControl : System.Windows.Forms.UserControl
    {
        public event System.EventHandler testEvent;

        public EventControl()
        {		
            this.BackColor = Color.White;	
            this.Size = new Size(320, 96);
        }

        protected override void Dispose( bool disposing )
        {
            base.Dispose( disposing );
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawString("IEventBindingService Example Control", new Font(FontFamily.GenericMonospace, 10), new SolidBrush(Color.Blue), 5, 5);
            
            e.Graphics.DrawString("Use the \"Connect testEvent\" command of the", new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.Black), 5, 22);
            e.Graphics.DrawString("right-click shortcut menu provided by this", new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.Black), 5, 32);
            e.Graphics.DrawString("control's associated EventDesigner to create", new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.Black), 5, 42);
            e.Graphics.DrawString("a new event handler linked with the testEvent", new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.Black), 5, 52);
            e.Graphics.DrawString("of this control in the initialization code", new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.Black), 5, 62);
            e.Graphics.DrawString("for this control.", new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.Black), 5, 72);
        }
    }
}
//</Snippet1>
