        public string DataTextField {
            get {
                object o = ViewState["DataTextField"];
                return((o == null) ? string.Empty : (string)o);
            }
            set {
                ViewState["DataTextField"] = value;
                if (Initialized) {
                    OnDataPropertyChanged();
                }
            }
        }