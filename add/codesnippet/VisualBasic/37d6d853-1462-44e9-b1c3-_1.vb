Imports System.Web.Hosting

Public Class SampleComponentFactory
  Implements IRegisteredObject

  Dim components As ArrayList = New ArrayList()

  Public Sub Start()
    HostingEnvironment.RegisterObject(Me)
  End Sub

  Public Sub [Stop](ByVal immediate As Boolean) Implements System.Web.Hosting.IRegisteredObject.Stop
    For Each c As SampleComponent In components
      CType(c, IRegisteredObject).Stop(immediate)
    Next
    HostingEnvironment.UnregisterObject(Me)
  End Sub

  Public Function CreateComponent() As SampleComponent
    Dim newComponent As SampleComponent
    newComponent = New SampleComponent
    newComponent.Initialize()

    components.Add(newComponent)
    Return newComponent
  End Function
End Class

Public Class SampleComponent
  Implements IRegisteredObject


  Sub [Stop](ByVal immediate As Boolean) Implements System.Web.Hosting.IRegisteredObject.Stop
    ' Clean up component resources here.
  End Sub

  Public Sub Initialize()
    ' Initialize component here.
  End Sub
End Class