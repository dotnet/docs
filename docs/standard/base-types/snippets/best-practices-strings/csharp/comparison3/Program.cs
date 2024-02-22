string separated = "\u0061\u030a";
string combined = "\u00e5";

Console.WriteLine("Equal sort weight of {0} and {1} using InvariantCulture: {2}",
                  separated, combined,
                  string.Compare(separated, combined, StringComparison.InvariantCulture) == 0);

Console.WriteLine("Equal sort weight of {0} and {1} using Ordinal: {2}",
                  separated, combined,
                  string.Compare(separated, combined, StringComparison.Ordinal) == 0);

// The example displays the following output:
//     Equal sort weight of a° and å using InvariantCulture: True
//     Equal sort weight of a° and å using Ordinal: False
