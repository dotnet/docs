//<snippet0>
//<snippet1>
using System;
using System.IdentityModel.Claims;
//</snippet1>

namespace Samples
{
    //<snippet2>
    public sealed class MyResourceType
    {
        // private members
        private string text;
        private int number;

        // Constructors
        public MyResourceType()
        {
        }

        public MyResourceType(string text, int number)
        {
            this.text = text;
            this.number = number;
        }

        // Public properties
        public string Text { get { return this.text; } }
        public int Number { get { return this.number; } }

        //<snippet3>
        // Override Object.Equals to perform specific comparison
        public override bool Equals(Object obj)
        {
            // If the object we're being asked to compare ourselves to is null
            // then return false
            if (obj == null)
                return false;

            // If the object we're being asked to compare ourselves to is us
            // then return true
            if (ReferenceEquals(this, obj))
                return true;

            // Try to convert the object we're being asked to compare ourselves to
            // into an instance of MyResourceType
            MyResourceType rhs = obj as MyResourceType;

            // If the object we're being asked to compare ourselves to
            // isn't an instance of MyResourceType then return false
            if (rhs == null)
                return false;

            // Return true if our members are the same as those of the object
            // we're being asked to compare ourselves to. Otherwise return false
            return (this.text == rhs.text && this.number == rhs.number);
        }
        //</snippet3>

        public override int GetHashCode()
        {
            return (this.text.GetHashCode() ^ this.number.GetHashCode());
        }
    }
    //</snippet2>

    class Program
    {
        public static void Main()
        {
            // Create two claims
            Claim c1 = new Claim("http://example.org/claims/mycustomclaim",
                new MyResourceType("Martin", 38), Rights.PossessProperty);
            Claim c2 = new Claim("http://example.org/claims/mycustomclaim",
                new MyResourceType("Martin", 38), Rights.PossessProperty);

            // Compare the claims
            if (c1.Equals(c2))
                Console.WriteLine("Claims are equal");
            else
                Console.WriteLine("Claims are not equal");
        }
    }
}
//</snippet0>

namespace Snippets
{
    public class ClaimCompareSnippets
    {
        private void Snippet9()
        {
            //<snippet9>
            Claim c1 = Claim.CreateNameClaim("someone");
            Claim c2 = Claim.CreateNameClaim("someone");
            //</snippet9>
        }

        private void Snippet4()
        {
            //<snippet4>
            Claim c1 = Claim.CreateUpnClaim("someone@example.com");
            Claim c2 = Claim.CreateUpnClaim("example\\someone");
        //</snippet4>
        }

        //<snippet5>
        public bool CompareTwoClaims(Claim c1, Claim c2)
        {
            return c1.Equals(c2);
        }
        //</snippet5>
    }
    public class HoldsCompare
    {
        //<snippet6>
        public bool CompareTwoClaims(Claim c1, Claim c2)
        {
            return c1.Equals(c2);
        }
        //</snippet6>

        private bool TestClaim1(object obj)
        {
            //<snippet7>
            if (obj == null) return false;
            //</snippet7>

            else
                return true;
        }

        private bool TestClaim2(object obj)
        {
            //<snippet8>
            if (ReferenceEquals(this, obj)) return true;
            //</snippet8>
            else
                return true;
        }
    }
}
