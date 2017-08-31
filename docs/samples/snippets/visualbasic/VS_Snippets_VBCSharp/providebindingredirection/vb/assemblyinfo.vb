
Imports Microsoft.VisualBasic
Imports System
Imports System.Reflection
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices

Imports Microsoft.VisualStudio.Shell


' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.
<Assembly: AssemblyTitle("VSPackageVB")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyConfiguration("")> 
<Assembly: AssemblyCompany("Microsoft")> 
<Assembly: AssemblyProduct("VSPackageVB")> 
<Assembly: AssemblyCopyright("")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: AssemblyCulture("")> 
<Assembly: ComVisible(False)> 
<Assembly: CLSCompliant(false)>
<Assembly: NeutralResourcesLanguage("en-US")>

' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version 
'      Build Number
'      Revision
'
' You can specify all the values or you can default the Revision and Build Numbers 
' by using the '*' as shown below:

<Assembly: AssemblyVersion("1.0.0.0")> 
<Assembly: AssemblyFileVersion("1.0.0.0")> 

' T:Microsoft.VisualStudio.Shell.ProvideBindingRedirectionAttribute
'<snippet1>
<Assembly: ProvideBindingRedirection(AssemblyName:="ClassLibrary1",
    NewVersion:="3.0.0.0", OldVersionLowerBound:="1.0.0.0",
    OldVersionUpperBound:="2.0.0.0")> 
'</snippet1>

' T:Microsoft.VisualStudio.Shell.ProvideCodeBaseAttribute
'<snippet2>
<Assembly: ProvideCodeBase(AssemblyName:="ClassLibrary1",
    Version:="1.0.0.0", CodeBase:="$PackageFolder$\ClassLibrary1.dll")> 
'</snippet2>

