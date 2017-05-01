//<Snippet1>
using System;
using System.Web.Security;

namespace Samples.AspNet.Membership.CS
{
    public class OdbcMembershipUser : MembershipUser
    {
        private bool _IsSubscriber;
        private string _CustomerID;

        public bool IsSubscriber
        {
            get { return _IsSubscriber; }
            set { _IsSubscriber = value; }
        }

        public string CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }

        public OdbcMembershipUser(string providername,
                                  string username,
                                  object providerUserKey,
                                  string email,
                                  string passwordQuestion,
                                  string comment,
                                  bool isApproved,
                                  bool isLockedOut,
                                  DateTime creationDate,
                                  DateTime lastLoginDate,
                                  DateTime lastActivityDate,
                                  DateTime lastPasswordChangedDate,
                                  DateTime lastLockedOutDate,
                                  bool isSubscriber,
                                  string customerID) :
                                  base(providername,
                                       username,
                                       providerUserKey,
                                       email,
                                       passwordQuestion,
                                       comment,
                                       isApproved,
                                       isLockedOut,
                                       creationDate,
                                       lastLoginDate,
                                       lastActivityDate,
                                       lastPasswordChangedDate,
                                       lastLockedOutDate)
        {
            this.IsSubscriber = isSubscriber;
            this.CustomerID = customerID;
        }



    }
}
//</Snippet1>