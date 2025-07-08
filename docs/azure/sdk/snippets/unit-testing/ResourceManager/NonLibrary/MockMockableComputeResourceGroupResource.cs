using Azure.Core;

namespace UnitTestingSampleApp.ResourceManager.NonLibrary;

public sealed class MockMockableComputeResourceGroupResource : MockableComputeResourceGroupResource
{
    private VirtualMachineCollection _virtualMachineCollection;
    public MockMockableComputeResourceGroupResource(VirtualMachineCollection virtualMachineCollection)
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
    private readonly MockableComputeResourceGroupResource _mockableComputeResourceGroupResource;
    public MockResourceGroupResource(VirtualMachineCollection virtualMachineCollection)
    {
        _mockableComputeResourceGroupResource =
            new MockMockableComputeResourceGroupResource(virtualMachineCollection);
    }

    internal MockResourceGroupResource(ArmClient client, ResourceIdentifier id) : base(client, id)
    {}

    public override T GetCachedClient<T>(Func<ArmClient, T> factory) where T : class
    {
        if (typeof(T) == typeof(MockableComputeResourceGroupResource))
            return _mockableComputeResourceGroupResource as T;
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
