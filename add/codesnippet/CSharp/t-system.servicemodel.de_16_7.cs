namespace TestPrincipalPermission
{
    class PrincipalPermissionModeWindows
    {
    
        [ServiceContract]
        interface ISecureService
        {
            [OperationContract]
            string Method1();
        }
                
        class SecureService : ISecureService
        {
            [PrincipalPermission(SecurityAction.Demand, Role = "everyone")]
            public string Method1()
            {
                return String.Format("Hello, \"{0}\"", Thread.CurrentPrincipal.Identity.Name);
            }
        }

        public void Run()
        {
            Uri serviceUri = new Uri(@"http://localhost:8006/Service");
            ServiceHost service = new ServiceHost(typeof(SecureService));
            service.AddServiceEndpoint(typeof(ISecureService), GetBinding(), serviceUri);
            service.Authorization.PrincipalPermissionMode = PrincipalPermissionMode.UseAspNetRoles;
            service.Open();

            EndpointAddress sr = new EndpointAddress(
                serviceUri, EndpointIdentity.CreateUpnIdentity(WindowsIdentity.GetCurrent().Name));
            ChannelFactory<ISecureService> cf = new ChannelFactory<ISecureService>(GetBinding(), sr);
            ISecureService client = cf.CreateChannel();
            Console.WriteLine("Client received response from Method1: {0}", client.Method1());
            ((IChannel)client).Close();
            Console.ReadLine();
            service.Close();
            
        }

        public static Binding GetBinding()
        {
            WSHttpBinding binding = new WSHttpBinding(SecurityMode.Message);
            binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
            return binding;
        }
    }
}