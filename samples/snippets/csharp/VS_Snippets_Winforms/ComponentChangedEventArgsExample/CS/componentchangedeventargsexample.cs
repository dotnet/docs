using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace MiscCompModSamples
{
	public class ComponentChangedEventArgsExample
	{
		public ComponentChangedEventArgsExample()
		{            
		}

        //<Snippet1>        
        // This example method creates a ComponentChangedEventArgs using the specified arguments.
        // Typically, this type of event args is created by a design mode subsystem.            
        public ComponentChangedEventArgs CreateComponentChangedEventArgs(object component, MemberDescriptor member, object oldValue, object newValue)
        {            
            // Creates a component changed event args with the specified arguments.
            ComponentChangedEventArgs args = new ComponentChangedEventArgs(component, member, oldValue, newValue);

            // The component that has changed:              args.Component
            // The member of the component that changed:    args.Member
            // The old value of the member:                 args.oldValue
            // The new value of the member:                 args.newValue

            return args;            
        }
        //</Snippet1>
	}
}
