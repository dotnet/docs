using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace MiscCompModSamples
{

	public class ComponentEventArgsExample
	{
		public ComponentEventArgsExample()
		{			
		}

        //<Snippet1>
        // This example method creates a ComponentEventArgs using the specified argument.
        // Typically, this type of event args is created by a design mode subsystem.  
        public ComponentEventArgs CreateComponentEventArgs(IComponent component)
        {
            ComponentEventArgs args = new ComponentEventArgs(component);

            // The component that is related to the event:  args.Component

            return args;
        }
        //</Snippet1>
	}
}
