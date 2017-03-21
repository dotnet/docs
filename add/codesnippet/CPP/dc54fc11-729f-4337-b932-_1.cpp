void IntPtrStringConstructor( IntPtr logonToken )
{
   
   // Construct a WindowsIdentity object using the input account token 
   // and the specified authentication type.
   String^ authenticationType = "WindowsAuthentication";
   WindowsIdentity^ windowsIdentity = gcnew WindowsIdentity( logonToken,authenticationType );
   
   Console::WriteLine( "Created a Windows identity object named {0}.", windowsIdentity->Name );
}
