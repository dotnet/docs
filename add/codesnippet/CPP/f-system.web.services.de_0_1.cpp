   // Create 'Binding' object.
   Binding^ myBinding = gcnew Binding;
   myBinding->Name = "MyHttpBindingServiceHttpPost";
   XmlQualifiedName^ qualifiedName = gcnew XmlQualifiedName( "s0:MyHttpBindingServiceHttpPost" );
   myBinding->Type = qualifiedName;
   
   // Create 'HttpBinding' object.
   HttpBinding^ myHttpBinding = gcnew HttpBinding;
   myHttpBinding->Verb = "POST";
   Console::WriteLine( "HttpBinding Namespace : {0}", HttpBinding::Namespace );