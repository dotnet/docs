Namespace My
  <HideModuleName()> 
  Module MyCustomExtensions
    Private _extension As New ThreadSafeObjectProvider(Of SampleExtension)
    Friend ReadOnly Property SampleExtension() As SampleExtension
      Get
        Return _extension.GetInstance()
      End Get
    End Property
  End Module
End Namespace