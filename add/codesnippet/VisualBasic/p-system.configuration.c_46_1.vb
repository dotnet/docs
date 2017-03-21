        ' Create an object based on HostingContext.
        Dim myWC As WebContext = _
          config.EvaluationContext.HostingContext
        ' Use the WebContext object to determine
        ' the ApplicationLevel.
        Console.WriteLine("ApplicationLevel: {0}", _
          myWC.ApplicationLevel)