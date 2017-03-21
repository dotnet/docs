      ' Creates a copy of the intersect SocketPermission.
      Dim mySocketPermissionIntersectCopy As SocketPermission = CType(mySocketPermissionIntersect.Copy(), SocketPermission)
      
      If mySocketPermissionIntersectCopy.Equals(mySocketPermissionIntersect) Then
         Console.WriteLine("Copy successfull")
      End If