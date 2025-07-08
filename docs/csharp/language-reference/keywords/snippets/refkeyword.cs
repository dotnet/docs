public class RefKeywordExamples
{
    // <PassByReference>
    public void M(ref int refParameter)
    {
        refParameter += 42;
    }
    // </PassByReference>

    // <ReturnByReference>
    public ref int RefMax(ref int left, ref int right)
    {
        if (left > right)
        {
            return ref left;
        }
        else
        {
            return ref right;
        }
    }
    // </ReturnByReference>

    // <LocalRef>
    public void M2(int variable)
    {
        ref int aliasOfvariable = ref variable;
    }
    // </LocalRef> 

    // <ConditionalRef>
    public ref int RefMaxConditions(ref int left, ref int right)
    {
        ref int returnValue = ref left > right ? ref left : ref right;
        return ref returnValue;
    }
    // </ConditionalRef>
}

// <SnippetRefStruct>
public ref struct CustomRef
{
    public ReadOnlySpan<int> Inputs;
    public ReadOnlySpan<int> Outputs;
}
// </SnippetRefStruct>

// <SnippetRefField>
public ref struct RefFieldExample
{
    private ref int number;
}
// </SnippetRefField>

// <SnippetRefGeneric>
class RefStructGeneric<T, S>
    where T : allows ref struct
    where S : T
{
    // etc
}
// </SnippetRefGeneric>
