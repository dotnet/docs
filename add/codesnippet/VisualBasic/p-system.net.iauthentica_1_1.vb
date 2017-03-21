      Private m_authenticationType As String
      Private m_canPreAuthenticate As Boolean


      ' The CustomBasic constructor initializes the properties of the customized 
      ' authentication.
      Public Sub New()
        m_authenticationType = "Basic"
        m_canPreAuthenticate = False
      End Sub 'New

      ' Define the authentication type. This type is then used to identify this
      ' custom authentication module. The default is set to Basic.

      Public ReadOnly Property AuthenticationType() As String _
       Implements IAuthenticationModule.AuthenticationType

        Get
          Return m_authenticationType
        End Get
      End Property

      ' Define the pre-authentication capabilities for the module. The default is set
      ' to false.

      Public ReadOnly Property CanPreAuthenticate() As Boolean _
       Implements IAuthenticationModule.CanPreAuthenticate


        Get
          Return m_canPreAuthenticate
        End Get
      End Property
