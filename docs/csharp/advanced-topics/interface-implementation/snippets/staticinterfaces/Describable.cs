// <Describable>
public interface IDescribable<T> where T : IDescribable<T>
{
    static abstract string TypeName { get; }
    static virtual string Describe() => T.TypeName;
}
// </Describable>
