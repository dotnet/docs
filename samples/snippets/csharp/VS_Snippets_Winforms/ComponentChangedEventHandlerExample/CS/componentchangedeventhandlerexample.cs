using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace MiscCompModSamples
{
	public class ComponentChangedEventHandlerExample
	{
		public ComponentChangedEventHandlerExample()
		{
		}

        //<Snippet1>
        public void LinkComponentChangedEvent(IComponentChangeService changeService)
        {
            // Registers an event handler for the ComponentChanged event.
            changeService.ComponentChanged += new ComponentChangedEventHandler(this.OnComponentChanged);            
        }

        private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
        {
            // Displays changed component information on the console.
            Console.WriteLine("Type of the component that has changed: "+e.Component.GetType().FullName);      
            Console.WriteLine("Name of the member of the component that has changed: "+e.Member.Name);            
            Console.WriteLine("Old value of the member: "+e.OldValue.ToString());
            Console.WriteLine("New value of the member: "+e.NewValue.ToString());
        }
        //</Snippet1>
	}
}
