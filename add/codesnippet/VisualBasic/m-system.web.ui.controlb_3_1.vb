   ' Override the AppendLiteralString method so that literal
   ' text between rows of controls are ignored.  
   Public Overrides Sub AppendLiteralString(s As String)
   End Sub 'AppendLiteralString
 End Class 'MyItemControlBuilder ' Ignores literals between rows.