
    'Declare the HelpProvider.
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider


    Private Sub InitializeHelpProvider()

        ' Construct the HelpProvider Object.
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider

        ' Set the HelpNamespace property to the Help file for 
        ' HelpProvider1.
        Me.HelpProvider1.HelpNamespace = "c:\windows\input.chm"

        ' Specify that the Help provider should open to the table
        ' of contents of the Help file.
        Me.HelpProvider1.SetHelpNavigator(TextBox1, _
            HelpNavigator.TableOfContents)

    End Sub