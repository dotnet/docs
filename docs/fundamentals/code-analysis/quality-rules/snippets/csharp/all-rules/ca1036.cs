using System;
using System.Globalization;

//<snippet1>
// Valid ratings are between A and C.
// A is the highest rating; it is greater than any other valid rating.
// C is the lowest rating; it is less than any other valid rating.

public class RatingInformation : IComparable, IComparable<RatingInformation>
{
    public string Rating { get; private set; }

    public RatingInformation(string rating)
    {
        ArgumentNullException.ThrowIfNull(rating);

        string v = rating.ToUpper(CultureInfo.InvariantCulture);
        if (v.Length != 1 ||
            string.Compare(v, "C", StringComparison.Ordinal) > 0 ||
            string.Compare(v, "A", StringComparison.Ordinal) < 0)
        {
            throw new ArgumentException("Invalid rating value was specified.", nameof(rating));
        }

        Rating = v;
    }

    public int CompareTo(object? obj)
    {
        if (obj == null)
        {
            return 1;
        }

        if (obj is RatingInformation other)
        {
            return CompareTo(other);
        }

        throw new ArgumentException("A RatingInformation object is required for comparison.", nameof(obj));
    }

    public int CompareTo(RatingInformation? other)
    {
        if (other is null)
        {
            return 1;
        }

        // Ratings compare opposite to normal string order,
        // so reverse the value returned by String.CompareTo.
        return -string.Compare(Rating, other.Rating, StringComparison.OrdinalIgnoreCase);
    }

    public static int Compare(RatingInformation left, RatingInformation right)
    {
        if (object.ReferenceEquals(left, right))
        {
            return 0;
        }
        if (left is null)
        {
            return -1;
        }
        return left.CompareTo(right);
    }

    // Omitting Equals violates rule: OverrideMethodsOnComparableTypes.
    public override bool Equals(object? obj)
    {
        if (obj is RatingInformation other)
        {
            return CompareTo(other) == 0;
        }

        return false;
    }

    // Omitting getHashCode violates rule: OverrideGetHashCodeOnOverridingEquals.
    public override int GetHashCode()
    {
        char[] c = Rating.ToCharArray();
        return (int)c[0];
    }

    // Omitting any of the following operator overloads
    // violates rule: OverrideMethodsOnComparableTypes.
    public static bool operator ==(RatingInformation left, RatingInformation right)
    {
        if (left is null)
        {
            return right is null;
        }
        return left.Equals(right);
    }
    public static bool operator !=(RatingInformation left, RatingInformation right)
    {
        return !(left == right);
    }
    public static bool operator <(RatingInformation left, RatingInformation right)
    {
        return (Compare(left, right) < 0);
    }
    public static bool operator >(RatingInformation left, RatingInformation right)
    {
        return (Compare(left, right) > 0);
    }
}
//</snippet1>

//<snippet2>
public class TestCompare
{
    public static void Main1036(params string[] args)
    {
        if (args.Length < 2)
        {
            return;
        }
        RatingInformation r1 = new(args[0]);
        RatingInformation r2 = new(args[1]);
        string answer;

        if (r1.CompareTo(r2) > 0)
            answer = "greater than";
        else if (r1.CompareTo(r2) < 0)
            answer = "less than";
        else
            answer = "equal to";

        Console.WriteLine($"{r1.Rating} is {answer} {r2.Rating}");
    }
}
//</snippet2>
