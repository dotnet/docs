Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports System.Windows.Navigation

Namespace VisualBasic
    ''' <summary>
    ''' Interaction logic for Window1.xaml
    ''' </summary>

    Partial Public Class Window1
        Inherits Window

        Public Sub New()
            InitializeComponent()

        End Sub

        Protected Overrides Sub OnInitialized(ByVal e As EventArgs)
            MyBase.OnInitialized(e)

            ' <SnippetSetNavigationUIVisibility>
            Me.hostFrame.NavigationUIVisibility = NavigationUIVisibility.Visible
            ' </SnippetSetNavigationUIVisibility>
        End Sub
    End Class
End Namespace