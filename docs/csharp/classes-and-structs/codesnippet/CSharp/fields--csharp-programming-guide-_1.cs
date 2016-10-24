    public class CalendarEntry
    {
        // private field
        private DateTime date;

        // public field (Generally not recommended.)
        public string day;

        // Public property exposes date field safely.
        public DateTime Date 
        {
            get 
            {
                return date;
            }
            set 
            {
                // Set some reasonable boundaries for likely birth dates.
                if (value.Year > 1900 && value.Year <= DateTime.Today.Year)
                {
                    date = value;
                }
                else
                    throw new ArgumentOutOfRangeException();
            }

        }

        // Public method also exposes date field safely.
        // Example call: birthday.SetDate("1975, 6, 30");
        public void SetDate(string dateString)
        {
            DateTime dt = Convert.ToDateTime(dateString);

            // Set some reasonable boundaries for likely birth dates.
            if (dt.Year > 1900 && dt.Year <= DateTime.Today.Year)
            {
                date = dt;
            }
            else
                throw new ArgumentOutOfRangeException();
        }

        public TimeSpan GetTimeSpan(string dateString)
        {
            DateTime dt = Convert.ToDateTime(dateString);

            if (dt != null && dt.Ticks < date.Ticks)
            {
                return date - dt;
            }
            else
                throw new ArgumentOutOfRangeException();  
 
        }
    }