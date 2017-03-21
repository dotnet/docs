        // Generate the design-time markup for the control 
        // when the template is empty.
        protected override string GetEmptyDesignTimeHtml()
        {
            // Generate a design-time placeholder containing the names of all
            // the role groups.
            MyLoginView myLoginViewCtl = (MyLoginView)ViewControl;
            RoleGroupCollection roleGroups = myLoginViewCtl.RoleGroups;
            string roleNames = null;

            // If there are any role groups, form a string of their names.
            if (roleGroups.Count > 0)
            {
                roleNames = "Role Groups: <br /> &nbsp;&nbsp;" + 
                    roleGroups[0].ToString();

                for( int rgX = 1; rgX < roleGroups.Count; rgX++ )
                    roleNames += 
                        "<br /> &nbsp;&nbsp;" + roleGroups[rgX].ToString();
            }
            return CreatePlaceHolderDesignTimeHtml( roleNames);
        } // GetEmptyDesignTimeHtml