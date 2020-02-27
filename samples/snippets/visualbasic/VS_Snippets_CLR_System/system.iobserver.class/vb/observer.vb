' <Snippet8>
Public Class LocationReporter : Implements IObserver(Of Location)
   Dim unsubscriber As IDisposable
   Dim instName As String

   Public Sub New(ByVal name As String)
      Me.instName = name
   End Sub

   Public ReadOnly Property Name As String
      Get
         Return instName
      End Get
   End Property

   Public Overridable Sub Subscribe(ByVal provider As IObservable(Of Location))
      If provider Is Nothing Then Exit Sub
      unsubscriber = provider.Subscribe(Me)
   End Sub

   ' <Snippet11>
   Public Overridable Sub OnCompleted() Implements System.IObserver(Of Location).OnCompleted
      Console.WriteLine("The Location Tracker has completed transmitting data to {0}.", Me.Name)
      Me.Unsubscribe()
   End Sub
   ' </Snippet11>

   ' <Snippet10>
   Public Overridable Sub OnError(ByVal e As System.Exception) Implements System.IObserver(Of Location).OnError
      Console.WriteLine("{0}: The location cannot be determined.", Me.Name)
   End Sub
   ' </Snippet10>

   ' <Snippet12>
   Public Overridable Sub OnNext(ByVal value As Location) Implements System.IObserver(Of Location).OnNext
      Console.WriteLine("{2}: The current location is {0}, {1}", value.Latitude, value.Longitude, Me.Name)
   End Sub
   ' </Snippet12>

   Public Overridable Sub Unsubscribe()
      unsubscriber.Dispose()
   End Sub
End Class
' </Snippet8>
