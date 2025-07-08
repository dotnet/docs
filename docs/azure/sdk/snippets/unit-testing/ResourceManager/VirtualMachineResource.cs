using Azure.Core;

#nullable disable

namespace UnitTestingSampleApp.ResourceManager;

public partial class VirtualMachineResource : ArmResource
{
    internal VirtualMachineResource(ArmClient client, ResourceIdentifier id) : base(client, id)
    { }
}
