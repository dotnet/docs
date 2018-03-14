using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DesignerEventServiceExample
{
    // DesignerMonitor provides a display for designer event notifications.
    [Designer(typeof(DesignerMonitorDesigner))]
    public class DesignerMonitor : System.Windows.Forms.UserControl
    {
        // List to contain strings that describe designer events.
        public ArrayList updates;
        public bool monitoring_events = false;		

        public DesignerMonitor()
        {
            updates = new ArrayList();			
            this.BackColor = Color.White;
            this.Size = new Size(450, 300);
        }

        // Display the message for the current mode, and any event messages if event monitoring is active.
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawString("IDesignerEventService DesignerMonitor Control", new Font(FontFamily.GenericMonospace, 10), new SolidBrush(Color.Blue), 5, 4);
            int yoffset = 10;
            if(!monitoring_events)
            {
                yoffset += 10;
                e.Graphics.DrawString("Currently not monitoring designer events.", new Font(FontFamily.GenericMonospace, 10), new SolidBrush(Color.Black), 5, yoffset+10);
                e.Graphics.DrawString("Use the shortcut menu commands", new Font(FontFamily.GenericMonospace, 10), new SolidBrush(Color.Black), 5, yoffset+30);
                e.Graphics.DrawString("provided by an associated DesignerMonitorDesigner", new Font(FontFamily.GenericMonospace, 10), new SolidBrush(Color.Black), 5, yoffset+40);
                e.Graphics.DrawString("to start or stop monitoring.", new Font(FontFamily.GenericMonospace, 10), new SolidBrush(Color.Black), 5, yoffset+50);
            }
            else
            {
                e.Graphics.DrawString("Currently monitoring designer events.", new Font(FontFamily.GenericMonospace, 10), new SolidBrush(Color.DarkBlue), 5,  yoffset+10);
                e.Graphics.DrawString("Designer created, changed and disposed events:", new Font(FontFamily.GenericMonospace, 9), new SolidBrush(Color.Brown), 5,  yoffset+35);
                for(int i=0; i<updates.Count; i++)
                {
                    e.Graphics.DrawString( (string)updates[i], new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.Black), 5, yoffset+55+(10*i));
                    yoffset+=10;
                }
            }
        }
    }

    // DesignerMonitorDesigner uses the IDesignerEventService to send event information 
    // to an associated DesignerMonitor control's updates collection.
    public class DesignerMonitorDesigner : System.Windows.Forms.Design.ControlDesigner
    {		
        private DesignerMonitor dm = null;
        private DesignerVerbCollection dvc = null;
        private int eventcount = 0;

        public DesignerMonitorDesigner()
        {		
            // Initializes the designer's shortcut menu with a "Start monitoring" command.
            dvc = new DesignerVerbCollection( new DesignerVerb[] { 
                    new DesignerVerb("Start monitoring", new EventHandler(this.StartMonitoring)) } );
        }
        
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);
            if(component.GetType() != typeof(DesignerMonitor))
                throw new Exception("This designer requires a DesignerMonitor control.");
            dm = (DesignerMonitor)component;	
        }

        public override System.ComponentModel.Design.DesignerVerbCollection Verbs
        {
            get
            {
                return dvc;
            }
        }

        private void StopMonitoring(object sender, EventArgs e)
        {			
            IDesignerEventService des = (IDesignerEventService)this.Control.Site.GetService(typeof(IDesignerEventService));
            if(des == null)
                return;
        
            // Remove event handlers for event notification methods.
            des.DesignerCreated -= new DesignerEventHandler(this.DesignerCreated);
            des.DesignerDisposed -= new DesignerEventHandler(this.DesignerDisposed);
            des.ActiveDesignerChanged -= new ActiveDesignerEventHandler(this.DesignerChanged);
            des.SelectionChanged -= new EventHandler(this.SelectionChanged);
            
            dm.monitoring_events = false;
            // Rebuild menu with "Start monitoring" command.
            dvc = new DesignerVerbCollection( new DesignerVerb[] { 
                    new DesignerVerb("Start monitoring", new EventHandler(this.StartMonitoring)) } );
            dm.Refresh();
        }
        
        private void StartMonitoring(object sender, EventArgs e)
        {		
            IDesignerEventService des = (IDesignerEventService)this.Control.Site.GetService(typeof(IDesignerEventService));
            if(des == null)
                return;

            // Add event handlers for event notification methods.
            des.DesignerCreated += new DesignerEventHandler(this.DesignerCreated);
            des.DesignerDisposed += new DesignerEventHandler(this.DesignerDisposed);
            des.ActiveDesignerChanged += new ActiveDesignerEventHandler(this.DesignerChanged);
            des.SelectionChanged += new EventHandler(this.SelectionChanged);
        
            dm.monitoring_events = true;
            // Rebuild menu with "Stop monitoring" command.
            dvc = new DesignerVerbCollection( new DesignerVerb[] { 
                         new DesignerVerb("Stop monitoring", new EventHandler(this.StopMonitoring)) } );			
            dm.Refresh();			
        }

        private void DesignerCreated(object sender, DesignerEventArgs e)
        {
            UpdateStatus("Designer for "+e.Designer.RootComponent.Site.Name+" was created.");
        }

        private void DesignerDisposed(object sender, DesignerEventArgs e)
        {
            UpdateStatus("Designer for "+e.Designer.RootComponent.Site.Name+" was disposed.");
        }

        private void DesignerChanged(object sender, ActiveDesignerEventArgs e)
        {			
            UpdateStatus("Active designer moved from "+e.OldDesigner.RootComponent.Site.Name+" to "+e.NewDesigner.RootComponent.Site.Name+".");
        }
        
        private void SelectionChanged(object sender, EventArgs e)
        {			
            UpdateStatus("A component selection was changed.");
        }

        // Update message buffer on DesignerMonitor control.
        private void UpdateStatus(string newmsg)
        {
            if( dm.updates.Count > 10 )
                dm.updates.RemoveAt(10);
            dm.updates.Insert(0, "Event #"+eventcount.ToString()+": "+newmsg);
            eventcount++;
            dm.Refresh();	
        }
    }
}