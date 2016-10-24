        public Form2()
        {
            // You can use a lambda expression to define an event handler.
            this.Click += (s, e) =>
                {
                    MessageBox.Show(
                        ((MouseEventArgs)e).Location.ToString());
                };
        }