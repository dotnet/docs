      ' Create the 'HttpBinding' object.
      Dim myHttpBinding As New HttpBinding()
      
      myHttpBinding.Verb = "POST"
      ' Add the 'HttpBinding' to the 'Binding'.
      myBinding.Extensions.Add(myHttpBinding)