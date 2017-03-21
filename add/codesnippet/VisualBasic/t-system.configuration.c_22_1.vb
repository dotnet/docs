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
            Console.WriteLine("Location Path: {0}", myLocation.Path)
            Dim myLocationConfiguration As System.Configuration.Configuration = _
                myLocation.OpenConfiguration()
            Console.WriteLine("Location Configuration Path: {0}", _
                myLocationConfiguration.FilePath)
        Next myLocation
        Console.WriteLine("Done...")
        Console.ReadLine()
    End Sub
End Class 'DisplayLocationInfo