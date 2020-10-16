using System;
using System.Threading.Tasks;

namespace SystemTextJsonHowTo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("======== Preserve references =========");
            PreserveReferences.Program.Main();
            Console.WriteLine();

            Console.WriteLine("======== Immutable types =========");
            Console.WriteLine("======== JsonConstructor for structs =========");
            ImmutableTypes.Program.Main();
            Console.WriteLine();

            Console.WriteLine("======== Record support =========");
            Records.Program.Main();
            Console.WriteLine();

            Console.WriteLine("======== Field support =========");
            Fields.Program.Main();
            Console.WriteLine();

            Console.WriteLine("======== Non-string key dictionary =========");
            NonStringKeyDictionary.Program.Main();
            Console.WriteLine();

            Console.WriteLine("======== HttpClient extension methods =========");
            await HttpClientExtensionMethods.Program.Main();
            Console.WriteLine();

            Console.WriteLine("======== Custom converter handle null =========");
            Console.WriteLine("======== JsonConstructor for parameterized constructor =========");
            CustomConverterHandleNull.Program.Main();
            Console.WriteLine();

            Console.WriteLine("======== Ignore value type default on serialize =========");
            IgnoreValueDefaultOnSerialize.Program.Main();
            Console.WriteLine();

            Console.WriteLine("======== Non-public accessors =========");
            NonPublicAccessors.Program.Main();
            Console.WriteLine();

            Console.WriteLine("======== Copy options instance =========");
            CopyOptions.Program.Main();
            Console.WriteLine();

            Console.WriteLine("======== Create options instance with specified defaults =========");
            OptionsDefaults.Program.Main();
            Console.WriteLine();
        }
    }
}
