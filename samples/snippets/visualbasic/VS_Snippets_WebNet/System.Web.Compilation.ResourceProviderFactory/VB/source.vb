' <Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Web.Compilation
Imports System.Resources
Imports System.Globalization
Imports System.Collections
Imports System.Reflection
Imports System.Web.UI.Design
Namespace CustomResourceProviders
    ' <Snippet2>
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
    ' </Snippet2>

    Public Class CustomDesignTimeResourceProviderFactory
        Inherits DesignTimeResourceProviderFactory

        Private _localResourceProvider As New CustomDesignTimeLocalResourceProvider
        Private _localResourceWriter As New CustomDesignTimeLocalResourceWriter
        Private _globalResourceProvider As New CustomDesignTimeGlobalResourceProvider

        Public Overrides Function CreateDesignTimeLocalResourceProvider(ByVal serviceProvider As IServiceProvider) As IResourceProvider
            ' Return an IResourceProvider.
            If (_localResourceProvider Is Nothing) Then
                _localResourceProvider = New CustomDesignTimeLocalResourceProvider
            End If
            Return _localResourceProvider
        End Function
        Public Overrides Function CreateDesignTimeLocalResourceWriter(ByVal serviceProvider As IServiceProvider) As IDesignTimeResourceWriter
            ' Return an IDesignTimeResourceWriter.
            If (_localResourceWriter Is Nothing) Then
                _localResourceWriter = New CustomDesignTimeLocalResourceWriter
            End If
            Return _localResourceWriter
        End Function
        Public Overrides Function CreateDesignTimeGlobalResourceProvider(ByVal serviceProvider As IServiceProvider, ByVal classKey As String) As IResourceProvider
            ' Return an IResourceProvider.
            If (_globalResourceProvider Is Nothing) Then
                _globalResourceProvider = New CustomDesignTimeGlobalResourceProvider
            End If
            Return _globalResourceProvider
        End Function
    End Class

    ' </Snippet1>

    Public Class CustomDesignTimeLocalResourceProvider
        Implements IResourceProvider

        Function GetObject(ByVal resourceKey As String, ByVal culture As CultureInfo) As Object Implements IResourceProvider.GetObject
            Return Nothing
        End Function


        ReadOnly Property ResourceReader() As IResourceReader Implements IResourceProvider.ResourceReader
            Get
                Return Nothing
            End Get
        End Property
    End Class

    Public Class CustomDesignTimeLocalResourceWriter
        Implements IDesignTimeResourceWriter
        Sub AddResource(ByVal name As String, ByVal value As Byte()) Implements IDesignTimeResourceWriter.AddResource

        End Sub
        Sub AddResource(ByVal name As String, ByVal value As String) Implements IDesignTimeResourceWriter.AddResource

        End Sub
        Sub AddResource(ByVal name As String, ByVal value As Object) Implements IDesignTimeResourceWriter.AddResource

        End Sub
        Sub Close() Implements IResourceWriter.Close

        End Sub
        Sub Generate() Implements IResourceWriter.Generate

        End Sub
        Sub Dispose() Implements IDisposable.Dispose

        End Sub
        Function CreateResourceKey(ByVal resourceName As String, ByVal obj As Object) As String Implements IDesignTimeResourceWriter.CreateResourceKey
            Return String.Empty
        End Function
    End Class

    Public Class CustomDesignTimeGlobalResourceProvider
        Implements IResourceProvider

        Function GetObject(ByVal resourceKey As String, ByVal culture As CultureInfo) As Object Implements IResourceProvider.GetObject
            Return Nothing
        End Function


        ReadOnly Property ResourceReader() As IResourceReader Implements IResourceProvider.ResourceReader
            Get
                Return Nothing
            End Get
        End Property
    End Class
End Namespace
