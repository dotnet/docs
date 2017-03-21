   UriBuilder^ uBuild = gcnew UriBuilder( "http://www.contoso.com/" );
   uBuild->Path = "index.htm";
   uBuild->Fragment = "main";
   Uri^ myUri = uBuild->Uri;