    ' Add Imports System.Linq.Expressions
    ' to the beginning of the file.
    ' The class derived from DynamicObject.
    Public Class DynamicNumber
        Inherits DynamicObject

        ' The inner dictionary to store field names and values.
        Dim dictionary As New Dictionary(Of String, Object)

        ' Get the property value.
        Public Overrides Function TryGetMember(
            ByVal binder As System.Dynamic.GetMemberBinder,
            ByRef result As Object) As Boolean

            Return dictionary.TryGetValue(binder.Name, result)

        End Function

        ' Set the property value.
        Public Overrides Function TrySetMember(
            ByVal binder As System.Dynamic.SetMemberBinder,
            ByVal value As Object) As Boolean

            dictionary(binder.Name) = value
            Return True

        End Function

        ' Perform the binary operation. 
        Public Overrides Function TryBinaryOperation(
            ByVal binder As System.Dynamic.BinaryOperationBinder,
            ByVal arg As Object, ByRef result As Object) As Boolean

            ' The Textual property contains the textual representaion 
            ' of two numbers, in addition to the name of the binary operation.
            Dim resultTextual As String =
                dictionary("Textual") & " " &
                binder.Operation.ToString() & " " &
            CType(arg, DynamicNumber).dictionary("Textual")

            Dim resultNumeric As Integer

            ' Checking what type of operation is being performed.
            Select Case binder.Operation
                ' Proccessing mathematical addition (a + b).
                Case ExpressionType.Add
                    resultNumeric =
                    CInt(dictionary("Numeric")) +
                    CInt((CType(arg, DynamicNumber)).dictionary("Numeric"))

                    ' Processing mathematical substraction (a - b).
                Case ExpressionType.Subtract
                    resultNumeric =
                    CInt(dictionary("Numeric")) -
                    CInt((CType(arg, DynamicNumber)).dictionary("Numeric"))

                Case Else
                    ' In case of any other binary operation,
                    ' print out the type of operation and return false,
                    ' which means that the language should determine 
                    ' what to do.
                    ' (Usually the language just throws an exception.)
                    Console.WriteLine(
                        binder.Operation.ToString() &
                        ": This binary operation is not implemented")
                    result = Nothing
                    Return False
            End Select

            Dim finalResult As Object = New DynamicNumber()
            finalResult.Textual = resultTextual
            finalResult.Numeric = resultNumeric
            result = finalResult
            Return True
        End Function
    End Class

    Sub Test()
        ' Creating the first dynamic number.
        Dim firstNumber As Object = New DynamicNumber()

        ' Creating properties and setting their values
        ' for the first dynamic number. 
        ' The TrySetMember method is called.
        firstNumber.Textual = "One"
        firstNumber.Numeric = 1

        ' Printing out properties. The TryGetMember method is called.
        Console.WriteLine(
            firstNumber.Textual & " " & firstNumber.Numeric)

        ' Creating the second dynamic number.
        Dim secondNumber As Object = New DynamicNumber()
        secondNumber.Textual = "Two"
        secondNumber.Numeric = 2
        Console.WriteLine(
            secondNumber.Textual & " " & secondNumber.Numeric)

        Dim resultNumber As Object = New DynamicNumber()

        ' Adding two numbers. TryBinaryOperation is called.
        resultNumber = firstNumber + secondNumber
        Console.WriteLine(
            resultNumber.Textual & " " & resultNumber.Numeric)

        ' Subtracting two numbers. TryBinaryOperation is called.
        resultNumber = firstNumber - secondNumber
        Console.WriteLine(
            resultNumber.Textual & " " & resultNumber.Numeric)

        ' The following statement produces a run-time exception
        ' because the multiplication operation is not implemented.
        ' resultNumber = firstNumber * secondNumber
    End Sub

    ' This code example produces the following output:

    ' One 1
    ' Two 2
    ' One Add Two 3
    ' One Subtract Two -1