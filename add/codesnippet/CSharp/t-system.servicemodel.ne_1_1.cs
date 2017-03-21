                NetNamedPipeBinding nnpb = new NetNamedPipeBinding();
                NetNamedPipeSecurity nnpSecurity = nnpb.Security;
                nnpSecurity.Mode = NetNamedPipeSecurityMode.Transport;
                NamedPipeTransportSecurity npts = nnpSecurity.Transport;
                serviceHost.AddServiceEndpoint(typeof(ICalculator), nnpb, "net.pipe://localhost/ServiceModelSamples/Service");