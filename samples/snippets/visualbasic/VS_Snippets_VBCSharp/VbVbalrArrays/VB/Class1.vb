Option Strict On
Imports System.Collections.Generic
Imports System.Diagnostics

Class VbVbalrArrays
    '<Snippet1>
    ' Define the class for a customer.
    Public Class Customer
        Public Property Name As String
        ' Insert code for other members of customer structure.
    End Class

    ' Create a module-level collection that can hold 200 elements.
    Public CustomerList As New List(Of Customer)(200)

    ' Add a specified customer to the collection.
    Private Sub AddNewCustomer(ByVal newCust As Customer)
        ' Insert code to perform validity check on newCust.
        CustomerList.Add(newCust)
    End Sub

    ' Display the list of customers in the Debug window.
    Private Sub PrintCustomers()
        For Each cust As Customer In CustomerList
            Debug.WriteLine(cust)
        Next cust
    End Sub
    '</Snippet1>


    '<Snippet4>
    Public Sub FindAnimal()
        Dim zooAnimals(2) As String
        zooAnimals(0) = "lion"
        zooAnimals(1) = "turtle"
        zooAnimals(2) = "ostrich"

        Dim turtleIndex = (Array.IndexOf(zooAnimals, "turtle"))
        MsgBox("The turtle is element " & turtleIndex)
    End Sub
    '</Snippet4>



    Public Sub Declarations()
        '<Snippet7>
        ' Declare a one-dimensional array.
        Dim cargoWeights As Double()

        ' Dimension the array.
        ReDim cargoWeights(15)
        '</Snippet7>

        '<Snippet8>
        ' Declare a multidimensional array.
        Dim atmospherePressures As Short(,,,)

        ' Dimension the array.
        ReDim atmospherePressures(1, 2, 3, 4)
        '</Snippet8>

        '<Snippet9>
        Dim inquiriesByYearMonthDay()()() As Byte
        '</Snippet9>
        '<Snippet14>
        Dim twoDimensionalStrings(-1, 3) As String
        '</Snippet14>
    End Sub

    Sub Snippet15()
        '<Snippet15>
        Dim thisTwoDimArray(,) As Integer = New Integer(9, 9) {}
        MsgBox("Type of thisTwoDimArray is " & TypeName(thisTwoDimArray))
        MsgBox("Type of thisTwoDimArray(0, 0) is " & TypeName(thisTwoDimArray(0, 0)))
        '</Snippet15>
    End Sub

    Sub InitializationHowTo()
        '<Snippet16>
        ' The following five lines of code create the same array.
        ' Preferred syntaxes are on the lines with chars1 and chars2.
        Dim chars1 = {"%"c, "&"c, "@"c}
        Dim chars2 As Char() = {"%"c, "&"c, "@"c}

        Dim chars3() As Char = {"%"c, "&"c, "@"c}
        Dim chars4 As Char() = New Char(2) {"%"c, "&"c, "@"c}
        Dim chars5() As Char = New Char(2) {"%"c, "&"c, "@"c}
        '</Snippet16>

        '<Snippet17>
        Dim numbers = {{1, 2}, {3, 4}, {5, 6}}
        Dim customerData = {{"City Power & Light", "http://www.cpandl.com/"},
                            {"Wide World Importers", "http://wideworldimporters.com"},
                            {"Lucerne Publishing", "http://www.lucernepublishing.com"}}

        ' You can nest array literals to create arrays that have more than two 
        ' dimensions.
        Dim twoSidedCube = {{{1, 2}, {3, 4}}, {{5, 6}, {7, 8}}}
        '</Snippet17>

        '<Snippet18>
        ' The following five lines of code create the same array.
        ' Preferred syntaxes are on the lines with scores1 and scores2.
        Dim scores1 = {{10S, 10S, 10S}, {10S, 10S, 10S}}
        Dim scores2 As Short(,) = {{10, 10, 10}, {10, 10, 10}}

        Dim scores3(,) As Short = {{10, 10, 10}, {10, 10, 10}}
        Dim scores4 As Short(,) = New Short(1, 2) {{10, 10, 10}, {10, 10, 10}}
        Dim scores5(,) As Short = New Short(1, 2) {{10, 10, 10}, {10, 10, 10}}
        '</Snippet18>

        '<Snippet19>
        ' Create a jagged array of arrays that have different lengths.
        Dim jaggedNumbers = {({1, 2, 3}), ({4, 5}), ({6}), ({7})}

        ' Create a jagged array of Byte arrays.
        Dim images = {New Byte() {}, New Byte() {}, New Byte() {}}
        '</Snippet19>
    End Sub

    Private Sub IterateMultidimensional()
        '<Snippet31>
        Dim numbers = {{1, 2}, {3, 4}, {5, 6}}

        ' Iterate through the array.
        For index0 = 0 To numbers.GetUpperBound(0)
            For index1 = 0 To numbers.GetUpperBound(1)
                Debug.Write(numbers(index0, index1).ToString & " ")
            Next
            Debug.WriteLine("")
        Next
        ' Output
        '  1 2
        '  3 4
        '  5 6
        '</Snippet31>
    End Sub

    Private Sub IterateJagged()
        '<Snippet32>
        ' Create a jagged array of arrays that have different lengths.
        Dim jaggedNumbers = {({1, 2, 3}), ({4, 5}), ({6}), ({7})}

        For indexA = 0 To jaggedNumbers.Length - 1
            For indexB = 0 To jaggedNumbers(indexA).Length - 1
                Debug.Write(jaggedNumbers(indexA)(indexB) & " ")
            Next
            Debug.WriteLine("")
        Next

        ' Output:
        '  1 2 3 
        '  4 5 
        '  6
        '  7
        '</Snippet32>
    End Sub


    Private Sub JaggedArray()
        '<Snippet21>
        ' Declare the jagged array.
        ' The New clause sets the array variable to a 12-element
        ' array. Each element is an array of Double elements.
        Dim sales()() As Double = New Double(11)() {}

        ' Set each element of the sales array to a Double
        ' array of the appropriate size.
        For month As Integer = 0 To 11
            Dim days As Integer =
                DateTime.DaysInMonth(Year(Now), month + 1)
            sales(month) = New Double(days - 1) {}
        Next month

        ' Store values in each element.
        For month As Integer = 0 To 11
            Dim upper = sales(month).GetUpperBound(0)
            For day = 0 To upper
                sales(month)(day) = (month * 100) + day
            Next
        Next
        '</Snippet21>
    End Sub


    Public Sub ForNextSingle()
        '<Snippet41>
        Dim numbers = {10, 20, 30}

        For index = 0 To numbers.GetUpperBound(0)
            Debug.WriteLine(numbers(index))
        Next
        ' Output:
        '  10
        '  20
        '  30
        '</Snippet41>
    End Sub

    Public Sub ForNextMult()
        '<Snippet42>
        Dim numbers = {{1, 2}, {3, 4}, {5, 6}}

        For index0 = 0 To numbers.GetUpperBound(0)
            For index1 = 0 To numbers.GetUpperBound(1)
                Debug.Write(numbers(index0, index1).ToString & " ")
            Next
            Debug.WriteLine("")
        Next
        ' Output 
        '  1 2 
        '  3 4 
        '  5 6
        '</Snippet42>
    End Sub

    Public Sub ForEachSingle()
        '<Snippet43>
        Dim numbers = {10, 20, 30}

        For Each number In numbers
            Debug.WriteLine(number)
        Next
        ' Output:
        '  10
        '  20
        '  30
        '</Snippet43>
    End Sub

    Public Sub ForEachMult()
        '<Snippet44>
        Dim numbers = {{1, 2}, {3, 4}, {5, 6}}

        For Each number In numbers
            Debug.WriteLine(number)
        Next
        ' Output:
        '  1
        '  2
        '  3
        '  4
        '  5
        '  6
        '</Snippet44>
    End Sub


    '<Snippet51>
    Public Sub Process()
        Dim numbers As Integer() = GetNumbers()
        ShowNumbers(numbers)
    End Sub

    Private Function GetNumbers() As Integer()
        Dim numbers As Integer() = {10, 20, 30}
        Return numbers
    End Function

    Private Sub ShowNumbers(numbers As Integer())
        For index = 0 To numbers.GetUpperBound(0)
            Debug.WriteLine(numbers(index) & " ")
        Next
    End Sub

    ' Output:
    '   10
    '   20
    '   30
    '</Snippet51>


    '<Snippet52>
    Public Sub ProcessMultidim()
        Dim numbers As Integer(,) = GetNumbersMultidim()
        ShowNumbersMultidim(numbers)
    End Sub

    Private Function GetNumbersMultidim() As Integer(,)
        Dim numbers As Integer(,) = {{1, 2}, {3, 4}, {5, 6}}
        Return numbers
    End Function

    Private Sub ShowNumbersMultidim(numbers As Integer(,))
        For index0 = 0 To numbers.GetUpperBound(0)
            For index1 = 0 To numbers.GetUpperBound(1)
                Debug.Write(numbers(index0, index1).ToString & " ")
            Next
            Debug.WriteLine("")
        Next
    End Sub

    ' Output  
    '  1 2  
    '  3 4  
    '  5 6
    '</Snippet52>

End Class

Module Module1
    Public Sub TestArrays()
        Dim test As New VbVbalrArrays()

        Debug.WriteLine("ForNextSingle")
        test.ForNextSingle()
        Debug.WriteLine("ForNextMult")
        test.ForNextMult()
        Debug.WriteLine("ForEachSingle")
        test.ForEachSingle()
        Debug.WriteLine("ForEachMult")
        test.ForEachMult()
        Debug.WriteLine("Process")
        test.Process()
        Debug.WriteLine("ProcessMultidim")
        test.ProcessMultidim()

        test.Snippet2()
        test.FindAnimal()
        test.Snippet5()
        test.Snippet6()
        test.Snippet15()
    End Sub
End Module
