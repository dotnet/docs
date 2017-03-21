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

        ' Perform the unary operation. 
        Public Overrides Function TryUnaryOperation(
            ByVal binder As System.Dynamic.UnaryOperationBinder,
            ByRef result As Object) As Boolean

            ' The Textual property contains the name of the unary operation
            ' in addition to the textual representaion of the number.
            Dim resultTextual As String =
            binder.Operation.ToString() & " " &
            dictionary("Textual")
            Dim resultNumeric As Integer

            ' Determining what type of operation is being performed.
            Select Case binder.Operation
                Case ExpressionType.Negate
                    resultNumeric = -CInt(dictionary("Numeric"))
                Case Else
                    ' In case of any other unary operation,
                    ' print out the type of operation and return false,
                    ' which means that the language should determine 
                    ' what to do.
                    ' (Usually the language just throws an exception.)            
                    Console.WriteLine(
                        binder.Operation.ToString() &
                        ": This unary operation is not implemented")
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
        Dim number As Object = New DynamicNumber()

        ' Creating properties and setting their values
        ' for the dynamic number.
        ' The TrySetMember method is called.
        number.Textual = "One"
        number.Numeric = 1

        ' Printing out properties. The TryGetMember method is called.
        Console.WriteLine(
            number.Textual & " " & number.Numeric)

        Dim negativeNumber As Object = New DynamicNumber()

        ' Performing a mathematical negation.
        ' The TryUnaryOperation is called.
        negativeNumber = -number

        Console.WriteLine(
            negativeNumber.Textual & " " & negativeNumber.Numeric)

        ' The following statement produces a run-time exception
        ' because the unary plus operation is not implemented.
        'negativeNumber = +number
    End Sub

    ' This code example produces the following output:

    ' One 1
    ' Negate One -1