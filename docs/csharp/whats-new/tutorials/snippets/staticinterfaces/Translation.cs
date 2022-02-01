public record Translation<T>(T XOffset, T YOffset) : IAdditiveIdentity<Translation<T>, Translation<T>> 
    where T : IAdditionOperators<T, T, T>, IAdditiveIdentity<T,T>
{
    public static Translation<T> AdditiveIdentity =>
        new Translation<T>(XOffset: T.AdditiveIdentity, YOffset: T.AdditiveIdentity);
}
