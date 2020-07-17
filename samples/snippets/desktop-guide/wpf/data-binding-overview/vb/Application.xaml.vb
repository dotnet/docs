Imports System.Collections.ObjectModel

Class Application

    ' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
    ' can be handled in this file.

    Public ReadOnly Property AuctionItems As ObservableCollection(Of AuctionItem) = New ObservableCollection(Of AuctionItem)

End Class
