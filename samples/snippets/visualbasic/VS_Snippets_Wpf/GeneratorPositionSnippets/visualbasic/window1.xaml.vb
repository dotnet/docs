Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes


Namespace GeneratorPositionSnippets
  ''' <summary>
  ''' Interaction logic for Window1.xaml
  ''' </summary>

  Partial Public Class Window1
	  Inherits Window

	Public Sub New()
	  InitializeComponent()
	End Sub

	Private Sub GenerateForwardFromBeginning()
	  '<SnippetGenerateForwardFromBeginningCODE>
	  ' Start generating items forward from the beginning of the item list
	  Dim position As New GeneratorPosition(-1, 0)
	  Dim direction As GeneratorDirection = GeneratorDirection.Forward
	  Dim generator As IItemContainerGenerator = CType(Me.itemsControl.ItemContainerGenerator, IItemContainerGenerator)
	  generator.StartAt(position, direction)
	  '</SnippetGenerateForwardFromBeginningCODE>
	End Sub

	Private Sub GenerateBackFromEnd()
	  '<SnippetGenerateBackwardFromEndCODE>
	  ' Start generating items backward from the end of the item list
	  Dim position As New GeneratorPosition(-1, 0)
	  Dim direction As GeneratorDirection = GeneratorDirection.Backward
	  Dim generator As IItemContainerGenerator = CType(Me.itemsControl.ItemContainerGenerator, IItemContainerGenerator)
	  generator.StartAt(position, direction)
	  '</SnippetGenerateBackwardFromEndCODE>
	End Sub

	Private Sub GenerateForwardFromMiddle()
	  '<SnippetGenerateForwardFromMiddleCODE>
	  ' Start generating items forward,
	  ' starting with the first unrealized item (offset of 1),
	  ' after the 5th realized item
	  ' (the item with index 4 among all realized items) in the list
	  Dim position As New GeneratorPosition(4, 1)
	  Dim direction As GeneratorDirection = GeneratorDirection.Forward
	  Dim generator As IItemContainerGenerator = CType(Me.itemsControl.ItemContainerGenerator, IItemContainerGenerator)
	  generator.StartAt(position, direction)
	  '</SnippetGenerateForwardFromMiddleCODE>
	End Sub
  End Class
End Namespace