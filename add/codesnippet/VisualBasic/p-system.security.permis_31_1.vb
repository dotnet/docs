    ' Set the Read, PathDiscovery, Append, Write, and All properties.
    <FileIOPermissionAttribute(SecurityAction.PermitOnly, Read:="C:\"), _
    FileIOPermissionAttribute(SecurityAction.PermitOnly, _
    PathDiscovery:="C:\Documents and Settings\All Users"), _
    FileIOPermissionAttribute(SecurityAction.PermitOnly, _
    Append:="C:\Documents and Settings\All Users\Application Data"), _
    FileIOPermissionAttribute(SecurityAction.PermitOnly, _
        Write:="C:\Documents and Settings\All Users\Application Data\Microsoft"), _
    FileIOPermissionAttribute(SecurityAction.PermitOnly, _
        All:="C:\Documents and Settings\All Users\Application Data\Microsoft\Network")> _
    Public Shared Sub PermitOnlyMethod()