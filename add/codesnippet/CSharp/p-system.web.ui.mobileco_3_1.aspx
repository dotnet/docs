    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Set the DataMembers of the List
            List1.DataValueField = "Status";
            List1.DataTextField = "TaskName";

            // Create an ArrayList of task data
            ArrayList arr = new ArrayList();
            arr.Add(new Task("Define transactions", "scheduled"));
            arr.Add(new Task("Verify transactions", "scheduled"));
            arr.Add(new Task("Check balance sheet", "scheduled"));
            arr.Add(new Task("Compile balance sheet", "scheduled"));
            arr.Add(new Task("Prepare report", "scheduled"));
            arr.Add(new Task("Send report", "scheduled"));

            // Bind the array to the list
            List1.DataSource = arr;
            List1.DataBind();

            const string spec = "Start: {0} tasks are done, {1} " +
               "tasks are scheduled, and {2} tasks are pending.";
            Label2.Text = String.Format(spec, doneCount, +
                schedCount, pendCount);

            List1.Decoration = ListDecoration.Bulleted;
        }
    }