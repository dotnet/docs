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