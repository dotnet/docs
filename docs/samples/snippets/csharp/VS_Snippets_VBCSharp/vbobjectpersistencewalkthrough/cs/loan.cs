using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnSerialized
{
    //<Snippet1>
    public class Loan : System.ComponentModel.INotifyPropertyChanged
    {
        public double LoanAmount {get; set;}
        public double InterestRate {get; set;}
        public int Term {get; set;}

        private string p_Customer;
        public string Customer
        {
            get { return p_Customer; }
            set 
            {
                p_Customer = value;
                PropertyChanged(this,
                  new System.ComponentModel.PropertyChangedEventArgs("Customer"));
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public Loan(double loanAmount,
                    double interestRate,
                    int term,
                    string customer)
        {
            this.LoanAmount = loanAmount;
            this.InterestRate = interestRate;
            this.Term = term;
            p_Customer = customer;
        }
    }
    //</Snippet1>
}

namespace LoanClass
{
    //<Snippet4>
    [Serializable()]
    public class Loan : System.ComponentModel.INotifyPropertyChanged
    {
        //</Snippet4>
        public double LoanAmount {get; set;}
        public double InterestRate {get; set;}
        public int Term {get; set;}

        private string p_Customer;
        public string Customer {
            get { return p_Customer; }
            set 
            {
                p_Customer = value;
                PropertyChanged(this,
                  new System.ComponentModel.PropertyChangedEventArgs("Customer"));
            }
        }
        
        //<Snippet5>
        [field: NonSerialized()]
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        //</Snippet5>

        public Loan(double loanAmount,
                         double interestRate,
                         int term,
                         string customer)
        {
            this.LoanAmount = loanAmount;
            this.InterestRate = interestRate;
            this.Term = term;
            p_Customer = customer;
        }
    }
}



