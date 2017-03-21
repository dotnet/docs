    ' Set the PartialCachingAttribute.Duration property to
    ' 20 seconds and the PartialCachingAttribute.VaryByControls
    ' property to the ID of the server control to vary the output by.
    ' In this case, it is state, the ID assigned to a DropDownList
    ' server control.
    <PartialCaching(20, Nothing, "state", Nothing)> _
    Public Class ctlSelect
        Inherits UserControl