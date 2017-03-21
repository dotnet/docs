    ' Return a new object that contains the intersection of 'this' and 'target'.
    Public Overrides Function Intersect(ByVal target As IPermission) As IPermission
        ' If 'target' is null, return null.
        If target Is Nothing Then
            Return Nothing
        End If
        ' Both objects must be the same type.
        Dim soundPerm As SoundPermission = VerifyTypeMatch(target)

        ' If 'this' and 'target' are unrestricted, return a new unrestricted permission.
        If m_specifiedAsUnrestricted AndAlso soundPerm.m_specifiedAsUnrestricted Then
            Return Clone(True, SoundPermissionState.PlayAnySound)
        End If
        ' Calculate the intersected permissions. If there are none, return null.
        Dim val As SoundPermissionState = CType(Math.Min(CType(m_flags, Int32), CType(soundPerm.m_flags, Int32)), SoundPermissionState)
        If val = 0 Then
            Return Nothing
        End If
        ' Return a new object with the intersected permission value.
        Return Clone(False, val)

    End Function 'Intersect
