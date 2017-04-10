
Imports System
Imports System.ServiceModel

<ServiceContract()> _
Public Interface IHttpFetcher
    <OperationContract()> _
    Function GetWebPage(ByVal address As String) As String
End Interface

'<snippet6>
' These classes have the invariant that:
'     this.slow.GetWebPage(this.cachedAddress) == this.cachedWebPage.
' When you read cached values you can assume they are valid. When
' you write the cached values, you must guarantee that they are valid.
'</snippet6>
' <snippet2>
' With ConcurrencyMode.Single, WCF does not call again into the object
' so long as the method is running. After the operation returns the object
' can be called again, so you must make sure state is consistent before
' returning.
<ServiceBehavior(ConcurrencyMode:=ConcurrencyMode.Single)> _
 Class SingleCachingHttpFetcher
    Implements IHttpFetcher
    Private cachedWebPage As String
    Private cachedAddress As String
    Private ReadOnly slow As IHttpFetcher

    Public Function GetWebPage(ByVal address As String) As String Implements IHttpFetcher.GetWebPage
        ' <-- Can assume cache is valid.
        If Me.cachedAddress = address Then
            Return Me.cachedWebPage
        End If

        ' <-- Cache is no longer valid because we are changing
        ' one of the values.
        Me.cachedAddress = address
        Dim webPage = slow.GetWebPage(address)
        Me.cachedWebPage = webPage
        ' <-- Cache is valid again here.

        Return Me.cachedWebPage
        ' <-- Must guarantee that the cache is valid because we are returning.
    End Function
End Class
' </snippet2>

' <snippet3>
' With ConcurrencyMode.Reentrant, WCF makes sure that only one
' thread runs in your code at a time. However, when you call out on a
' channel, the operation can get called again on another thread. Therefore 
' you must confirm that state is consistent both before channel calls and
' before you return.
<ServiceBehavior(ConcurrencyMode:=ConcurrencyMode.Reentrant)> _
 Class ReentrantCachingHttpFetcher
    Implements IHttpFetcher
    Private cachedWebPage As String
    Private cachedAddress As String
    Private ReadOnly slow As SlowHttpFetcher

    Public Sub New()
        Me.slow = New SlowHttpFetcher()
    End Sub

    Public Function GetWebPage(ByVal address As String) As String Implements IHttpFetcher.GetWebPage
        ' <-- Can assume that cache is valid.
        If Me.cachedAddress = address Then
            Return Me.cachedWebPage
        End If

        ' <-- Must guarantee that the cache is valid, because 
        ' the operation can be called again before we return.
        Dim webPage = slow.GetWebPage(address)
        ' <-- Can assume cache is valid.

        ' <-- Cache is no longer valid because we are changing
        ' one of the values.
        Me.cachedAddress = address
        Me.cachedWebPage = webPage
        ' <-- Cache is valid again here.

        Return Me.cachedWebPage
        ' <-- Must guarantee that cache is valid because we are returning.
    End Function
End Class
' </snippet3>

' <snippet4>
' With ConcurrencyMode.Multiple, threads can call an operation at any time.  
' It is your responsibility to guard your state with locks. If
' you always guarantee you leave state consistent when you leave
' the lock, you can assume it is valid when you enter the lock.
<ServiceBehavior(ConcurrencyMode:=ConcurrencyMode.Multiple)> _
 Class MultipleCachingHttpFetcher
    Implements IHttpFetcher
    Private cachedWebPage As String
    Private cachedAddress As String
    Private ReadOnly slow As SlowHttpFetcher
    Private ReadOnly ThisLock As New Object()

    Public Sub New()
        Me.slow = New SlowHttpFetcher()
    End Sub

    Public Function GetWebPage(ByVal address As String) As String Implements IHttpFetcher.GetWebPage
        SyncLock Me.ThisLock
            ' <-- Can assume cache is valid.
            If Me.cachedAddress = address Then
                Return Me.cachedWebPage
                ' <-- Must guarantee that cache is valid because 
                ' the operation returns and releases the lock.
            End If
            ' <-- Must guarantee that cache is valid here because
            ' the operation releases the lock.
        End SyncLock

        Dim webPage = slow.GetWebPage(address)

        SyncLock Me.ThisLock
            ' <-- Can assume cache is valid.

            ' <-- Cache is no longer valid because the operation 
            ' changes one of the values.
            Me.cachedAddress = address
            Me.cachedWebPage = webPage
            ' <-- Cache is valid again here.

            ' <-- Must guarantee that cache is valid because
            ' the operation releases the lock.
        End SyncLock

        Return webPage
    End Function
End Class
' </snippet4>


'<snippet5>
' This class has the invariant that:
'     this.slow.GetWebPage(this.cachedAddress) == this.cachedWebPage.
' When you read cached values you can assume they are valid. When
' you write the cached values, you must guarantee that they are valid.
'</snippet5>

Public Class SlowHttpFetcher
    Public Function GetWebPage(ByVal address As String) As String
        Return "The return value."
    End Function

End Class