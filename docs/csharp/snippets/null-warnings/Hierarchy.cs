namespace null_warnings
{
    // <Hierarchy>
    public class B
    {
        public virtual string GetMessage(string id) => string.Empty;
    }
    public class D : B
    {
        public override string? GetMessage(string? id) => default;
    }
    // </Hierarchy>
}
