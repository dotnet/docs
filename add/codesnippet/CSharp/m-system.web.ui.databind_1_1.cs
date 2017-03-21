        // Create a Text property with accessors that obtain 
        // the property value from and set the property value
        // to the Text key in the DataBindingCollection class.
        public string Text
        {
            get
            {
                DataBinding myBinding = DataBindings["Text"];
                if (myBinding != null)
                {
                    return myBinding.Expression;
                }
                return String.Empty;
            }
            set
            {

                if ((value == null) || (value.Length == 0))
                {
                    DataBindings.Remove("Text");
                }
                else
                {

                    DataBinding binding = DataBindings["Text"];

                    if (binding == null)
                    {
                        binding = new DataBinding("Text", typeof(string), value);
                    }
                    else
                    {
                        binding.Expression = value;
                    }
                    // Call the DataBinding constructor, then add
                    // the initialized DataBinding object to the 
                    // DataBindingCollection for this custom designer.
                    DataBinding binding1 = (DataBinding)DataBindings.SyncRoot;
                    DataBindings.Add(binding);
                    DataBindings.Add(binding1);
                }
                PropertyChanged("Text");
            }
        }