using System.Collections.Generic;

namespace Initializers
{
    public class Examples
    {
        // <CollectionInitializer>
        private Dictionary<int, string> messages = new Dictionary<int, string>
        {
            { 404, "Page not Found"},
            { 302, "Page moved, but left a forwarding address."},
            { 500, "The web server can't come out to play today."}
        };
        // </CollectionInitializer>

        // <DictionaryInitializer>
        private Dictionary<int, string> webErrors = new Dictionary<int, string>
        {
            [404] = "Page not Found",
            [302] = "Page moved, but left a forwarding address.",
            [500] = "The web server can't come out to play today."
        };
         // </DictionaryInitializer>
    }
}