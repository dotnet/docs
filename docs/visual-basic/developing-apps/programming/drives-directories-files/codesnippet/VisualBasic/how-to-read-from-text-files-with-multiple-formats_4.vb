      Catch ex As Microsoft.VisualBasic.
                    FileIO.MalformedLineException
         MsgBox("Line " & ex.Message & " is invalid.")
      End Try
   End While
End Using