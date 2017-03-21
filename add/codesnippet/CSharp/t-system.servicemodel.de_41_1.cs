    public class MyClientCredentials : ClientCredentials
    {
        string creditCardNumber;

        public MyClientCredentials()
        {
            // Perform client credentials initialization.
        }

        protected MyClientCredentials(MyClientCredentials other)
            : base(other)
        {
            // Clone fields defined in this class.
            this.creditCardNumber = other.creditCardNumber;
        }

        public string CreditCardNumber
        {
            get
            {
                return this.creditCardNumber;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                this.creditCardNumber = value;
            }
        }

        public override SecurityTokenManager CreateSecurityTokenManager()
        {
            // Return your implementation of the SecurityTokenManager.
            return new MyClientCredentialsSecurityTokenManager(this);
        }

        protected override ClientCredentials CloneCore()
        {
            // Implement the cloning functionality.
            return new MyClientCredentials(this);
        }
    }