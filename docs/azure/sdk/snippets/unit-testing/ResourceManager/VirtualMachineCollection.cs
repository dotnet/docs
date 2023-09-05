using Azure.Core;

namespace UnitTestingSampleApp.ResourceManager;

public class VirtualMachineCollection : ArmCollection
{
    protected VirtualMachineCollection()
    {}
    
    internal VirtualMachineCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
    {}
}