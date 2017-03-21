' The DemoComboBox2 class shows that a control can
' support both simple binding as well as list binding.
<LookupBindingProperties( _
"DataSource", _
"DisplayMember", _
"ValueMember", _
"SelectedValue"), _
DefaultBindingProperty("Text")> _
Public Class DemoComboBox2
    Inherits Control
End Class