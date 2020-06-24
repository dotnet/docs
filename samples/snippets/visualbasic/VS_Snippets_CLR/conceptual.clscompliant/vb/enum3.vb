' Visual Basic .NET Document
Option Strict On

' <Snippet7>
<Assembly: CLSCompliant(True)>

Public Enum Size As UInt32
    Unspecified = 0
    XSmall = 1
    Small = 2
    Medium = 3
    Large = 4
    XLarge = 5
End Enum

Public Class Clothing
    Public Name As String
    Public Type As String
    Public Size As Size
End Class
' The attempt to compile the example displays a compiler warning like the following:
'    Enum3.vb(6) : warning BC40032: Underlying type 'UInt32' of Enum is not CLS-compliant.
'    
'    Public Enum Size As UInt32
'                ~~~~
' </Snippet7>



