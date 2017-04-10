using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace MiscCompModSamples
{	
	public class ComponentChangingEventHandlerExample
	{
		public ComponentChangingEventHandlerExample()
		{
		}

        //<Snippet1>
        public void LinkComponentChangingEvent(IComponentChangeService changeService)
        {
            // Registers an event handler for the ComponentChanging event.
            changeService.ComponentChanging += new ComponentChangingEventHandler(this.OnComponentChanging);            
        }

        private void OnComponentChanging(object sender, ComponentChangingEventArgs e)
        {
            // Displays changing component information on the console.
            Console.WriteLine("Type of the component that is about to change: "+e.Component.GetType().FullName);      
            Console.WriteLine("Name of the member of the component that is about to change: "+e.Member.Name);                        
        }
        //</Snippet1>
	}
}
