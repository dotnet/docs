
Imports System
Imports System.IO
Imports System.Collections
Imports System.Runtime.Remoting

Namespace SampleNamespace

Public Class SampleWellKnown
    Inherits MarshalByRefObject
    Public State As Integer = 0
    
    
    Public Function Add(ByVal a As Integer, ByVal b As Integer) As Integer 
        Console.WriteLine("Add method called")
        Return a + b
    
    End Function 'Add
End Class 'SampleWellKnown

End Namespace