    <DesignTimeResourceProviderFactoryAttribute(GetType(CustomDesignTimeResourceProviderFactory))> _
    Public Class CustomResourceProviderFactory
        Inherits ResourceProviderFactory
        Public Overrides Function CreateGlobalResourceProvider(ByVal classname As String) As IResourceProvider
            Return New CustomResourceProvider(Nothing, classname)
        End Function
        Public Overrides Function CreateLocalResourceProvider(ByVal virtualPath As String) As IResourceProvider
            Return New CustomResourceProvider(virtualPath, Nothing)
        End Function
    End Class

    ' Define the resource provider for global and local resources.
    Friend Class CustomResourceProvider
        Implements IResourceProvider
        Dim _virtualPath As String
        Dim _className As String

        Public Sub New(ByVal virtualPath As String, ByVal classname As String)
            _virtualPath = virtualPath
            _className = classname
        End Sub

        Private Function GetResourceCache(ByVal culturename As String) As IDictionary
            Return System.Web.HttpContext.Current.Cache(culturename)
        End Function

        Function GetObject(ByVal resourceKey As String, ByVal culture As CultureInfo) As Object Implements IResourceProvider.GetObject
            Dim value As Object
            Dim cultureName As String
            cultureName = Nothing
            If (IsNothing(culture)) Then
                cultureName = CultureInfo.CurrentUICulture.Name
            Else
                cultureName = culture.Name
            End If

            value = GetResourceCache(cultureName)(resourceKey)
            If (value = Nothing) Then
                value = GetResourceCache(Nothing)(resourceKey)
            End If
            Return value
        End Function


        ReadOnly Property ResourceReader() As IResourceReader Implements IResourceProvider.ResourceReader
            Get
                Dim cultureName As String
                Dim currentUICulture As CultureInfo
                cultureName = Nothing
                currentUICulture = CultureInfo.CurrentUICulture
                If (Not (String.Equals(currentUICulture.Name, CultureInfo.InstalledUICulture.Name))) Then
                    cultureName = currentUICulture.Name
                End If

                Return New CustomResourceReader(GetResourceCache(cultureName))
            End Get
        End Property
    End Class

    Friend NotInheritable Class CustomResourceReader
        Implements IResourceReader
        Private _resources As IDictionary

        Public Sub New(ByVal resources As IDictionary)
            _resources = resources
        End Sub

        Function GetEnumerator1() As IDictionaryEnumerator Implements IResourceReader.GetEnumerator
            Return _resources.GetEnumerator()
        End Function

        Sub Close() Implements IResourceReader.Close

        End Sub

        Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return _resources.GetEnumerator()
        End Function

        Sub Dispose() Implements IDisposable.Dispose

        End Sub
    End Class