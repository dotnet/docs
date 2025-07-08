using Azure.Core;

#nullable disable

namespace UnitTestingSampleApp.ResourceManager;

public static partial class ComputeExtensions
{
    private static MockableComputeResourceGroupResource GetMockableComputeResourceGroupResource(
        ArmResource resource)
    {
        return resource.GetCachedClient(client =>
            new MockableComputeResourceGroupResource(client, resource.Id));
    }

    public static VirtualMachineCollection GetVirtualMachines(
        this ResourceGroupResource resourceGroup)
    {
        return GetMockableComputeResourceGroupResource(resourceGroup)
            .GetVirtualMachines();
    }
}

public partial class MockableComputeResourceGroupResource : ArmResource
{
    protected MockableComputeResourceGroupResource()
    { }

    internal MockableComputeResourceGroupResource(
        ArmClient client, ResourceIdentifier id) : base(client, id)
    { }

    public virtual VirtualMachineCollection GetVirtualMachines()
    {
        return new VirtualMachineCollection(Client, Id);
    }
}
