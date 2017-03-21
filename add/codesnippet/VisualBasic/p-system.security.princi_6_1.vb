 Dim wp As New WindowsPrincipal(WindowsIdentity.GetCurrent())
 Dim username As String = wp.Identity.Name
