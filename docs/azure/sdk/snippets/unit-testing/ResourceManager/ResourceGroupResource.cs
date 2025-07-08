using Azure.Core;

#nullable disable

namespace UnitTestingSampleApp.ResourceManager;

public partial class ResourceGroupResource : ArmResource
{
    protected ResourceGroupResource()
    { }

    internal ResourceGroupResource(ArmClient client, ResourceIdentifier id) : base(client, id)
    { }
}
