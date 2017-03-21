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