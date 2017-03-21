      [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
      public override IntPtr SupportsInterface(ref Guid myGuid)
      {
         Console.WriteLine("SupportsInterface method called");
         // Object reference is requested for communication with unmanaged objects
         // in the current process through COM.
         IntPtr myIntPtr = this.GetCOMIUnknown(false);
         // Stores an unmanaged proxy of the object.
         this.SetCOMIUnknown(myIntPtr);
         // return COM Runtime Wrapper pointer.
         return myIntPtr;
      }