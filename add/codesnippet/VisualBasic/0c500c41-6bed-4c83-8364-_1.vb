  Public Sub [Stop](ByVal immediate As Boolean) Implements System.Web.Hosting.IRegisteredObject.Stop
    For Each c As SampleComponent In components
      CType(c, IRegisteredObject).Stop(immediate)
    Next
    HostingEnvironment.UnregisterObject(Me)
  End Sub