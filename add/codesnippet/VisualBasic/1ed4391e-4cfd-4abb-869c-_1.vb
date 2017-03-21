    ' Creates an identifier for a particular data type that does not conflict 
    ' with the identifiers of any components in the specified collection
    Public Function CreateName(ByVal container As System.ComponentModel.IContainer, ByVal dataType As System.Type) As String Implements INameCreationService.CreateName
        ' Create a basic type name string
        Dim baseName As String = dataType.Name
        Dim uniqueID As Integer = 1

        Dim unique As Boolean = False
        ' Continue to increment uniqueID numeral until a unique ID is located.
        While Not unique
            unique = True
            ' Check each component in the container for a matching 
            ' base type name and unique ID.
            Dim i As Integer
            For i = 0 To container.Components.Count - 1
                ' Check component name for match with unique ID string.
                If container.Components(i).Site.Name.StartsWith((baseName + uniqueID.ToString())) Then
                    ' If a match is encountered, set flag to recycle 
                    ' collection, increment ID numeral, and restart.
                    unique = False
                    uniqueID += 1
                    Exit For
                End If
            Next i
        End While

        Return baseName + uniqueID.ToString()
    End Function