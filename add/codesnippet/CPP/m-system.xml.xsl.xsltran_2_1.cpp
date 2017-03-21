   // Create the XslTransform object.
   XslTransform^ xslt = gcnew XslTransform;
   
   // Load the stylesheet.
   xslt->Load( "output.xsl" );
   
   // Transform the file.
   xslt->Transform("books.xml","books.html");