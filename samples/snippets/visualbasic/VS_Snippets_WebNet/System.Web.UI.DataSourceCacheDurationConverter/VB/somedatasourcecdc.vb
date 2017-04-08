Imports System
Imports System.ComponentModel
Imports System.Web.UI

Namespace Samples.AspNet.VB.Controls

' <Snippet1>

    <NonVisualControl()>  _
    Public Class SomeDataSource
        Inherits DataSourceControl
        ' Implementation of a custom data source control.
        ' The SdsCache object is an imaginary cache object
        ' provided for this example. It has not actual 
        ' implementation.
        Private myCache As New SdsCache()

        Friend ReadOnly Property Cache() As SdsCache 
            Get
                Return myCache
            End Get
        End Property 

        <TypeConverterAttribute(GetType(DataSourceCacheDurationConverter))>  _
        Public ReadOnly Property CacheDuration() As Integer 
            Get
                Return Cache.Duration
            End Get
        End Property 

        Public Property CacheExpirationPolicy() As DataSourceCacheExpiry 
            Get
                Return Cache.Expiry
            End Get
            Set
                Cache.Expiry = value
            End Set
        End Property 

        Public Property EnableCaching() As Boolean 
            Get
                Return Cache.Enabled
            End Get
            Set
                Cache.Enabled = value
            End Set
        End Property 

        Protected Overrides Function GetView(ByVal viewName As String) As System.Web.UI.DataSourceView
            Throw New Exception("The method or operation is not implemented.")
        End Function
        
        ' Continue implementation of data source control.
        ' ...
        
    End Class 'SomeDataSource 
' </Snippet1>    

    Class SdsCache

        Public Duration As Integer = 0

        Public Enabled As Boolean = True

        Public Expiry As DataSourceCacheExpiry = DataSourceCacheExpiry.Absolute
    End Class 'SdsCache
    
End Namespace