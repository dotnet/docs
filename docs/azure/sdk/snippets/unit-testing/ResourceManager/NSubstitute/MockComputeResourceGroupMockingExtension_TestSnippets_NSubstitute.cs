using NSubstitute;

namespace UnitTestingSampleApp.ResourceManager.NSubstitute;

public class MockComputeResourceGroupMockingExtension_TestSnippets_NSubstitute
{
    public void GetVirtualMachinesSnippets()
    {
        ResourceGroupResource rgMock = Substitute.For<ResourceGroupResource>();
        MockableComputeResourceGroupResource mockableRg =
            Substitute.For<MockableComputeResourceGroupResource>();
        // mock the actual method
        mockableRg.GetVirtualMachines()
            .Returns(Substitute.For<VirtualMachineCollection>());
        // mock the GetCachedClient method
        rgMock.GetCachedClient(Arg.Any<Func<ArmClient, MockableComputeResourceGroupResource>>())
            .Returns(mockableRg);

        ResourceGroupResource resourceGroup = rgMock;
    }
}
