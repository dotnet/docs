'<Snippet1>
Imports System.Windows.Forms

NameSpace UsageLibrary

Public Class MyForm
   Inherits Form

   Public Sub New()
      Me.Text = "Hello World!"
   End Sub
    
   ' Satisfies rule: MarkWindowsFormsEntryPointsWithStaThread.
   <STAThread()> _
   Public Shared Sub Main()
      Dim aform As New MyForm()
      Application.Run(aform)
   End Sub

End Class

End Namespace
'</Snippet1>
