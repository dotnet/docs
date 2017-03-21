    ' Return a new object that matches 'this' object's permissions.
    Public Overrides Function Copy() As IPermission
        Return CType(Clone(), IPermission)

    End Function 'Copy
