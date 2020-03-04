
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



'/ <summary>
'/ Interaction logic for Window1.xaml
'/ </summary>

Class Window1
    Inherits System.Windows.Window

    Public Sub New() 
        InitializeComponent()
    
    End Sub
End Class



'<Snippet2>
Public Class NumberDataTemplateSelector
    Inherits DataTemplateSelector

    Public Property NumberTemplate As DataTemplate
    Public Property LargeNumberTemplate As DataTemplate

    Public Overrides Function SelectTemplate(ByVal item As Object, _
                    ByVal container As DependencyObject) As DataTemplate

        ' Nothing can be passed by IDE designer
        if (item Is Nothing) Then
            Return Nothing
        End If

        Dim num = Convert.ToInt32(CStr(item))

        ' Select one of the DataTemplate objects, based on the 
        ' value of the selected item in the ComboBox.
        If num < 5 Then
            Return NumberTemplate

        Else
            Return LargeNumberTemplate
        End If

    End Function 'SelectTemplate
End Class
'</Snippet2>
