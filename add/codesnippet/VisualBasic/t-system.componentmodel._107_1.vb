    ' This control demonstrates a simple logging capability. 
    <ComplexBindingProperties("DataSource", "DataMember"), _
    DefaultBindingProperty("TitleText"), _
    DefaultEvent("ThresholdExceeded"), _
    DefaultProperty("Threshold"), _
    HelpKeywordAttribute(GetType(UserControl)), _
    ToolboxItem("System.Windows.Forms.Design.AutoSizeToolboxItem,System.Design")> _
    Public Class AttributesDemoControl
        Inherits UserControl