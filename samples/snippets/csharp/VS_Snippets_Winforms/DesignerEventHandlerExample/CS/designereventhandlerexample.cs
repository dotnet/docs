using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace MiscCompModSamples
{	
	public class DesignerEventHandlerExample
	{
		public DesignerEventHandlerExample()
		{			
		}

        //<Snippet1>
        public void LinkDesignerEvent(IDesignerEventService eventService)
        {                                   
            // Registers an event handler for the DesignerCreated and DesignerDisposed events.
            eventService.DesignerCreated += new DesignerEventHandler(this.OnDesignerEvent);
            eventService.DesignerDisposed += new DesignerEventHandler(this.OnDesignerEvent);            
        }

        private void OnDesignerEvent(object sender, DesignerEventArgs e)
        {
            // Displays designer event information on the console.
            Console.WriteLine("Name of the root component of the created or disposed designer: "+e.Designer.RootComponentClassName);
        }
        //</Snippet1>
	}
}