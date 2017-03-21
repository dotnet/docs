    Private Sub showHelp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles showHelp.Click
        ' Display Help using the Help navigator enumeration
        ' that is selected in the combo box. Some enumeration
        ' values make use of an extra parameter, which can
        ' be passed in through the Parameter text box.
        Dim navigator As HelpNavigator = HelpNavigator.TableOfContents
        If (navigatorCombo.SelectedItem IsNot Nothing) Then
            navigator = CType(navigatorCombo.SelectedItem, HelpNavigator)
        End If
        Help.ShowHelp(Me, helpfile, navigator, parameterTextBox.Text)
    End Sub 'showHelp_Click