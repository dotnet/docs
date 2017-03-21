public partial class SampleServiceClient : System.ServiceModel.ClientBase<ISampleService>, ISampleService
{
    
    public SampleServiceClient()
    {
    }
    
    public SampleServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public SampleServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public SampleServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public SampleServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public string SampleMethod(string msg)
    {
        return base.Channel.SampleMethod(msg);
    }
}