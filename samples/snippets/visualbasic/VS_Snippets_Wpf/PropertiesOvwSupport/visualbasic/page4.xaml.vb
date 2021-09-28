Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Input
Imports System.Collections.Generic

Namespace MyNamespace
  Partial Public Class MyCode
	  Inherits Canvas
	  Private Sub MakeANewThing(ByVal sender As Object, ByVal e As RoutedEventArgs)
'<SnippetAPCode>
	  Dim myDockPanel As New DockPanel()
	  Dim myCheckBox As New CheckBox()
	  myCheckBox.Content = "Hello"
	  myDockPanel.Children.Add(myCheckBox)
	  DockPanel.SetDock(myCheckBox, Dock.Top)
'</SnippetAPCode>
        End Sub

        ' The c# version uses DPFormBasic2 along with DPFormBasic to splice the
        ' dp field, but you can't intersperse comments into a statement, 
        ' so vb only uses DPFormBasic.
        '<SnippetDPFormBasic>
        Public Shared ReadOnly IsSpinningProperty As DependencyProperty =
            DependencyProperty.Register("IsSpinning",
                                        GetType(Boolean),
                                        GetType(MyCode))

        Public Property IsSpinning() As Boolean
            Get
                Return CBool(GetValue(IsSpinningProperty))
            End Get
            Set(ByVal value As Boolean)
                SetValue(IsSpinningProperty, value)
            End Set
        End Property
        '</SnippetDPFormBasic>
	  Private Sub DoAqStuff()
'<SnippetCollectionProblemTestCode>
		  Dim myAq1 As New Aquarium()
		  Dim myAq2 As New Aquarium()
		  Dim f1 As New Fish()
		  Dim f2 As New Fish()
		  myAq1.AquariumContents.Add(f1)
		  myAq2.AquariumContents.Add(f2)
		  MessageBox.Show("aq1 contains " & myAq1.AquariumContents.Count.ToString() & " things")
		  MessageBox.Show("aq2 contains " & myAq2.AquariumContents.Count.ToString() & " things")
'</SnippetCollectionProblemTestCode>
	  End Sub
	  Private Sub BAQ(ByVal sender As Object, ByVal e As EventArgs)
		  DoAqStuff()
	  End Sub
  End Class
'<SnippetCollectionProblemDefinition>
	Public Class Fish
		Inherits FrameworkElement
	End Class
	Public Class Aquarium
		Inherits DependencyObject
		Private Shared ReadOnly AquariumContentsPropertyKey As DependencyPropertyKey = DependencyProperty.RegisterReadOnly("AquariumContents", GetType(List(Of FrameworkElement)), GetType(Aquarium), New FrameworkPropertyMetadata(New List(Of FrameworkElement)()))
		Public Shared ReadOnly AquariumContentsProperty As DependencyProperty = AquariumContentsPropertyKey.DependencyProperty

		Public ReadOnly Property AquariumContents() As List(Of FrameworkElement)
			Get
				Return CType(GetValue(AquariumContentsProperty), List(Of FrameworkElement))
			End Get
        End Property
        '</SnippetCollectionProblemDefinition>

'<SnippetCollectionProblemCtor>
		Public Sub New()
			MyBase.New()
			SetValue(AquariumContentsPropertyKey, New List(Of FrameworkElement)())
		End Sub
'</SnippetCollectionProblemCtor>

'<SnippetCollectionProblemEndB>
	End Class
'</SnippetCollectionProblemEndB>
End Namespace
