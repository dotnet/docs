using Azure;
using NSubstitute;

namespace UnitTestingSampleApp.ResourceManager.NSubstitute;

public class MockComputeResourceGroupMockingExtension_TestSnippets_NSubstitute
{
    public void GetVirtualMachinesSnippets()
    {
        // <NSubstitute_GetVirtualMachines>
        ResourceGroupResource rgMock = Substitute.For<ResourceGroupResource>();
        ComputeResourceGroupMockingExtension rgMockingExtensionMock = Substitute.For<ComputeResourceGroupMockingExtension>();
        // mock the actual method
        rgMockingExtensionMock.GetVirtualMachines()
            .Returns(Substitute.For<VirtualMachineCollection>());
        // mock the GetCachedClient method
        rgMock.GetCachedClient(Arg.Any<Func<ArmClient, ComputeResourceGroupMockingExtension>>())
            .Returns(rgMockingExtensionMock);

        ResourceGroupResource resourceGroup = rgMock;
        // </NSubstitute_GetVirtualMachines>
    }
}
