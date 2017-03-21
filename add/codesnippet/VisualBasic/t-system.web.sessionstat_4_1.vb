Imports System
Imports System.Web
Imports System.Web.SessionState
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Text
Imports System.Threading
Imports System.Globalization

Namespace Samples.AspNet.SessionState

  Public NotInheritable Class MySessionState
    Implements IHttpSessionState
  
    Const MAX_TIMEOUT As Integer = 24 * 60  ' Timeout cannot exceed 24 hours.

    Dim pId            As String
    Dim pSessionItems  As ISessionStateItemCollection
    Dim pStaticObjects As HttpStaticObjectsCollection
    Dim pTimeout       As Integer
    Dim pNewSession    As Boolean
    Dim pCookieMode    As HttpCookieMode
    Dim pMode          As SessionStateMode
    Dim pAbandon       As Boolean
    Dim pIsReadonly    As Boolean

    Public Sub New(id            As String, _
                   sessionItems  As ISessionStateItemCollection, _
                   staticObjects As HttpStaticObjectsCollection, _
                   timeout       As Integer, _
                   newSession    As Boolean, _
                   cookieMode    As HttpCookieMode, _
                   mode          As SessionStateMode, _  
                   isReadonly As Boolean)
    
      pId            = id   
      pSessionItems  = sessionItems
      pStaticObjects = staticObjects
      pTimeout       = timeout    
      pNewSession    = newSession 
      pCookieMode    = cookieMode
      pMode          = mode
      pIsReadonly    = isReadonly
    End Sub


    Public Property Timeout As Integer Implements IHttpSessionState.Timeout
      Get
        Return pTimeout
      End Get
      Set
        If value <= 0 Then _
          Throw New ArgumentException("Timeout value must be greater than zero.")

        If value > MAX_TIMEOUT Then _
          Throw New ArgumentException("Timout cannot be greater than " & MAX_TIMEOUT.ToString())

        pTimeout = value
      End Set
    End Property


    Public ReadOnly Property SessionID As String Implements IHttpSessionState.SessionID
      Get
        Return pId
      End Get
    End Property


    Public ReadOnly Property IsNewSession As Boolean Implements IHttpSessionState.IsNewSession
      Get
        Return pNewSession
      End Get
    End Property


    Public ReadOnly Property Mode As SessionStateMode Implements IHttpSessionState.Mode    
      Get
        Return pMode
      End Get
    End Property


    Public ReadOnly Property IsCookieless As Boolean Implements IHttpSessionState.IsCookieLess    
      Get
        Return CookieMode = HttpCookieMode.UseUri
      End Get
    End Property


    Public ReadOnly Property CookieMode As HttpCookieMode Implements IHttpSessionState.CookieMode    
      Get
        Return pCookieMode
      End Get
    End Property


    '
    ' Abandon marks the session as abandoned. The IsAbandoned property is used by the
    ' session state module to perform the abandon work during the ReleaseRequestState event.
    '
    Public Sub Abandon() Implements IHttpSessionState.Abandon
      pAbandon = True
    End Sub

    Public ReadOnly Property IsAbandoned As Boolean  
      Get
        Return pAbandon
      End Get
    End Property

    '
        ' Session.LCID exists only to support legacy ASP compatibility. ASP.NET developers should use
    ' Page.LCID instead.
    '
    Public Property LCID As Integer Implements IHttpSessionState.LCID
      Get
        Return Thread.CurrentThread.CurrentCulture.LCID
      End Get
      Set
        Thread.CurrentThread.CurrentCulture = CultureInfo.ReadOnly(new CultureInfo(value))
      End Set
    End Property


    '
        ' Session.CodePage exists only to support legacy ASP compatibility. ASP.NET developers should use
    ' Response.ContentEncoding instead.
    '
    Public Property CodePage As Integer Implements IHttpSessionState.CodePage    
      Get
        If Not HttpContext.Current Is Nothing Then
          Return HttpContext.Current.Response.ContentEncoding.CodePage
        Else
          Return Encoding.Default.CodePage
        End If
      End Get
      Set       
        If Not HttpContext.Current Is Nothing Then _
          HttpContext.Current.Response.ContentEncoding = Encoding.GetEncoding(value)
      End Set
    End Property


    Public ReadOnly Property StaticObjects As HttpStaticObjectsCollection _
      Implements IHttpSessionState.StaticObjects
    
      Get
        Return pStaticObjects
      End Get
    End Property


    Public Property Item(name As String) As Object Implements IHttpSessionState.Item
      Get
        Return pSessionItems(name)
      End Get
      Set
        pSessionItems(name) = value
      End Set
    End Property


    Public Property Item(index As Integer) As Object Implements IHttpSessionState.Item    
      Get
        Return pSessionItems(index)
      End Get
      Set
        pSessionItems(index) = value
      End Set
    End Property
        

    Public Sub Add(name As String, value As Object) Implements IHttpSessionState.Add    
      pSessionItems(name) = value        
    End Sub


    Public Sub Remove(name As String) Implements IHttpSessionState.Remove    
      pSessionItems.Remove(name)
    End Sub


    Public Sub RemoveAt(index As Integer) Implements IHttpSessionState.RemoveAt    
      pSessionItems.RemoveAt(index)
    End Sub


    Public Sub Clear() Implements IHttpSessionState.Clear 
      pSessionItems.Clear()
    End Sub

    Public Sub RemoveAll() Implements IHttpSessionState.RemoveAll
        Clear()
    End Sub



    Public ReadOnly Property Count As Integer Implements IHttpSessionState.Count    
      Get
        Return pSessionItems.Count
      End Get
    End Property



    Public ReadOnly Property Keys As NameObjectCollectionBase.KeysCollection _
      Implements IHttpSessionState.Keys
    
      Get
        Return pSessionItems.Keys
      End Get
    End Property


    Public Function GetEnumerator() As IEnumerator Implements IHttpSessionState.GetEnumerator
        Return pSessionItems.GetEnumerator()
    End Function


    Public Sub CopyTo(items As Array, index As Integer) Implements IHttpSessionState.CopyTo    
      For Each o As Object In items
        items.SetValue(o, index)
        index += 1
      Next
    End Sub


    Public ReadOnly Property SyncRoot As Object Implements IHttpSessionState.SyncRoot    
        Get
          Return Me
       End Get
    End Property


    Public ReadOnly Property IsReadOnly As Boolean Implements IHttpSessionState.IsReadOnly    
      Get
        Return pIsReadonly
      End Get
    End Property


    Public ReadOnly Property IsSynchronized As Boolean Implements IHttpSessionState.IsSynchronized    
      Get
        Return False
      End Get
    End Property
  End Class
End Namespace