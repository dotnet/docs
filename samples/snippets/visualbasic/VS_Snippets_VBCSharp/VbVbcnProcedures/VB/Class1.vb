Imports Microsoft.VisualBasic.Interaction
Imports System.Diagnostics
'<Snippet30>
' Insert the following line at the beginning of your source file.
Imports System.Data.SqlTypes
'</Snippet30>
'<Snippet56>
Imports MSVB = Microsoft.VisualBasic
'</Snippet56>
Public Class Class1

  '****************************************************************************
  '<Snippet66>
  Function AllOnes(n As Integer) As Integer()
      Dim iArray(n - 1) As Integer
      For i = 0 To n - 1
          iArray(i) = 1
      Next
      Return iArray
  End Function
  '</Snippet66>


  '****************************************************************************
  '<Snippet62>
  Overloads Sub z(ByVal x As Byte, ByVal y As Double)
  End Sub
  Overloads Sub z(ByVal x As Short, ByVal y As Single)
  End Sub
  Overloads Sub z(ByVal x As Integer, ByVal y As Single)
  End Sub
  '</Snippet62>


  '****************************************************************************
  Overloads Sub z(ByVal x As Byte, ByVal y As Short)
  End Sub


  '****************************************************************************
  Sub TestZ()
    '<Snippet63>
    Dim r, s As Short
    Call z(r, s)
    Dim p As Byte, q As Short
    ' The following statement causes an overload resolution error.
    Call z(p, q)
    '</Snippet63>

    '<Snippet65>
    Call z(CType(p, Short), CType(q, Single))
    '</Snippet65>
  End Sub


'****************************************************************************
'<Snippet59>
Sub q(ByVal b As Byte, Optional ByVal j As Long = 6)
'</Snippet59>
End Sub

'<Snippet69>
Sub p(ByVal d As Date, ByVal ParamArray c() As Char)
'</Snippet69>
End Sub


'****************************************************************************
Class Considerations

'<Snippet58>
Overloads Sub q(ByVal b As Byte, Optional ByVal j As Long = 6)
'</Snippet58>
End Sub

'<Snippet60>
' The preceding definition is equivalent to the following two overloads.
' Overloads Sub q(ByVal b As Byte)
' Overloads Sub q(ByVal b As Byte, ByVal j As Long)
'</Snippet60>

'<Snippet61>
' Therefore, the following overload is not valid because the signature is already in use.
' Overloads Sub q(ByVal c As Byte, ByVal k As Long)
' The following overload uses a different signature and is valid.
Overloads Sub q(ByVal b As Byte, ByVal j As Long, ByVal s As Single)
'</Snippet61>
End Sub

'<Snippet68>
Overloads Sub p(ByVal d As Date, ByVal ParamArray c() As Char)
'</Snippet68>
End Sub

'<Snippet70>
' The preceding definition is equivalent to the following overloads.
' Overloads Sub p(ByVal d As Date)
' Overloads Sub p(ByVal d As Date, ByVal c() As Char)
' Overloads Sub p(ByVal d As Date, ByVal c1 As Char)
' Overloads Sub p(ByVal d As Date, ByVal c1 As Char, ByVal c2 As Char)
' And so on, with an additional Char argument in each successive overload.
'</Snippet70>

'<Snippet71>
' The following overload is not valid because it takes an array for the parameter array.
' Overloads Sub p(ByVal x As Date, ByVal y() As Char)
' The following overload takes a single value for the parameter array and is valid.
Overloads Sub p(ByVal z As Date, ByVal w As Char)
'</Snippet71>
End Sub

End Class


  '****************************************************************************
  Sub TestPost()
    '<Snippet57>
    Dim customer As String
    Dim accountNum As Integer
    Dim amount As Single
    customer = MSVB.Interaction.InputBox("Enter customer name or number")
    amount = MSVB.Interaction.InputBox("Enter transaction amount")
    Try
        accountNum = CInt(customer)
        Call post(accountNum, amount)
    Catch
        Call post(customer, amount)
    End Try
    '</Snippet57>
  End Sub


  '****************************************************************************
  Class segregateSnippets54and55 ' to avoid double definitions of these overloads in new snippet 72
  '<Snippet54>
  Overloads Sub post(ByVal custName As String, ByVal amount As Single)
      ' Insert code to access customer record by customer name.
  End Sub
  '</Snippet54>
  '<Snippet55>
  Overloads Sub post(ByVal custAcct As Integer, ByVal amount As Single)
      ' Insert code to access customer record by account number.
  End Sub
  '</Snippet55>
  End Class

  ' New snippet to replace "VbVbcnProcedures#54,55" CREF (How to: Define Multiple Versions of a Procedure)
  '<Snippet72>
  Overloads Sub post(ByVal custName As String, ByVal amount As Single)
      ' Insert code to access customer record by customer name.
  End Sub
  Overloads Sub post(ByVal custAcct As Integer, ByVal amount As Single)
      ' Insert code to access customer record by account number.
  End Sub
  '</Snippet72>


  '****************************************************************************
  Class segregateSnippets52and53 ' to avoid double definitions of these overloads in new snippet 73
