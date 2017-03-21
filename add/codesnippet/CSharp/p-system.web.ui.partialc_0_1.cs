// Set the PartialCachingAttribute.Duration property to
// 20 seconds and the PartialCachingAttribute.VaryByCustom
// property to browser.
[PartialCaching(20, null, null, "browser")]
public partial class ctlSelect : UserControl