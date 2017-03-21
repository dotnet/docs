
               // Create the 'HttpBinding' object.
               HttpBinding myHttpBinding = new HttpBinding();

               myHttpBinding.Verb="POST";
               // Add the 'HttpBinding' to the 'Binding'.
               myBinding.Extensions.Add(myHttpBinding);