public class ConfigBindingSG
{
    static void RunIt(params string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        IConfigurationSection section = builder.Configuration.GetSection("MyOptions");

        // !! Configure call - to be replaced with source-gen'd implementation
        builder.Services.Configure<MyOptions>(section);

        // !! Get call - to be replaced with source-gen'd implementation
        MyOptions? options0 = section.Get<MyOptions>();

        // !! Bind call - to be replaced with source-gen'd implementation
        MyOptions options1 = new();
        section.Bind(options1);

        WebApplication app = builder.Build();
        app.MapGet("/", () => "Hello World!");
        app.Run();
    }

    public class MyOptions
    {
        public int A { get; set; }
        public string S { get; set; }
        public byte[] Data { get; set; }
        public Dictionary<string, string> Values { get; set; }
        public List<MyClass> Values2 { get; set; }
    }

    public class MyClass
    {
        public int SomethingElse { get; set; }
    }
}
