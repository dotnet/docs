// <Snippet1>
using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        // Set the default culture and display the current date in the current application domain.
        Info info1 = new Info();
        SetAppDomainCultures("fr-FR");

        // Create a second application domain.
        AppDomainSetup setup = new AppDomainSetup();
        setup.AppDomainInitializer = SetAppDomainCultures;
        setup.AppDomainInitializerArguments = new string[] { "ru-RU" };
        AppDomain domain = AppDomain.CreateDomain("Domain2", null, setup);
        // Create an Info object in the new application domain.
        Info info2 = (Info)domain.CreateInstanceAndUnwrap(typeof(Example).Assembly.FullName,
                                                           "Info");

        // Execute methods in the two application domains.
        info2.DisplayDate();
        info2.DisplayCultures();

        info1.DisplayDate();
        info1.DisplayCultures();
    }

    public static void SetAppDomainCultures(string[] names)
    {
        SetAppDomainCultures(names[0]);
    }

    public static void SetAppDomainCultures(string name)
    {
        try
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture(name);
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CreateSpecificCulture(name);
        }
        // If an exception occurs, we'll just fall back to the system default.
        catch (CultureNotFoundException)
        {
            return;
        }
        catch (ArgumentException)
        {
            return;
        }
    }
}

public class Info : MarshalByRefObject
{
    public void DisplayDate()
    {
        Console.WriteLine($"Today is {DateTime.Now:D}");
    }

    public void DisplayCultures()
    {
        Console.WriteLine($"Application domain is {AppDomain.CurrentDomain.Id}");
        Console.WriteLine($"Default Culture: {CultureInfo.DefaultThreadCurrentCulture}");
        Console.WriteLine($"Default UI Culture: {CultureInfo.DefaultThreadCurrentUICulture}");
    }
}
// The example displays the following output:
//       Today is 14 октября 2011 г.
//       Application domain is 2
//       Default Culture: ru-RU
//       Default UI Culture: ru-RU
//       Today is vendredi 14 octobre 2011
//       Application domain is 1
//       Default Culture: fr-FR
//       Default UI Culture: fr-FR
// </Snippet1>
