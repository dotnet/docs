    protected void Page_Load(object sender, EventArgs args)
    {
        if (!IsPostBack)
        {
            Primes.ItemCount = 2000;
            Primes.ItemsPerPage = 20;
            form1.ControlToPaginate = Primes;
        }
    }