// <Snippet1>

[System.ServiceModel.ServiceContractAttribute(
    Namespace = "http://Microsoft.ServiceModel.Samples")]
public interface IAdd
{

	[System.ServiceModel.OperationContractAttribute(
        Action = "http://Microsoft.ServiceModel.Samples/IAdd/Add", 
        ReplyAction = "http://Microsoft.ServiceModel.Samples/IAdd/AddResponse")]
	double Add(double n1, double n2);

}

public interface IAddChannel : IAdd, System.ServiceModel.IClientChannel
{
}

public partial class AddClient : System.ServiceModel.ClientBase<IAdd>, IAdd
{

	public AddClient()
	{
	}

	public AddClient(string endpointConfigurationName)
		:
			base(endpointConfigurationName)
	{
	}

    public AddClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress address)
		:
			base(binding, address)
	{
	}

	public double Add(double n1, double n2)
	{
		return base.Channel.Add(n1, n2);
	}

}


// </Snippet1>
   