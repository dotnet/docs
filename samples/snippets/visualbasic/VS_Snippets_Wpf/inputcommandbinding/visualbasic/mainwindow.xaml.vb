Class MainWindow 

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        InitializeCommand()
    End Sub

    '<SnippetInitializeCommand> 
    Public ReadOnly Property ChangeColorCommand() As SimpleDelegateCommand
        Get
            Return _changeColorCommand
        End Get
    End Property

    Private _changeColorCommand As SimpleDelegateCommand
    Private originalColor As Brush, alternateColor As Brush

    Private Sub InitializeCommand()
        originalColor = Me.Background

        _changeColorCommand = New SimpleDelegateCommand(Function(x) Me.ChangeColor(x))

        DataContext = Me
        _changeColorCommand.GestureKey = Key.C
        _changeColorCommand.GestureModifier = ModifierKeys.Control
        _changeColorCommand.MouseGesture = MouseAction.RightClick
    End Sub

    ' Switch the Background color between 
    ' the original and selected color. 
    Private Function ChangeColor(ByVal colorString As Object) As Integer

        If colorString Is Nothing Then
            Return 0
        End If

        Dim newColor As Color = DirectCast(ColorConverter.ConvertFromString(DirectCast(colorString, [String])), Color)

        alternateColor = New SolidColorBrush(newColor)

        If Brush.Equals(Me.Background, originalColor) Then
            Me.Background = alternateColor
        Else
            Me.Background = originalColor
        End If

        Return 0
    End Function
    '</SnippetInitializeCommand> 
End Class

'<SnippetDelegateCommand> 
' Create a class that implements ICommand and accepts a delegate. 
Public Class SimpleDelegateCommand
    Implements ICommand

    ' Specify the keys and mouse actions that invoke the command. 
    Private _GestureKey As Key
    Private _GestureModifier As ModifierKeys
    Private _MouseGesture As MouseAction

    Public Property GestureKey() As Key
        Get
            Return _GestureKey
        End Get
        Set(ByVal value As Key)
            _GestureKey = value
        End Set
    End Property

    Public Property GestureModifier() As ModifierKeys
        Get
            Return _GestureModifier
        End Get
        Set(ByVal value As ModifierKeys)
            _GestureModifier = value
        End Set
    End Property

    Public Property MouseGesture() As MouseAction
        Get
            Return _MouseGesture
        End Get
        Set(ByVal value As MouseAction)
            _MouseGesture = value
        End Set
    End Property

    Private _executeDelegate As Action(Of Object)

    Public Sub New(ByVal executeDelegate As Action(Of Object))
        _executeDelegate = executeDelegate
    End Sub

    Public Sub Execute(ByVal parameter As Object) _
        Implements ICommand.Execute

        _executeDelegate(parameter)
    End Sub

    Public Function CanExecute(ByVal parameter As Object) As Boolean _
        Implements ICommand.CanExecute

        Return True
    End Function

    Public Event CanExecuteChanged As EventHandler _
        Implements ICommand.CanExecuteChanged
End Class
'</SnippetDelegateCommand> 