' <snippet1>
Imports System
Imports System.ComponentModel

' The following example demonstrates how to create
' a resource class that implements the IDisposable interface
' and the IDisposable.Dispose method.
Public Class DisposeExample

   ' A class that implements IDisposable.
   ' By implementing IDisposable, you are announcing that 
   ' instances of this type allocate scarce resources.
   Public Class MyResource
      Implements IDisposable
      ' Pointer to an external unmanaged resource.
      Private handle As IntPtr
      ' Other managed resource this class uses.
      Private component As component
      ' Track whether Dispose has been called.
      Private disposed As Boolean = False

      ' The class constructor.
      Public Sub New(ByVal handle As IntPtr)
         Me.handle = handle
      End Sub

      ' Implement IDisposable.
      ' Do not make this method virtual.
      ' A derived class should not be able to override this method.
      Public Overloads Sub Dispose() Implements IDisposable.Dispose
         Dispose(True)
         ' This object will be cleaned up by the Dispose method.
         ' Therefore, you should call GC.SupressFinalize to
         ' take this object off the finalization queue 
         ' and prevent finalization code for this object
         ' from executing a second time.
         GC.SuppressFinalize(Me)
      End Sub

      ' Dispose(bool disposing) executes in two distinct scenarios.
      ' If disposing equals true, the method has been called directly
      ' or indirectly by a user's code. Managed and unmanaged resources
      ' can be disposed.
      ' If disposing equals false, the method has been called by the 
      ' runtime from inside the finalizer and you should not reference 
      ' other objects. Only unmanaged resources can be disposed.
      Protected Overridable Overloads Sub Dispose(ByVal disposing As Boolean)
         ' Check to see if Dispose has already been called.
         If Not Me.disposed Then
            ' If disposing equals true, dispose all managed 
            ' and unmanaged resources.
            If disposing Then
               ' Dispose managed resources.
               component.Dispose()
            End If

            ' Call the appropriate methods to clean up 
            ' unmanaged resources here.
            ' If disposing is false, 
            ' only the following code is executed.
            CloseHandle(handle)
            handle = IntPtr.Zero

            ' Note disposing has been done.
            disposed = True

         End If
      End Sub

      ' Use interop to call the method necessary  
      ' to clean up the unmanaged resource.
      <System.Runtime.InteropServices.DllImport("Kernel32")> _
      Private Shared Function CloseHandle(ByVal handle As IntPtr) As [Boolean]
      End Function

      ' This finalizer will run only if the Dispose method 
      ' does not get called.
      ' It gives your base class the opportunity to finalize.
      ' Do not provide finalize methods in types derived from this class.
      Protected Overrides Sub Finalize()
         ' Do not re-create Dispose clean-up code here.
         ' Calling Dispose(false) is optimal in terms of
         ' readability and maintainability.
         Dispose(False)
         MyBase.Finalize()
      End Sub
   End Class

   Public Shared Sub Main()
      ' Insert code here to create
      ' and use the MyResource object.
   End Sub

End Class
' </snippet1>