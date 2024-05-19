#nullable disable

namespace UnitTestingSampleApp.ResourceManager;

public class ResourceManagerCodeStructure
{
    public void CallingExtensionMethodForHierarchy(ResourceGroupResource resourceGroup)
    {
        // <ParentOfVMIsRG>
        VirtualMachineCollection virtualMachineCollection = resourceGroup.GetVirtualMachines();
        // </ParentOfVMIsRG>
    }
}
