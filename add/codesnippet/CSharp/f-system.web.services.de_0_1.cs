      // Create 'Binding' object.
      Binding myBinding = new Binding();
      myBinding.Name = "MyHttpBindingServiceHttpPost";
      XmlQualifiedName qualifiedName = new XmlQualifiedName("s0:MyHttpBindingServiceHttpPost");
      myBinding.Type = qualifiedName;
      // Create 'HttpBinding' object.
      HttpBinding myHttpBinding = new HttpBinding();
      myHttpBinding.Verb = "POST";
      Console.WriteLine("HttpBinding Namespace : "+HttpBinding.Namespace);