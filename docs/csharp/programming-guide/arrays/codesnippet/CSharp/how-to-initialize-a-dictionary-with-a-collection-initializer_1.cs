            class StudentName
            {
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public int ID { get; set; }
            }

            class CollInit
            {
                Dictionary<int, StudentName> students = new Dictionary<int, StudentName>()
                {
                    { 111, new StudentName {FirstName="Sachin", LastName="Karnik", ID=211}},
                    { 112, new StudentName {FirstName="Dina", LastName="Salimzianova", ID=317}},
                    { 113, new StudentName {FirstName="Andy", LastName="Ruth", ID=198}}
                };
            }