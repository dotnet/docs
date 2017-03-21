    ' Create a custom ControlCollection that writes
    ' information to the Trace log when an instance
    ' of the collection is created.
    <AspNetHostingPermission(SecurityAction.Demand, _
       Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomControlCollection
        Inherits ControlCollection

        Private context As HttpContext

        Public Sub New(ByVal owner As Control)
            MyBase.New(owner)
            HttpContext.Current.Trace.Write("The control collection is created.")
            ' Display the Name of the control
            ' that uses this collection when tracing is enabled.
            HttpContext.Current.Trace.Write("The owner is: " _
          & Me.Owner.ToString())
        End Sub


    End Class
