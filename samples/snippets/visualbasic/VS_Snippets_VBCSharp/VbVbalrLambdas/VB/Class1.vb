'Option Strict On

Imports System.Collections.Generic

Module Module0

    Sub Main()
        '<Snippet14>
        Dim increment1 = Function(x) x + 1
        Dim increment2 = Function(x)
                             Return x + 2
                         End Function

        ' Write the value 2.
        Console.WriteLine(increment1(1))

        ' Write the value 4.
        Console.WriteLine(increment2(2))
        '</Snippet14>

        '<Snippet15>
        Dim writeline1 = Sub(x) Console.WriteLine(x)
        Dim writeline2 = Sub(x)
                             Console.WriteLine(x)
                         End Sub

        ' Write "Hello".
        writeline1("Hello")

        ' Write "World"
        writeline2("World")
        '</Snippet15>

        '<Snippet17>
        Dim writeMessage = Sub(msg As String) Console.WriteLine(msg)
        '</Snippet17>

        '<Snippet18>
        ' The following line prints "Hello".
        writeMessage("Hello")
        '</Snippet18>

        '<Snippet19>
        Dim getSortColumn = Function(index As Integer)
                                Select Case index
                                    Case 0
                                        Return "FirstName"
                                    Case 1
                                        Return "LastName"
                                    Case 2
                                        Return "CompanyName"
                                    Case Else
                                        Return "LastName"
                                End Select
                            End Function
        '</Snippet19>

        '<Snippet20>
        Dim sortColumn = getSortColumn(0)
        '</Snippet20>

        '<Snippet21>
        Dim writeToLog = Sub(msg As String)
                             Dim log As New EventLog()
                             log.Source = "Application"
                             log.WriteEntry(msg)
                             log.Close()
                         End Sub
        '</Snippet21>

        '<Snippet22>
        writeToLog("Application started.")
        '</Snippet22>


        '<Snippet1>
        Dim add1 = Function(num As Integer) num + 1
        '</Snippet1>

        '<Snippet2>
        ' The following line prints 6.
        Console.WriteLine(add1(5))
        '</Snippet2>

        '<Snippet3>
        Console.WriteLine((Function(num As Integer) num + 1)(5))
        '</Snippet3>

        '<Snippet4>
        Dim notNothing =
          Function(num? As Integer) num IsNot Nothing
        Dim arg As Integer = 14
        Console.WriteLine("Does the argument have an assigned value?")
        Console.WriteLine(notNothing(arg))
        '</Snippet4>

        '<Snippet5>
        Dim numbers() = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}
        Dim lastIndex =
          Function(intArray() As Integer) intArray.Length - 1
        For i = 0 To lastIndex(numbers)
            numbers(i) += 1
        Next
        '</Snippet5>

    End Sub

    '<Snippet16>
    ' Explicitly specify a delegate type.
    Delegate Function MultipleOfTen(ByVal num As Integer) As Boolean

    ' This function matches the delegate type.
    Function IsMultipleOfTen(ByVal num As Integer) As Boolean
        Return num Mod 10 = 0
    End Function

    ' This method takes an input parameter of the delegate type. 
    ' The checkDelegate parameter could also be of 
    ' type Func(Of Integer, Boolean).
    Sub CheckForMultipleOfTen(ByVal values As Integer(),
                              ByRef checkDelegate As MultipleOfTen)
        For Each value In values
            If checkDelegate(value) Then
                Console.WriteLine(value & " is a multiple of ten.")
            Else
                Console.WriteLine(value & " is not a multiple of ten.")
            End If
        Next
    End Sub

    ' This method shows both an explicitly defined delegate and a
    ' lambda expression passed to the same input parameter.
    Sub CheckValues()
        Dim values = {5, 10, 11, 20, 40, 30, 100, 3}
        CheckForMultipleOfTen(values, AddressOf IsMultipleOfTen)
        CheckForMultipleOfTen(values, Function(num) num Mod 10 = 0)
    End Sub
    '</Snippet16>

End Module



