//<Snippet1>
using System;
using System.Globalization;

namespace DesignLibrary
{
    // Valid ratings are between A and C.
    // A is the highest rating; it is greater than any other valid rating.
    // C is the lowest rating; it is less than any other valid rating.
 
    public class RatingInformation : IComparable, IComparable<RatingInformation>
    {
        public string Rating
        {
            get;
            private set;
        }
 
        public RatingInformation(string rating)
        {
            if (rating == null)
            {
                throw new ArgumentNullException("rating");
            }
            string v = rating.ToUpper(CultureInfo.InvariantCulture);
            if (v.Length != 1 || string.Compare(v, "C", StringComparison.Ordinal) > 0 || string.Compare(v, "A", StringComparison.Ordinal) < 0)
            {
                throw new ArgumentException("Invalid rating value was specified.", "rating");
            }
            this.Rating = v;
        }
 
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            RatingInformation other = obj as RatingInformation; // avoid double casting
            if (other == null)
            {
                throw new ArgumentException("A RatingInformation object is required for comparison.", "obj");
            }
            return this.CompareTo(other);
        }
 
        public int CompareTo(RatingInformation other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            // Ratings compare opposite to normal string order, 
            // so reverse the value returned by String.CompareTo.
            return -string.Compare(this.Rating, other.Rating, StringComparison.OrdinalIgnoreCase);
        }
 
        public static int Compare(RatingInformation left, RatingInformation right)
        {
            if (object.ReferenceEquals(left, right))
            {
                return 0;
            }
            if (object.ReferenceEquals(left, null))
            {
                return -1;
            }
            return left.CompareTo(right);
        }
 
        // Omitting Equals violates rule: OverrideMethodsOnComparableTypes.
        public override bool Equals(object obj)
        {
            RatingInformation other = obj as RatingInformation; //avoid double casting
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            return this.CompareTo(other) == 0;
        }
 
        // Omitting getHashCode violates rule: OverrideGetHashCodeOnOverridingEquals.
        public override int GetHashCode()
        {
            char[] c = this.Rating.ToCharArray();
            return (int)c[0];
        }
 
        // Omitting any of the following operator overloads 
        // violates rule: OverrideMethodsOnComparableTypes.
        public static bool operator ==(RatingInformation left, RatingInformation right)
        {
            if (object.ReferenceEquals(left, null))
            {
                return object.ReferenceEquals(right, null);
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
}
//</Snippet1>
