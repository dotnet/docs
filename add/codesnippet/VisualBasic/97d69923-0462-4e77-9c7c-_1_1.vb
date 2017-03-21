    Public Class myService_M_AuthorizationManager
        Inherits ServiceAuthorizationManager

        ' set max size for message
        Private someMaxSize As Integer = 16000

        Public Overrides Function CheckAccess(ByVal operationContext As OperationContext, _
                                              ByRef message As Message) As Boolean
            Dim accessAllowed = False
            Dim requestBuffer = Message.CreateBufferedCopy(someMaxSize)

            ' do access checks using the message parameter value and set accessAllowed appropriately
            If accessAllowed Then
                ' replace incoming message with fresh copy since accessing the message consumes it
                Message = requestBuffer.CreateMessage()
            End If
            Return accessAllowed
        End Function
    End Class