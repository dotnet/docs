' Visual Basic .NET Document
Option Strict On
' <Snippet1>
<Assembly: CLSCompliant(True)>

Public Class Person
    Private personAge As UInt16

    Public ReadOnly Property Age As UInt16
        Get
            Return personAge
        End Get
    End Property
End Class
' The attempt to compile the example displays the following compiler warning:
'    Public1.vb(9) : warning BC40027: Return type of function 'Age' is not CLS-compliant.
'    
'       Public ReadOnly Property Age As UInt16
'                                ~~~
' </Snippet1>    
