'********************************************************************
'<Snippet47>
' Force explicit variable declaration.
Option Explicit On
'</Snippet47>


'********************************************************************
'<Snippet16>
' Add an Imports statement at the top of the class, structure, or
' module that uses the DllImport attribute.
Imports System.Runtime.InteropServices
'</Snippet16>


'********************************************************************
'<Snippet35>
' Place Imports statements at the top of your program.
Imports str = Microsoft.VisualBasic.Strings
'</Snippet35>


'********************************************************************
Imports System.Diagnostics
Imports System.Drawing.Font
Imports System.Drawing.FontStyle
Imports System.Windows.Forms
Imports System.IO


'********************************************************************
'<Snippet41>
Namespace n1.n2
    Class a
        ' Insert class definition.
    End Class
End Namespace
'</Snippet41>


Namespace Wrap
    '********************************************************************
    '<Snippet43>
    Namespace n1
        Namespace n2
            Class a
                ' Insert class definition.
            End Class
        End Namespace
    End Namespace
    '</Snippet43>
End Namespace


'********************************************************************
'<Snippet62>
Class BankAccount
    Shared interestRate As Decimal
    Private accountBalance As Decimal
    Public holdOnAccount As Boolean = False

    Public ReadOnly Property Balance() As Decimal
        Get
            Return accountBalance
        End Get
    End Property

    Public Sub PostInterest()
        accountBalance = accountBalance * (1 + interestRate)
    End Sub

    Public Sub PostDeposit(ByVal amountIn As Decimal)
        accountBalance = accountBalance + amountIn
    End Sub

    Public Sub PostWithdrawal(ByVal amountOut As Decimal)
        accountBalance = accountBalance - amountOut
    End Sub
End Class
'</Snippet62>


'********************************************************************
'<Snippet69>
Public Module thisModule
    Sub Main()
        Dim userName As String = InputBox("What is your name?")
        MsgBox("User name is " & userName)
    End Sub
    ' Insert variable, property, procedure, and event declarations.
End Module
'</Snippet69>


'*************************************************************************
Public Class widget
    Sub SpinClockwise()
    End Sub
    Sub SpinCounterClockwise()
    End Sub
End Class


