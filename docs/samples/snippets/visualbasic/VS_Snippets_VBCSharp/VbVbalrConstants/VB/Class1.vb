'<Snippet1>
Option Strict On

Public Class Sample
  Public Const MyByte As Byte = 2
End Class
'</Snippet1>

Class Sample2
  '<Snippet2>
  Dim MyDecimal As Decimal = 100000000000000000000D
  '</Snippet2>
End Class

Module Module2
  Public Class ConstantsSample
    '<Snippet3>
    ' Default to Integer.
    Public Const DefaultInteger As Integer = 100

    ' Default to Double.
    Public Const DefaultDouble As Double = 54.3345612

    ' Force constant to be type Char.
    Public Const MyCharacter As Char = "a"c

    ' DateTime constants.
    Public Const MyDate As DateTime = #1/15/2001#
    Public Const MyTime As DateTime = #1:15:59 AM#

    ' Force data type to be Long.
    Public Const MyLong As Long = 45L

    ' Force data type to be Single.
    Public Const MySingle As Single = 45.55!
    '</Snippet3>

    Sub ShowDefaultButtons()
    '<Snippet4>
    ' Set the Abort button as the default button.
    MsgBox("Error occurred", vbDefaultButton1 Or vbAbortRetryIgnore)
    '</Snippet4>

    '<Snippet5>
    ' Set the Retry button as the default button.
    MsgBox("Error occurred", vbDefaultButton2 Or vbAbortRetryIgnore)
    '</Snippet5>

    '<Snippet6>
    ' Set the Ignore button as the default button.
    MsgBox("Error occurred", vbDefaultButton3 Or vbAbortRetryIgnore)
    '</Snippet6>
    End Sub
  End Class
End Module