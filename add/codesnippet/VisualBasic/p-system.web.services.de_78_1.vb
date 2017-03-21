         Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read ("MimeContentSample_vb.wsdl")

         ' Get the Binding.
         Dim myBinding As Binding = myServiceDescription.Bindings("b1")

         ' Get the first OperationBinding.
         Dim myOperationBinding As OperationBinding = myBinding.Operations(0)
         Dim myOutputBinding As OutputBinding = myOperationBinding.Output
         Dim myServiceDescriptionFormatExtensionCollection As _
            ServiceDescriptionFormatExtensionCollection = _
            myOutputBinding.Extensions

         ' Find all MimeContentBinding objects in extensions.
         Dim myMimeContentBindings As MimeContentBinding() = _
            CType(myServiceDescriptionFormatExtensionCollection.FindAll( _
            GetType(MimeContentBinding)), MimeContentBinding())

         ' Enumerate the array and display MimeContentBinding properties.
         Dim myMimeContentBinding As MimeContentBinding
         For Each myMimeContentBinding In  myMimeContentBindings
            Console.WriteLine("Type: " & myMimeContentBinding.Type)
            Console.WriteLine("Part: " & myMimeContentBinding.Part)
         Next myMimeContentBinding