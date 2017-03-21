            ' Check whether the underlying stream supports seeking.
            If bufStream.CanSeek Then
                Console.WriteLine("NetworkStream supports" & _
                    "seeking." & vbCrLf)
            Else
                Console.WriteLine("NetworkStream does not " & _
                    "support seeking." & vbCrLf)
            End If