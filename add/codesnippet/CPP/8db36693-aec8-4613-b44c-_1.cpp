   // The PreAuthenticate method specifies if the authentication implemented
   // by this class allows pre-authentication.
   // Even if you do not use it, this method must be implemented to obey to the rules
   // of interface implemebtation.
   // In this case it always returns null.
   virtual Authorization^ PreAuthenticate( WebRequest^ request, ICredentials^ credentials )
   {
      return nullptr;
   }

