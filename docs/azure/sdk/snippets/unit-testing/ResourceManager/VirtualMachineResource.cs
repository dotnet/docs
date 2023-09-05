using Azure.Core;

namespace UnitTestingSampleApp.ResourceManager;

public partial class VirtualMachineResource : ArmResource
{
    internal VirtualMachineResource(ArmClient client, ResourceIdentifier id) : base(client, id)
    {}
}