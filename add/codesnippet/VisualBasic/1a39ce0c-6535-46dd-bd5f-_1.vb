        ' Create an empty PublisherIdentityPermission to serve as the target of the copy.
        publisherPerm2 = New PublisherIdentityPermission(PermissionState.None)
        publisherPerm2 = CType(publisherPerm1.Copy(), PublisherIdentityPermission)
        Console.WriteLine("Result of copy = " + publisherPerm2.ToString())

    End Sub 'CopyDemo