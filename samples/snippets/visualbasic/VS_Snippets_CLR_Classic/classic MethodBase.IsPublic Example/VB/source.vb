Imports System
Imports System.Reflection
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

' <Snippet1>
Class methodbase1
    
    Public Shared Function Main() As Integer
    
        Console.WriteLine(ControlChars.Cr + "Reflection.MethodBase")
        
        'Get the MethodBase of a method.
        
        'Get the type
        Dim MyType As Type = Type.GetType("System.MulticastDelegate")
        
        'Get and display the method
        Dim Mymethodbase As MethodBase = _
           MyType.GetMethod("RemoveImpl", BindingFlags.NonPublic)
        
        Console.Write(ControlChars.Cr _
           + "Mymethodbase = " + Mymethodbase.ToString())
        
        Dim Myispublic As Boolean = Mymethodbase.IsPublic
        If Myispublic Then
            Console.Write(ControlChars.Cr _
               + "Mymethodbase is a public method")
        Else
            Console.Write(ControlChars.Cr _
               + "Mymethodbase is not a public method")
        End If 
        Return 0
    End Function
End Class

' Produces the following output
' 
' Reflection.MethodBase
' Mymethodbase = System.Delegate RemoveImpl (System.Delegate)
' Mymethodbase is not a public method 
' </Snippet1>