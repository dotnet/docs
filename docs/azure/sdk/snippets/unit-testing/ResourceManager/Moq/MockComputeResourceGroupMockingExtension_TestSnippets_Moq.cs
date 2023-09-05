using Azure;
using Moq;

namespace UnitTestingSampleApp.ResourceManager.Moq;

public class MockComputeResourceGroupMockingExtension_TestSnippets_Moq
{
    public void GetVirtualMachinesSnippets()
    {
        // <Moq_GetVirtualMachines>
        Mock<ResourceGroupResource> rgMock = new Mock<ResourceGroupResource>();
        Mock<ComputeResourceGroupMockingExtension> rgMockingExtensionMock = new Mock<ComputeResourceGroupMockingExtension>();
        // mock the actual implementation on ComputeResourceGroupMockingExtension
        rgMockingExtensionMock.Setup(rg => rg.GetVirtualMachines())
            .Returns(Mock.Of<VirtualMachineCollection>());
        // mock the GetCachedClient method
        rgMock.Setup(rg => rg.GetCachedClient(It.IsAny<Func<ArmClient, ComputeResourceGroupMockingExtension>>()))
            .Returns(rgMockingExtensionMock.Object);
        
        ResourceGroupResource resourceGroup = rgMock.Object;
        // </Moq_GetVirtualMachines>
    }
}
