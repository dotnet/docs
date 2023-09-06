using Azure.Core;

namespace UnitTestingSampleApp.ResourceManager;

// <HowExtensionMethodsAreImplemented>
public static partial class ComputeExtensions
{
    private static ComputeResourceGroupMockingExtension GetComputeResourceGroupMockingExtension(
        ArmResource resource)
    {
        return resource.GetCachedClient(client =>
            new ComputeResourceGroupMockingExtension(client, resource.Id));
    }

    public static VirtualMachineCollection GetVirtualMachines(
        this ResourceGroupResource resourceGroup)
    {
        return GetComputeResourceGroupMockingExtension(resourceGroup)
            .GetVirtualMachines();
    }
}

public partial class ComputeResourceGroupMockingExtension : ArmResource
{
    protected ComputeResourceGroupMockingExtension()
    { }

    internal ComputeResourceGroupMockingExtension(
        ArmClient client, ResourceIdentifier id) : base(client, id)
    { }

    public virtual VirtualMachineCollection GetVirtualMachines()
    {
        return new VirtualMachineCollection(Client, Id);
    }
}
// </HowExtensionMethodsAreImplemented>