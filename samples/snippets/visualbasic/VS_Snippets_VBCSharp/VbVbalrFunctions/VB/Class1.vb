'<Snippet99>
' Imports statements must be at the top of a module.
Imports Microsoft.VisualBasic.CallType
'</Snippet99>

Public Class Class1


    '****************************************************************************
    Shared Function FunctionTest() As Long
        '<Snippet60>
        ' The following statements set datTim1 to a Thursday
        ' and datTim2 to the following Tuesday.
        Dim datTim1 As Date = #1/4/2001#
        Dim datTim2 As Date = #1/9/2001#
        ' Assume Sunday is specified as first day of the week.
        Dim wD As Long = DateDiff(DateInterval.Weekday, datTim1, datTim2)
        Dim wY As Long = DateDiff(DateInterval.WeekOfYear, datTim1, datTim2)
        '</Snippet60>

        'Dim x As Long
        'For i As Long = 1 To 1000000
        '  x = i * i
        'Next

        '<Snippet61>
        Dim startTime As Date = Now
        ' Run the process that is to be timed.
        Dim runLength As Global.System.TimeSpan = Now.Subtract(startTime)
        Dim millisecs As Double = runLength.TotalMilliseconds
        '</Snippet61>

        Return millisecs
        'Return wD
        'Return wY
    End Function


    '****************************************************************************
    Shared Function FunctionYear() As Integer
        '<Snippet59>
        Dim thisDate As Date
        Dim thisYear As Integer
        thisDate = #2/12/1969#
        thisYear = Year(thisDate)
        ' thisYear now contains 1969.
        '</Snippet59>

        Return thisYear
    End Function


    '****************************************************************************
    Shared Function FunctionWeekdayName() As String
        '<Snippet58>
        Dim oldDate As Date
        Dim oldWeekDayName As String
        oldDate = #2/12/1969#
        oldWeekDayName = WeekdayName(Weekday(oldDate))
        ' oldWeekDayName now contains "Wednesday".
        '</Snippet58>

        Return oldWeekDayName
    End Function


    '****************************************************************************
    Shared Function FunctionWeekday() As Integer
        '<Snippet57>
        Dim oldDate As Date
        Dim oldWeekDay As Integer
        oldDate = #2/12/1969#
        oldWeekDay = Weekday(oldDate)
        ' oldWeekDay now contains 4 because thisDate represents a Wednesday.
        '</Snippet57>

        Return oldWeekDay
    End Function


    '****************************************************************************
    Shared Function FunctionVbTypeName() As String
        '<Snippet56>
        Dim sysDateName As String = "System.DateTime"
        Dim sysShortName As String = "Int16"
        Dim sysBadName As String = "Nonsense"
        Dim testVbName As String
        testVbName = VbTypeName(sysDateName)
        ' Returns "Date".
        testVbName = VbTypeName(sysShortName)
        ' Returns "Short".
        testVbName = VbTypeName(sysBadName)
        ' Returns Nothing.
        '</Snippet56>

        Return testVbName
    End Function


    '****************************************************************************
    Shared Function FunctionVarType() As VariantType
        '<Snippet55>
        Dim testString As String = "String for testing"
        Dim testObject As New Object
        Dim testNumber, testArray(5) As Integer
        Dim testVarType As VariantType
        testVarType = VarType(testVarType)
        ' Returns VariantType.Integer.
        testVarType = VarType(testString)
        ' Returns VariantType.String.
        testVarType = VarType(testObject)
        ' Returns VariantType.Object.
        testVarType = VarType(testNumber)
        ' Returns VariantType.Integer.
        testVarType = VarType(testArray)
        ' Returns the bitwise OR of VariantType.Array and VariantType.Integer.
        '</Snippet55>

        Return testVarType
    End Function


    '****************************************************************************
    Shared Function FunctionVal() As Double
        '<Snippet54>
        Dim valResult As Double
        ' The following line of code sets valResult to 2457.
        valResult = Val("2457")
        ' The following line of code sets valResult to 2457.
        valResult = Val(" 2 45 7")
        ' The following line of code sets valResult to 24.
        valResult = Val("24 and 57")
        '</Snippet54>

        Return valResult
    End Function


    '****************************************************************************
    Shared Function FunctionUBound() As Integer
        '<Snippet53>
        Dim highest, bigArray(10, 15, 20), littleArray(6) As Integer
        highest = UBound(bigArray, 1)
        highest = UBound(bigArray, 3)
        highest = UBound(littleArray)
        ' The three calls to UBound return 10, 20, and 6 respectively.
        '</Snippet53>

        Return highest
    End Function


    '****************************************************************************
    Shared Function FunctionTypeName() As String
        '<Snippet52>
        Dim testType As String
        Dim strVar As String = "String for testing"
        Dim decVar As Decimal
        Dim intVar, arrayVar(5) As Integer
        testType = TypeName(strVar)
        ' The preceding call returns "String".
        testType = TypeName(decVar)
        ' The preceding call returns "Decimal".
        testType = TypeName(intVar)
        ' The preceding call returns "Integer".
        testType = TypeName(arrayVar)
        ' The preceding call returns "Integer()".
        '</Snippet52>

        Return testType
    End Function


    '****************************************************************************
    Shared Function FunctionTimeValue() As Date
        '<Snippet51>
        Dim thisTime As Date
        thisTime = TimeValue("4:35:17 PM")
        '</Snippet51>

        Return thisTime
    End Function


    '****************************************************************************
    Shared Function FunctionTimeSerial() As Date
        '<Snippet50>
        Dim thisTime As Date
        thisTime = TimeSerial(16, 35, 17)
        '</Snippet50>

        Return thisTime
    End Function


    '****************************************************************************
    Shared Function FunctionSystemTypeName() As String
        '<Snippet49>
        Dim vbLongName As String = "Long"
        Dim vbDateName As String = "Date"
        Dim vbBadName As String = "Number"
        Dim testSysName As String
        testSysName = SystemTypeName(vbLongName)
        ' The preceding call returns "System.Int64".
        testSysName = SystemTypeName(vbDateName)
        ' The preceding call returns "System.DateTime".
        testSysName = SystemTypeName(vbBadName)
        ' The preceding call returns Nothing.
        '</Snippet49>

        Return testSysName
    End Function


    '****************************************************************************
    '<Snippet48>
    Function matchLanguage(ByVal cityName As String) As String
        Return CStr(Microsoft.VisualBasic.Switch( 
            cityName = "London", "English", 
            cityName = "Rome", "Italian", 
            cityName = "Paris", "French"))
    End Function
    '</Snippet48>


    '****************************************************************************
    Shared Function FunctionShell() As Integer
        '<Snippet47>
        Dim procID As Integer
        ' Run calculator.
        procID = Shell("C:\Windows\system32\calc.exe", AppWinStyle.NormalFocus)
        ' The preceding path is for Windows XP.
        ' The Windows 2000 path is C:\WINNT\system32\calc.exe.
        '</Snippet47>

        Return procID
    End Function


    '****************************************************************************
    Shared Function FunctionSecond() As String
        '<Snippet46>
        Dim thisTime As Date
        Dim thisSecond As Integer
        thisTime = #4:35:17 PM#
        thisSecond = Second(thisTime)
        ' thisSecond now contains 17.
        '</Snippet46>

        Return thisSecond.ToString
    End Function


    '****************************************************************************
    Shared Sub FunctionPartition()
        '<Snippet45>
        Dim year As Long = 1984
        ' Assume the value of year is provided by data or by user input.
        Dim decade As String
        decade = Partition(year, 1950, 2049, 10)
        MsgBox("Year " & CStr(year) & " is in decade " & decade & ".")
        '</Snippet45>
    End Sub


    '****************************************************************************
    Shared Function FunctionMonthName() As String
        '<Snippet44>
        Dim thisMonth As Integer
        Dim name As String
        thisMonth = 4
        ' Set Abbreviate to True to return an abbreviated name.
        name = MonthName(thisMonth, True)
        ' name now contains "Apr".
        '</Snippet44>

        Return name
    End Function


    '****************************************************************************
    Shared Function FunctionMonth() As Integer
        '<Snippet43>
        Dim thisDate As Date
        Dim thisMonth As Integer
        thisDate = #2/12/1969#
        thisMonth = Month(thisDate)
        ' thisMonth now contains 2.
        '</Snippet43>

        Return thisMonth
    End Function


    '****************************************************************************
    Shared Function FunctionMinute() As Integer
        '<Snippet42>
        Dim thisTime As Date
        Dim thisMinute As Integer
        thisTime = #4:35:17 PM#
        thisMinute = Minute(thisTime)
        ' thisMinute now contains 35.
        '</Snippet42>

        Return thisMinute
    End Function


    '****************************************************************************
    Shared Function FunctionLBound() As Integer
        '<Snippet41>
        Dim lowest, bigArray(10, 15, 20), littleArray(6) As Integer
        lowest = LBound(bigArray, 1)
        lowest = LBound(bigArray, 3)
        lowest = LBound(littleArray)
        ' All three calls to LBound return 0.
        '</Snippet41>

        Return lowest
    End Function


    '****************************************************************************
    Shared Function FunctionIsReference() As Boolean
        '<Snippet40>
        Dim testArray(3) As Boolean
        Dim testString As String = "Test string"
        Dim testObject As Object = New Object()
        Dim testNumber As Integer = 12
        testArray(0) = IsReference(testArray)
        testArray(1) = IsReference(testString)
        testArray(2) = IsReference(testObject)
        testArray(3) = IsReference(testNumber)
        '</Snippet40>

        Return testArray(2)
    End Function


    '****************************************************************************
    Shared Function FunctionIsNumeric() As Boolean
        '<Snippet39>
        Dim testVar As Object
        Dim numericCheck As Boolean
        testVar = "53"
        ' The following call to IsNumeric returns True.
        numericCheck = IsNumeric(testVar)
        testVar = "459.95"
        ' The following call to IsNumeric returns True.
        numericCheck = IsNumeric(testVar)
        testVar = "45 Help"
        ' The following call to IsNumeric returns False.
        numericCheck = IsNumeric(testVar)
        '</Snippet39>

        Return numericCheck
    End Function


    '****************************************************************************
    Shared Function FunctionIsNothing() As Boolean
        '<Snippet38>
        Dim testVar As Object
        ' No instance has been assigned to variable testVar yet.
        Dim testCheck As Boolean
        ' The following call returns True.
        testCheck = IsNothing(testVar)
        ' Assign a string instance to variable testVar.
        testVar = "ABCDEF"
        ' The following call returns False.
        testCheck = IsNothing(testVar)
        ' Disassociate variable testVar from any instance.
        testVar = Nothing
        ' The following call returns True.
        testCheck = IsNothing(testVar)
        '</Snippet38>

        Return testCheck
    End Function


    '****************************************************************************
    '<Snippet37>
    Sub demonstrateIsError(ByVal firstArg As Integer)
        Dim returnVal As New Object
        Dim badArg As String = "Bad argument value"
        Dim errorCheck As Boolean
        If firstArg > 10000 Then
            returnVal = New System.ArgumentOutOfRangeException(badArg)
        End If
        errorCheck = IsError(returnVal)
    End Sub
    '</Snippet37>


    '****************************************************************************
    Shared Function FunctionIsDBNull() As Boolean
        '<Snippet36>
        Dim testVar As Object
        Dim nullCheck As Boolean
        nullCheck = IsDBNull(testVar)
        testVar = ""
        nullCheck = IsDBNull(testVar)
        testVar = System.DBNull.Value
        nullCheck = IsDBNull(testVar)
        ' The first two calls to IsDBNull return False; the third returns True.
        '</Snippet36>

        Return nullCheck
    End Function


    '****************************************************************************
    Shared Function FunctionIsDate() As Boolean
        '<Snippet35>
        Dim firstDate, secondDate As Date
        Dim timeOnly, dateAndTime, noDate As String
        Dim dateCheck As Boolean
        firstDate = CDate("February 12, 1969")
        secondDate = #2/12/1969#
        timeOnly = "3:45 PM"
        dateAndTime = "March 15, 1981 10:22 AM"
        noDate = "Hello"
        dateCheck = IsDate(firstDate)
        dateCheck = IsDate(secondDate)
        dateCheck = IsDate(timeOnly)
        dateCheck = IsDate(dateAndTime)
        dateCheck = IsDate(noDate)
        '</Snippet35>

        Return dateCheck
    End Function


    '****************************************************************************
    Shared Function FunctionIsArray() As Boolean
        '<Snippet34>
        Dim firstArray(4), secondArray(3) As Integer
        Dim thisString As String = "Test"
        Dim arrayCheck As Boolean
        arrayCheck = IsArray(firstArray)
        arrayCheck = IsArray(secondArray)
        arrayCheck = IsArray(thisString)
        ' The first two calls to IsArray return True; the third returns False.
        '</Snippet34>

        Return arrayCheck
    End Function


    '****************************************************************************
    '<Snippet33>
    Function checkIt(ByVal testMe As Integer) As String
        Return CStr(IIf(testMe > 1000, "Large", "Small"))
    End Function
    '</Snippet33>


    '****************************************************************************
    Shared Function FunctionHour() As Integer
        '<Snippet32>
        Dim someTime As Date
        Dim someHour As Integer
        someTime = #4:35:17 PM#
        someHour = Hour(someTime)
        ' someHour now contains 16.
        '</Snippet32>

        Return someHour
    End Function


    '****************************************************************************
    Shared Function FunctionDay() As Integer
        '<Snippet30>
        Dim oldDate As Date
        Dim oldDay As Integer
        ' Assign a date using standard short format.
        oldDate = #2/12/1969#
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)
        ' oldDay now contains 12.
        '</Snippet30>

        Return oldDay
    End Function


    '****************************************************************************
    Shared Function FunctionDateValue() As Date
        '<Snippet29>
        Dim oldDate As Date
        oldDate = DateValue("February 12, 1969")
        '</Snippet29>

        Return oldDate
    End Function


    '****************************************************************************
    Shared Function FunctionDateSerial() As Date
        '<Snippet28>
        ' DateSerial returns the date for a specified year, month, and day.
        Dim aDate As Date
        ' Variable aDate contains the date for February 12, 1969.
        aDate = DateSerial(1969, 2, 12)
        Console.WriteLine(aDate)

        ' The following example uses DateSerial to determine and display
        ' the last day of the previous month.
        ' First, establish a starting date.
        Dim startDate = #1/23/1994#
        ' The 0 for the day represents the last day of the previous month.
        Dim endOfLastMonth = DateSerial(startDate.Year, startDate.Month, 0)
        Console.WriteLine("Last day in the previous month: " & endOfLastMonth)

        ' The following example finds and displays the day of the week that the 
        ' 15th day of the following month will fall on.
        Dim fifteenthsDay = DateSerial(Today.Year, Today.Month + 1, 15)
        Console.WriteLine("The 15th of next month is a {0}", fifteenthsDay.DayOfWeek)
        '</Snippet28>

        Return aDate
    End Function


    '****************************************************************************
    Shared Function FunctionDatePart() As String
        '<Snippet27>
        Dim DateString, Msg As String
        Dim ActualDate As Date
        ' Enter February 12, 2008, or 2/12/2008.
        DateString = InputBox("Enter a date:")
        ActualDate = CDate(DateString)

        ' The first two examples use enumeration values for the interval.
        Msg = "Quarter: " & DatePart(DateInterval.Quarter, ActualDate)
        ' The quarter is 1.
        MsgBox(Msg)
        Msg = "The day of the month: " & DatePart(DateInterval.Day, ActualDate)
        ' The day of the month is 12.
        MsgBox(Msg)

        ' The next two examples use string values for the interval parameter.
        Msg = "The week of the year: " & DatePart("ww", ActualDate)
        ' The week of the year is 7.
        MsgBox(Msg)
        Msg = "The day of the week: " & DatePart("w", ActualDate)
        ' The day of the week is 3 (Tuesday).
        MsgBox(Msg)
        '</Snippet27>

        Return "okay"
    End Function


    '****************************************************************************
    Shared Function FunctionDateDiff() As String
        '<Snippet26>
        Dim date2Entered As String = InputBox("Enter a date")

        Try
            Dim date2 As Date = Date.Parse(date2Entered)
            Dim date1 As Date = Now

            ' Determine the number of days between the two dates.
            Dim days As Long = DateDiff(DateInterval.Day, date1, date2)

            ' This statement has a string interval argument, and
            ' is equivalent to the above statement.
            'Dim days As Long = DateDiff("d", date1, date2)

            MessageBox.Show("Days from today: " & days.ToString)
        Catch ex As Exception
            MessageBox.Show("Invalid Date: " & ex.Message)
        End Try
        '</Snippet26>

        Return "okay"
    End Function


    '****************************************************************************
    Shared Function FunctionDateAdd() As String
        '<Snippet25>
        Dim dateEntered As String =
        InputBox("Enter a date", DefaultResponse:=Date.Now.ToShortDateString)
        Dim monthsEntered As String =
        InputBox("Enter number of months to add", DefaultResponse:="12")

        Dim dateValue As Date = Date.Parse(dateEntered)
        Dim monthsValue As Integer = Integer.Parse(monthsEntered)

        ' Add the months to the date.
        Dim newDate As Date = DateAdd(DateInterval.Month, monthsValue, dateValue)

        ' This statement has a string interval argument, and
        ' is equivalent to the above statement.
        'Dim newDate As Date = DateAdd("m", monthsValue, dateValue)

        MessageBox.Show("New date: " & newDate.ToShortDateString)
        '</Snippet25>

        Return "okay"
    End Function


    '****************************************************************************
    Shared Function FunctionCType() As Single
        '<Snippet24>
        Dim testNumber As Long = 1000
        ' The following line of code sets testNewType to 1000.0.
        Dim testNewType As Single = CType(testNumber, Single)
        '</Snippet24>

        Return testNewType
    End Function


    '****************************************************************************
    '<Snippet22>
    Function GetChoice(ByVal Ind As Integer) As String
        GetChoice = CStr(Choose(Ind, "Speedy", "United", "Federal"))
    End Function
    '</Snippet22>


    '****************************************************************************
    '<Snippet21>
    Public Sub TestCallByName2()
        Dim col As New Collection()

        'Store the string "Item One" in a collection by 
        'calling the Add method.
        CallByName(col, "Add", CallType.Method, "Item One")

        'Retrieve the first entry from the collection using the 
        'Item property and display it using MsgBox().
        MsgBox(CallByName(col, "Item", CallType.Get, 1))
    End Sub
    '</Snippet21>


    Dim TextBox1 As System.Windows.Forms.Control.TextBox
    '****************************************************************************
    '<Snippet20>
    Sub TestCallByName1()
        'Set a property.
        CallByName(TextBox1, "Text", CallType.Set, "New Text")

        'Retrieve the value of a property.
        MsgBox(CallByName(TextBox1, "Text", CallType.Get))

        'Call a method.
        CallByName(TextBox1, "Hide", CallType.Method)
    End Sub
    '</Snippet20>


    '****************************************************************************
    Shared Function FunctionAsc() As Integer
        '<Snippet19>
        Dim codeInt As Integer
        ' The following line of code sets codeInt to 65.
        codeInt = Asc("A")
        ' The following line of code sets codeInt to 97.
        codeInt = Asc("a")
        ' The following line of code sets codeInt to 65.
        codeInt = Asc("Apple")
        '</Snippet19>

        Return codeInt
    End Function


    '****************************************************************************
    Shared Sub FunctionCUShort()
        '<Snippet18>
        Dim aDouble As Double
        Dim aUShort As UShort
        aDouble = 39.501
        ' The following line of code sets aUShort to 40.
        aUShort = CUShort(aDouble)
        '</Snippet18>
    End Sub


    '****************************************************************************
    Shared Sub FunctionCULng()
        '<Snippet17>
        Dim aDouble As Double
        Dim aULong As ULong
        aDouble = 39.501
        ' The following line of code sets aULong to 40.
        aULong = CULng(aDouble)
        '</Snippet17>
    End Sub


    '****************************************************************************
    Shared Sub FunctionCUInt()
        '<Snippet16>
        Dim aDouble As Double
        Dim aUInteger As UInteger
        aDouble = 39.501
        ' The following line of code sets aUInteger to 40.
        aUInteger = CUInt(aDouble)
        '</Snippet16>
    End Sub


    '****************************************************************************
    Shared Function FunctionCStrDate() As String
        '<Snippet15>
        Dim aDate As Date
        Dim aString As String
        ' The following line of code generates a COMPILER ERROR because of invalid format.
        ' aDate = #February 12, 1969 00:00:00#
        ' Date literals must be in the format #m/d/yyyy# or they are invalid.
        ' The following line of code sets the time component of aDate to midnight.
        aDate = #2/12/1969#
        ' The following conversion suppresses the neutral time value of 00:00:00.
        ' The following line of code sets aString to "2/12/1969".
        aString = CStr(aDate)
        ' The following line of code sets the time component of aDate to one second past midnight.
        aDate = #2/12/1969 12:00:01 AM#
        ' The time component becomes part of the converted value.
        ' The following line of code sets aString to "2/12/1969 12:00:01 AM".
        aString = CStr(aDate)
        '</Snippet15>

        Return aString
    End Function


    '****************************************************************************
    Shared Function FunctionCStrNumber() As String
        '<Snippet14>
        Dim aDouble As Double
        Dim aString As String
        aDouble = 437.324
        ' The following line of code sets aString to "437.324".
        aString = CStr(aDouble)
        '</Snippet14>

        Return aString
    End Function


    '****************************************************************************
    Shared Function FunctionCSng() As Single
        '<Snippet13>
        Dim aDouble1, aDouble2 As Double
        Dim aSingle1, aSingle2 As Single
        aDouble1 = 75.3421105
        aDouble2 = 75.3421567
        ' The following line of code sets aSingle1 to 75.34211.
        aSingle1 = CSng(aDouble1)
        ' The following line of code sets aSingle2 to 75.34216.
        aSingle2 = CSng(aDouble2)
        '</Snippet13>

        Return aSingle2
    End Function


    '****************************************************************************
    Shared Function FunctionCShort() As Short
        '<Snippet12>
        Dim aByte As Byte
        Dim aShort As Short
        aByte = 100
        ' The following line of code sets aShort to 100.
        aShort = CShort(aByte)
        '</Snippet12>

        Return aShort
    End Function


    '****************************************************************************
    Shared Sub FunctionCSByte()
        '<Snippet11>
        Dim aDouble As Double
        Dim anSByte As SByte
        aDouble = 39.501
        ' The following line of code sets anSByte to 40.
        anSByte = CSByte(aDouble)
        '</Snippet11>
    End Sub


    '****************************************************************************
    Shared Function FunctionCObj() As String
        '<Snippet10>
        Dim aDouble As Double
        Dim anObject As Object
        aDouble = 2.7182818284
        ' The following line of code sets anObject to a pointer to aDouble.
        anObject = CObj(aDouble)
        '</Snippet10>

        Return anObject.ToString
    End Function


    '****************************************************************************
    Shared Function FunctionCLng() As Long
        '<Snippet9>
        Dim aDbl1, aDbl2 As Double
        Dim aLng1, aLng2 As Long
        aDbl1 = 25427.45
        aDbl2 = 25427.55
        ' The following line of code sets aLng1 to 25427.
        aLng1 = CLng(aDbl1)
        ' The following line of code sets aLng2 to 25428.
        aLng2 = CLng(aDbl2)
        '</Snippet9>

        Return aLng2
    End Function


    '****************************************************************************
    Shared Function FunctionCInt() As Integer
        '<Snippet8>
        Dim aDbl As Double
        Dim anInt As Integer
        aDbl = 2345.5678
        ' The following line of code sets anInt to 2346.
        anInt = CInt(aDbl)
        '</Snippet8>

        Return anInt
    End Function


    '****************************************************************************
    Shared Function FunctionCDec() As Decimal
        '<Snippet7>
        Dim aDouble As Double
        Dim aDecimal As Decimal
        aDouble = 10000000.0587
        ' The following line of code sets aDecimal to 10000000.0587.
        aDecimal = CDec(aDouble)
        '</Snippet7>

        Return aDecimal
    End Function


    '****************************************************************************
    Shared Function FunctionCDbl() As Double
        '<Snippet6>
        Dim aDec As Decimal
        Dim aDbl As Double
        ' The following line of code uses the literal type character D to make aDec a Decimal.
        aDec = 234.456784D
        ' The following line of code sets aDbl to 1.9225456288E+1.
        aDbl = CDbl(aDec * 8.2D * 0.01D)
        '</Snippet6>

        Return aDbl
    End Function


    '****************************************************************************
    Shared Function FunctionCDate() As Date
        '<Snippet5>
        Dim aDateString, aTimeString As String
        Dim aDate, aTime As Date
        aDateString = "February 12, 1969"
        aTimeString = "4:35:47 PM"
        ' The following line of code sets aDate to a Date value.
        aDate = CDate(aDateString)
        ' The following line of code sets aTime to Date value.
        aTime = CDate(aTimeString)
        '</Snippet5>

        Return aDate
    End Function


    '****************************************************************************
    Shared Function FunctionCCharInteger() As Char
        '<Snippet4>
        Dim someDigits As String
        Dim codePoint As Integer
        Dim thisChar As Char
        someDigits = InputBox("Enter code point of character:")
        codePoint = CInt(someDigits)
        ' The following line of code sets thisChar to the Char value of codePoint.
        thisChar = ChrW(codePoint)
        '</Snippet4>

        Return thisChar
    End Function


    '****************************************************************************
    Shared Function FunctionCCharString() As Char
        '<Snippet3>
        Dim aString As String
        Dim aChar As Char
        ' CChar converts only the first character of the string.
        aString = "BCD"
        ' The following line of code sets aChar to "B".
        aChar = CChar(aString)
        '</Snippet3>

        Return aChar
    End Function


    '****************************************************************************
    Shared Function FunctionCByte() As Byte
        '<Snippet2>
        Dim aDouble As Double
        Dim aByte As Byte
        aDouble = 125.5678
        ' The following line of code sets aByte to 126.
        aByte = CByte(aDouble)
        '</Snippet2>

        Return aByte
    End Function


    '****************************************************************************
    Shared Function FunctionCBool() As Boolean
        '<Snippet1>
        Dim a, b, c As Integer
        Dim check As Boolean
        a = 5
        b = 5
        ' The following line of code sets check to True.
        check = CBool(a = b)
        c = 0
        ' The following line of code sets check to False.
        check = CBool(c)
        '</Snippet1>

        Return check
    End Function


    Class System
        Class ArgumentOutOfRangeException
            Sub New()
            End Sub
            Sub New(ByVal s As String)
            End Sub
        End Class
        Class DBNull
            Public Shared Value As Integer
        End Class
        Class Windows
            Class Forms
                '******************
                Class Button
                End Class
                '******************
                Class Form
                End Class
                '******************
                Class Label
                End Class
                '******************
                Class Control
                    Class TextBox

                    End Class
                End Class
                '******************
            End Class
        End Class
    End Class
End Class
