    ' Implement the TryInvokeMember method of the DynamicObject class for 
    ' dynamic member calls that have arguments.
    Public Overrides Function TryInvokeMember(ByVal binder As InvokeMemberBinder,
                                              ByVal args() As Object,
                                              ByRef result As Object) As Boolean

        Dim StringSearchOption As StringSearchOption = StringSearchOption.StartsWith
        Dim trimSpaces = True

        Try
            If args.Length > 0 Then StringSearchOption = CType(args(0), StringSearchOption)
        Catch
            Throw New ArgumentException("StringSearchOption argument must be a StringSearchOption enum value.")
        End Try

        Try
            If args.Length > 1 Then trimSpaces = CType(args(1), Boolean)
        Catch
            Throw New ArgumentException("trimSpaces argument must be a Boolean value.")
        End Try

        result = GetPropertyValue(binder.Name, StringSearchOption, trimSpaces)

        Return If(result Is Nothing, False, True)
    End Function