namespace SystemTextJsonHowTo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("======== Custom converter Unix Epoch DateTimeOffset =========");
            DateTimeOffset date = DateTimeOffset.Now;
            CustomConverterUnixEpochDate.Program.STJExample(date);
            CustomConverterUnixEpochDate.Program.NewtonsoftExample(date);
            Console.WriteLine();

            Console.WriteLine("======== Custom converter Unix Epoch DateTime =========");
            DateTime date2 = DateTime.Now;
            CustomConverterUnixEpochDateNoZone.Program.STJExample(date2);
            CustomConverterUnixEpochDateNoZone.Program.NewtonsoftExample(date2);
            Console.WriteLine();

            Console.WriteLine("======== Preserve references =========");
            PreserveReferences.Program.Run();
            Console.WriteLine();

            Console.WriteLine("======== Custom converter Preserve references =========");
            CustomConverterPreserveReferences.Program.Run();
            Console.WriteLine();

            Console.WriteLine("======== Preserve references Multiple calls =========");
            PreserveReferencesMultipleCalls.Program.Run();
            Console.WriteLine();

            Console.WriteLine("======== Immutable types =========");
            ImmutableTypes.Program.Run();
            Console.WriteLine();

            Console.WriteLine("======== Immutable types =========");
            ImmutableTypesCtorParms.Program.Run();
            Console.WriteLine();

            Console.WriteLine("======== Record support =========");
            Records.Program.Run();
            Console.WriteLine();

            Console.WriteLine("======== Field support =========");
            Fields.Program.Run();
            Console.WriteLine();

            Console.WriteLine("======== Non-string key dictionary =========");
            NonStringKeyDictionary.Program.Run();
            Console.WriteLine();

            Console.WriteLine("======== HttpClient extension methods =========");
            await HttpClientExtensionMethods.Program.Run();
            Console.WriteLine();

            Console.WriteLine("======== Custom converter handle null =========");
            CustomConverterHandleNull.Program.Run();
            Console.WriteLine();

            Console.WriteLine("======== Custom converter inferred types to object =========");
            CustomConverterInferredTypesToObject.Program.Run();
            Console.WriteLine();

            Console.WriteLine("======== Ignore value type default on serialize =========");
            IgnoreValueDefaultOnSerialize.Program.Run();
            Console.WriteLine();

            Console.WriteLine("======== Ignore null on serialize =========");
            IgnoreNullOnSerialize.Program.Run();
            Console.WriteLine();

            Console.WriteLine("======== Conditionally ignore selected properties on serialize =========");
            JsonIgnoreAttributeExample.Program.Run();
            Console.WriteLine();

            Console.WriteLine("======== Non-public accessors =========");
            NonPublicAccessors.Program.Run();
            Console.WriteLine();

            Console.WriteLine("======== Copy options instance =========");
            CopyOptions.Program.Run();
            Console.WriteLine();

            Console.WriteLine("======== Create options instance with specified defaults =========");
            OptionsDefaults.Program.Run();
            Console.WriteLine();

            Console.WriteLine("======== Quoted numbers =========");
            QuotedNumbers.Program.Run();
            Console.WriteLine();

            Console.WriteLine("======== GuidReferenceResolver =========");
            GuidReferenceResolverExample.Program.Run();
            Console.WriteLine();
        }
    }
}
