using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace MiscCompModSamples
{
	public class ComponentRenameEventArgsExample
	{
		public ComponentRenameEventArgsExample()
		{			
		}

        //<Snippet1>
        // This example method creates a ComponentRenameEventArgs using the specified arguments.
        // Typically, this type of event args is created by a design mode subsystem.  
        public ComponentRenameEventArgs CreateComponentRenameEventArgs(object component, string oldName, string newName)
        {
            ComponentRenameEventArgs args = new ComponentRenameEventArgs(component, oldName, newName);

            // The component that was renamed:          args.Component
            // The previous name of the component:      args.OldName
            // The new name of the component:           args.NewName            

            return args;
        }
        //</Snippet1>
	}
}
