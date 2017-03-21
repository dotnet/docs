        // Add property values to view state with set;
        // retrieve them from view state with get.
        public String Text
        {
            get 
            { 
                object o = ViewState["Text"]; 
                return (o == null)? String.Empty : (string)o;
            }

            set
            {
                ViewState["Text"] = value;
            }
        }
