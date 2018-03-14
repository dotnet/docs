'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Public Class Form1
   Inherits System.Windows.Forms.Form
   
   Dim WithEvents rtb As New RichTextBox()
   
   Public Sub New()
      MyBase.New()
      Me.Controls.Add(rtb)
      rtb.Dock = DockStyle.Fill
   End Sub

   Private Sub languageChange( _
      ByVal sender As Object, _
      ByVal e As InputLanguageChangedEventArgs _
   ) Handles MyBase.InputLanguageChanged

      ' If the input language is Japanese.
      ' set the initial IMEMode to Katakana.
      If e.InputLanguage.Culture.TwoLetterISOLanguageName.Equals("ja") = True Then
         rtb.ImeMode = System.Windows.Forms.ImeMode.Katakana
      End If
   End Sub

   Public Shared Sub Main()
      Application.Run(new Form1())
   End Sub

End Class
'</Snippet1>