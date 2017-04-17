Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Configuration.Install


Public Class Class1
    
    ' <Snippet1>
    <RunInstallerAttribute(True)> _
    Public Class MyProjectInstaller
        Inherits Installer

        ' Insert code here.
    End Class 'MyProjectInstaller
    ' </Snippet1>
    ' <Snippet2>
    Public Shared Function Main() As Integer
        ' Creates a new installer.
        Dim myNewProjectInstaller As New MyProjectInstaller()
        
        ' Gets the attributes for the collection.
        Dim attributes As AttributeCollection = TypeDescriptor.GetAttributes(myNewProjectInstaller)
        
        ' Prints whether to run the installer by retrieving the
        ' RunInstallerAttribute from the AttributeCollection. 
        Dim myAttribute As RunInstallerAttribute = _
            CType(attributes(GetType(RunInstallerAttribute)), RunInstallerAttribute)

        Console.WriteLine(("Run the installer? " & myAttribute.RunInstaller.ToString()))
        Return 0
    End Function 'Main
    ' </Snippet2>
End Class 'Class1 
