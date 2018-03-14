using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataBindingLab
{
    public class User
    {
        private string name;
        private int rating;
        private DateTime memberSince;

        #region Property Getters and Setters
        public string Name
        {
            get { return this.name; }
        }

        public int Rating
        {
            get { return this.rating; }
            set { this.rating = value; }
        }

        public DateTime MemberSince
        {
            get { return this.memberSince; }
        }
        #endregion

        public User(string name, int rating, DateTime memberSince)
        {
            this.name = name;
            this.rating = rating;
            this.memberSince = memberSince;
        }
    }

}
