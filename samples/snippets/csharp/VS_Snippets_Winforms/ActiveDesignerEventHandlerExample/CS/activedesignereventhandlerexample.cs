using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace MiscCompModSamples
{
	public class ActiveDesignerEventHandlerExample
	{
		public ActiveDesignerEventHandlerExample()
		{            
		}

        //<Snippet1>
        public void LinkActiveDesignerEvent(IDesignerEventService eventService)
        {
            // Registers an event handler for the ActiveDesignerChanged event.
            eventService.ActiveDesignerChanged += new ActiveDesignerEventHandler(this.OnActiveDesignerEvent);
        }

        private void OnActiveDesignerEvent(object sender, ActiveDesignerEventArgs e)
        {
            // Displays changed designer information on the console.
            if( e.NewDesigner.RootComponent.Site != null )
                Console.WriteLine("Name of the component of the new active designer: "+e.NewDesigner.RootComponent.Site.Name);            
            Console.WriteLine("Type of the component of the new active designer: "+e.NewDesigner.RootComponentClassName);
            if( e.OldDesigner.RootComponent.Site != null )
                Console.WriteLine("Name of the component of the previously active designer: "+e.OldDesigner.RootComponent.Site.Name);
            Console.WriteLine("Type of the component of the previously active designer: "+e.OldDesigner.RootComponentClassName);
        }
        //</Snippet1>
	}
}