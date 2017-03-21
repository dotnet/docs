    // Add "using System.ComponentModel;" line 
    // to the beginning of the file.
    class Program
    {
        static void Test()
        {
            dynamic employee = new ExpandoObject();
            ((INotifyPropertyChanged)employee).PropertyChanged +=
                new PropertyChangedEventHandler(HandlePropertyChanges);
            employee.Name = "John Smith";
        }

        private static void HandlePropertyChanges(
            object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine("{0} has changed.", e.PropertyName);
        }
    }