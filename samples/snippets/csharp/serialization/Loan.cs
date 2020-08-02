using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace serialization
{
    // <Snippet2>
    [Serializable()]
    // </Snippet2>
    // <Snippet1>
    public class Loan : INotifyPropertyChanged
    {
        public double LoanAmount { get; set; }
        public double InterestRatePercent { get; set; }

        // <Snippet4>
        [field: NonSerialized()]
        public DateTime TimeLastLoaded { get; set; }
        // </Snippet4>

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

        // <Snippet3>
        [field: NonSerialized()]
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        // </Snippet3>

        public Loan(double loanAmount,
                    double interestRate,
                    int term,
                    string customer)
        {
            this.LoanAmount = loanAmount;
            this.InterestRatePercent = interestRate;
            this.Term = term;
            this.customer = customer;
        }
    }
    // </Snippet1>
}
