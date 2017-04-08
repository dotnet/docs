' <Snippet1>
Imports System.Collections.Generic

Public Class Example

    Shared Sub Main()

        Console.WriteLine(vbCrLf & _
            "Interfaces implemented by Dictionary(Of Integer, String):" & vbCrLf)
        
        For Each tinterface As Type In GetType(Dictionary(Of Integer, String)).GetInterfaces()

            Console.WriteLine(tinterface.ToString())

        Next

        'Console.ReadLine()      ' Uncomment this line for Visual Studio. 
    End Sub
End Class

' This example produces output similar to the following:
'
'Interfaces implemented by Dictionary(Of Integer, String):
'System.Collections.Generic.IDictionary`2[System.Int32,System.String]
'System.Collections.Generic.ICollection`1[System.Collections.Generic.KeyValuePair`2[System.Int32,System.String]]
'System.Collections.Generic.IEnumerable`1[System.Collections.Generic.KeyValuePair`2[System.Int32,System.String]]
'System.Collection.IEnumerable
'System.Collection.IDictionary
'System.Collection.ICollection
'System.Runtime.Serialization.ISerializable
'System.Runtime.Serialization.IDeserializationCallback
' </Snippet1>
