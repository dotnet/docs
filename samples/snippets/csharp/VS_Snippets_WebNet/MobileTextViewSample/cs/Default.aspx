<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    // Returns an array of Boolean values
    private bool[] TestPrimes(int from, int howMany)
    {
        // Test a range of numbers to determine which are prime.
        bool[] isPrime = new bool[howMany];

        int endAt = from + howMany - 1;
        for (int i = from; i < endAt; i++)
        {   // Set a default value of true
            isPrime[i - from] = true;

            int sqrt = (int)Math.Sqrt(i);
            for (int factor = 2; factor <= sqrt; factor++)
            {
                if ((i % factor) == 0)
                {   // Set value as false
                    isPrime[i - from] = false;
                    break;
                }
            }
        }
        return isPrime;
    }

//<Snippet2>
    protected void Page_Load(object sender, EventArgs args)
    {
        if (!IsPostBack)
        {
            Primes.ItemCount = 2000;
            Primes.ItemsPerPage = 20;
            form1.ControlToPaginate = Primes;
        }
    }
//</Snippet2>

    protected void Primes_OnLoadItems(object sender, LoadItemsEventArgs args)
    {
        StringBuilder StrBldr = new StringBuilder();
        Primes.Text = "";

        // Start the list at 2.
        int startNumber = args.ItemIndex + 2;
        bool[] isPrime;
        isPrime = TestPrimes(startNumber, args.ItemCount);

        for (int i = 0; i < args.ItemCount; i++)
        {
            string message;
            if (isPrime[i])
                message = String.Format("<b>{0} is prime</b>", 
                    i + startNumber);
            else
                message = String.Format("<b>{0}</b> is not prime", 
                    i + startNumber);

            StrBldr.Append(message);
            StrBldr.Append("<br />");
        }
        Primes.Text = StrBldr.ToString();
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server" paginate="true">
        <mobile:TextView id="Primes" runat="server" 
            OnLoadItems="Primes_OnLoadItems" />
    </mobile:form>
</body>
</html>
<!-- </Snippet1> -->
