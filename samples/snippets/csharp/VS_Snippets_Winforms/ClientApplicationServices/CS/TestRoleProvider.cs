using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace ClientAppServicesDemo
{
    //<snippet601>
    class TestRoleProvider : RoleProvider 
    //</snippet601>
    {
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        //<snippet602>
        internal static string ManagerRoleName =
            "Manager".ToLowerInvariant();
        internal static string EmployeeRoleName =
            "Employee".ToLowerInvariant();

        public override bool IsUserInRole(string username, string roleName)
        {
            string[] roles = GetRolesForUser(username);
            foreach (string role in roles)
            {
                if (string.Compare(role, roleName, true) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public override string[] GetRolesForUser(string username)
        {
            if (string.Compare(username,
                TestMembershipProvider.ManagerUserName, true) == 0)
            {
                return new string[] { ManagerRoleName };
            }
            else if (string.Compare(username,
                TestMembershipProvider.EmployeeUserName, true) == 0)
            {
                return new string[] { EmployeeRoleName };
            }
            else
            {
                return new string[0];
            }
        }
        //</snippet602>
    
    }
}
