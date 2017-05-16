using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace MiscCompModSamples
{
	public class ComponentRenameEventHandlerExample
	{
		public ComponentRenameEventHandlerExample()
		{
		}

        //<Snippet1>
        public void LinkComponentRenameEvent(IComponentChangeService changeService)
        {
            // Registers an event handler for the ComponentRename event.
            changeService.ComponentRename += new ComponentRenameEventHandler(this.OnComponentRename);            
        }

        private void OnComponentRename(object sender, ComponentRenameEventArgs e)
        {
            // Displayss component renamed information on the console.           
            Console.WriteLine("Type of the component that has been renamed: "+e.Component.GetType().FullName);                  
            Console.WriteLine("New name of the component that has been renamed: "+e.NewName);
            Console.WriteLine("Old name of the component that has been renamed: "+e.OldName);
        }
        //</Snippet1>
	}
}