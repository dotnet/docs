using System.Collections.Generic;

namespace Initializers
{
    public class Examples
    {
        // <ListInitializer>
        private List<string> messages = new List<string> 
        {
            "Page not Found",
            "Page moved, but left a forwarding address.",
            "The web server can't come out to play today."
        };
        // </ListInitializer>

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