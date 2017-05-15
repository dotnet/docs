using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
using System.Configuration.Install;
public class Class1
{
    // <Snippet1>
    [RunInstallerAttribute(true)]
     public class MyProjectInstaller : Installer {
        // Insert code here.
     }
    // </Snippet1>
    
    // <Snippet2>
    public static int Main() {
        // Creates a new installer.
        MyProjectInstaller myNewProjectInstaller = new MyProjectInstaller();
     
        // Gets the attributes for the collection.
        AttributeCollection attributes = TypeDescriptor.GetAttributes(myNewProjectInstaller);
     
        /* Prints whether to run the installer by retrieving the 
         * RunInstallerAttribute from the AttributeCollection. */
        RunInstallerAttribute myAttribute = 
           (RunInstallerAttribute)attributes[typeof(RunInstallerAttribute)];
        Console.WriteLine("Run the installer? " + myAttribute.RunInstaller.ToString());
      
        return 0;
     }
    // </Snippet2>
}
