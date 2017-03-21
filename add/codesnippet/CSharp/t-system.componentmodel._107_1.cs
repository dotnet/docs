    // This control demonstrates a simple logging capability. 
    [ComplexBindingProperties("DataSource", "DataMember")]
    [DefaultBindingProperty("TitleText")]
    [DefaultEvent("ThresholdExceeded")]
    [DefaultProperty("Threshold")]
    [HelpKeywordAttribute(typeof(UserControl))]
    [ToolboxItem("System.Windows.Forms.Design.AutoSizeToolboxItem,System.Design")]
    public class AttributesDemoControl : UserControl
    {