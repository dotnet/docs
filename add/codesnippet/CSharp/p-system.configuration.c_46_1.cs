          // Create an object based on HostingContext.
          WebContext myWC =
            (WebContext)config.EvaluationContext.HostingContext;
          // Use the WebContext object to determine
          // the ApplicationLevel.
          Console.WriteLine("ApplicationLevel: {0}",
            myWC.ApplicationLevel);