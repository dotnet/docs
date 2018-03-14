        private void dataRepeater1_NewItemNeeded(object sender, System.EventArgs e)
        {
            Employee newEmployee = new Employee();
            Employees.Add(newEmployee);
            blnNewItemNeedEventFired = true;
        }