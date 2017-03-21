    ' Return a new object that contains the union of 'this' and 'target'.
    ' Note: You do not have to implement this method. If you do not, the version
    ' in CodeAccessPermission does this:
    '    1. If target is not null, a NotSupportedException is thrown.
    '    2. If target is null, then Copy is called and the new object is returned.
    Public Overrides Function Union(ByVal target As IPermission) As IPermission
        ' If 'target' is null, then return a copy of 'this'.
        If target Is Nothing Then
            Return Copy()
        End If
        ' Both objects must be the same type.
        Dim soundPerm As SoundPermission = VerifyTypeMatch(target)

        ' If 'this' or 'target' are unrestricted, return a new unrestricted permission.
        If m_specifiedAsUnrestricted OrElse soundPerm.m_specifiedAsUnrestricted Then
            Return Clone(True, SoundPermissionState.PlayAnySound)
        End If
        ' Return a new object with the calculated, unioned permission value.
        Return Clone(False, CType(Math.Max(CType(m_flags, Int32), CType(soundPerm.m_flags, Int32)), SoundPermissionState))

    End Function 'Union