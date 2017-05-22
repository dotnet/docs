'<Snippet1>
Imports System.Device.Location
Module CourseAndSpeed
    '<Snippet2>

    Public Sub GetLocationCourseAndSpeed()
        Dim watcher As GeoCoordinateWatcher
        watcher = New System.Device.Location.GeoCoordinateWatcher()
        watcher.TryStart(False, TimeSpan.FromMilliseconds(1000))

        If Not watcher.Position.Location.IsUnknown Then
            Dim coord As GeoCoordinate = watcher.Position.Location
            Console.WriteLine("Course: {0}, Speed: {1}",
                coord.Course,
                coord.Speed) 'NaN if not available.
        Else
            Console.WriteLine("Location unknown.")
        End If

    End Sub

    '</Snippet2>

    Public Sub Main()
        GetLocationCourseAndSpeed()
    End Sub

End Module
'</Snippet1>
