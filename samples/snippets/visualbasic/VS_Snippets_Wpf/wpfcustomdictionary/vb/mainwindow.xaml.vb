Class MainWindow
    ' Note: This following click event won't work. the assembly in the pack URI is incorrect but matches 
    ' the assembly info from the C# version and the XAML seen in the docs
    ' Change WPFCustomDictionary to WPFCustomDictionaries_VB to correct this for running the sample
    '<Snippet2>
    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim dictionaries As IList = SpellCheck.GetCustomDictionaries(richTextBox1)
        ' customwords2.lex is included as a resource file
        dictionaries.Add(New Uri("pack://application:,,,/WPFCustomDictionary;component/customwords2.lex"))
    End Sub
    '</Snippet2>
End Class
