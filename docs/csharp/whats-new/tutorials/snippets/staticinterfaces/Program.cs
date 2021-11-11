// See https://aka.ms/new-console-template for more information

// <TestAddition>
var pt = new Point<int>(3, 4);

var translate = new Translation<int>(5, 10);

var final = pt + translate;

Console.WriteLine(pt);
Console.WriteLine(translate);
Console.WriteLine(final);
// </TestAddition>


// <FinalTranslation>
public record Translation<T>(T XOffset, T YOffset) : IAdditiveIdentity<Translation<T>, Translation<T>> 
    where T : IAdditionOperators<T, T, T>, IAdditiveIdentity<T,T>
{
    public static Translation<T> AdditiveIdentity =>
        new Translation<T>(XOffset: T.AdditiveIdentity, YOffset: T.AdditiveIdentity);
}
// </FinalTranslation>

// <FinalPointImplementation>
public record Point<T>(T X, T Y) : IAdditionOperators<Point<T>, Translation<T>, Point<T>>
    where T : IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T>
{
    // <OperatorAdd>
    public static Point<T> operator +(Point<T> left, Translation<T> right) =>
        left with { X = left.X + right.XOffset, Y = left.Y + right.YOffset };
    // </OperatorAdd>
}
// <FinalPointImplementation>
