' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim domain As AppDomain = AppDomain.CurrentDomain
      ' Set a timeout interval of 2 seconds.
      domain.SetData("REGEX_DEFAULT_MATCH_TIMEOUT", TimeSpan.FromSeconds(2))
      Dim timeout As Object = domain.GetData("REGEX_DEFAULT_MATCH_TIMEOUT")
      Console.WriteLine("Default regex match timeout: {0}",
                         If(timeout Is Nothing, "<null>", timeout))

      Dim rgx As New Regex("[aeiouy]")
      Console.WriteLine("Regular expression pattern: {0}", rgx.ToString())
      Console.WriteLine("Timeout interval for this regex: {0} seconds",
                        rgx.MatchTimeout.TotalSeconds)
   End Sub
End Module
' The example displays the following output:
'       Default regex match timeout: 00:00:02
'       Regular expression pattern: [aeiouy]
'       Timeout interval for this regex: 2 seconds
' </Snippet1>
