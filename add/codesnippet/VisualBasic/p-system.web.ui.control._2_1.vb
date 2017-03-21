      ' Override the ViewStateIgnoresCase property to allow the same
      ' entries with different casing to be stored in the control's
      ' ViewState property.
      Overrides Protected ReadOnly Property ViewStateIgnoresCase As Boolean
         Get
            Return True
         End Get
      End Property