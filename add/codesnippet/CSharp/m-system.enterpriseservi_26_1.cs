
// Note: Access checks must be performed at the component level to allow access
// to private components.
[assembly: ApplicationAccessControl(false,
AccessChecksLevel=AccessChecksLevelOption.ApplicationComponent)]

[PrivateComponent]
public class PrivateComponentAttribute_Example : ServicedComponent
{
    public void Example()
    {
        // Display some output.
        Console.WriteLine("Private component called successfully.");
    }
}