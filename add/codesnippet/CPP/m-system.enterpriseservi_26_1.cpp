
// Note: Access checks must be performed at the component level to allow access
// to private components.
[assembly: ApplicationAccessControl(false,
AccessChecksLevel=AccessChecksLevelOption::ApplicationComponent)];

[PrivateComponent]
public ref class PrivateComponentAttributeExample : public ServicedComponent
{
public:
    void DisplayMessage()
    {
        // Display some output.
        Console::WriteLine("Private component called successfully.");
    }
};