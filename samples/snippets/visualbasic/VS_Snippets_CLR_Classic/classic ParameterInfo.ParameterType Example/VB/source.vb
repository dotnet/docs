' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Class parminfo
    
    Public Shared Sub mymethod(int1m As Integer, ByRef str2m As String, _
    ByRef str3m As String)
        str2m = "in mymethod"
    End Sub
       
    Public Shared Function Main() As Integer
        Console.WriteLine(ControlChars.CrLf + "Reflection.Parameterinfo")
        
        'Get the ParameterInfo parameter of a function.
        'Get the type.
        Dim Mytype As Type = GetType(parminfo)
        
        'Get and display the method.
        Dim Mymethodbase As MethodBase = Mytype.GetMethod("mymethod")
        Console.Write(ControlChars.CrLf _
           + "Mymethodbase = " + Mymethodbase.ToString())
        
        'Get the ParameterInfo array.
        Dim Myarray As ParameterInfo() = Mymethodbase.GetParameters()
        
        'Get and display the ParameterInfo of each parameter.
        Dim Myparam As ParameterInfo
        For Each Myparam In  Myarray
            Console.Write(ControlChars.CrLf _
               + "For parameter # " + Myparam.Position.ToString() _
               + ", the ParameterType is - " + Myparam.ParameterType.ToString())
        Next Myparam
        Return 0
    End Function
End Class

' This code produces the following output:
' 
' Reflection.Parameterinfo

' Mymethodbase = Void mymethod(Int32, System.String ByRef, System.String ByRef)
' For parameter # 0, the ParameterType is - System.Int32
' For parameter # 1, the ParameterType is - System.String&
' For parameter # 2, the ParameterType is - System.String& 
' </Snippet1>