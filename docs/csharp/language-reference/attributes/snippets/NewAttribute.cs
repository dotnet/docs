namespace AttributeExamples
{
    namespace VersionOne
    {
        // <SnippetUsageFirst>
        [AttributeUsage(AttributeTargets.All,
                           AllowMultiple = false,
                           Inherited = true)]
        class NewAttribute : Attribute { }
        // </SnippetUsageFirst>
    }
    namespace VersionTwo
    {
        // <SnippetUsageSecond>
        [AttributeUsage(AttributeTargets.All)]
        class NewAttribute : Attribute { }
        // </SnippetUsageSecond>
    }
}
