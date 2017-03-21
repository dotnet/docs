      ' Create 'Binding' object.
      Dim myBinding As New Binding()
      myBinding.Name = "MyHttpBindingServiceHttpPost"
      Dim qualifiedName As New XmlQualifiedName("s0:MyHttpBindingServiceHttpPost")
      myBinding.Type = qualifiedName
      ' Create 'HttpBinding' object.
      Dim myHttpBinding As New HttpBinding()
      myHttpBinding.Verb = "POST"
      Console.WriteLine("HttpBinding Namespace : " + HttpBinding.Namespace)