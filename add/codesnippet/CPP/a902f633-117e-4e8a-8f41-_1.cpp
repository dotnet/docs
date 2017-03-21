   [System::Security::Permissions::SecurityPermissionAttribute(
   System::Security::Permissions::SecurityAction::LinkDemand,
   Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
   virtual void GetObjectData( SerializationInfo^ info, StreamingContext context ) override
   {
      // Add your custom data if any here.
      RealProxy::GetObjectData( info, context );
   }