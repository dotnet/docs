         XmlNamespaceManager^ namespaceManager;
         namespaceManager = gcnew XmlNamespaceManager( xmlDoc->NameTable );
         XmlNodeList^ productsNodeList;
         productsNodeList = xmlDoc->SelectNodes( L"//.", namespaceManager );
         xmlTransform->LoadInput( productsNodeList );