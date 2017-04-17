// <snippet10>
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace IListSourceCS
{
    public class Employee : BusinessObjectBase
    {
        private string      _id;
        private string      _name;
        private Decimal     parkingId;

        public Employee() : this(string.Empty, 0) {}
        public Employee(string name) : this(name, 0) {}

        public Employee(string name, Decimal parkingId) : base()
        {
            this._id = System.Guid.NewGuid().ToString();

            // Set values
            this.Name = name;
            this.ParkingID = parkingId;
        }

        public string ID
        {
            get { return _id; }
        }

        const string NAME = "Name";
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;

                    // Raise the PropertyChanged event.
                    OnPropertyChanged(NAME);
                }
            }
        }

        const string PARKING_ID = "Salary";
        public Decimal ParkingID
        {
            get { return parkingId; }
            set
            {
                if (parkingId != value)
                {
                    parkingId = value;

                    // Raise the PropertyChanged event.
                    OnPropertyChanged(PARKING_ID);
                }
            }
        }
    }
}
// </snippet10>