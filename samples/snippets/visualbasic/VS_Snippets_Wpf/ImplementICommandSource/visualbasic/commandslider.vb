Namespace SDKSamples
    '<SnippetImplementICommandSourceClassDefinition>
    Public Class CommandSlider
        Inherits Slider
        Implements ICommandSource
        Public Sub New()
            MyBase.New()

        End Sub
        '</SnippetImplementICommandSourceClassDefinition>

        ' ICommand Interface Memembers
        '<SnippetImplementICommandSourceCommandPropertyDefinition>
        ' Make Command a dependency property so it can use databinding.
        Public Shared ReadOnly CommandProperty As DependencyProperty =
            DependencyProperty.Register("Command", GetType(ICommand),
                GetType(CommandSlider),
                New PropertyMetadata(CType(Nothing, ICommand),
                    New PropertyChangedCallback(AddressOf CommandChanged)))

        Public ReadOnly Property Command1() As ICommand Implements ICommandSource.Command
            Get
                Return CType(GetValue(CommandProperty), ICommand)
            End Get
        End Property

        Public Property Command() As ICommand
            Get
                Return CType(GetValue(CommandProperty), ICommand)
            End Get
            Set(ByVal value As ICommand)
                SetValue(CommandProperty, value)
            End Set
        End Property
        '</SnippetImplementICommandSourceCommandPropertyDefinition>
        ' Make CommandTarget a dependency property so it can use databinding.
        Public Shared ReadOnly CommandTargetProperty As DependencyProperty = DependencyProperty.Register("CommandTarget", GetType(IInputElement), GetType(CommandSlider), New PropertyMetadata(CType(Nothing, IInputElement)))

        Public ReadOnly Property CommandTarget1() As IInputElement Implements ICommandSource.CommandTarget
            Get
                Return CType(GetValue(CommandTargetProperty), IInputElement)
            End Get
        End Property
        Public Property CommandTarget() As IInputElement
            Get
                Return CType(GetValue(CommandTargetProperty), IInputElement)
            End Get
            Set(ByVal value As IInputElement)
                SetValue(CommandTargetProperty, value)
            End Set
        End Property

        ' Make CommandParameter a dependency property so it can use databinding.
        Public Shared ReadOnly CommandParameterProperty As DependencyProperty = DependencyProperty.Register("CommandParameter", GetType(Object), GetType(CommandSlider), New PropertyMetadata(CObj(Nothing)))

        Public ReadOnly Property CommandParameter1() As Object Implements ICommandSource.CommandParameter
            Get
                Return CObj(GetValue(CommandParameterProperty))
            End Get

        End Property
        Public Property CommandParameter() As Object
            Get
                Return CObj(GetValue(CommandParameterProperty))
            End Get
            Set(ByVal value As Object)
                SetValue(CommandParameterProperty, value)
            End Set
        End Property

        '<SnippetImplementICommandSourceCommandChanged>
        ' Command dependency property change callback.
        Private Shared Sub CommandChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
            Dim cs As CommandSlider = CType(d, CommandSlider)
            cs.HookUpCommand(CType(e.OldValue, ICommand), CType(e.NewValue, ICommand))
        End Sub
        '</SnippetImplementICommandSourceCommandChanged>
        '<SnippetImplementICommandSourceHookUnHookCommands>
        ' Add a new command to the Command Property.
        Private Sub HookUpCommand(ByVal oldCommand As ICommand, ByVal newCommand As ICommand)
            ' If oldCommand is not null, then we need to remove the handlers.
            If oldCommand IsNot Nothing Then
                RemoveCommand(oldCommand, newCommand)
            End If
            AddCommand(oldCommand, newCommand)
        End Sub

        ' Remove an old command from the Command Property.
        Private Sub RemoveCommand(ByVal oldCommand As ICommand, ByVal newCommand As ICommand)
            Dim handler As EventHandler = AddressOf CanExecuteChanged
            RemoveHandler oldCommand.CanExecuteChanged, handler
        End Sub

        ' Add the command.
        Private Sub AddCommand(ByVal oldCommand As ICommand, ByVal newCommand As ICommand)
            Dim handler As New EventHandler(AddressOf CanExecuteChanged)
            canExecuteChangedHandler = handler
            If newCommand IsNot Nothing Then
                AddHandler newCommand.CanExecuteChanged, canExecuteChangedHandler
            End If
        End Sub
        '</SnippetImplementICommandSourceHookUnHookCommands>
        '<SnippetImplementICommandCanExecuteChanged>
        Private Sub CanExecuteChanged(ByVal sender As Object, ByVal e As EventArgs)

            If Me.Command IsNot Nothing Then
                Dim command As RoutedCommand = TryCast(Me.Command, RoutedCommand)

                ' If a RoutedCommand.
                If command IsNot Nothing Then
                    If command.CanExecute(CommandParameter, CommandTarget) Then
                        Me.IsEnabled = True
                    Else
                        Me.IsEnabled = False
                    End If
                    ' If a not RoutedCommand.
                Else
                    If Me.Command.CanExecute(CommandParameter) Then
                        Me.IsEnabled = True
                    Else
                        Me.IsEnabled = False
                    End If
                End If
            End If
        End Sub
        '</SnippetImplementICommandCanExecuteChanged>

        '<SnippetImplementICommandExecute>
        ' If Command is defined, moving the slider will invoke the command;
        ' Otherwise, the slider will behave normally.
        Protected Overrides Sub OnValueChanged(ByVal oldValue As Double, ByVal newValue As Double)
            MyBase.OnValueChanged(oldValue, newValue)

            If Me.Command IsNot Nothing Then
                Dim command As RoutedCommand = TryCast(Me.Command, RoutedCommand)

                If command IsNot Nothing Then
                    command.Execute(CommandParameter, CommandTarget)
                Else
                    CType(Me.Command, ICommand).Execute(CommandParameter)
                End If
            End If
        End Sub
        '</SnippetImplementICommandExecute>

        '<SnippetImplementICommandHandlerReference>
        ' Keep a copy of the handler so it doesn't get garbage collected.
        Private Shared canExecuteChangedHandler As EventHandler
        '</SnippetImplementICommandHandlerReference>
    End Class

End Namespace
