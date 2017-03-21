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