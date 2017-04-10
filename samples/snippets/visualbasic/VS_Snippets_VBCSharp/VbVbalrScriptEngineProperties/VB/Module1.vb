Module Module1

  Sub Main()
    Console.WriteLine(getRuntimeInfo)
  End Sub

'<Snippet1>
  Function getRuntimeInfo() As String
      Dim runtime As String = ScriptEngine & " Version "
      runtime &= CStr(ScriptEngineMajorVersion) & "."
      runtime &= CStr(ScriptEngineMinorVersion) & "."
      runtime &= CStr(ScriptEngineBuildVersion)
      ' Return the current runtime information.
      Return runtime
  End Function
'</Snippet1>

End Module
