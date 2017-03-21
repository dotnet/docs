public:
   virtual void FromXml( SecurityElement^ e ) override
   {
      // The following code for unrestricted permission is only included as an example for
      // permissions that allow the unrestricted state. It is of no value for this permission.
      String^ elUnrestricted = e->Attribute("Unrestricted");
      if ( nullptr != elUnrestricted )
      {
         m_Unrestricted = Boolean::Parse( elUnrestricted );
         return;
      }

      String^ elName = e->Attribute("Name");
      m_Name = elName == nullptr ? nullptr : elName;
   }