public:
   virtual SecurityElement^ ToXml() override
   {
      // Use the SecurityElement class to encode the permission to XML.
      SecurityElement^ esd = gcnew SecurityElement( "IPermission" );
      String^ name = NameIdPermission::typeid->AssemblyQualifiedName;
      esd->AddAttribute( "class", name );
      esd->AddAttribute( "version", "1.0" );
      
      // The following code for unrestricted permission is only included as an example for
      // permissions that allow the unrestricted state. It is of no value for this permission.
      if ( m_Unrestricted )
      {
         esd->AddAttribute( "Unrestricted", true.ToString() );
      }

      if ( m_Name != nullptr )
      {
         esd->AddAttribute( "Name", m_Name );
      }

      return esd;
   }