using Azure;
using Azure.Core;

namespace UnitTestingSampleApp.ResourceManager.NonLibrary;

public sealed class MockComputeResourceGroupMockingExtension : ComputeResourceGroupMockingExtension
{
    private VirtualMachineCollection _virtualMachineCollection;
    public MockComputeResourceGroupMockingExtension(VirtualMachineCollection virtualMachineCollection)
    {
        _virtualMachineCollection = virtualMachineCollection;
    }

    public override VirtualMachineCollection GetVirtualMachines()
    {
        return _virtualMachineCollection;
    }
}

public sealed class MockResourceGroupResource : ResourceGroupResource
{
    public MockResourceGroupResource()
    {}

    internal MockResourceGroupResource(ArmClient client, ResourceIdentifier id) : base(client, id)
    {}

    public override T GetCachedClient<T>(Func<ArmClient, T> factory) where T : class
    {
        if (typeof(T) == typeof(ComputeResourceGroupMockingExtension))
            return new MockComputeResourceGroupMockingExtension(new MockVirtualMachineCollection()) as T;
        return base.GetCachedClient(factory);
    }
}

public sealed class MockVirtualMachineCollection : VirtualMachineCollection
{
    public MockVirtualMachineCollection()
    {}

    internal MockVirtualMachineCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
    {}
}
