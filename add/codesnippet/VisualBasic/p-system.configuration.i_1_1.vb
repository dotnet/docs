   ' Override the property 'HelpText'.
   Public Overrides ReadOnly Property HelpText() As String
      Get
         Return _
         "Installer Description : This is a sample Installer" + ControlChars.NewLine + _
         "HelpText is used to provide useful information about the installer."
      End Get
   End Property