'<Snippet52>
  Sub postName(ByVal custName As String, ByVal amount As Single)
  '</Snippet52>
  End Sub

  '<Snippet53>
  Sub postAcct(ByVal custAcct As Integer, ByVal amount As Single)
  '</Snippet53>
  End Sub
  End Class

  ' New snippet to replace "VbVbcnProcedures#52,53" CREF (Procedure Overloading)
  '<Snippet73>
  Sub postName(ByVal custName As String, ByVal amount As Single)
      ' Insert code to access customer record by customer name.
  End Sub
  Sub postAcct(ByVal custAcct As Integer, ByVal amount As Single)
      ' Insert code to access customer record by account number.
  End Sub
  '</Snippet73>


  '****************************************************************************
  '<Snippet51>
  Function Factorial(n As Integer) As Integer
      If n <= 1 Then
          Return 1
      End If
      Return Factorial(n - 1) * n
  End Function
  '</Snippet51>


  '****************************************************************************
  Sub TestStudentScores()
    '<Snippet50>
    Call studentScores("George")
    '</Snippet50>

    '<Snippet49>
    Call studentScores("Anne", "10", "26", "32", "15", "22", "24", "16")
    Call studentScores("Mary", "High", "Low", "Average", "High")
    Dim JohnScores() As String = {"35", "Absent", "21", "30"}
    Call studentScores("John", JohnScores)
    '</Snippet49>
  End Sub


  '****************************************************************************
  '<Snippet48>
  Sub studentScores(ByVal name As String, ByVal ParamArray scores() As String)
      Debug.WriteLine("Scores for " & name & ":" & vbCrLf)
      ' Use UBound to determine largest subscript of the array.
      For i As Integer = 0 To UBound(scores, 1)
          Debug.WriteLine("Score " & i & ": " & scores(i))
      Next i
  End Sub
  '</Snippet48>


  '****************************************************************************
  Sub TestMsgBox2()
    '<Snippet47>
    MsgBox("Important message", MsgBoxStyle.Critical, "MsgBox Example")
    MsgBox("Just display this message.")
    MsgBox("Test message", , "Title bar text")
    MsgBox(Title:="Title bar text", Prompt:="Test message")
    '</Snippet47>
  End Sub


  '****************************************************************************
  '<Snippet46>
  Sub notify(ByVal company As String, Optional ByVal office As String = "QJZ")
      If office = "QJZ" Then
          Debug.WriteLine("office not supplied -- using Headquarters")
          office = "Headquarters"
      End If
      ' Insert code to notify headquarters or specified office.
  End Sub
  '</Snippet46>


  '****************************************************************************
  Sub TestStudentInfo()
    '<Snippet42>
    Call studentInfo("Mary", 19, #9/21/1981#)
    '</Snippet42>

    '<Snippet43>
    Call studentInfo("Mary", , #9/21/1981#)
    '</Snippet43>

    '<Snippet44>
    Call studentInfo(age:=19, birth:=#9/21/1981#, name:="Mary")
    '</Snippet44>

    '<Snippet45>
    Call studentInfo("Mary", birth:=#9/21/1981#)
    '</Snippet45>
  End Sub


  '****************************************************************************
  '<Snippet41>
  Sub studentInfo(ByVal name As String, 
         Optional ByVal age As Short = 0, 
         Optional ByVal birth As Date = #1/1/2000#)

    Debug.WriteLine("Name = " & name & 
                  "; age = " & CStr(age) & 
                  "; birth date = " & CStr(birth))
  End Sub
  '</Snippet41>


  '****************************************************************************
  Sub TestSetNewString()
    '<Snippet40>
    Dim str As String = "Cannot be replaced if passed ByVal"

    ' The following call passes str ByVal even though it is declared ByRef.
    Call setNewString((str))
    ' The parentheses around str protect it from change.
    MsgBox(str)

    ' The following call allows str to be passed ByRef as declared.
    Call setNewString(str)
    ' Variable str is not protected from change.
    MsgBox(str)
    '</Snippet40>
  End Sub


  '****************************************************************************
  '<Snippet39>
  Sub setNewString(ByRef inString As String)
      inString = "This is a new value for the inString argument."
      MsgBox(inString)
  End Sub
  '</Snippet39>


  '****************************************************************************
  Sub TestArrayParams()
    '<Snippet37>
    Dim n() As Long = {10, 20, 30, 40}
    Call increase(n)
    MsgBox("After increase(n): " & CStr(n(0)) & ", " & 
        CStr(n(1)) & ", " & CStr(n(2)) & ", " & CStr(n(3)))
    Call replace(n)
    MsgBox("After replace(n): " & CStr(n(0)) & ", " & 
        CStr(n(1)) & ", " & CStr(n(2)) & ", " & CStr(n(3)))
    '</Snippet37>


    Dim o As New WrapReplace
    Dim x() As Long = {10, 20, 30, 40}
    o.replace(x)
    MsgBox("After replace(x): " & CStr(x(0)) & ", " & 
        CStr(x(1)) & ", " & CStr(x(2)))
  End Sub


  '****************************************************************************
  '<Snippet35>
  Public Sub increase(ByVal a() As Long)
      For j As Integer = 0 To UBound(a)
          a(j) = a(j) + 1
      Next j
  End Sub
  '</Snippet35>


  '****************************************************************************
  '<Snippet36>
  '<Snippet64>
  Public Sub replace(ByRef a() As Long)
  '</Snippet64>
      Dim k() As Long = {100, 200, 300}
      a = k
      For j As Integer = 0 To UBound(a)
          a(j) = a(j) + 1
      Next j
  End Sub
  '</Snippet36>


  '****************************************************************************
  Class WrapReplace
    '<Snippet38>
    Public Sub replace(ByVal a() As Long)
        Dim k() As Long = {100, 200, 300}
        a = k
        For j As Integer = 0 To UBound(a)
            a(j) = a(j) + 1
        Next j
    End Sub
    '</Snippet38>
  End Class


  '****************************************************************************
  Sub TestMsgBox()
    '<Snippet34>
    Dim mbResult As MsgBoxResult
    Dim displayString As String = "Show this string to the user"
    mbResult = MsgBox(displayString, , "Put this in the title bar")
    '</Snippet34>
  End Sub

  '****************************************************************************
  '<Snippet33>
  Sub updateCustomer(ByRef c As customer, ByVal region As String, 
    Optional ByVal level As Integer = 0)
    ' Insert code to update a customer object.
  End Sub
  '</Snippet33>


  '****************************************************************************
  '<Snippet32>
  Function appointment(ByVal day As String, ByVal hour As Integer) As String
      ' Insert code to return any appointment for the given day and time.
      Return "appointment"
  End Function
  '</Snippet32>


  '****************************************************************************
  '<Snippet31>
  Public Sub setJobString(ByVal g As Integer)
      Dim title As String
      Dim jobTitle As System.Data.SqlTypes.SqlString
      Select Case g
          Case 1
              title = "President"
          Case 2
              title = "Vice President"
          Case 3
              title = "Director"
          Case 4
              title = "Manager"
          Case Else
              title = "Worker"
      End Select
      jobTitle = CType(title, SqlString)
      MsgBox("Group " & CStr(g) & " generates title """ &
            CType(jobTitle, String) & """")
  End Sub
  '</Snippet31>


  '****************************************************************************
  Sub TestTimeSpan()
    '<Snippet29>
    Dim firstSpan As New TimeSpan(3, 30, 0)
    Dim secondSpan As New TimeSpan(1, 30, 30)
    Dim combinedSpan As TimeSpan = firstSpan + secondSpan
    Dim s As String = firstSpan.ToString() & 
              " + " & secondSpan.ToString() & 
              " = " & combinedSpan.ToString()
    MsgBox(s)
    '</Snippet29>
  End Sub


  '****************************************************************************
  '<Snippet28>
  Public Sub consumeDigit()
      Dim d1 As New digit(4)
      Dim d2 As New digit(7)
      Dim d3 As digit = CType(CByte(3), digit)
      Dim s As String = "Initial 4 generates " & CStr(CType(d1, Byte)) &
            vbCrLf & "Initial 7 generates " & CStr(CType(d2, Byte)) &
            vbCrLf & "Converted 3 generates " & CStr(CType(d3, Byte))
      Try
          Dim d4 As digit
          d4 = CType(CType(d1, Byte) + CType(d2, Byte), digit)
      Catch e4 As System.Exception
          s &= vbCrLf & "4 + 7 generates " & """" & e4.Message & """"
      End Try
      Try
          Dim d5 As digit = CType(CByte(10), digit)
      Catch e5 As System.Exception
          s &= vbCrLf & "Initial 10 generates " & """" & e5.Message & """"
      End Try
      MsgBox(s)
  End Sub
  '</Snippet28>


  '****************************************************************************
  '<Snippet27>
  Public Structure digit
  Private dig As Byte
      Public Sub New(ByVal b As Byte)
          If (b < 0 OrElse b > 9) Then Throw New System.ArgumentException(
              "Argument outside range for Byte")
          Me.dig = b
      End Sub
      Public Shared Widening Operator CType(ByVal d As digit) As Byte
          Return d.dig
      End Operator
      Public Shared Narrowing Operator CType(ByVal b As Byte) As digit
          Return New digit(b)
      End Operator
  End Structure
  '</Snippet27>


  '****************************************************************************
  '<Snippet26>
  Public Sub consumeHeight()
      Dim p1 As New height(3, 10)
      Dim p2 As New height(4, 8)
      Dim p3 As height = p1 + p2
      Dim s As String = p1.ToString() & " + " & p2.ToString() &
            " = " & p3.ToString() & " (= 8' 6"" ?)"
      Dim p4 As New height(2, 14)
      s &= vbCrLf & "2' 14"" = " & p4.ToString() & " (= 3' 2"" ?)"
      Dim p5 As New height(4, 24)
      s &= vbCrLf & "4' 24"" = " & p5.ToString() & " (= 6' 0"" ?)"
      MsgBox(s)
  End Sub
  '</Snippet26>


  '****************************************************************************
  '<Snippet25>
  Public Shadows Structure height
      ' Need Shadows because System.Windows.Forms.Form also defines property Height.
      Private feet As Integer
      Private inches As Double
      Public Sub New(ByVal f As Integer, ByVal i As Double)
          Me.feet = f + (CInt(i) \ 12)
          Me.inches = i Mod 12.0
      End Sub
      Public Overloads Function ToString() As String
          Return Me.feet & "' " & Me.inches & """"
      End Function
      Public Shared Operator +(ByVal h1 As height, 
                               ByVal h2 As height) As height
          Return New height(h1.feet + h2.feet, h1.inches + h2.inches)
      End Operator
  End Structure
  '</Snippet25>


  '****************************************************************************
  Sub TestVeryLong()
    '<Snippet24>
    Dim v1, v2, v3 As veryLong
    v1.highOrder = 1
    v1.lowOrder = Long.MaxValue
    v2.highOrder = 0
    v2.lowOrder = 4
    v3 = v1 + v2
    '</Snippet24>
    MsgBox(v3.lowOrder)
    MsgBox(v3.highOrder)
  End Sub


  '****************************************************************************
  '<Snippet23>
  Public Structure veryLong
      Dim highOrder As Long
      Dim lowOrder As Long
      Public Shared Operator +(ByVal v As veryLong, 
                               ByVal w As veryLong) As veryLong
          Dim sum As New veryLong
          sum = v
          Try
              sum.lowOrder += w.lowOrder
          Catch ex As System.OverflowException
              sum.lowOrder -= (Long.MaxValue - w.lowOrder + 1)
              sum.highOrder += 1
          End Try
          sum.highOrder += w.highOrder
          Return sum
      End Operator
  End Structure
  '</Snippet23>


  '****************************************************************************
  Sub Test2()
    Dim x As New class1(3)
    '<Snippet19>
    x.myProperty(1) = "Hello"
    x.myProperty(2) = " "
    x.myProperty(3) = "World"
    '</Snippet19>

    '<Snippet20>
    MsgBox(x(1))
    '</Snippet20>
  End Sub


  '****************************************************************************
  Sub Test3()
    Dim x As String = "Hi"

    '<Snippet21>
    MsgBox(x)
    '</Snippet21>
  End Sub


  '****************************************************************************
  '<Snippet13>
  Sub Test()
      '<Snippet16>
      Dim x As New class1(3)
      '</Snippet16>
      '<Snippet14>
      x(1) = "Hello"
      x(2) = " "
      x(3) = "World"
      '</Snippet14>
      '<Snippet15>
      MsgBox(x(1) & x(2) & x(3))
      '</Snippet15>
  End Sub
  '</Snippet13>


  '****************************************************************************
  Class Step1
    '<Snippet18>
    Property myProperty() As String
    '</Snippet18>
      Get
        Return "hi"
      End Get
      Set(ByVal value As String)
      End Set
    End Property
  End Class


  '****************************************************************************
  '<Snippet12>
  Public Class class1
      Private myStrings() As String
      Sub New(ByVal size As Integer)
          ReDim myStrings(size)
      End Sub
      '<Snippet17>
      Default Property myProperty(ByVal index As Integer) As String
      '</Snippet17>
          Get
              ' The Get property procedure is called when the value
              ' of the property is retrieved.
              Return myStrings(index)
          End Get
          Set(ByVal Value As String)
              ' The Set property procedure is called when the value
              ' of the property is modified.
              ' The value to be assigned is passed in the argument 
              ' to Set.
              myStrings(index) = Value
          End Set
      End Property
  End Class
  '</Snippet12>


  '****************************************************************************
  Sub testTimeOfDay()
    '<Snippet11>
    ' The following statement calls the Set procedure of the Visual Basic TimeOfDay property.
    TimeOfDay = #12:00:00 PM#
    '</Snippet11>
    MsgBox(TimeOfDay)
  End Sub

  '****************************************************************************
  '<Snippet10>
  Public Class employee
      Private salaryValue As Double
      Protected Property salary() As Double
          Get
              Return salaryValue
          End Get
          Private Set(ByVal value As Double)
              salaryValue = value
          End Set
      End Property
  End Class
  '</Snippet10>


  '****************************************************************************
  Sub testproperty()
    '<Snippet9>
    fullName = "MyFirstName MyLastName"
    MsgBox(fullName)
    '</Snippet9>
  End Sub


  '****************************************************************************
  '<Snippet8>
  Dim firstName, lastName As String
  Property fullName() As String
      Get
        If lastName = "" Then
            Return firstName
        Else
            Return firstName & " " & lastName
        End If

      End Get
      Set(ByVal Value As String)
          Dim space As Integer = Value.IndexOf(" ")
          If space < 0 Then
              firstName = Value
              lastName = ""
          Else
              firstName = Value.Substring(0, space)
              lastName = Value.Substring(space + 1)
          End If
      End Set
  End Property
  '</Snippet8>


  '****************************************************************************
  Sub testreturn()
    '<Snippet7>
    MsgBox("Value of PATH is " & Environ("PATH"))
    Dim currentPath As String = Environ("PATH")
    '</Snippet7>
  End Sub

  '****************************************************************************
  Function TestHyp() As Double
    '<Snippet6>
    Dim testLength, testHypotenuse As Double
    testHypotenuse = Hypotenuse(testLength, 10.7)
    '</Snippet6>

    Return testHypotenuse
  End Function

    '****************************************************************************
    Sub testTellOperator()
        '<Snippet3>
        tellOperator("file update")
        '</Snippet3>
    End Sub


    '****************************************************************************
    '<Snippet2>
    Sub tellOperator(ByVal task As String)
        Dim stamp As Date
        stamp = TimeOfDay()
        MsgBox("Starting " & task & " at " & CStr(stamp))
    End Sub
    '</Snippet2>


    '****************************************************************************
    '<Snippet1>
    Function Hypotenuse(side1 As Double, side2 As Double) As Double
        Return Math.Sqrt((side1 ^ 2) + (side2 ^ 2))
    End Function
    '</Snippet1>


    ' Class CancelEventArgs ' for Snippet5 -- removed to try different approach
    ' End Class

    ' Event Closing(ByVal sender As Object, ByVal e As CancelEventArgs) ' for Snippet5 -- removed to try different approach

    Class customer
    End Class

End Class
