    ' Returns true if permission is effectively unrestricted.
    Public Function IsUnrestricted() As [Boolean] Implements IUnrestrictedPermission.IsUnrestricted
        ' This means that the object is unrestricted at runtime.
        Return m_flags = SoundPermissionState.PlayAnySound

    End Function 'IsUnrestricted