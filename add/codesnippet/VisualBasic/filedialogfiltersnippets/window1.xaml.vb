Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes

'<SnippetNSCODE>
Imports Microsoft.Win32
'</SnippetNSCODE>

Namespace FileDialogFilterSnippets
    ''' <summary>
    ''' Interaction logic for Window1.xaml
    ''' </summary>

    Partial Public Class Window1
        Inherits System.Windows.Window

        Public Sub New()
            InitializeComponent()
            method8()
        End Sub

        Private Sub method1()
            '<SnippetFilterString1>
            Dim dlg As New OpenFileDialog()

            ' Show all files
            dlg.Filter = String.Empty

            dlg.ShowDialog()
            '</SnippetFilterString1>
        End Sub
        Private Sub method2()
            '<SnippetFilterString2>
            Dim dlg As New OpenFileDialog()

            ' Show all files
            dlg.Filter = Nothing

            dlg.ShowDialog()
            '</SnippetFilterString2>
        End Sub
        Private Sub method3()
            '<SnippetFilterString3>
            Dim dlg As New OpenFileDialog()

            ' Filter by Word Documents
            dlg.Filter = "Word Documents|*.doc"

            dlg.ShowDialog()
            '</SnippetFilterString3>
        End Sub
        Private Sub method4()
            '<SnippetFilterString4>
            Dim dlg As New OpenFileDialog()

            ' Filter by Excel Worksheets
            dlg.Filter = "Excel Worksheets|*.xls"

            dlg.ShowDialog()
            '</SnippetFilterString4>
        End Sub
        Private Sub method5()
            '<SnippetFilterString5>
            Dim dlg As New OpenFileDialog()

            ' Filter by PowerPoint Presentations
            dlg.Filter = "PowerPoint Presentations|*.ppt"

            dlg.ShowDialog()
            '</SnippetFilterString5>
        End Sub
        Private Sub method6()
            '<SnippetFilterString6>
            Dim dlg As New OpenFileDialog()

            ' Filter by Office Files
            dlg.Filter = "Office Files|*.doc;*.xls;*.ppt"

            dlg.ShowDialog()
            '</SnippetFilterString6>
        End Sub
        Private Sub method7()
            '<SnippetFilterString7>
            Dim dlg As New OpenFileDialog()

            ' Filter by All Files
            dlg.Filter = "All Files|*.*"

            dlg.ShowDialog()
            '</SnippetFilterString7>
        End Sub
        Private Sub method8()
            '<SnippetFilterString8>
            Dim dlg As New OpenFileDialog()

            ' Filter by Word Documents OR Excel Worksheets OR PowerPoint Presentations 
            '           OR Office Files 
            '           OR All Files
            dlg.Filter = "Word Documents|*.doc|Excel Worksheets|*.xls|PowerPoint Presentations|*.ppt" & "|Office Files|*.doc;*.xls;*.ppt" & "|All Files|*.*"

            dlg.ShowDialog()
            '</SnippetFilterString8>
        End Sub
    End Class
End Namespace