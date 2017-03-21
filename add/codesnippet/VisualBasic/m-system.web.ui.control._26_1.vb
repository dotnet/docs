      ' Ensure the current control has children,
      ' then get or set the Text property.
      
      Public Property Value() As Integer
         Get
            Me.EnsureChildControls()
            Return Int32.Parse(CType(Controls(1), TextBox).Text)
         End Get
         Set
            Me.EnsureChildControls()
            CType(Controls(1), TextBox).Text = value.ToString()
         End Set
      End Property
      
      