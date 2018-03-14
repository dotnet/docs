' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim title As String = "The House of the Seven Gables"
      Dim searchString As String = "the"
      Dim comparison As StringComparison = StringComparison.InvariantCulture
      Console.WriteLine("'{0}':", title)
      Console.WriteLine("   Starts with '{0}' ({1:G} comparison): {2}",
                        searchString, comparison,
                        title.StartsWith(searchString, comparison))

      comparison = StringComparison.InvariantCultureIgnoreCase
      Console.WriteLine("   Starts with '{0}' ({1:G} comparison): {2}",
                        searchString, comparison,
                        title.StartsWith(searchString, comparison))
   End Sub
End Module
' The example displays the following output:
'    'The House of the Seven Gables':
'       Starts with 'the' (InvariantCulture comparison): False
'       Starts with 'the' (InvariantCultureIgnoreCase comparison): True
' </Snippet2>
