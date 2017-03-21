    // The PreAuthenticate method specifies whether the authentication implemented 
    // by this class allows pre-authentication. 
    // Even if you do not use it, this method must be implemented to obey to the rules 
    // of interface implementation.
    // In this case it always returns null. 
    public Authorization PreAuthenticate(WebRequest request, ICredentials credentials) 
    {                
      return null;
    }