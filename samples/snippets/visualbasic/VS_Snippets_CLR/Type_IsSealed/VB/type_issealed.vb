' <Snippet1>   
Public Class Example
    ' Declare InnerClass as sealed.
    Public NotInheritable Class InnerClass
    End Class
    
    Public Shared Sub Main()
         Dim inner As New InnerClass()
         ' Get the type of InnerClass.
         Dim innerType As Type = inner.GetType()
         ' Get the IsSealed property of InnerClass.
         Dim sealed As Boolean = innerType.IsSealed
         Console.WriteLine("{0} is sealed: {1}.", innerType.FullName, sealed)
    End Sub
End Class
' The example displays the following output:
'       Example+InnerClass is sealed: True.
' </Snippet1>
