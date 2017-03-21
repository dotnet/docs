    public class MyServiceCredentials : ServiceCredentials
    {
        X509Certificate2 additionalCertificate;

        public MyServiceCredentials()
        {
        }

        protected MyServiceCredentials(MyServiceCredentials other)
            : base(other)
        {
            this.additionalCertificate = other.additionalCertificate;
        }

        public X509Certificate2 AdditionalCertificate
        {
            get
            {
                return this.additionalCertificate;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                this.additionalCertificate = value;
            }
        }

        public override SecurityTokenManager CreateSecurityTokenManager()
        {
            return base.CreateSecurityTokenManager();
        }

        protected override ServiceCredentials CloneCore()
        {
            return new MyServiceCredentials(this);
        }
    }