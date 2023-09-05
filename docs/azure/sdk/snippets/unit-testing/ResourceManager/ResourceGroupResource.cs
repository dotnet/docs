using Azure.Core;

namespace UnitTestingSampleApp.ResourceManager;

public partial class ResourceGroupResource : ArmResource
{
    protected ResourceGroupResource()
    { }

    internal ResourceGroupResource(ArmClient client, ResourceIdentifier id) : base(client, id)
    { }
}