      <SecurityPermission(SecurityAction.LinkDemand, Flags := SecurityPermissionFlag.Infrastructure)> _
      Public Overrides Function SupportsInterface(ByRef myGuid As Guid) As IntPtr
         Console.WriteLine("SupportsInterface method called")
         ' Object reference is requested for communication with unmanaged objects
         ' in the current process through COM.
         Dim myIntPtr As IntPtr = Me.GetCOMIUnknown(False)
         ' Stores an unmanaged proxy of the object.
         Me.SetCOMIUnknown(myIntPtr)
         ' return COM Runtime Wrapper pointer.
         Return myIntPtr
      End Function 'SupportsInterface