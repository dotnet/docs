' Set the PartialCachingAttribute.Duration property to
' 20 seconds and the PartialCachingAttribute.VaryByCustom
' property to browser.
<PartialCaching(20, Nothing, Nothing, "browser")> _
Public Class ctlSelect
    Inherits UserControl