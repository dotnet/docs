namespace Shared
{
    public record IdentifiableJokeValue(int Id)
    {
        private string? _joke;

        public string? Joke
        {
            // The _joke contains HTML with first-rate typesetting
            // replace the named entity with the double quote string.
            init => _joke = value?.Replace("&quot;", "\"");
            get => _joke;
        }
    }
}
