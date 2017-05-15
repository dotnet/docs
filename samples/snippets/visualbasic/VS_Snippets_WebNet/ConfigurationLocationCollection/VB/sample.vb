'<Snippet1>
Imports System
Imports System.Collections
Imports System.Configuration

Class DisplayLocationInfo
    Public Overloads Shared Sub Main()
        Dim config As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Dim myLocationCollection As _
            System.Configuration.ConfigurationLocationCollection = config.Locations
        Dim myLocation As ConfigurationLocation
        For Each myLocation In  myLocationCollection
            '<Snippet2>
            Console.WriteLine("Location Path: {0}", myLocation.Path)
            '</Snippet2>
            '<Snippet3>
            Dim myLocationConfiguration As System.Configuration.Configuration = _
                myLocation.OpenConfiguration()
            Console.WriteLine("Location Configuration Path: {0}", _
                myLocationConfiguration.FilePath)
            '</Snippet3>
        Next myLocation
        Console.WriteLine("Done...")
        Console.ReadLine()
    End Sub
End Class 'DisplayLocationInfo
'</Snippet1>