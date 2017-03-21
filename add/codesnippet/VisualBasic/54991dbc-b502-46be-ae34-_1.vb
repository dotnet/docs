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

        Public Overrides Function TryConvert(ByVal binder As System.Dynamic.ConvertBinder, ByRef result As Object) As Boolean
            ' Converting to string. 
            If binder.Type = GetType(String) Then
                result = dictionary("Textual")
                Return True
            End If

            ' Converting to integer.
            If binder.Type = GetType(Integer) Then
                result = dictionary("Numeric")
                Return True
            End If
            ' In case of any other type, the binder 
            ' attempts to perform the conversion itself.
            ' In most cases, a run-time exception is thrown.
            Return MyBase.TryConvert(binder, result)
        End Function
    End Class

    Sub Main()
        ' Creating the first dynamic number.
        Dim number As Object = New DynamicNumber()

        ' Creating properties and setting their values
        ' for the dynamic number.
        ' The TrySetMember method is called.
        number.Textual = "One"
        number.Numeric = 1


        ' Explicit conversion to string.
        Dim testString = CTypeDynamic(Of String)(number)
        Console.WriteLine(testString)

        ' Explicit conversion to integer.
        Dim testInteger = CTypeDynamic(number, GetType(Integer))
        Console.WriteLine(testInteger)

        ' The following statement produces a run-time exception
        ' because the conversion to double is not implemented.
        ' Dim testDouble = CTypeDynamic(Of Double)(number)

    End Sub
    ' This example has the following output:

    ' One
    ' 1
