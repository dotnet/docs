Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace Microsoft.Samples.Workflow
    'Skeleton of the interfaces the code sample is expecting
    Public Class OrderingStateMachine
        Public Class IOrderService
        End Class
    End Class

    Public Class OrderApplication
        Public Interface IOrderService
        End Interface
    End Class
    

    Public Class SpeechApplication
        Public Class ISpeechService
        End Class
    End Class
End Namespace
