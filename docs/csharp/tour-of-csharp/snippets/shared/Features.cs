namespace TourOfCsharp;

// <DelegateExample>
delegate double Function(double x);

class Multiplier
{
    double _factor;

    public Multiplier(double factor) => _factor = factor;

    public double Multiply(double x) => x * _factor;
}

class DelegateExample
{
    static double[] Apply(double[] a, Function f)
    {
        var result = new double[a.Length];
        for (int i = 0; i < a.Length; i++) result[i] = f(a[i]);
        return result;
    }

    public static void Main()
    {
        double[] a = { 0.0, 0.5, 1.0 };
        double[] squares = Apply(a, (x) => x * x);
        double[] sines = Apply(a, Math.Sin);
        Multiplier m = new(2.0);
        double[] doubles = Apply(a, m.Multiply);
    }
}
// </DelegateExample>

// <DefineAttribute>
public class HelpAttribute : Attribute
{
    string _url;
    string _topic;

    public HelpAttribute(string url) => _url = url;

    public string Url => _url;

    public string Topic
    {
        get => _topic;
        set => _topic = value;
    }
}
// </DefineAttribute>

// <UseAttributes>
[Help("https://docs.microsoft.com/dotnet/csharp/tour-of-csharp/features")]
public class Widget
{
    [Help("https://docs.microsoft.com/dotnet/csharp/tour-of-csharp/features",
    Topic = "Display")]
    public void Display(string text) { }
}
// </UseAttributes>


class Features
{
    public static void Examples()
    {
        ArraysSamples();
        DeclareArrays();
        ArrayOfArrays();
        InitializeArray();

        var weatherData = (Date: DateTime.Now, LowTemp: 5, HighTemp: 30);
        // <StringInterpolation>
        Console.WriteLine($"The low and high temperature on {weatherData.Date:MM-DD-YYYY}");
        Console.WriteLine($"    was {weatherData.LowTemp} and {weatherData.HighTemp}.");
        // Output (similar to):
        // The low and high temperature on 08-11-2020
        //     was 5 and 30.
        // </StringInterpolation>
        DelegateExample.Main();

        ReadAttributes();

    }

    // <AsyncExample>
    public async Task<int> RetrieveDocsHomePage()
    {
        var client = new HttpClient();
        byte[] content = await client.GetByteArrayAsync("https://docs.microsoft.com/");

        Console.WriteLine($"{nameof(RetrieveDocsHomePage)}: Finished downloading.");
        return content.Length;
    }
    // </AsyncExample>


    private static void ReadAttributes()
    {
        // <ReadAttributes>
        Type widgetType = typeof(Widget);

        object[] widgetClassAttributes = widgetType.GetCustomAttributes(typeof(HelpAttribute), false);

        if (widgetClassAttributes.Length > 0)
        {
            HelpAttribute attr = (HelpAttribute)widgetClassAttributes[0];
            Console.WriteLine($"Widget class help URL : {attr.Url} - Related topic : {attr.Topic}");
        }

        System.Reflection.MethodInfo displayMethod = widgetType.GetMethod(nameof(Widget.Display));

        object[] displayMethodAttributes = displayMethod.GetCustomAttributes(typeof(HelpAttribute), false);

        if (displayMethodAttributes.Length > 0)
        {
            HelpAttribute attr = (HelpAttribute)displayMethodAttributes[0];
            Console.WriteLine($"Display method help URL : {attr.Url} - Related topic : {attr.Topic}");
        }
        // </ReadAttributes>
    }

    static double[] Apply(double[] a, Function f)
    {
        double[] result = new double[a.Length];
        for (int i = 0; i < a.Length; i++) result[i] = f(a[i]);
        return result;
    }


    static void ApplyDelegate()
    {
        double[] a = { 0.0, 0.5, 1.0 };
        // <UseDelegate>
        double[] doubles = Apply(a, (double x) => x * 2.0);
        // </UseDelegate>
    }


    private static void InitializeArray()
    {
        {
            // <InitializeArray>
            int[] a = new int[] { 1, 2, 3 };
            // </InitializeArray>
        }
        {
            // <InitializeShortened>
            int[] a = { 1, 2, 3 };
            // </InitializeShortened>
        }
        {
            // <InitializeGenerated>
            int[] t = new int[3];
            t[0] = 1;
            t[1] = 2;
            t[2] = 3;
            int[] a = t;
            // </InitializeGenerated>

            // <EnumerateArray>
            foreach (int item in a)
            {
                Console.WriteLine(item);
            }
            // </EnumerateArray>
        }

    }

    private static void ArrayOfArrays()
    {
        // <ArrayOfArrays>
        int[][] a = new int[3][];
        a[0] = new int[10];
        a[1] = new int[5];
        a[2] = new int[20];
        // </ArrayOfArrays>
    }

    private static void DeclareArrays()
    {
        // <DeclareArrays>
        int[] a1 = new int[10];
        int[,] a2 = new int[10, 5];
        int[,,] a3 = new int[10, 5, 2];
        // </DeclareArrays>
    }

    private static void ArraysSamples()
    {
        // <ArraysSample>
        int[] a = new int[10];
        for (int i = 0; i < a.Length; i++)
        {
            a[i] = i * i;
        }
        for (int i = 0; i < a.Length; i++)
        {
            Console.WriteLine($"a[{i}] = {a[i]}");
        }
        // </ArraysSample>
    }
}
