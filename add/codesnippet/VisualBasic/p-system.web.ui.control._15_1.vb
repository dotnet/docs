        <System.Security.Permissions.PermissionSetAttribute( _
            System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
        Protected Overrides Function OnBubbleEvent(ByVal sender As Object, ByVal e As EventArgs) As Boolean

            ' Use the Context property to write text to the TraceContext object
            ' associated with the current request.         
            Context.Trace.Write("The ParentControl's OnBubbleEvent method is called.")
            Context.Trace.Write("The Source of event is: " + sender.ToString())

            Return True
        End Function 'OnBubbleEvent