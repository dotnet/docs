' <Snippet1>
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
'Imports Libraries

Module Program
   Sub Main()
      Dim value = ValueTuple.Create("03244562", DateTime.Now, 13452.50d)
      If Libraries.UtilityLibrary.IsSerializable(value) Then
   		Dim formatter As New BinaryFormatter()
	   	' Serialize the value tuple.
         Dim stream As New FileStream("data.bin", FileMode.Create, 
			                             FileAccess.Write, FileShare.None)
			formatter.Serialize(stream, value)
			stream.Close()
         ' Deserialize the value tuple.
         Dim readStream As New FileStream("data.bin", FileMode.Open)
         Dim restoredValue = formatter.Deserialize(readStream)
         Console.WriteLine($"{restoredValue.GetType().Name}: {restoredValue}")
		Else
			Console.WriteLine($"{nameof(value)} is not serializable")
		End If
    End Sub
End Module
' The example displays output like the following:
'    ValueTuple`3: (03244562, 10/18/2017 5:25:22 PM, 13452.50)
' </Snippet1>

' <Snippet2>
Namespace Libraries
	Public Class UtilityLibrary
    	Public Shared Function IsSerializable(obj As Object) As Boolean
    		If obj Is Nothing Then Return False 

			Dim t As Type = obj.GetType()
			Return t.IsSerializable
		End Function
	End Class
End Namespace
' </Snippet2>