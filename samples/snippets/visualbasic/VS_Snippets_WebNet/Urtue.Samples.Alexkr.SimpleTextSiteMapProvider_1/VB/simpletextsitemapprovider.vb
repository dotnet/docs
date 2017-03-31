' <Snippet1>
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Configuration.Provider
Imports System.IO
Imports System.Security.Permissions
Imports System.Web

Namespace Samples.AspNet.VB

  <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public Class SimpleTextSiteMapProvider
    Inherits SiteMapProvider

    Private parentSiteMapProvider As SiteMapProvider = Nothing
    Private simpleTextProviderName As String = Nothing
    Private sourceFilename As String = Nothing
    Private aRootNode As SiteMapNode = Nothing
    Private siteMapNodes As ArrayList = Nothing
    Private childParentRelationship As ArrayList = Nothing

    ' A default constructor. The Name property is initialized in the
    ' Initialize method.
    Public Sub New()
    End Sub 'New

    ' <Snippet2>
    ' Implement the CurrentNode property.
    Public Overrides ReadOnly Property CurrentNode() As SiteMapNode
      Get
        Dim currentUrl As String = FindCurrentUrl()
        ' Find the SiteMapNode that represents the current page.
        Dim aCurrentNode As SiteMapNode = FindSiteMapNode(currentUrl)
        Return aCurrentNode
      End Get
    End Property

    ' Implement the RootNode property.
    Public Overrides ReadOnly Property RootNode() As SiteMapNode
      Get
        Return aRootNode
      End Get
    End Property
    ' </Snippet2>

    ' <Snippet4>
    ' Implement the ParentProvider property.
    Public Overrides Property ParentProvider() As SiteMapProvider
      Get
        Return parentSiteMapProvider
      End Get
      Set(ByVal value As SiteMapProvider)
        parentSiteMapProvider = Value
      End Set
    End Property

    ' Implement the RootProvider property.
    Public Overrides ReadOnly Property RootProvider() As SiteMapProvider
      Get
        ' If the current instance belongs to a provider hierarchy, it
        ' cannot be the RootProvider. Rely on the ParentProvider.
        If Not (Me.ParentProvider Is Nothing) Then
          Return ParentProvider.RootProvider
          ' If the current instance does not have a ParentProvider, it is
          ' not a child in a hierarchy, and can be the RootProvider.
        Else
          Return Me
        End If
      End Get
    End Property

    ' </Snippet4>
    ' <Snippet5>
    ' Implement the FindSiteMapNode method.
    Public Overrides Function FindSiteMapNode(ByVal rawUrl As String) As SiteMapNode
      ' Does the root node match the URL?
      If RootNode.Url = rawUrl Then
        Return RootNode
      Else
        Dim candidate As SiteMapNode = Nothing
        ' Retrieve the SiteMapNode that matches the URL.
        SyncLock Me
          candidate = GetNode(siteMapNodes, rawUrl)
        End SyncLock
        Return candidate
      End If
    End Function 'FindSiteMapNode
    ' </Snippet5>

    ' <Snippet6>
    ' Implement the GetChildNodes method.
    Public Overrides Function GetChildNodes(ByVal node As SiteMapNode) As SiteMapNodeCollection
      Dim children As New SiteMapNodeCollection()
      ' Iterate through the ArrayList and find all nodes that have the specified node as a parent.
      SyncLock Me
        Dim i As Integer
        For i = 0 To childParentRelationship.Count - 1

          Dim de As DictionaryEntry = CType(childParentRelationship(i), DictionaryEntry)
          Dim nodeUrl As String = CType(de.Key, String)

          Dim parent As SiteMapNode = GetNode(childParentRelationship, nodeUrl)

          If Not (parent Is Nothing) AndAlso node.Url = parent.Url Then
            ' The SiteMapNode with the Url that corresponds to nodeUrl
            ' is a child of the specified node. Get the SiteMapNode for
            ' the nodeUrl.
            Dim child As SiteMapNode = FindSiteMapNode(nodeUrl)
            If Not (child Is Nothing) Then
              children.Add(CType(child, SiteMapNode))
            Else
              Throw New Exception("ArrayLists not in sync.")
            End If
          End If
        Next i
      End SyncLock
      Return children
    End Function 'GetChildNodes

    ' <Snippet3>
    Protected Overrides Function GetRootNodeCore() As SiteMapNode
      Return RootNode
    End Function ' GetRootNodeCore()
    ' </Snippet3>

    ' Implement the GetParentNode method.
    Public Overrides Function GetParentNode(ByVal node As SiteMapNode) As SiteMapNode
      ' Check the childParentRelationship table and find the parent of the current node.
      ' If there is no parent, the current node is the RootNode.
      Dim parent As SiteMapNode = Nothing
      SyncLock Me
        ' Get the Value of the node in childParentRelationship
        parent = GetNode(childParentRelationship, node.Url)
      End SyncLock
      Return parent
    End Function 'GetParentNode
    ' </Snippet6>

    ' <Snippet7>
    ' Implement the ProviderBase.Initialize method.
    ' Initialize is used to initialize the state that the Provider holds, but
    ' not actually build the site map.
    Public Overrides Sub Initialize(ByVal name As String, ByVal attributes As NameValueCollection)
      SyncLock Me
        MyBase.Initialize(name, attributes)
        simpleTextProviderName = name
        sourceFilename = attributes("siteMapFile")
        siteMapNodes = New ArrayList()
        childParentRelationship = New ArrayList()
        ' Build the site map in memory.
        LoadSiteMapFromStore()
      End SyncLock
    End Sub 'Initialize

    ' </Snippet7>
    ' Private helper methods
    ' <Snippet8>
    Private Function GetNode(ByVal list As ArrayList, ByVal url As String) As SiteMapNode
      Dim i As Integer
      For i = 0 To list.Count - 1
        Dim item As DictionaryEntry = CType(list(i), DictionaryEntry)
        If CStr(item.Key) = url Then
          Return CType(item.Value, SiteMapNode)
        End If
      Next i
      Return Nothing
    End Function 'GetNode


    ' Get the URL of the currently displayed page.
    Private Function FindCurrentUrl() As String
      Try
        ' The current HttpContext.
        Dim currentContext As HttpContext = HttpContext.Current
        If Not (currentContext Is Nothing) Then
          Return currentContext.Request.RawUrl
        Else
          Throw New Exception("HttpContext.Current is Invalid")
        End If
      Catch e As Exception
        Throw New NotSupportedException("This provider requires a valid context.", e)
      End Try
    End Function 'FindCurrentUrl

    ' </Snippet8>
    ' <Snippet9>
    Protected Overridable Sub LoadSiteMapFromStore()
      Dim pathToOpen As String
      SyncLock Me
        ' If a root node exists, LoadSiteMapFromStore has already
        ' been called, and the method can return.
        If Not (aRootNode Is Nothing) Then
          Return
        Else
          pathToOpen = HttpContext.Current.Server.MapPath("~" & "\\" & sourceFilename)
          If File.Exists(pathToOpen) Then
            ' Open the file to read from.
            Dim sr As StreamReader = File.OpenText(pathToOpen)
            Try

              ' Clear the state of the collections and aRootNode
              aRootNode = Nothing
              siteMapNodes.Clear()
              childParentRelationship.Clear()

              ' Parse the file and build the site map
              Dim s As String = ""
              Dim nodeValues As String() = Nothing
              Dim temp As SiteMapNode = Nothing

              Do
                s = sr.ReadLine()

                If Not s Is Nothing Then
                  ' Build the various SiteMapNode objects and add
                  ' them to the ArrayList collections. The format used
                  ' is: URL,TITLE,DESCRIPTION,PARENTURL
                  nodeValues = s.Split(","c)

                  temp = New SiteMapNode(Me, _
                      HttpRuntime.AppDomainAppVirtualPath & "/" & nodeValues(0), _
                      HttpRuntime.AppDomainAppVirtualPath & "/" & nodeValues(0), _
                      nodeValues(1), _
                      nodeValues(2))

                  ' Is this a root node yet?
                  If aRootNode Is Nothing AndAlso _
                    (nodeValues(3) Is Nothing OrElse _
                     nodeValues(3) = String.Empty) Then
                    aRootNode = temp

                    ' If not the root node, add the node to the various collections.
                  Else

                    siteMapNodes.Add(New DictionaryEntry(temp.Url, temp))

                    ' The parent node has already been added to the collection.
                    Dim parentNode As SiteMapNode = _
                        FindSiteMapNode(HttpRuntime.AppDomainAppVirtualPath & "/" & nodeValues(3))

                    If Not (parentNode Is Nothing) Then
                      childParentRelationship.Add(New DictionaryEntry(temp.Url, parentNode))
                    Else
                      Throw New Exception("Parent node not found for current node.")
                    End If
                  End If
                End If
              Loop Until s Is Nothing
            Finally
              sr.Close()
            End Try
          Else
            Throw New Exception("File not found")
          End If
        End If
      End SyncLock
      Return
    End Sub 'LoadSiteMapFromStore
  End Class 'SimpleTextSiteMapProvider
  ' </Snippet9>
End Namespace
' </Snippet1>