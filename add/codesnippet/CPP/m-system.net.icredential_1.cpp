ref class CredentialList: public ICredentials
{
private:
   ref class CredentialInfo
   {
   public:
      Uri^ uriObj;
      String^ authenticationType;
      NetworkCredential^ networkCredentialObj;
      CredentialInfo( Uri^ uriObj, String^ authenticationType, NetworkCredential^ networkCredentialObj )
      {
         this->uriObj = uriObj;
         this->authenticationType = authenticationType;
         this->networkCredentialObj = networkCredentialObj;
      }
   };

   ArrayList^ arrayListObj;

public:
   CredentialList()
   {
      arrayListObj = gcnew ArrayList;
   }

   void Add( Uri^ uriObj, String^ authenticationType, NetworkCredential^ credential )
   {
      
      // Add a 'CredentialInfo' object into a list.
      arrayListObj->Add( gcnew CredentialInfo( uriObj,authenticationType,credential ) );
   }

   // Remove the 'CredentialInfo' object from the list that matches to the given 'Uri' and 'AuthenticationType'
   void Remove( Uri^ uriObj, String^ authenticationType )
   {
      for ( int index = 0; index < arrayListObj->Count; index++ )
      {
         CredentialInfo^ credentialInfo = dynamic_cast<CredentialInfo^>(arrayListObj[ index ]);
         if ( uriObj->Equals( credentialInfo->uriObj ) && authenticationType->Equals( credentialInfo->authenticationType ) )
                  arrayListObj->RemoveAt( index );
      }
   }

   virtual NetworkCredential^ GetCredential( Uri^ uriObj, String^ authenticationType )
   {
      for ( int index = 0; index < arrayListObj->Count; index++ )
      {
         CredentialInfo^ credentialInfoObj = dynamic_cast<CredentialInfo^>(arrayListObj[ index ]);
         if ( uriObj->Equals( credentialInfoObj->uriObj ) && authenticationType->Equals( credentialInfoObj->authenticationType ) )
                  return credentialInfoObj->networkCredentialObj;
      }
      return nullptr;
   }
};