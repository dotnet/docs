using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace MiscCompModSamples
{
	public class ComponentEventHandlerExample
	{
		public ComponentEventHandlerExample()
		{
		}

        //<Snippet1>
        public void LinkComponentEvent(IComponentChangeService changeService)
        {
            // Registers an event handler for the ComponentAdded,
            // ComponentAdding, ComponentRemoved, and ComponentRemoving events.
            changeService.ComponentAdded += new ComponentEventHandler(this.OnComponentEvent);            
            changeService.ComponentAdding += new ComponentEventHandler(this.OnComponentEvent);            
            changeService.ComponentRemoved += new ComponentEventHandler(this.OnComponentEvent);            
            changeService.ComponentRemoving += new ComponentEventHandler(this.OnComponentEvent);                        
        }

        private void OnComponentEvent(object sender, ComponentEventArgs e)
        {
            // Displays changed component information on the console.            
            if( e.Component.Site != null )
                Console.WriteLine("Name of the component related to the event: "+e.Component.Site.Name);      
            Console.WriteLine("Type of the component related to the event: "+e.Component.GetType().FullName);
        }
        //</Snippet1>
	}
}