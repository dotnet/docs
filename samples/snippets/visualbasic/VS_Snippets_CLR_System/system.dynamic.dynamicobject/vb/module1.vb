Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Dynamic
Imports System.Linq.Expressions
Imports System.Reflection

' Class description, TrySetMember, TryGetMember
Module Module1
    '<Snippet1>
    ' The class derived from DynamicObject.
    Public Class DynamicDictionary
        Inherits DynamicObject

        ' The inner dictionary.
        Dim dictionary As New Dictionary(Of String, Object)

        ' This property returns the number of elements
        ' in the inner dictionary.
        ReadOnly Property Count As Integer
            Get
                Return dictionary.Count
            End Get
        End Property


        ' If you try to get a value of a property that is
        ' not defined in the class, this method is called.

        Public Overrides Function TryGetMember(
            ByVal binder As System.Dynamic.GetMemberBinder,
            ByRef result As Object) As Boolean

            ' Converting the property name to lowercase
            ' so that property names become case-insensitive.
            Dim name As String = binder.Name.ToLower()

            ' If the property name is found in a dictionary,
            ' set the result parameter to the property value and return true.
            ' Otherwise, return false.
            Return dictionary.TryGetValue(name, result)
        End Function

        Public Overrides Function TrySetMember(
            ByVal binder As System.Dynamic.SetMemberBinder,
            ByVal value As Object) As Boolean

            ' Converting the property name to lowercase
            ' so that property names become case-insensitive.
            dictionary(binder.Name.ToLower()) = value

            ' You can always add a value to a dictionary,
            ' so this method always returns true.
            Return True
        End Function
    End Class

    Sub Main()
        ' Creating a dynamic dictionary.
        Dim person As Object = New DynamicDictionary()

        ' Adding new dynamic properties.
        ' The TrySetMember method is called.
        person.FirstName = "Ellen"
        person.LastName = "Adams"

        ' Getting values of the dynamic properties.
        ' The TryGetMember method is called.
        ' Note that property names are now case-insensitive,
        ' although they are case-sensitive in C#.
        Console.WriteLine(person.firstname & " " & person.lastname)

        ' Getting the value of the Count property.
        ' The TryGetMember is not called, 
        ' because the property is defined in the class.
        Console.WriteLine("Number of dynamic properties:" & person.Count)

        ' The following statement throws an exception at run time.
        ' There is no "address" property,
        ' so the TryGetMember method returns false and this causes
        ' a MissingMemberException.
        ' Console.WriteLine(person.address)
    End Sub
    ' This examples has the following output:
    ' Ellen Adams
    ' Number of dynamic properties: 2
    '</Snippet1>

End Module

'TryBinaryOperation
Module M2
    '<Snippet2>
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
    '</Snippet2>
End Module

'TryConvert
Module M3
    '<Snippet3>
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

    '</Snippet3>
End Module

'TryGetIndex and TrySetIndex
Module M4
    '<Snippet4>
    ' The class derived from DynamicObject.
    Public Class SampleDynamicObject
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

        ' Set the property value by index.
        Public Overrides Function TrySetIndex(
            ByVal binder As System.Dynamic.SetIndexBinder,
            ByVal indexes() As Object, ByVal value As Object) As Boolean

            Dim index As Integer = CInt(indexes(0))
            ' If a corresponding property already exists, set the value.
            If (dictionary.ContainsKey("Property" & index)) Then
                dictionary("Property" & index) = value
            Else
                ' If a property does not exist, create it.
                dictionary.Add("Property" & index, value)
            End If
            Return True
        End Function

        ' Get the property value by index.
        Public Overrides Function TryGetIndex(
            ByVal binder As System.Dynamic.GetIndexBinder,
            ByVal indexes() As Object, ByRef result As Object) As Boolean

            Dim index = CInt(indexes(0))
            Return dictionary.TryGetValue("Property" & index, result)
        End Function
    End Class

    Sub Test()
        ' Creating a dynamic object.
        Dim sampleObject As Object = New SampleDynamicObject()

        ' Creating Property0.
        ' The TrySetMember method is called.
        sampleObject.Property0 = "Zero"

        ' Getting the value by index.
        ' The TryGetIndex method is called.
        Console.WriteLine(sampleObject(0))

        ' Setting the property value by index.
        ' The TrySetIndex method is called.
        ' (This method also creates Property1.)
        sampleObject(1) = 1

        ' Getting the Property1 value.
        ' The TryGetMember method is called.
        Console.WriteLine(sampleObject.Property1)

        ' The following statement produces a run-time exception
        ' because there is no corresponding property.
        ' Console.WriteLine(sampleObject(2))
    End Sub

    ' This code example produces the following output:

    ' Zero
    ' 1
    '</Snippet4>
End Module

' TryInvoke not supported in VB
Module M5

End Module

' TryInvokeMember
Module M6
    '<Snippet6>
    ' Add Imports System.Reflection
    ' to the beginning of the file.

    ' The class derived from DynamicObject.
    Public Class DynamicDictionary
        Inherits DynamicObject

        ' The inner dictionary.
        Dim dictionary As New Dictionary(Of String, Object)

        ' Getting a property value.
        Public Overrides Function TryGetMember(
            ByVal binder As System.Dynamic.GetMemberBinder,
            ByRef result As Object) As Boolean

            Return dictionary.TryGetValue(binder.Name, result)
        End Function

        ' Setting a property value.
        Public Overrides Function TrySetMember(
            ByVal binder As System.Dynamic.SetMemberBinder,
            ByVal value As Object) As Boolean

            dictionary(binder.Name) = value
            Return True
        End Function


        ' Calling a method.
        Public Overrides Function TryInvokeMember(
            ByVal binder As System.Dynamic.InvokeMemberBinder,
            ByVal args() As Object, ByRef result As Object) As Boolean

            Dim dictType As Type = GetType(Dictionary(Of String, Object))
            Try
                result = dictType.InvokeMember(
                             binder.Name,
                             BindingFlags.InvokeMethod,
                             Nothing, dictionary, args)
                Return True
            Catch ex As Exception
                result = Nothing
                Return False
            End Try
        End Function

        ' This method prints out dictionary elements.
        Public Sub Print()
            For Each pair In dictionary
                Console.WriteLine(pair.Key & " " & pair.Value)
            Next
            If (dictionary.Count = 0) Then
                Console.WriteLine("No elements in the dictionary.")
            End If
        End Sub
    End Class

    Sub Test()
        ' Creating a dynamic dictionary.
        Dim person As Object = New DynamicDictionary()

        ' Adding new dynamic properties.
        ' The TrySetMember method is called.
        person.FirstName = "Ellen"
        person.LastName = "Adams"

        ' Calling a method defined in the DynmaicDictionary class.
        ' The Print method is called.
        person.Print()

        Console.WriteLine(
            "Removing all the elements from the dictionary.")

        ' Calling a method that is not defined in the DynamicDictionary class.
        ' The TryInvokeMember method is called.
        person.Clear()

        ' Calling the Print method again.
        person.Print()

        ' The following statement throws an exception at run time.
        ' There is no Sample method 
        ' in the dictionary or in the DynamicDictionary class.
        ' person.Sample()
    End Sub


    ' This example has the following output:

    ' FirstName Ellen 
    ' LastName Adams
    ' Removing all the elements from the dictionary.
    ' No elements in the dictionary.
    '</Snippet6>
End Module

Module M7
    '<Snippet7>
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
    '</Snippet7>

End Module