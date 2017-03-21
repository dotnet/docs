        // The following method uses Add to add dates that are 
        // bolded, followed by an UpdateBoldedDates to make the
        // added dates visible.
        
        private void loadDates()
        {
            String myInput ;
            try
            {
                StreamReader myInputStream = File.OpenText("myDates.txt");
                while((myInput = myInputStream.ReadLine()) != null)
                {
                    monthCalendar1.AddBoldedDate(DateTime.Parse(myInput.Substring(0,myInput.IndexOf(" "))));
                    listBox1.Items.Add(myInput);
                }
                monthCalendar1.UpdateBoldedDates();
                myInputStream.Close();
                File.Delete("myDates.txt");
            }catch(FileNotFoundException fnfe)
            {
                // Code to handle a file that could not be found should go here.
            Console.WriteLine("An error occurred: '{0}'", fnfe);
            }             
        }