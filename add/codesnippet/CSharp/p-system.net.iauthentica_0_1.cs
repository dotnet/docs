    private string m_authenticationType ;
    private bool m_canPreAuthenticate ;

    // The CustomBasic constructor initializes the properties of the customized 
    // authentication.
    public CustomBasic()
    {
      m_authenticationType = "Basic";
      m_canPreAuthenticate = false;
    }

    // Define the authentication type. This type is then used to identify this
    // custom authentication module. The default is set to Basic.
    public string AuthenticationType
    {
      get
      {
        return m_authenticationType;
      }
    }

    // Define the pre-authentication capabilities for the module. The default is set
    // to false.
    public bool CanPreAuthenticate
    {
      get
      {
        return m_canPreAuthenticate;
      }
    }