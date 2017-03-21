    ' Called by the Demand method: returns true if 'this' is a subset of 'target'.
    Public Overrides Function IsSubsetOf(ByVal target As IPermission) As [Boolean]
        ' If 'target' is null and this permission allows nothing, return true.
        If target Is Nothing Then
            Return m_flags = 0
        End If
        ' Both objects must be the same type.
        Dim soundPerm As SoundPermission = VerifyTypeMatch(target)

        ' Return true if the permissions of 'this' is a subset of 'target'.
        Return m_flags <= soundPerm.m_flags

    End Function 'IsSubsetOf
