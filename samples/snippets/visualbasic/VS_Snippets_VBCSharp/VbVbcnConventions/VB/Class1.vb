'*************************************************************************
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing.Color


'*************************************************************************
Public Class Class1

  '***********************************************************************
  '<Snippet15>
  Public Class hasDefault
    Default Public ReadOnly Property index(ByVal s As String) As Integer
      Get
        Return 32768 + AscW(s)
      End Get
    End Property
  End Class
  Public Class testHasDefault
    Public Sub compareAccess()
      Dim hD As hasDefault = New hasDefault()
      MsgBox("Traditional access returns " & hD.index("X") & vbCrLf & 
        "Default property access returns " & hD("X") & vbCrLf & 
        "Dictionary access returns " & hD!X)
    End Sub
  End Class
  '</Snippet15>


  '***********************************************************************
  Sub Test()

    '<Snippet17>
    ' This comment is too long to fit on a single line, so we break 
    ' it into two lines. Some comments might need three or more lines.
    '</Snippet17>


    '<Snippet18>
    ' This entire line is a comment.
    Dim DailyTotal As Decimal = 0   ' Sales total for today.
    ' This comment is so long that it requires more than one line, so 
    ' the comment character (') must be repeated on the second line.
    '</Snippet18>


    '<Snippet14>
    Dim nextForm As New System.Windows.Forms.Form
    ' Access Text member (property) of Form class (on nextForm object).
    nextForm.Text = "This is the next form"
    ' Access Close member (method) on nextForm.
    nextForm.Close()
    '</Snippet14>


    Dim var1, var2 As Object
    Dim resultA As Double, resultB As String

    '<Snippet13>
    var1 = "10.01"
    var2 = 11
    resultA = var1 + var2
    resultB = var1 & var2
    '</Snippet13>

    '<Snippet11>
    Dim a, b, c, d, e As Double
    a = 3.2
    b = 7.6
    c = 2
    d = b + c / a
    e = (b + c) / a
    '</Snippet11>


    '<Snippet12>
    a = 3.2 : b = 7.6 : c = 2
    '</Snippet12>


    Dim text1 As New System.Windows.Forms.TextBox

    '<Snippet10>
    text1.Text = "Hello" : text1.BackColor = System.Drawing.Color.Red
    '</Snippet10>


    '<Snippet16>
    ' This is a comment beginning at the left edge of the screen.
    text1.Text = "Hi!"   ' This is an inline comment.
    '</Snippet16>


    Dim cmd As New System.Data.SqlClient.SqlCommand

    '<Snippet9>
    cmd.CommandText = 
        "SELECT * FROM Titles JOIN Publishers " &
        "ON Publishers.PubId = Titles.PubID " &
        "WHERE Publishers.State = 'CA'"
    '</Snippet9>

    '<Snippet20>
    cmd.CommandText = _
        "SELECT * FROM Titles JOIN Publishers " _
        & "ON Publishers.PubId = Titles.PubID " _
        & "WHERE Publishers.State = 'CA'"
    '</Snippet20>
  End Sub


  '***********************************************************************
  Public Class sampleForm
    Public Class [Loop]
      Public Shared Visible As Boolean
    End Class
  End Class

  Public Class [Loop]
    Public Shared Visible As Boolean
  End Class

  Sub TestLoop()
    '<Snippet8>
   ' The following statement precedes Loop with a full qualification string.
   sampleForm.Loop.Visible = True
   ' The following statement encloses Loop in square brackets.
    [Loop].Visible = True
    '</Snippet8>
  End Sub


  '***********************************************************************
  '<Snippet5>
  Function Main() As Integer
    MsgBox("Hello, World!") ' Display message on computer screen.
    Return 0 ' Zero usually means successful completion.
  End Function
  '</Snippet5>


  '<Snippet6>
  Function Main(ByVal CmdArgs() As String) As Integer
    Dim ArgNum As Integer ' Index of individual command-line argument.
    ' See if there are any arguments.
    If CmdArgs.Length > 0 Then
        For ArgNum = 0 To UBound(CmdArgs)
            ' Insert code to examine CmdArgs(ArgNum) for settings
            ' you need to handle.
        Next ArgNum
    End If
    MsgBox("Hello, World!") ' Display message on computer screen.
    Return 0 ' Zero usually means successful completion.
  End Function
  '</Snippet6>


  Class WrapMain
    '<Snippet7>
    Sub Main(ByVal CmdArgs() As String)
    '</Snippet7>
    End Sub
  End Class
End Class
