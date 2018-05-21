    ' Implement the TryGetMember method of the DynamicObject class for dynamic member calls.
    Public Overrides Function TryGetMember(ByVal binder As GetMemberBinder,
                                           ByRef result As Object) As Boolean
        result = GetPropertyValue(binder.Name)
        Return If(result Is Nothing, False, True)
    End Function