'*************************************************************************
Public Class Class1

    ' Option Compare Statement
    ' 54e8eeeb-3b0d-4fb9-acce-fbfbd5975f6e
    Private Sub OptionCompareEx()
        '<Snippet45>
        ' Option Compare Binary

        Console.WriteLine("A" < "a")
        ' Output: True
        '</Snippet45>

        '<Snippet46>
        ' Option Compare Text

        Console.WriteLine("A" = "a")
        ' Output: True
        '</Snippet46>
    End Sub

    ' Try...Catch...Finally Statement (Visual Basic)
    ' d6488026-ccb3-42b8-a810-0d97b9d6472b
    '<Snippet94>
    Private Sub TextFileExample(ByVal filePath As String)

        ' Verify that the file exists.
        If System.IO.File.Exists(filePath) = False Then
            Console.Write("File Not Found: " & filePath)
        Else
            ' Open the text file and display its contents.
            Dim sr As System.IO.StreamReader =
                System.IO.File.OpenText(filePath)

            Console.Write(sr.ReadToEnd)

            sr.Close()
        End If
    End Sub
    '</Snippet94>

    ' Try...Catch...Finally Statement (Visual Basic)
    ' d6488026-ccb3-42b8-a810-0d97b9d6472b
    '<Snippet93>
    Private Sub InnerExceptionExample()
        Try
            Try
                ' Set a reference to a StringBuilder.
                ' The exception below does not occur if the commented
                ' out statement is used instead.
                Dim sb As System.Text.StringBuilder
                'Dim sb As New System.Text.StringBuilder

                ' Cause a NullReferenceException.
                sb.Append("text")
            Catch ex As Exception
                ' Throw a new exception that has the inner exception
                ' set to the original exception.
                Throw New ApplicationException("Something happened :(", ex)
            End Try
        Catch ex2 As Exception
            ' Show the exception.
            Console.WriteLine("Exception: " & ex2.Message)
            Console.WriteLine(ex2.StackTrace)

            ' Show the inner exception, if one is present.
            If ex2.InnerException IsNot Nothing Then
                Console.WriteLine("Inner Exception: " & ex2.InnerException.Message)
                Console.WriteLine(ex2.StackTrace)
            End If
        End Try
    End Sub
    '</Snippet93>

    ' Try...Catch...Finally Statement (Visual Basic)
    ' d6488026-ccb3-42b8-a810-0d97b9d6472b
    '<Snippet92>
    Private Sub WhenExample()
        Dim i As Integer = 5

        Try
            Throw New ArgumentException()
        Catch e As OverflowException When i = 5
            Console.WriteLine("First handler")
        Catch e As ArgumentException When i = 4
            Console.WriteLine("Second handler")
        Catch When i = 5
            Console.WriteLine("Third handler")
        End Try
    End Sub
    ' Output: Third handler
    '</Snippet92>


    ' Try...Catch...Finally Statement (Visual Basic)
    ' d6488026-ccb3-42b8-a810-0d97b9d6472b
    '<Snippet91>
    Public Sub RunSample()
        Try
            CreateException()
        Catch ex As System.IO.IOException
            ' Code that reacts to IOException.
        Catch ex As NullReferenceException
            Console.WriteLine("NullReferenceException: " & ex.Message)
            Console.WriteLine("Stack Trace: " & vbCrLf & ex.StackTrace)
        Catch ex As Exception
            ' Code that reacts to any other exception.
        End Try
    End Sub

    Private Sub CreateException()
        ' This code throws a NullReferenceException.
        Dim obj = Nothing
        Dim prop = obj.Name

        ' This code also throws a NullReferenceException.
        'Throw New NullReferenceException("Something happened.")
    End Sub
    '</Snippet91>

    Sub Test()
        '<Snippet87>
        Const naturalLogBase As Object = CDec(2.7182818284)
        MsgBox("Run-time type of constant naturalLogBase is " &
            naturalLogBase.GetType.ToString())
        '</Snippet87>
    End Sub


    '********************************************************************
    ' Try...Catch...Finally Statement (Visual Basic)
    ' d6488026-ccb3-42b8-a810-0d97b9d6472b
    '<Snippet86>
    Public Sub TryExample()
        ' Declare variables.
        Dim x As Integer = 5
        Dim y As Integer = 0

        ' Set up structured error handling.
        Try
            ' Cause a "Divide by Zero" exception.
            x = x \ y

            ' This statement does not execute because program
            ' control passes to the Catch block when the
            ' exception occurs.
            Console.WriteLine("end of Try block")
        Catch ex As Exception
            ' Show the exception's message.
            Console.WriteLine(ex.Message)

            ' Show the stack trace, which is a list of methods
            ' that are currently executing.
            Console.WriteLine("Stack Trace: " & vbCrLf & ex.StackTrace)
        Finally
            ' This line executes whether or not the exception occurs.
            Console.WriteLine("in Finally block")
        End Try
    End Sub
    '</Snippet86>

    '********************************************************************
    Private Sub StartProcess()

        '<Snippet85>
        Try
            Process.Start("http://www.microsoft.com")
        Catch ex As Exception
            Console.WriteLine("Can't load Web page" & vbCrLf & ex.Message)
        End Try
        '</Snippet85>
    End Sub

    '********************************************************************
    Sub TestThrow()
        '<Snippet84>
        ' Throws a new exception.
        Throw New System.Exception("An exception has occurred.")
        '</Snippet84>
    End Sub

    '********************************************************************
    '<Snippet83>
    Public Sub StartWidget(ByVal aWidget As widget,
        ByVal clockwise As Boolean, ByVal revolutions As Integer)
        Dim counter As Integer
        If clockwise = True Then
            For counter = 1 To revolutions
                aWidget.SpinClockwise()
            Next counter
        Else
            For counter = 1 To revolutions
                aWidget.SpinCounterClockwise()
            Next counter
        End If
    End Sub
    '</Snippet83>

    '********************************************************************
    Function FindResult(ByVal i As Integer) As Integer
        Return i
    End Function

    '********************************************************************
    '<Snippet82>
    Dim f As New FileInfo("filename")
    '</Snippet82>

    '********************************************************************
    '<Snippet81>
    Dim m As Integer = 45
    ' The preceding declaration creates m and assigns the value 45 to it.
    '</Snippet81>

    '********************************************************************
    '<Snippet80>
    Public Sub ApplyFormat()
        Const limit As Integer = 33
        Dim thisWidget As New widget
        ' Insert code to implement the procedure.
    End Sub
    '</Snippet80>

    '********************************************************************
    Sub TestAssignments()
        Dim v, n As Integer
        Dim x, y, z As Integer

        '<Snippet79>
        Dim q As String = "Sample "
        q &= "String"
        ' q now contains "Sample String".
        '</Snippet79>

        '<Snippet78>
        n = n + 1
        '</Snippet78>

        '<Snippet77>
        n += 1
        '</Snippet77>

        '<Snippet76>
        Dim r, s, t As Boolean
        r = True
        s = 45 > 1003
        t = 45 > 1003 Or 45 > 17
        ' The preceding statements assign False to s and True to t.
        '</Snippet76>

        '<Snippet75>
        Dim a, b As String
        a = "String variable assignment"
        b = "Con" & "cat" & "enation"
        ' The preceding statement assigns the value "Concatenation" to b.
        '</Snippet75>

        '<Snippet74>
        x = y + z + FindResult(3)
        '</Snippet74>

        '<Snippet73>
        v = 42
        '</Snippet73>
    End Sub

    '********************************************************************
    '<Snippet71>
    Public Sub DemoBox()
        Dim nameVar As String
        nameVar = "John"
        MsgBox("Hello " & nameVar _
            & ". How are you?")
    End Sub
    '</Snippet71>

    '********************************************************************
    Sub TestStatOver()
        '<Snippet70>
        Dim sampleString As String = "Hello World" : MsgBox(sampleString)
        '</Snippet70>
    End Sub

    '********************************************************************
    '<Snippet63>
    ' The following statement declares and initializes a Long variable.
    Dim startingAmount As Long = 500
    '</Snippet63>

    '********************************************************************
    '<Snippet65>
    ' The following statement declares a variable that can only be
    ' accessed by code in the same class, structure, or module.
    Private homeTelephone As String = ""
    '</Snippet65>

    '********************************************************************
    Sub TestDim()
        '<Snippet66>
        ' The following statement declares a local variable that always retains
        ' its value, even after its procedure returns to the calling code.
        Static totalSales As Double
        '</Snippet66>

        totalSales = 50

        '<Snippet67>
        ' The following statement declares a variable that refers to an array.
        Dim highTemperature(31) As Integer
        '</Snippet67>

        '<Snippet68>
        ' The following statement declares and initializes an array variable
        ' that holds 4 Boolean check values.
        Dim checkValues() As Boolean = {False, False, True, False}
        '</Snippet68>
    End Sub

    '********************************************************************
    Public Sub TestWhile()
        '<Snippet60>
        Dim counter As Integer = 0
        While counter < 20
            counter += 1
            ' Insert code to use current value of counter.
        End While
        MsgBox("While loop ran " & CStr(counter) & " times")
        '</Snippet60>
    End Sub

    ' Using Statement (Visual Basic)
    ' 665d1580-dd54-4e96-a9a9-6be2a68948f1

    '<Snippet50>
    Private Sub WriteFile()
        Using writer As System.IO.TextWriter = System.IO.File.CreateText("log.txt")
            writer.WriteLine("This is line one.")
            writer.WriteLine("This is line two.")
        End Using
    End Sub

    Private Sub ReadFile()
        Using reader As System.IO.TextReader = System.IO.File.OpenText("log.txt")
            Dim line As String

            line = reader.ReadLine()
            Do Until line Is Nothing
                Console.WriteLine(line)
                line = reader.ReadLine()
            Loop
        End Using
    End Sub
    '</Snippet50>

    '********************************************************************
    '<Snippet58>
    Sub ComputeArea(ByVal length As Double, ByVal width As Double)
        ' Declare local variable.
        Dim area As Double
        If length = 0 Or width = 0 Then
            ' If either argument = 0 then exit Sub immediately.
            Exit Sub
        End If
        ' Calculate area of rectangle.
        area = length * width
        ' Print area to Immediate window.
        Debug.WriteLine(area)
    End Sub
    '</Snippet58>

    '********************************************************************
    '<Snippet57>
    Public Structure employee
        ' Public members, accessible from throughout declaration region.
        Public firstName As String
        Public middleName As String
        Public lastName As String
        ' Friend members, accessible from anywhere within the same assembly.
        Friend employeeNumber As Integer
        Friend workPhone As Long
        ' Private members, accessible only from within the structure itself.
        Private homePhone As Long
        Private level As Integer
        Private salary As Double
        Private bonus As Double
        ' Procedure member, which can access structure's private members.
        Friend Sub CalculateBonus(ByVal rate As Single)
            bonus = salary * CDbl(rate)
        End Sub
        ' Property member to return employee's eligibility.
        Friend ReadOnly Property Eligible() As Boolean
            Get
                Return level >= 25
            End Get
        End Property
        ' Event member, raised when business phone number has changed.
        Public Event ChangedWorkPhone(ByVal newPhone As Long)
    End Structure
    '</Snippet57>

    '********************************************************************
    Sub TestStop()
        '<Snippet56>
        Dim i As Integer
        For i = 1 To 10
            Debug.WriteLine(i)
            ' Stop during each iteration and wait for user to resume.
            Stop
        Next i
        '</Snippet56>
    End Sub

    '********************************************************************
    Class Wrap
        '<Snippet55>
        Class propClass
            Private propVal As Integer
            Property Prop1() As Integer
                Get
                    Return propVal
                End Get
                Set(ByVal value As Integer)
                    propVal = value
                End Set
            End Property
        End Class
        '</Snippet55>
    End Class


    '********************************************************************
    Sub TestCase()
        '<Snippet54>
        Dim number As Integer = 8
        Select Case number
            Case 1 To 5
                Debug.WriteLine("Between 1 and 5, inclusive")
                ' The following is the only Case clause that evaluates to True.
            Case 6, 7, 8
                Debug.WriteLine("Between 6 and 8, inclusive")
            Case 9 To 10
                Debug.WriteLine("Equal to 9 or 10")
            Case Else
                Debug.WriteLine("Not between 1 and 10, inclusive")
        End Select
        '</Snippet54>
    End Sub


    '********************************************************************
    '<Snippet53>
    Public Function GetAgePhrase(ByVal age As Integer) As String
        If age > 60 Then Return "Senior"
        If age > 40 Then Return "Middle-aged"
        If age > 20 Then Return "Adult"
        If age > 12 Then Return "Teen-aged"
        If age > 4 Then Return "School-aged"
        If age > 1 Then Return "Toddler"
        Return "Infant"
    End Function
    '</Snippet53>


    '********************************************************************
    Sub TestReDim()
        '<Snippet52>
        Dim intArray(10, 10, 10) As Integer
        ReDim Preserve intArray(10, 10, 20)
        ReDim Preserve intArray(10, 10, 15)
        ReDim intArray(10, 10, 10)
        '</Snippet52>
    End Sub


    '********************************************************************
    '<Snippet51>
    Class Class1
        ' Define a local variable to store the property value.
        Private propertyValue As String
        ' Define the property.
        Public Property Prop1() As String
            Get
                ' The Get property procedure is called when the value
                ' of a property is retrieved.
                Return propertyValue
            End Get
            Set(ByVal value As String)
                ' The Set property procedure is called when the value
                ' of a property is modified.  The value to be assigned
                ' is passed in the argument to Set.
                propertyValue = value
            End Set
        End Property
    End Class
    '</Snippet51>


    '********************************************************************
    '<Snippet44>
    Public Structure abc
        Dim d As Date
        Public Shared Operator And(ByVal x As abc, ByVal y As abc) As abc
            Dim r As New abc
            ' Insert code to calculate And of x and y.
            Return r
        End Operator
        Public Shared Operator Or(ByVal x As abc, ByVal y As abc) As abc
            Dim r As New abc
            ' Insert code to calculate Or of x and y.
            Return r
        End Operator
        Public Shared Operator IsFalse(ByVal z As abc) As Boolean
            Dim b As Boolean
            ' Insert code to calculate IsFalse of z.
            Return b
        End Operator
        Public Shared Operator IsTrue(ByVal z As abc) As Boolean
            Dim b As Boolean
            ' Insert code to calculate IsTrue of z.
            Return b
        End Operator
    End Structure
    '</Snippet44>


    '********************************************************************
    '<Snippet42>
    Dim instance As New n1.n2.a
    '</Snippet42>


    '********************************************************************
    '<Snippet40>
    Public Interface thisInterface
        Property ThisProp(ByVal thisStr As String) As Char
        Function ThisFunc(ByVal thisInt As Integer) As Integer
    End Interface
    '</Snippet40>


    '********************************************************************
    '<Snippet39>
    Public Interface IDemo
        Sub DoSomething()
    End Interface
    Public Class implementIDemo
        Implements IDemo
        Private Sub DoSomething() Implements IDemo.DoSomething
        End Sub
    End Class
    Dim varAsInterface As IDemo = New implementIDemo()
    Dim varAsClass As implementIDemo = New implementIDemo()
    '</Snippet39>


    '********************************************************************
    Class wrapInterface
        '<Snippet38>
        Public Interface thisInterface
            Inherits IComparable, IDisposable, IFormattable
            ' Add new property, procedure, and event definitions.
        End Interface
        '</Snippet38>
    End Class


    '********************************************************************
    Public Class anotherClass
    End Class


    '********************************************************************
    '<Snippet37>
    Public Class thisClass
        Inherits anotherClass
        ' Add code to override, overload, or extend members
        ' inherited from the base class.
        ' Add new variable, property, procedure, and event declarations.
    End Class
    '</Snippet37>


    '********************************************************************
    '<Snippet36>
    Class testClass1
        Sub ShowHello()
            ' Display only the word "Hello"
            MsgBox(str.Left("Hello World", 5))
        End Sub
    End Class
    '</Snippet36>


    '********************************************************************
    '<Snippet34>
    Public Sub TestImplements()
        ' This procedure tests the interface implementation by
        ' creating an instance of the class that implements ICustomerInfo.
        Dim cust As ICustomerInfo = New customerInfo()
        ' Associate an event handler with the event that is raised by
        ' the cust object.
        AddHandler cust.UpdateComplete, AddressOf HandleUpdateComplete
        ' Set the CustomerName Property
        cust.CustomerName = "Fred"
        ' Retrieve and display the CustomerName property.
        MsgBox("Customer name is: " & cust.CustomerName)
        ' Call the UpdateCustomerStatus procedure, which raises the
        ' UpdateComplete event.
        cust.UpdateCustomerStatus()
    End Sub

    Sub HandleUpdateComplete()
        ' This is the event handler for the UpdateComplete event.
        MsgBox("Update is complete.")
    End Sub
    '</Snippet34>


    '********************************************************************
    '<Snippet33>
    Public Interface ICustomerInfo
        Event UpdateComplete()
        Property CustomerName() As String
        Sub UpdateCustomerStatus()
    End Interface

    Public Class customerInfo
        Implements ICustomerInfo
        ' Storage for the property value.
        Private customerNameValue As String
        Public Event UpdateComplete() Implements ICustomerInfo.UpdateComplete
        Public Property CustomerName() As String _
            Implements ICustomerInfo.CustomerName
            Get
                Return customerNameValue
            End Get
            Set(ByVal value As String)
                ' The value parameter is passed to the Set procedure
                ' when the contents of this property are modified.
                customerNameValue = value
            End Set
        End Property

        Public Sub UpdateCustomerStatus() _
            Implements ICustomerInfo.UpdateCustomerStatus
            ' Add code here to update the status of this account.
            ' Raise an event to indicate that this procedure is done.
            RaiseEvent UpdateComplete()
        End Sub
    End Class
    '</Snippet33>


    '********************************************************************
    Sub TestIf()
        '<Snippet32>
        Dim number, digits As Integer
        Dim myString As String
        number = 53
        If number < 10 Then
            digits = 1
        ElseIf number < 100 Then
            digits = 2
        Else
            digits = 3
        End If
        If digits = 1 Then myString = "One" Else myString = "More than one"
        '</Snippet32>
    End Sub


    '********************************************************************
    '<Snippet31>
    Sub GoToStatementDemo()
        Dim number As Integer = 1
        Dim sampleString As String
        ' Evaluate number and branch to appropriate label.
        If number = 1 Then GoTo Line1 Else GoTo Line2
