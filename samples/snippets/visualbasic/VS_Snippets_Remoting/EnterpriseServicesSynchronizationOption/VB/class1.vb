' <snippet0>
Imports System
Imports System.EnterpriseServices
Imports System.Reflection


' References:
' System.EnterpriseServices

' An instance of this class will not join an activity, but can share its
' caller's context even if its caller is configured as NotSupported,
' Supported, Required, or RequiresNew.
<Synchronization(SynchronizationOption.Disabled)>  _
Public Class SynchronizationAttribute_SynchronizationDisabled
    Inherits ServicedComponent
End Class 'SynchronizationAttribute_SynchronizationDisabled

' An instance of this class will not join an activity, and will share its
' caller's context only if its caller is also configured as NotSupported.
<Synchronization(SynchronizationOption.NotSupported)>  _
Public Class SynchronizationAttribute_SynchronizationNotSupported
    Inherits ServicedComponent
End Class 'SynchronizationAttribute_SynchronizationNotSupported

' An instance of this class will join its caller's activity if one exists.
<Synchronization(SynchronizationOption.Supported)>  _
Public Class SynchronizationAttribute_SynchronizationSupported
    Inherits ServicedComponent
End Class 'SynchronizationAttribute_SynchronizationSupported

' An instance of this class will join its caller's activity if one exists.
' If not, a new activity will be created for it.
<Synchronization(SynchronizationOption.Required)>  _
Public Class SynchronizationAttribute_SynchronizationRequired
    Inherits ServicedComponent
End Class 'SynchronizationAttribute_SynchronizationRequired

' A new activity will always be created for an instance of this class.
<Synchronization(SynchronizationOption.RequiresNew)>  _
Public Class SynchronizationAttribute_SynchronizationRequiresNew
    Inherits ServicedComponent
End Class 'SynchronizationAttribute_SynchronizationRequiresNew

' </snippet0>

'add Main so code compiles
Public Class Test
    
    Public Shared Sub Main() 
    
    End Sub 'Main
End Class 'Test 