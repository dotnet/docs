' Visual Basic .NET Document
Option Strict On

' <Snippet6>
<Assembly: CLSCompliant(True)>

Public Interface INumber
    Function Length As Integer

    <CLSCompliant(False)> Function GetUnsigned As ULong
End Interface
' Attempting to compile the example displays output like the following:
'    Interface2.vb(9) : warning BC40033: Non CLS-compliant 'function' is not allowed in a 
'    CLS-compliant interface.
'    
'       <CLSCompliant(False)> Function GetUnsigned As ULong
'                                      ~~~~~~~~~~~
' </Snippet6>


Module Example
    Public Sub Main()

    End Sub
End Module

