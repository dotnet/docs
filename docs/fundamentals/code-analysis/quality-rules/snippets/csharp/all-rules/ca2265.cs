using System;

namespace ca2265;
class CA2265
{
    public static void RunIt()
    {
        // <Snippet1>
        Span<int> span = new([1, 2, 3]);
        // CA2265 violation.
        if (span == null) { }
        // CA2265 violation.
        if (span == default) { }

        // Fixes the violation.
        if (span.IsEmpty) { }
        // </Snippet1>
    }
}
