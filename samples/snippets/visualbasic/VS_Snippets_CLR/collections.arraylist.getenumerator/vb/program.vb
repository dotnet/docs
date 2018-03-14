' <Snippet1>
Imports System
Imports System.Collections

Class Program
    Private Shared Sub Main(ByVal args As String())
        Dim colors As New ArrayList()
        colors.Add("red")
        colors.Add("blue")
        colors.Add("green")
        colors.Add("yellow")
        colors.Add("beige")
        colors.Add("brown")
        colors.Add("magenta")
        colors.Add("purple")
        
        Dim e As IEnumerator = colors.GetEnumerator()
        While e.MoveNext()
            Dim obj As [Object] = e.Current
            Console.WriteLine(obj)
        End While
        
        Console.WriteLine()
        
        Dim e2 As IEnumerator = colors.GetEnumerator(2, 4)
        While e2.MoveNext()
            Dim obj As [Object] = e2.Current
            Console.WriteLine(obj)
        End While
    End Sub
End Class

' This code example produces
' the following ouput:
' red
' blue
' green
' yellow
' beige
' brown
' magenta
' purple
'
' green
' yellow
' beige
' brown
' 

' </Snippet1>