' <snippet4>
Imports System.Windows.Input

Namespace SimpleMVVM.ViewModel

    Public Class RelayCommand
        Implements ICommand

        Private _isEnabled As Boolean
        Private ReadOnly _handler As Action

        Public Sub New(ByVal handler As Action)
            _handler = handler
        End Sub

        Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

        Public Property IsEnabled() As Boolean
            Get
                Return _isEnabled
            End Get
            Set(ByVal value As Boolean)
                If (value <> _isEnabled) Then
                    _isEnabled = value
                    RaiseEvent CanExecuteChanged(Me, EventArgs.Empty)
                End If
            End Set
        End Property

        Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
            Return IsEnabled
        End Function

        Public Sub Execute(parameter As Object) Implements ICommand.Execute
            _handler()
        End Sub

    End Class
End Namespace
' </snippet4>
