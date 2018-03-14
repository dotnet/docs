using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace MiscCompModSamples
{
	public class ComponentChangingEventArgsExample
	{
		public ComponentChangingEventArgsExample()
		{
		}

        //<Snippet1>
        // This example method creates a ComponentChangingEventArgs using the specified arguments.
        // Typically, this type of event args is created by a design mode subsystem.  
        public ComponentChangingEventArgs CreateComponentChangingEventArgs(object component, MemberDescriptor member)
        {
            ComponentChangingEventArgs args = new ComponentChangingEventArgs(component, member);

            // The component that is about to change:       args.Component
            // The member that is about to change:          args.Member

            return args;
        }
        //</Snippet1>
	}
}
