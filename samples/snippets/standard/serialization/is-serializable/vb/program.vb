' <Snippet1>
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports Libraries

Module Program
    Sub Main()
        Dim value = ValueTuple.Create("03244562", DateTime.Now, 13452.50d)
        If value.IsSerializable() Then
            Dim formatter As New BinaryFormatter()
            ' Serialize the value tuple.
            Using stream As New FileStream("data.bin", FileMode.Create,
                                           FileAccess.Write, FileShare.None)
                formatter.Serialize(stream, value)
            End Using
            ' Deserialize the value tuple.
            Using readStream As New FileStream("data.bin", FileMode.Open)
                Dim restoredValue = formatter.Deserialize(readStream)
                Console.WriteLine($"{restoredValue.GetType().Name}: {restoredValue}")
            End Using
        Else
            Console.WriteLine($"{nameof(value)} is not serializable")
        End If
    End Sub
End Module
' The example displays output like the following:
'    ValueTuple`3: (03244562, 10/18/2017 5:25:22 PM, 13452.50)
' </Snippet1>
