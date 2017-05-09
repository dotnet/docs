 ' <snippet1>
Imports System
Imports System.ComponentModel
Imports System.Windows.Forms

' <snippet2>
' The DemoControl class shows properties 
' used with lookup-based binding.
<LookupBindingProperties( _
"DataSource", _
"DisplayMember", _
"ValueMember", _
"LookupMember")> _
Public Class DemoControl
    Inherits Control
End Class
' </snippet2>

' <snippet3>
' The DemoComboBox control shows a standard
' combo box binding definition.
<LookupBindingProperties( _
"DataSource", _
"DisplayMember", _
"ValueMember", _
"SelectedValue")> _
Public Class DemoComboBox
    Inherits Control
End Class
' </snippet3>

' <snippet4>
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
' </snippet4>

' <snippet5>
' NonBindableCombo control shows how to unset the
' LookupBindingProperties by specifying no arguments.
<LookupBindingProperties()>  _
Public Class NonBindableCombo
    Inherits Control
End Class
' </snippet5>

' </snippet1>