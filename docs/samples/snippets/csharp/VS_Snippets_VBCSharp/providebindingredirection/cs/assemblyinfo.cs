using System;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Microsoft.VisualStudio.Shell;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("VSPackage3")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("VSPackage3")]
[assembly: AssemblyCopyright("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]   
[assembly: ComVisible(false)]     
[assembly: CLSCompliant(false)]
[assembly: NeutralResourcesLanguage("en-US")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

// T:Microsoft.VisualStudio.Shell.ProvideBindingRedirectionAttribute
//<snippet1>
[assembly: ProvideBindingRedirection(AssemblyName = "ClassLibrary1",
    NewVersion = "3.0.0.0", OldVersionLowerBound = "1.0.0.0",
    OldVersionUpperBound = "2.0.0.0")]
//</snippet1>

// T:Microsoft.VisualStudio.Shell.ProvideCodeBaseAttribute
//<snippet2>
[assembly: ProvideCodeBase(AssemblyName = "ClassLibrary1",
Version = "1.0.0.0", CodeBase = "$PackageFolder$\\ClassLibrary1.dll")]
//</snippet2>


