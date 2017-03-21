         SecurityElement^ newElement = gcnew SecurityElement(
            L"PolicyStatement" );
         newElement->AddAttribute( L"class", (
            *policyStatement)->ToString() );
         newElement->AddAttribute( L"version", L"1.1" );

         newElement->AddChild( gcnew SecurityElement( L"PermissionSet" ) );

         ( *policyStatement)->FromXml( newElement );