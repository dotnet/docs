using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace null_warnings;
internal class NullWarnings
{
    // <PossibleNullDereference>
    class Container
    {
        public List<string>? States { get; set; }
    }

    internal void PossibleDereferenceNullExamples(string? message)
    {
        Console.WriteLine(message.Length); // CS8602

        var c = new Container { States = { "Red", "Yellow", "Green" } }; // CS8670
    }
    // </PossibleNullDereference>

    // <NullExhaustiveSwitch>
    int AsScale(string status) =>
        status switch
        {
            "Red" => 0,
            "Yellow" => 5,
            "Green" => 10,
            { } => -1
        };
    // </NullExhaustiveSwitch>

}

internal class UpdatedDefinition
{
    // <SnippetUpdatedDefinition>
    class Container
    {
        public List<string> States { get; } = new();
    }
    // </SnippetUpdatedDefinition>

}


