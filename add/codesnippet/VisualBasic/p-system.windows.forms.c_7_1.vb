      Protected Overrides ReadOnly Property DefaultImeMode() As ImeMode
         Get
            ' Disable the IME mode for the control.
            Return ImeMode.Off
         End Get
      End Property