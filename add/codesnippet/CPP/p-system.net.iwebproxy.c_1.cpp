public ref class WebProxy_Interface: public IWebProxy
{
private:
   // The credentials to be used with the web proxy.
   ICredentials^ iCredentials;

   // Uri of the associated proxy server.
   Uri^ webProxyUri;

public:
   WebProxy_Interface( Uri^ proxyUri )
   {
      webProxyUri = proxyUri;
   }

   property ICredentials^ Credentials 
   {
      // Get and Set the Credentials property.
      virtual ICredentials^ get()
      {
         return iCredentials;
      }
      virtual void set( ICredentials^ value )
      {
         if ( iCredentials != value )
         {
            iCredentials = value;
         }
      }
   }

   // Return the web proxy for the specified destination (destUri).
   virtual Uri^ GetProxy( Uri^ destUri )
   {
      // Always use the same proxy.
      return webProxyUri;
   }

   // Return whether the web proxy should be bypassed for the specified destination (hostUri).
   virtual bool IsBypassed( Uri^ hostUri )
   {
      // Never bypass the proxy.
      return false;
   }
};