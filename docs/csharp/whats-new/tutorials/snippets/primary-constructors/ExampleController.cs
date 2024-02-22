using StructTwo;
using Microsoft.AspNetCore.Mvc;

namespace PrimaryConstructors;

// <DependencyInjection>
public interface IService
{
    Distance GetDistance();
}

public class ExampleController(IService service) : ControllerBase
{
    [HttpGet]
    public ActionResult<Distance> Get()
    {
        return service.GetDistance();
    }
}
// </DependencyInjection>