Line1:
        sampleString = "Number equals 1"
        GoTo LastLine
Line2:
        ' The following statement never gets executed because number = 1.
        sampleString = "Number equals 2"
LastLine:
        ' Write "Number equals 1" in the Debug window.
        Debug.WriteLine(sampleString)
    End Sub
    '</Snippet31>


    '********************************************************************
    '<Snippet30>
    Class propClass
        ' Define a private local variable to store the property value.
        Private currentTime As String
        ' Define the read-only property.
        Public ReadOnly Property DateAndTime() As String
            Get
                ' The Get procedure is called automatically when the
                ' value of the property is retrieved.
                currentTime = CStr(Now)
                ' Return the date and time As a string.
                Return currentTime
            End Get
        End Property
    End Class
    '</Snippet30>


    '********************************************************************
    '<Snippet27>
    Private quoteValue As String = "No quote assigned yet."
    '</Snippet27>


    '********************************************************************
    '<Snippet28>
    ReadOnly Property QuoteForTheDay() As String
        Get
            QuoteForTheDay = quoteValue
            Exit Property
        End Get
    End Property
    '</Snippet28>


    '********************************************************************
    Class WrapQuoteForTheDay
        Private quoteValue As String = "No quote assigned yet."

        '<Snippet29>
        ReadOnly Property QuoteForTheDay() As String
            Get
                Return quoteValue
            End Get
        End Property
        '</Snippet29>
    End Class




    '********************************************************************
    '<Snippet25>
    Public Function CalcSum(ByVal ParamArray args() As Double) As Double
        CalcSum = 0
        If args.Length <= 0 Then Exit Function
        For i As Integer = 0 To UBound(args, 1)
            CalcSum += args(i)
        Next i
    End Function
    '</Snippet25>


    '********************************************************************
    Class WrapFunction
        ' Used in "Function Statement (Visual Basic)" and "Exit Statement (Visual Basic)"
        '<Snippet24>
        Function MyFunction(ByVal j As Integer) As Double
            Return 3.87 * j
        End Function
        '</Snippet24>
    End Class


    '********************************************************************
    ' Used in "Function Statement (Visual Basic)" and "Exit Statement (Visual Basic)"
    '<Snippet23>
    Function MyFunction(ByVal j As Integer) As Double
        MyFunction = 3.87 * j
        Exit Function
    End Function
    '</Snippet23>


    '********************************************************************
    Sub TestFor()
        '<Snippet22>
        Dim words, digit As Integer
        Dim thisString As String = ""
        For words = 10 To 1 Step -1
            For digit = 0 To 9
                thisString &= CStr(digit)
            Next digit
            thisString &= " "
        Next words
        '</Snippet22>
    End Sub


    '********************************************************************
    Sub TestForEach()
        '<Snippet21>
        Dim found As Boolean = False
        Dim thisCollection As New Collection
        For Each thisObject As String In thisCollection
            If thisObject = "Hello" Then
                found = True
                Exit For
            End If
        Next thisObject
        '</Snippet21>

        '<Snippet88>
        Dim m As Long = 987
        ' Does not compile.
        'Dim n As Integer = m
        '</Snippet88>


    End Sub


    '********************************************************************
    '<Snippet20>
    Sub ExitStatementDemo()
        Dim demoNum As Single
        ' Set up an infinite loop.
        Do
            For i As Integer = 1 To 10000000
                demoNum = Int(Rnd() * 100)
                Select Case demoNum
                    Case 7 : Exit For
                    Case 29 : Exit Do
                    Case 54 : Exit Sub
                End Select
            Next i
        Loop
    End Sub
    '</Snippet20>


    '********************************************************************
    Sub TestErase()
        '<Snippet19>
        Dim threeDimArray(9, 9, 9), twoDimArray(9, 9) As Integer
        Erase threeDimArray, twoDimArray
        ReDim threeDimArray(4, 4, 9)
        '</Snippet19>
    End Sub


    '********************************************************************
    '<Snippet18>
    Sub DoExample()
        Dim check As Boolean = True
        Dim counter As Integer = 0
        Do
            Do While counter < 20
                counter += 1
                If counter = 10 Then
                    check = False
                    Exit Do
                End If
            Loop
        Loop Until check = False
    End Sub
    '</Snippet18>


    '********************************************************************
    '<Snippet17>
    Sub ExitDoExample()
        Dim counter As Integer = 0
        Dim number As Integer = 8
        Do Until number = 10
            If number <= 0 Then Exit Do
            number -= 1
            counter += 1
        Loop
        MsgBox("The loop ran " & counter & " times.")
    End Sub
    '</Snippet17>


    '********************************************************************
    '<Snippet15>
    Declare Function GetUserName Lib "advapi32.dll" Alias "GetUserNameA" (
        ByVal lpBuffer As String, ByRef nSize As Integer) As Integer
    Sub GetUser()
        Dim buffer As String = New String(CChar(" "), 25)
        Dim retVal As Integer = GetUserName(buffer, 25)
        Dim userName As String = Strings.Left(buffer, InStr(buffer, Chr(0)) - 1)
        MsgBox(userName)
    End Sub
    '</Snippet15>


    '********************************************************************
    Sub TestContinue()
        '<Snippet14>
        Dim row, col As Integer
        Dim lastrow As Integer = 6
        Dim lastcol As Integer = 10
        Dim a(,) As Double = New Double(lastrow, lastcol) {}
        Dim b(7) As Double
        row = -1
        While row < lastrow
            row += 1
            col = -1
            While col < lastcol
                col += 1
                a(row, col) = 0
                For i As Integer = 0 To b.GetUpperBound(0)
                    If b(i) = col Then
                        Continue While
                    Else
                        a(row, col) += (row + b(i)) / (col - b(i))
                    End If
                Next i
            End While
        End While
        '</Snippet14>
    End Sub


    '********************************************************************
    '<Snippet13>
    ' The following statements declare constants.
    Const maximum As Long = 459
    Public Const helpString As String = "HELP"
    Private Const startValue As Integer = 5
    '</Snippet13>


    '*************************************************************************
    Public Sub CallStatement()
        '<Snippet9>
        ' (1) Call a Sub procedure.
        Call PrintToDebugWindow("Hello World")
        '</Snippet9>

        '<Snippet11>
        ' (2) Call a Visual Basic run-time function (Shell), discard the return value.
        Call Shell("C:\WINNT\system32\calc.exe", AppWinStyle.NormalFocus)
        ' The preceding path is for Windows 2000;
        ' The Windows XP path is C:\Windows\system32\calc.exe.
        '</Snippet11>
    End Sub


    '********************************************************************
    '<Snippet10>

    ' The above statement passes control to the following Sub procedure.
    Sub PrintToDebugWindow(ByVal anyString As String)
        Debug.WriteLine(anyString)
    End Sub
    '</Snippet10>


    '********************************************************************
    '<Snippet12>
    ' (3) Call a Microsoft Windows DLL procedure. The Declare statement
    ' must be Private in a class, not in a module.
    Private Declare Sub MessageBeep Lib "User32" (ByVal N As Integer)
    Sub CallBeepDll()
        Call MessageBeep(-1)
    End Sub
    '</Snippet12>

    ' Call Statement (Visual Basic)
    '<Snippet97>
    Sub TestCall()
        Call (Sub() Console.Write("Hello"))()

        Call New TheClass().ShowText()
    End Sub

    Class TheClass
        Public Sub ShowText()
            Console.Write(" World")
        End Sub
    End Class
    '</Snippet97>


    '*************************************************************************
    Private Shared Sub Labels()
        '<Snippet7>
