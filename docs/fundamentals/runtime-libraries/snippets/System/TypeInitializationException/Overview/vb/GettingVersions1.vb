' Visual Basic .NET Document
Option Strict On

Imports System.Reflection

<Assembly: CLSCompliant(True)>
Module modMain

   Public Sub Main()
      GetOsVersion()
      Console.WriteLine()      
      GetClrVersion()
      Console.WriteLine()
      GetSpecificAssemblyVersion()
      Console.WriteLine()
        Example2.GetExecutingAssemblyVersion()
        Console.WriteLine()
      GetApplicationVersion()
   End Sub
   
   Private Sub GetOsVersion()
      ' <Snippet1>
      ' Get the operating system version.
      Dim os As OperatingSystem = Environment.OSVersion
      Dim ver As Version = os.Version
      Console.WriteLine("Operating System: {0} ({1})", os.VersionString, ver.ToString())
      ' </Snippet1>
   End Sub
   
   Private Sub GetClrVersion()
      ' <Snippet2>
      ' Get the common language runtime version.
      Dim ver As Version = Environment.Version
      Console.WriteLine("CLR Version {0}", ver.ToString())
      ' </Snippet2>
   End Sub

   Private Sub GetSpecificAssemblyVersion()
      ' Get the version of a specific assembly.
      Dim filename As String = ".\StringLibrary.dll"
      Dim assem As Assembly = Assembly.ReflectionOnlyLoadFrom(filename)
      Dim assemName As AssemblyName = assem.GetName()
      Dim ver As Version = assemName.Version
      Console.WriteLine("{0}, Version {1}", assemName.Name, ver.ToString())
   End Sub

   Private Sub GetApplicationVersion()
      ' Get the version of the executing assembly (that is, this assembly).
      Dim assem As Assembly = Assembly.GetEntryAssembly()
      Dim assemName As AssemblyName = assem.GetName()
      Dim ver As Version = assemName.Version
      Console.WriteLine("Application {0}, Version {1}", assemName.Name, ver.ToString())
   End Sub
End Module

Public Module Example2
    Public Sub GetExecutingAssemblyVersion()
        ' Get the version of the current assembly.
        Dim assem As Assembly = Assembly.GetExecutingAssembly()
        Dim assemName As AssemblyName = assem.GetName()
        Dim ver As Version = assemName.Version
        Console.WriteLine("{0}, Version {1}", assemName.Name, ver.ToString())
    End Sub
End Module
