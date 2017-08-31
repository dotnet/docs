Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Diagnostics

Public Class Class1


    '****************************************************************************
    Sub TestComparisons()
        Dim newCustomer As Boolean

        '<Snippet90>
        If 45 < 12 And testFunction(3) = 81 Then
            ' Add code to continue execution.
        End If
        '</Snippet90>


        '<Snippet89>
        If 45 < 12 AndAlso testFunction(3) = 81 Then
            ' Add code to continue execution.
        End If
        '</Snippet89>


        '<Snippet88>
        If newCustomer = True Then
            newCustomer = False
        End If
        '</Snippet88>

        '<Snippet87>
        If newCustomer = True Then
            ' Insert code to execute if newCustomer = True.
        Else
            ' Insert code to execute if newCustomer = False.
        End If
        '</Snippet87>

        '<Snippet86>
        Dim x As Boolean
        x = 50 < 30
        ' The preceding statement assigns False to x.
        '</Snippet86>

        '<Snippet85>
        If x = 50 Then
            ' Insert code to continue program.
        End If
        '</Snippet85>

        '<Snippet84>
        If x > 50 Then
            ' Insert code to run if x is greater than 50.
        Else
            ' Insert code to run if x is less than or equal to 50.
        End If
        '</Snippet84>
    End Sub


    '****************************************************************************
    Sub TestCalcVals2()

        '<Snippet83>
        Dim i As Integer = 2
        Dim j, k As Integer
        j = 4 * (67 + i)
        k = 4 * 67 + i
        '</Snippet83>
    End Sub


    '****************************************************************************
    Sub TestCalcVals()

        '<Snippet82>
        Dim i As Integer = 2
        Dim j As Integer
        j = 4 * (67 + i)
        '</Snippet82>
    End Sub


    '****************************************************************************
    '<Snippet81>
    Dim amount As Integer = 12
    Dim highestAllowed As Integer = 45
    Dim grandTotal As Integer
    '</Snippet81>


    '****************************************************************************
    Sub TestShortCircuit()
        '<Snippet80>
        If amount > highestAllowed And checkIfValid(amount) Then
            ' The preceding statement calls checkIfValid().
        End If
        If amount > highestAllowed AndAlso checkIfValid(amount) Then
            ' The preceding statement does not call checkIfValid().
        End If
        If amount < highestAllowed Or checkIfValid(amount) Then
            ' The preceding statement calls checkIfValid().
        End If
        If amount < highestAllowed OrElse checkIfValid(amount) Then
            ' The preceding statement does not call checkIfValid().
        End If
        '</Snippet80>
    End Sub


    '****************************************************************************
    '<Snippet79>
    Function checkIfValid(ByVal checkValue As Integer) As Boolean
        If checkValue > 15 Then
            MsgBox(CStr(checkValue) & " is not a valid value.")
            ' The MsgBox warning is not displayed if the call to
            ' checkIfValid() is part of a short-circuited expression.
            Return False
        Else
            grandTotal += checkValue
            ' The grandTotal value is not updated if the call to
            ' checkIfValid() is part of a short-circuited expression.
            Return True
        End If
    End Function
    '</Snippet79>


    '****************************************************************************
    Public Sub TestLogic()

        '<Snippet78>
        Dim a, b, c, d, e, f, g As Boolean

        a = 23 > 14 And 11 > 8
        b = 14 > 23 And 11 > 8
        ' The preceding statements set a to True and b to False.

        c = 23 > 14 Or 8 > 11
        d = 23 > 67 Or 8 > 11
        ' The preceding statements set c to True and d to False.

        e = 23 > 67 Xor 11 > 8
        f = 23 > 14 Xor 11 > 8
        g = 14 > 23 Xor 8 > 11
        ' The preceding statements set e to True, f to False, and g to False.
        '</Snippet78>

        '<Snippet77>
        Dim x, y As Boolean
        x = Not 23 > 14
        y = Not 23 > 67
        ' The preceding statements set x to False and y to True.
        '</Snippet77>
    End Sub


    '****************************************************************************
    Public Sub TestConCat()

        '<Snippet76>
        Dim a As String = "abc"
        Dim d As String = "def"
        Dim z As String = a & d
        Dim w As String = a + d
        ' The preceding statements set both z and w to "abcdef".
        '</Snippet76>

        '<Snippet75>
        Dim x As String = "Con" & "caten" & "ation"
        Dim y As String = "Con" + "caten" + "ation"
        ' The preceding statements set both x and y to "Concatenation".
        '</Snippet75>
    End Sub


    '****************************************************************************
    Dim myString As String = "Hello"
    Dim phoneNum As String = "9999999"

    '****************************************************************************
    Public Sub TestPattern5()
        '<Snippet74>
        Dim sMatch As Boolean = 
          (phoneNum Like "###[ -.]####") OrElse (phoneNum Like "#######")
        '</Snippet74>
    End Sub

    '****************************************************************************
    Public Sub TestPattern4()
        '<Snippet73>
        Dim sMatch As Boolean = myString Like "num[i-m]"
        '</Snippet73>
    End Sub

    '****************************************************************************
    Public Sub TestPattern3()
        '<Snippet72>
        Dim sMatch As Boolean = myString Like "?[ACE]"
        '</Snippet72>
    End Sub

    '****************************************************************************
    Public Sub TestPattern2()
        '<Snippet71>
        Dim sMatch As Boolean = myString Like "W??"
        '</Snippet71>
    End Sub

    '****************************************************************************
    Public Sub TestPattern()
        '<Snippet70>
        Dim sMatch As Boolean = myString Like "H"
        '</Snippet70>
    End Sub


    '****************************************************************************
    '<Snippet69>
    Public Sub processControl(ByVal f As System.Windows.Forms.Form, 
        ByVal c As System.Windows.Forms.Control)
        Dim active As System.Windows.Forms.Control = f.ActiveControl
        If (active IsNot Nothing) And (c Is active) Then
            ' Insert code to process control c
        End If
        Return
    End Sub
    '</Snippet69>


    '****************************************************************************
    Sub TestComp3()

        '<Snippet68>
        Dim x As System.Windows.Forms.Button
        x = New System.Windows.Forms.Button()
        If TypeOf x Is System.Windows.Forms.Control Then
            ' Insert code to run if x is of type System.Windows.Forms.Control.
        End If
        '</Snippet68>
    End Sub


    '****************************************************************************
    Sub TestComp2()

        '<Snippet67>
        Dim a As New classA()
        Dim b As New classB()
        If a IsNot b Then
            ' Insert code to run if a and b point to different instances.
        End If
        '</Snippet67>

        '<Snippet66>
        Dim x As New customer()
        Dim y As New customer()
        If x Is y Then
            ' Insert code to run if x and y point to the same instance.
        End If
        '</Snippet66>
    End Sub


    '****************************************************************************
    Sub TestComp()

        '<Snippet65>
        Dim x As testClass
        Dim y As New testClass()
        x = y
        If x Is y Then
            ' Insert code to run if x and y point to the same instance.
        End If
        '</Snippet65>
    End Sub


    '****************************************************************************
    Sub TestArith4()

        '<Snippet64>
        Dim lResult, rResult As Integer
        Dim pattern As Integer = 12
        ' The low-order bits of pattern are 0000 1100.
        lResult = pattern << 3
        ' A left shift of 3 bits produces a value of 96.
        rResult = pattern >> 2
        ' A right shift of 2 bits produces value of 3.
        '</Snippet64>

        '<Snippet62>
        Dim x As Integer = 100
        Dim y As Integer = 6
        Dim z As Integer
        z = x Mod y
        ' The preceding statement sets z to 4.
        '</Snippet62>

        '<Snippet63>
        Dim a As Double = 100.3
        Dim b As Double = 4.13
        Dim c As Double
        c = a Mod b
        ' The preceding statement sets c to 1.18.
        '</Snippet63>
    End Sub


    '****************************************************************************
    Sub TestArith3()
        '<Snippet61>
        Dim k As Integer
        k = 23 \ 5
        ' The preceding statement sets k to 4.
        '</Snippet61>

        '<Snippet60>
        Dim z As Double
        z = 23 ^ 3
        ' The preceding statement sets z to 12167 (the cube of 23).
        '</Snippet60>

        '<Snippet59>
        Dim y As Double
        y = 45 * 55.23
        y = 32 / 23
        '</Snippet59>

        '<Snippet57>
        Dim x As Integer
        x = 67 + 34
        x = 32 - 12
        '</Snippet57>
    End Sub


    '****************************************************************************
    Sub TestArith2()
        '<Snippet58>
        Dim x As Integer = 65
        Dim y As Integer
        y = -x
        '</Snippet58>
    End Sub


    '****************************************************************************
    Sub TestOps()
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim z As Integer = 0
        '<Snippet56>
        x = 45 + y * z ^ 2
        '</Snippet56>
    End Sub


    '****************************************************************************
    Sub TestShift2()
        '<Snippet55>
        Dim negPattern As Short = -8192
        ' The bit pattern is 1110 0000 0000 0000.
        Dim negResult1, negResult2 As Short
        negResult1 = negPattern >> 4
        negResult2 = negPattern >> 13
        '</Snippet55>
    End Sub


    '****************************************************************************
    Shared Function OperatorXorInteger() As Integer
        '<Snippet41>
        Dim a As Integer = 10 ' 1010 in binary
        Dim b As Integer = 8  ' 1000 in binary
        Dim c As Integer = 6  ' 0110 in binary
        Dim firstPattern, secondPattern, thirdPattern As Integer
        firstPattern = (a Xor b)  '  2, 0010 in binary
        secondPattern = (a Xor c) ' 12, 1100 in binary
        thirdPattern = (b Xor c)  ' 14, 1110 in binary
        '</Snippet41>

        Return thirdPattern
    End Function

    '****************************************************************************
    Shared Function OperatorXorBoolean() As Boolean

        '<Snippet40>
        Dim a As Integer = 10
        Dim b As Integer = 8
        Dim c As Integer = 6
        Dim firstCheck, secondCheck, thirdCheck As Boolean
        firstCheck = a > b Xor b > c
        secondCheck = b > a Xor b > c
        thirdCheck = b > a Xor c > b
        '</Snippet40>

        Return secondCheck
    End Function


    '****************************************************************************
    Shared Function OperatorTypeOf() As Boolean
        '<Snippet39>
        Dim refInteger As Object = 2
        MsgBox("TypeOf Object[Integer] Is Integer? " & TypeOf refInteger Is Integer)
        MsgBox("TypeOf Object[Integer] Is Double? " & TypeOf refInteger Is Double)
        Dim refForm As Object = New System.Windows.Forms.Form
        MsgBox("TypeOf Object[Form] Is Form? " & TypeOf refForm Is System.Windows.Forms.Form)
        MsgBox("TypeOf Object[Form] Is Label? " & TypeOf refForm Is System.Windows.Forms.Label)
        MsgBox("TypeOf Object[Form] Is Control? " & TypeOf refForm Is System.Windows.Forms.Control)
        MsgBox("TypeOf Object[Form] Is IComponent? " & TypeOf refForm Is System.ComponentModel.IComponent)
        '</Snippet39>

        Return True
    End Function


    '****************************************************************************
    Shared Function OperatorOrElse() As Boolean

        '<Snippet37>
        Dim a As Integer = 10
        Dim b As Integer = 8
        Dim c As Integer = 6
        Dim firstCheck, secondCheck, thirdCheck As Boolean
        firstCheck = a > b OrElse b > c
        secondCheck = b > a OrElse b > c
        thirdCheck = b > a OrElse c > b
        '</Snippet37>

        '<Snippet38>
        If testFunction(5) = True OrElse otherFunction(4) = True Then
            ' If testFunction(5) is True, otherFunction(4) is not called.
            ' Insert code to be executed.
        End If
        '</Snippet38>

        Return secondCheck
    End Function


    '****************************************************************************
    Shared Function testFunction(ByVal i As Integer) As Boolean
        'do nothing
    End Function

    Shared Function otherFunction(ByVal i As Integer) As Boolean
        'do nothing
    End Function


    '****************************************************************************
    Shared Function OperatorOrInteger() As Integer

        '<Snippet36>
        Dim a As Integer = 10
        Dim b As Integer = 8
        Dim c As Integer = 6
        Dim firstPattern, secondPattern, thirdPattern As Integer
        firstPattern = (a Or b)
        secondPattern = (a Or c)
        thirdPattern = (b Or c)
        '</Snippet36>

        Return thirdPattern
    End Function


    '****************************************************************************
    Shared Function OperatorOrBoolean() As Boolean

        '<Snippet35>
        Dim a As Integer = 10
        Dim b As Integer = 8
        Dim c As Integer = 6
        Dim firstCheck, secondCheck, thirdCheck As Boolean
        firstCheck = a > b Or b > c
        secondCheck = b > a Or b > c
        thirdCheck = b > a Or c > b
        '</Snippet35>

        Return secondCheck
    End Function


    '****************************************************************************
    Shared Function OperatorNotInteger() As Integer

        '<Snippet34>
        Dim a As Integer = 10
        Dim b As Integer = 8
        Dim c As Integer = 6
        Dim firstPattern, secondPattern, thirdPattern As Integer
        firstPattern = (Not a)
        secondPattern = (Not b)
        thirdPattern = (Not c)
        '</Snippet34>

        Return thirdPattern
    End Function


    '****************************************************************************
    Shared Function OperatorNotBoolean() As Boolean

        '<Snippet33>
        Dim a As Integer = 10
        Dim b As Integer = 8
        Dim c As Integer = 6
        Dim firstCheck, secondCheck As Boolean
        firstCheck = Not (a > b)
        secondCheck = Not (b > a)
        '</Snippet33>

        Return secondCheck
    End Function


    '****************************************************************************
    Shared Function OperatorModPrecision() As Double
        Dim firstResult, secondResult As Double

        '<Snippet32>
        firstResult = 2.0 Mod 0.2
        ' Double operation returns 0.2, not 0.
        secondResult = 2D Mod 0.2D
        ' Decimal operation returns 0.
        '</Snippet32>

        Return secondResult
        'Return firstResult
    End Function


    '****************************************************************************
    Shared Function OperatorMod() As Double

        '<Snippet31>
        Debug.WriteLine(10 Mod 5)
        ' Output: 0
        Debug.WriteLine(10 Mod 3)
        ' Output: 1
        Debug.WriteLine(-10 Mod 3)
        ' Output: -1
        Debug.WriteLine(12 Mod 4.3)
        ' Output: 3.4
        Debug.WriteLine(12.6 Mod 5)
        ' Output: 2.6
        Debug.WriteLine(47.9 Mod 9.35)
        ' Output: 1.15
        '</Snippet31>

        Return testResult
    End Function


    '****************************************************************************
    Shared Function OperatorLike() As Boolean

        '<Snippet30>
        Dim testCheck As Boolean
        ' The following statement returns True (does "F" satisfy "F"?)
        testCheck = "F" Like "F"
        ' The following statement returns False for Option Compare Binary
        '    and True for Option Compare Text (does "F" satisfy "f"?)
        testCheck = "F" Like "f"
        ' The following statement returns False (does "F" satisfy "FFF"?)
        testCheck = "F" Like "FFF"
        ' The following statement returns True (does "aBBBa" have an "a" at the
        '    beginning, an "a" at the end, and any number of characters in 
        '    between?)
        testCheck = "aBBBa" Like "a*a"
        ' The following statement returns True (does "F" occur in the set of
        '    characters from "A" through "Z"?)
        testCheck = "F" Like "[A-Z]"
        ' The following statement returns False (does "F" NOT occur in the 
        '    set of characters from "A" through "Z"?)
        testCheck = "F" Like "[!A-Z]"
        ' The following statement returns True (does "a2a" begin and end with
        '    an "a" and have any single-digit number in between?)
        testCheck = "a2a" Like "a#a"
        ' The following statement returns True (does "aM5b" begin with an "a",
        '    followed by any character from the set "L" through "P", followed
        '    by any single-digit number, and end with any character NOT in
        '    the character set "c" through "e"?)
        testCheck = "aM5b" Like "a[L-P]#[!c-e]"
        ' The following statement returns True (does "BAT123khg" begin with a
        '    "B", followed by any single character, followed by a "T", and end
        '    with zero or more characters of any type?)
        testCheck = "BAT123khg" Like "B?T*"
        ' The following statement returns False (does "CAT123khg"?) begin with
        '    a "B", followed by any single character, followed by a "T", and
        '    end with zero or more characters of any type?)
        testCheck = "CAT123khg" Like "B?T*"
        '</Snippet30>

        Return testCheck
    End Function


    '****************************************************************************
    Shared Function OperatorIsNot() As String

        '<Snippet29>
        Dim o1, o2 As New Object
        If Not o1 Is o2 Then MsgBox("o1 and o2 do not refer to the same instance.")
        If o1 IsNot o2 Then MsgBox("o1 and o2 do not refer to the same instance.")
        '</Snippet29>

        Return "okay"
    End Function


    '****************************************************************************
    '<Snippet28>
    Public Structure p
        Dim a As Double
        Public Shared Operator IsFalse(ByVal w As p) As Boolean
            Dim b As Boolean
            ' Insert code to calculate IsFalse of w.
            Return b
        End Operator
        Public Shared Operator IsTrue(ByVal w As p) As Boolean
            Dim b As Boolean
            ' Insert code to calculate IsTrue of w.
            Return b
        End Operator
    End Structure
    '</Snippet28>


    '****************************************************************************
    Shared Function OperatorIs() As Boolean

        '<Snippet27>
        Dim myObject As New Object
        Dim otherObject As New Object
        Dim yourObject, thisObject, thatObject As Object
        Dim myCheck As Boolean
        yourObject = myObject
        thisObject = myObject
        thatObject = otherObject
        ' The following statement sets myCheck to True.
        myCheck = yourObject Is thisObject
        ' The following statement sets myCheck to False.
        myCheck = thatObject Is thisObject
        ' The following statement sets myCheck to False.
        myCheck = myObject Is thatObject
        thatObject = myObject
        ' The following statement sets myCheck to True.
        myCheck = thisObject Is thatObject
        '</Snippet27>

        Return myCheck
    End Function


    '****************************************************************************
    Shared Function OperatorGetType() As String

        '<Snippet26>
        ' The following statement returns the Type object for Integer.
        MsgBox(GetType(Integer).ToString())
        ' The following statement returns the Type object for one-dimensional string arrays.
        MsgBox(GetType(String()).ToString())
        '</Snippet26>

        Return "Okay"
    End Function


    '****************************************************************************
    '<Snippet25>
    Public Function findValue(ByVal arr() As Double, 
        ByVal searchValue As Double) As Double
        Dim i As Integer = 0
        While i <= UBound(arr) AndAlso arr(i) <> searchValue
            ' If i is greater than UBound(arr), searchValue is not checked.
            i += 1
        End While
        If i > UBound(arr) Then i = -1
        Return i
    End Function
    '</Snippet25>


    '****************************************************************************
    Shared Function OperatorAndAlsoBoolean() As Boolean

        '<Snippet24>
        Dim a As Integer = 10
        Dim b As Integer = 8
        Dim c As Integer = 6
        Dim firstCheck, secondCheck, thirdCheck As Boolean
        firstCheck = a > b AndAlso b > c
        secondCheck = b > a AndAlso b > c
        thirdCheck = a > b AndAlso c > b
        '</Snippet24>

        Return secondCheck
    End Function


    '****************************************************************************
    Shared Function OperatorAndBitwise() As Integer

        '<Snippet23>
        Dim a As Integer = 10
        Dim b As Integer = 8
        Dim c As Integer = 6
        Dim firstPattern, secondPattern, thirdPattern As Integer
        firstPattern = (a And b)
        secondPattern = (a And c)
        thirdPattern = (b And c)
        '</Snippet23>

        Return secondPattern
    End Function


    '****************************************************************************
    Shared Function OperatorAndBoolean() As Boolean

        '<Snippet22>
        Dim a As Integer = 10
        Dim b As Integer = 8
        Dim c As Integer = 6
        Dim firstCheck, secondCheck As Boolean
        firstCheck = a > b And b > c
        secondCheck = b > a And b > c
        '</Snippet22>

        Return firstCheck
    End Function


    '****************************************************************************
    Shared Function OperatorExpEquals() As Integer

        '<Snippet21>
        Dim var1 As Integer = 10
        Dim var2 As Integer = 3
        var1 ^= var2
        ' The value of var1 is now 1000.
        '</Snippet21>

        Return var1
    End Function


    '****************************************************************************
    Shared Function OperatorExp() As Double

        '<Snippet20>
        Dim exp1, exp2, exp3, exp4, exp5, exp6 As Double
        exp1 = 2 ^ 2
        exp2 = 3 ^ 3 ^ 3
        exp3 = (-5) ^ 3
        exp4 = (-5) ^ 4
        exp5 = 8 ^ (1.0 / 3.0)
        exp6 = 8 ^ (-1.0 / 3.0)
        '</Snippet20>

        Return exp3
    End Function


    '****************************************************************************
    Shared Function OperatorDivEquals() As Integer

        '<Snippet19>
        Dim var1 As Integer = 10
        Dim var2 As Integer = 3
        var1 \= var2
        ' The value of var1 is now 3.
        '</Snippet19>

        Return var1
    End Function


    '****************************************************************************
    Shared Function OperatorDiv() As Integer

        '<Snippet18>
        Dim resultValue As Integer
        resultValue = 11 \ 4
        resultValue = 9 \ 3
        resultValue = 100 \ 3
        resultValue = 67 \ -3
        '</Snippet18>

        Return resultValue
    End Function


    '****************************************************************************
    Shared Function OperatorDivideEquals() As Integer

        '<Snippet17>
        Dim var1 As Integer = 12
        Dim var2 As Integer = 3
        var1 /= var2
        ' The value of var1 is now 4.
        '</Snippet17>

        Return var1
    End Function


    '****************************************************************************
    Shared Function OperatorDivide() As Double

        '<Snippet16>
        Dim resultValue As Double
        resultValue = 10 / 4
        resultValue = 10 / 3
        '</Snippet16>

        Return resultValue
    End Function


    '****************************************************************************
    Shared Function OperatorRightShiftEquals() As Integer

        '<Snippet15>
        Dim var As Integer = 10
        Dim shift As Integer = 2
        var >>= shift
        ' The value of var is now 2 (two bits were lost off the right end).
        '</Snippet15>

        Return var
    End Function


    '****************************************************************************
    Shared Function OperatorRightShift() As Short

        '<Snippet14>
        Dim pattern As Short = 2560
        ' The bit pattern is 0000 1010 0000 0000.
        Dim result1, result2, result3, result4, result5 As Short
        result1 = pattern >> 0
        result2 = pattern >> 4
        result3 = pattern >> 10
        result4 = pattern >> 18
        result5 = pattern >> -1
        '</Snippet14>

        Return result2
    End Function


    '****************************************************************************
    Shared Function OperatorLeftShiftEquals() As Integer

        '<Snippet13>
        Dim var As Integer = 10
        Dim shift As Integer = 3
        var <<= shift
        ' The value of var is now 80.
        '</Snippet13>

        Return var
    End Function


    '****************************************************************************
    Shared Function OperatorLeftShift() As Short

        '<Snippet12>
        Dim pattern As Short = 192
        ' The bit pattern is 0000 0000 1100 0000.
        Dim result1, result2, result3, result4, result5 As Short
        result1 = pattern << 0
        result2 = pattern << 4
        result3 = pattern << 9
        result4 = pattern << 17
        result5 = pattern << -1
        '</Snippet12>

        Return result2
    End Function


    '****************************************************************************
    Shared Function OperatorMinusEquals() As Integer

        '<Snippet11>
        Dim var1 As Integer = 10
        Dim var2 As Integer = 3
        var1 -= var2
        ' The value of var1 is now 7.
        '</Snippet11>

        Return var1
    End Function


    '****************************************************************************
    Shared Function OperatorMinus() As Double

        '<Snippet10>
        Dim binaryResult As Double = 459.35 - 334.9
        Dim unaryResult As Double = -334.9
        '</Snippet10>

        'Return binaryResult
        Return unaryResult
    End Function


    '****************************************************************************
    Shared Function OperatorEquals() As String

        '<Snippet9>
        Dim testInt As Integer
        Dim testString As String
        Dim testButton As System.Windows.Forms.Button
        Dim testObject As Object
        testInt = 42
        testString = "This is an example of a string literal."
        testButton = New System.Windows.Forms.Button()
        testObject = testInt
        testObject = testString
        testObject = testButton
        '</Snippet9>

        Return "Okay"
    End Function


    '****************************************************************************
    Shared Function OperatorAddEqualsStr() As String

        '<Snippet8>
        ' This part uses string variables.
        Dim str1 As String = "10"
        Dim str2 As String = "3"
        str1 += str2
        '</Snippet8>

        Return str1
    End Function


    '****************************************************************************
    Shared Function OperatorAddEqualsNum() As Integer

        '<Snippet7>
        ' This part uses numeric variables.
        Dim num1 As Integer = 10
        Dim num2 As Integer = 3
        num1 += num2
        '</Snippet7>

        Return num1
    End Function


    '****************************************************************************
    Shared Function OperatorAdd() As Integer

        '<Snippet6>
        Dim sumNumber As Integer
        sumNumber = 2 + 2
        sumNumber = 4257.04 + 98112
        ' The preceding statements set sumNumber to 4 and 102369.
        '</Snippet6>

        Return sumNumber
    End Function


    '****************************************************************************
    Shared Function OperatorMultEquals() As Integer

        '<Snippet5>
        Dim var1 As Integer = 10
        Dim var2 As Integer = 3
        var1 *= var2
        ' The value of var1 is now 30.
        '</Snippet5>

        Return var1
    End Function


    '****************************************************************************
    Shared Function OperatorMult() As Double

        '<Snippet4>
        Dim testValue As Double
        testValue = 2 * 2
        ' The preceding statement sets testValue to 4.
        testValue = 459.35 * 334.9
        ' The preceding statement sets testValue to 153836.315.
        '</Snippet4>

        Return testValue
    End Function


    '****************************************************************************
    Shared Function OperatorAmpersandEquals() As String

        '<Snippet3>
        Dim var1 As String = "Hello "
        Dim var2 As String = "World!"
        var1 &= var2
        ' The value of var1 is now "Hello World!".
        '</Snippet3>

        Return var1
    End Function


    '****************************************************************************
    Shared Function OperatorAmpersand() As String

        '<Snippet2>
        Dim sampleStr As String
        sampleStr = "Hello" & " World"
        ' The preceding statement sets sampleStr to "Hello World".
        '</Snippet2>

        Return sampleStr
    End Function


    '****************************************************************************
    Shared Function ComparisonOperators() As Boolean

        '<Snippet1>
        Dim testResult As Boolean
        testResult = 45 < 35
        testResult = 45 = 45
        testResult = 4 <> 3
        testResult = "5" > "4444"
        '</Snippet1>

        Return testResult
    End Function


    '****************************************************************************
    Class testClass
    End Class

    '****************************************************************************
    Class customer
    End Class

    '****************************************************************************
    Class classA
    End Class

    '****************************************************************************
    Class classB
    End Class
End Class
