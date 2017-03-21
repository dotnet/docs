void IntPtrStringTypeConstructor( IntPtr logonToken )
{
   
   // Construct a WindowsIdentity object using the input account token,
   // and the specified authentication type and Windows account type.
   String^ authenticationType = "WindowsAuthentication";
   WindowsAccountType guestAccount = WindowsAccountType::Guest;
   WindowsIdentity^ windowsIdentity = gcnew WindowsIdentity( logonToken,authenticationType,guestAccount );
   
   Console::WriteLine( "Created a Windows identity object named {0}.", windowsIdentity->Name );
}