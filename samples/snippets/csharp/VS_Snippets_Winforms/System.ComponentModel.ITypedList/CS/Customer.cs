// <snippet10>
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ITypedListCS
{
	class Customer : INotifyPropertyChanged
    {
        public Customer() {}

        public Customer(int id, string name, string company, string address, string city, string state, string zip)
        {
            this._id = id;
            this._name = name;
            this._company = company;
            this._address = address;
            this._city = city;
            this._state = state;
            this._zip = zip;
        }

        #region Public Properties

        private int _id;

		public int ID
		{
			get { return _id; }
			set
			{
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("ID"));
                }
			}
		}

		private string _name;

		public string Name
		{
			get { return _name; }
			set
			{
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Name"));
                }
			}
		}

		private string _company;

		public string Company
		{
			get { return _company; }
			set
			{
                if (_company != value)
                {
                    _company = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Company"));
                }
			}
		}

		private string _address;

		public string Address
		{
			get { return _address; }
			set
			{
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Address"));
                }
			}
		}

		private string _city;

		public string City
		{
			get { return _city; }
			set
			{
                if (_city != value)
                {
                    _city = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("City"));
                }
			}
		}

		private string _state;

		public string State
		{
			get { return _state; }
			set
			{
                if (_state != value)
                {
                    _state = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("State"));
                }
			}
		}

		private string _zip;

		public string ZipCode
		{
			get { return _zip; }
			set
			{
                if (_zip != value)
                {
                    _zip = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("ZipCode"));
                }
			}
        }

        #endregion

		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			if (null != PropertyChanged)
			{
				PropertyChanged(this, e);
			}
		}

		#endregion
	}
}
// </snippet10>