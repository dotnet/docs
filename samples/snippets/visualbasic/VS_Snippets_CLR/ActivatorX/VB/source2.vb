'<snippet4>
Imports System

Class DynamicInstanceList
    Private Shared instanceSpec As String = "System.EventArgs;System.Random;" + _
        "System.Exception;System.Object;System.Version"

    Public Shared Sub Main()
        Dim instances() As String = instanceSpec.Split(";")
        Dim instlist As Array = Array.CreateInstance(GetType(Object), instances.Length)
        Dim item As Object

        For i As Integer = 0 To instances.Length -1
            ' create the object from the specification string
            Console.WriteLine("Creating instance of: {0}", instances(i))
            item = Activator.CreateInstance(Type.GetType(instances(i)))
            instlist.SetValue(item, i)
        Next i
        Console.WriteLine(vbNewLine + "Objects and their default values:" + vbNewLine)
        For Each o As Object In instlist
            Console.WriteLine("Type:     {0}" + vbNewLine + "Value:    {1}" + _
                vbNewLine + "HashCode: {2}" + vbNewLine, _
                o.GetType().FullName, o.ToString(), o.GetHashCode())
        Next o
    End Sub
End Class

' This program will display output similar to the following:
'
' Creating instance of: System.EventArgs
' Creating instance of: System.Random
' Creating instance of: System.Exception
' Creating instance of: System.Object
' Creating instance of: System.Version
'
' Objects and their default values:
'
' Type:     System.EventArgs
' Value:    System.EventArgs
' HashCode: 46104728
'
' Type:     System.Random
' Value:    System.Random
' HashCode: 12289376
'
' Type:     System.Exception
' Value:    System.Exception: Exception of type 'System.Exception' was thrown.
' HashCode: 55530882
'
' Type:     System.Object
' Value:    System.Object
' HashCode: 30015890
'
' Type:     System.Version
' Value:    0.0
' HashCode: 1048575
'</snippet4>
