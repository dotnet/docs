Imports System
Imports System.Web
Imports System.Web.Caching

' A namespace that contains a class, CustomCacheDependency, that 
' extends the functionality of the CacheDependency class.
Namespace CachingSamples
' <snippet1>
   ' Declare the class.
   Public Class CustomCacheDependency 
      Inherits CacheDependency

        ' Constructor with no arguments 
        ' provided by CacheDependency class.
        Public Sub New()
        End Sub ' New
      
        ' Declare a Boolean field named disposedValue.
        ' This will be used by Disposed property.
        Private disposedValue As Boolean                
        
        ' Create accessors for the Disposed property.
        Public Property Disposed As Boolean
          Get
              Return disposedValue
          End Get
          Set (ByVal value As Boolean)
              disposedValue = value
          End Set
        End Property
        
        ' Create a public method that sets the latest
        ' changed time of the CustomCacheDependency
        ' and notifies the underlying CacheDependency that the 
        ' dependency has changed, even though the HasChanged
        ' property is false.
        Public Sub ResetDependency()
           If Me.HasChanged = False              
              SetUtcLastModified(DateTime.MinValue)
              NotifyDependencyChanged(Me, EventArgs.Empty)
           End If
        End Sub
        
        ' Overrides the DependencyDispose method to set the
        ' Disposed proerty to true. This method automatically
        ' notifies the underlying CacheDependency object to 
        ' release any resources associated with this class. 
        Protected Overrides Sub DependencyDispose()
           Disposed = True
        End Sub
        
        
    End Class
' </snippet1>
End Namespace
