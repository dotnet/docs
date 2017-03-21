WindowsIdentity clientId = null;
WindowsImpersonationContext impersonatedUser = null;

clientId = SqlContext.WindowsIdentity;

// This outer try block is used to thwart exception filter attacks which would prevent
// the inner finally block from executing and resetting the impersonation.
try
{
   try
   {
      impersonatedUser = clientId.Impersonate();
      if (impersonatedUser != null)
      {
        // Perform some action using impersonation.
      }
      
   }
   finally
   {
      if (impersonatedUser != null)
         impersonatedUser.Undo();
   }
}
catch
{
   throw;
}
