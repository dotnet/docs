'<!--<SnippetCodeBehind>-->

Imports System
Imports System.Windows
Imports System.Windows.Controls

Namespace MyUserControl
	Partial Public Class NumericUpDown
		Inherits System.Windows.Controls.UserControl
		''' <summary>
		''' Initializes a new instance of the NumericUpDownControl.
		''' </summary>
		Public Sub New()
			InitializeComponent()

			UpdateTextBlock()
		End Sub

		''' <summary>
		''' Gets or sets the value assigned to the control.
		''' </summary>
		Public Property Value() As Decimal
			Get
				Return _value
			End Get
			Set(ByVal value As Decimal)
				If value <> _value Then
					If MinValue <= value AndAlso value <= MaxValue Then
						_value = value
						UpdateTextBlock()
						OnValueChanged(EventArgs.Empty)
					End If
				End If
			End Set
		End Property


		Private _value As Decimal = MinValue


		''' <summary>
		''' Occurs when the Value property changes.
		''' </summary>
		Public Event ValueChanged As EventHandler(Of EventArgs)


		''' <summary>
		''' Raises the ValueChanged event.
		''' </summary>
		''' <param name="args">An EventArgs that contains the event data.</param>
		Protected Overridable Sub OnValueChanged(ByVal args As EventArgs)
			Dim handler As EventHandler(Of EventArgs) = ValueChangedEvent
			If handler IsNot Nothing Then
				handler(Me, args)
			End If
		End Sub

		'<SnippetEventHandlerCode>
		Private Sub upButton_Click(ByVal sender As Object, ByVal e As EventArgs)
				Value += 1
		End Sub

		Private Sub downButton_Click(ByVal sender As Object, ByVal e As EventArgs)
				Value -= 1
		End Sub
		'</SnippetEventHandlerCode>

		'<SnippetUIRefCode>
		Private Sub UpdateTextBlock()
			valueText.Text = Value.ToString()
		End Sub
		'</SnippetUIRefCode>

		Private Const MinValue As Decimal = 0, MaxValue As Decimal = 100
	End Class
End Namespace
'<!--</SnippetCodeBehind>-->