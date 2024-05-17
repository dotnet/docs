using Moq;

namespace UnitTestingSampleApp.ResourceManager.Moq;

public class MockComputeResourceGroupMockingExtension_TestSnippets_Moq
{
    public void GetVirtualMachinesSnippets()
    {
        Mock<ResourceGroupResource> rgMock = new();
        Mock<MockableComputeResourceGroupResource> mockableRg = new();

        // mock the actual implementation on ComputeResourceGroupMockingExtension
        mockableRg.Setup(rg => rg.GetVirtualMachines())
            .Returns(Mock.Of<VirtualMachineCollection>());

        // mock the GetCachedClient method to hook up the mockable resource and the extension method
        rgMock.Setup(rg => rg.GetCachedClient(
                It.IsAny<Func<ArmClient,MockableComputeResourceGroupResource>>()))
            .Returns(mockableRg.Object);
        
        ResourceGroupResource resourceGroup = rgMock.Object;
    }
}
