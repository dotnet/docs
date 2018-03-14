.NET Framework 3.0 XAML Browser Application Readme
----------------------------------
XAML Browser Applications run in a sandbox with "Internet Permissions".
Only those .NET Framework 3.0 features that have been successfully security reviewed and validated as safe by the .NET Framework 3.0 team will run inside the sandbox.

.NET Framework 3.0 Item Templates - which work in the sandbox?
--------------------------------------------------------
Won't work by design - .NET Framework 3.0 Window - In the internet zone, you don't have the permission to "popup" new windows.

Debugging XAML Browser Applications - (F5)
--------------------------------------------------------
In order to successfully debug an XAML Browser Application in Visual Studio, you must enable unmanaged code debugging
via the Debug page in the Properties view. Developers using Visual C# and Visual Basic Express do not need to do this.

The first time that this project is debugged, a dialog may appear stating that there 
is no debug information available for PresentationHost.exe.  This dialog can be
safely dismissed.
