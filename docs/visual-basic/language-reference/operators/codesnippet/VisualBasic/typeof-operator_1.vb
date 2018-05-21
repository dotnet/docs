        Dim refInteger As Object = 2
        MsgBox("TypeOf Object[Integer] Is Integer? " & TypeOf refInteger Is Integer)
        MsgBox("TypeOf Object[Integer] Is Double? " & TypeOf refInteger Is Double)
        Dim refForm As Object = New System.Windows.Forms.Form
        MsgBox("TypeOf Object[Form] Is Form? " & TypeOf refForm Is System.Windows.Forms.Form)
        MsgBox("TypeOf Object[Form] Is Label? " & TypeOf refForm Is System.Windows.Forms.Label)
        MsgBox("TypeOf Object[Form] Is Control? " & TypeOf refForm Is System.Windows.Forms.Control)
        MsgBox("TypeOf Object[Form] Is IComponent? " & TypeOf refForm Is System.ComponentModel.IComponent)