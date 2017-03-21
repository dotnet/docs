                Dim dirNames As String() = isoFile.GetDirectoryNames("*")
                Dim fileNames As String() = isoFile.GetFileNames("*")
                Dim name As String

                ' List directories currently in this Isolated Storage.
                If dirNames.Length > 0 Then

                    For Each name In dirNames
                        Console.WriteLine("Directory Name: " & name)
                    Next name
                End If

                ' List the files currently in this Isolated Storage.
                ' The list represents all users who have personal preferences stored for this application.
                If fileNames.Length > 0 Then

                    For Each name In fileNames
                        Console.WriteLine("File Name: " & name)
                    Next name
                End If