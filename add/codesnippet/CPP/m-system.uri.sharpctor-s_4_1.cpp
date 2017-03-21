   // Create an absolute Uri from a string.
   String^ addressString1 = "http://www.contoso.com/";
   String^ addressString2 = "catalog/shownew.htm?date=today";
   Uri^ absoluteUri = gcnew Uri(addressString1);

   // Create a relative Uri from a string.  allowRelative = true to allow for 
   // creating a relative Uri.
   Uri^ relativeUri = gcnew Uri(addressString2);

   // Check whether the new Uri is absolute or relative.
   if (  !relativeUri->IsAbsoluteUri )
      Console::WriteLine( "{0} is a relative Uri.", relativeUri );

   // Create a new Uri from an absolute Uri and a relative Uri.
   Uri^ combinedUri = gcnew Uri( absoluteUri,relativeUri );
   Console::WriteLine( combinedUri->AbsoluteUri );