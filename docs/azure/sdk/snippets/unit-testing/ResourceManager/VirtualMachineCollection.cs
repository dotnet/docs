using Azure.Core;

#nullable disable

namespace UnitTestingSampleApp.ResourceManager;

public class VirtualMachineCollection : ArmCollection
{
    protected VirtualMachineCollection()
    { }

    internal VirtualMachineCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
    { }
}
