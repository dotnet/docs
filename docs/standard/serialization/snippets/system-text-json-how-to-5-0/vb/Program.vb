Namespace SystemTextJsonHowTo
    Module Program

        Sub Main(args As String())
            Call Main1(args).Wait()
        End Sub

        Private Async Function Main1(_0 As String()) As Task
            Console.WriteLine("======== Preserve references =========")
            PreserveReferences.Program.Main()
            Console.WriteLine()

            Console.WriteLine("======== Immutable types =========")
            ImmutableTypes.Program.Main()
            Console.WriteLine()

            Console.WriteLine("======== Field support =========")
            Fields.Program.Main()
            Console.WriteLine()

            Console.WriteLine("======== Non-string key dictionary =========")
            NonStringKeyDictionary.Program.Main()
            Console.WriteLine()

            Console.WriteLine("======== HttpClient extension methods =========")
            Await HttpClientExtensionMethods.Program.Main()
            Console.WriteLine()

            Console.WriteLine("======== Ignore value type default on serialize =========")
            IgnoreValueDefaultOnSerialize.Program.Main()
            Console.WriteLine()

            Console.WriteLine("======== Ignore null on serialize =========")
            IgnoreNullOnSerialize.Program.Main()
            Console.WriteLine()

            Console.WriteLine("======== Conditionally ignore selected properties on serialize =========")
            JsonIgnoreAttributeExample.Program.Main()
            Console.WriteLine()

            Console.WriteLine("======== Non-public accessors =========")
            NonPublicAccessors.Program.Main()
            Console.WriteLine()

            Console.WriteLine("======== Copy options instance =========")
            CopyOptions.Program.Main()
            Console.WriteLine()

            Console.WriteLine("======== Create options instance with specified defaults =========")
            OptionsDefaults.Program.Main()
            Console.WriteLine()

            Console.WriteLine("======== Quoted numbers =========")
            QuotedNumbers.Program.Main()
            Console.WriteLine()

            Console.WriteLine("======== GuidReferenceResolver =========")
            GuidReferenceResolverExample.Program.Main()
            Console.WriteLine()
        End Function

    End Module
End Namespace