Jump:   FileOpen(1, "MYFILE", OpenMode.Input)
        '</Snippet7>

        '<Snippet8>
120:    FileClose(1)
        '</Snippet8>
    End Sub

    ' added 6/20/2005 to get around bogus ellipsis (VSW#523299)
    Private Shared Sub LabelsFused()
        '<Snippet708>
Jump:   FileOpen(1, "testFile", OpenMode.Input)
        ' ...
120:    FileClose(1)
        '</Snippet708>
    End Sub


    '****************************************************************************
    Public Shared Function Foo() As Integer

        '<Snippet6>
        Dim demoStr1, demoStr2 As String
        demoStr1 = "Hello" REM Comment after a statement using REM.
        demoStr2 = "Goodbye" ' Comment after a statement using the ' character.
        REM This entire line is a comment.
        ' This entire line is also a comment.
        '</Snippet6>

        Dim x, i As Integer
        Dim a() As Integer = {1}
        Dim b() As Integer = {2}
        Dim statusMessage As String = "hello"

        '<Snippet72>
        ' This is a comment on a separate code line.
        REM This is another comment on a separate code line.
        x += a(i) * b(i) ' Add this amount to total.
        MsgBox(statusMessage) REM Inform operator of status.
        '</Snippet72>

        Return 0
    End Function

    '****************************************************************************
    '<Snippet3>
    Public Class dictionary(Of entryType, keyType As {IComparable, IFormattable, New})
        Public Sub add(ByVal et As entryType, ByVal kt As keyType)
            Dim dk As keyType
            If kt.CompareTo(dk) = 0 Then
            End If
        End Sub
    End Class
    '</Snippet3>


    '****************************************************************************
    '<Snippet4>
    Dim dictInt As New dictionary(Of String, Integer)
    '</Snippet4>


    '****************************************************************************
    '<Snippet5>
    Public Class dictionary
        Public Sub Add(ByVal et As String, ByVal kt As Integer)
            Dim dk As Integer
            If kt.CompareTo(dk) = 0 Then
            End If
        End Sub
    End Class
    '</Snippet5>


    '****************************************************************************
    '<Snippet2>
    Public Function HowMany(ByVal ch As Char, ByVal st As String) As Integer
    End Function
    Dim howManyA As Integer = HowMany("a"c, "How many a's in this string?")
    '</Snippet2>


    '****************************************************************************
    '<Snippet1>
    <DllImportAttribute("kernel32.dll", EntryPoint:="MoveFileW",
        SetLastError:=True, CharSet:=CharSet.Unicode,
        ExactSpelling:=True,
        CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function MoveFile(ByVal src As String,
      ByVal dst As String) As Boolean
        ' This function copies a file from the path src to the path dst.
        ' Leave this function empty. The DLLImport attribute forces calls
        ' to MoveFile to be forwarded to MoveFileW in KERNEL32.DLL.
    End Function
    '</Snippet1>

End Class
'********************************************************************
'<Snippet26>
Module Module1

    Sub Main()
        ' In the following function call, CalcSum's local variables
        ' are assigned the following values: args(0) = 4, args(1) = 3,
        ' and so on. The displayed sum is 10.
        Dim returnedValue As Double = CalcSum(4, 3, 2, 1)
        Console.WriteLine("Sum: " & returnedValue)
        ' Parameter args accepts zero or more arguments. The sum
        ' displayed by the following statements is 0.
        returnedValue = CalcSum()
        Console.WriteLine("Sum: " & returnedValue)
    End Sub

    Public Function CalcSum(ByVal ParamArray args() As Double) As Double
        CalcSum = 0
        If args.Length <= 0 Then Exit Function
        For i As Integer = 0 To UBound(args, 1)
            CalcSum += args(i)
        Next i
    End Function

End Module
'</Snippet26>
