using System.ComponentModel;
using System.Text.Json.Serialization;

namespace serialization
{
    // <Snippet1>
    public class Loan : INotifyPropertyChanged
    {
        public double LoanAmount { get; set; }
        public double InterestRate { get; set; }

        // <Snippet2>
        [JsonIgnore]
        public DateTime TimeLastLoaded { get; set; }
        // </Snippet2>

        public int Term { get; set; }

        private string customer;
        public string Customer
        {
            get { return customer; }
            set
            {
                customer = value;
                PropertyChanged?.Invoke(this,
                  new PropertyChangedEventArgs(nameof(Customer)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public Loan(double loanAmount,
                    double interestRate,
                    int term,
                    string customer)
        {
            this.LoanAmount = loanAmount;
            this.InterestRate = interestRate;
            this.Term = term;
            this.customer = customer;
        }
    }
    // </Snippet1>
}
