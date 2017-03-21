    ' An interface that the transformer provides to the consumer.
    <AspNetHostingPermission(SecurityAction.Demand, _
       Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
       Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Interface IString
        Sub GetStringValue(ByVal callback As StringCallback)
    End Interface