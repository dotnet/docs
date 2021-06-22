using System;
using System.Threading.Tasks;

namespace SystemTextJsonHowTo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("======== Custom converter Unix Epoch DateTimeOffset =========");
            CustomConverterUnixEpochDate.Program.Main();
            Console.WriteLine();

            Console.WriteLine("======== Custom converter Unix Epoch DateTime =========");
            CustomConverterUnixEpochDateNoZone.Program.Main();
            Console.WriteLine();

            Console.WriteLine("======== Preserve references =========");
            PreserveReferences.Program.Main();
            Console.WriteLine();

            Console.WriteLine("======== Custom converter Preserve references =========");
            CustomConverterPreserveReferences.Program.Main();
            Console.WriteLine();

            Console.WriteLine("======== Preserve references Multiple calls =========");
            PreserveReferencesMultipleCalls.Program.Main();
            Console.WriteLine();

            Console.WriteLine("======== Immutable types =========");
            ImmutableTypes.Program.Main();
            Console.WriteLine();

            Console.WriteLine("======== Immutable types =========");
            ImmutableTypesCtorParms.Program.Main();
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
            CustomConverterHandleNull.Program.Main();
            Console.WriteLine();

            Console.WriteLine("======== Custom converter inferred types to object =========");
            CustomConverterInferredTypesToObject.Program.Main();
            Console.WriteLine();

            Console.WriteLine("======== Ignore value type default on serialize =========");
            IgnoreValueDefaultOnSerialize.Program.Main();
            Console.WriteLine();

            Console.WriteLine("======== Ignore null on serialize =========");
            IgnoreNullOnSerialize.Program.Main();
            Console.WriteLine();

            Console.WriteLine("======== Conditionally ignore selected properties on serialize =========");
            JsonIgnoreAttributeExample.Program.Main();
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

            Console.WriteLine("======== Quoted numbers =========");
            QuotedNumbers.Program.Main();
            Console.WriteLine();

            Console.WriteLine("======== GuidReferenceResolver =========");
            GuidReferenceResolverExample.Program.Main();
            Console.WriteLine();
        }
    }
}
