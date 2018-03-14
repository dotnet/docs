//<snippet000>
using System;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;

//<snippet100>
public class Form1 : Form
{
    private List<Employee> employees = new List<Employee>();
    private List<Task> tasks = new List<Task>();
    private Button reportButton = new Button();
    private DataGridView dataGridView1 = new DataGridView();

    [STAThread]
    public static void Main()
    {
        Application.Run(new Form1());
    }

    public Form1()
    {
        dataGridView1.Dock = DockStyle.Fill;
        dataGridView1.AutoSizeColumnsMode = 
            DataGridViewAutoSizeColumnsMode.AllCells;
        reportButton.Text = "Generate Report";
        reportButton.Dock = DockStyle.Top;
        reportButton.Click += new EventHandler(reportButton_Click);

        Controls.Add(dataGridView1);
        Controls.Add(reportButton);
        Load += new EventHandler(Form1_Load);
        Text = "DataGridViewComboBoxColumn Demo";
    }

    // Initializes the data source and populates the DataGridView control.
    private void Form1_Load(object sender, EventArgs e)
    {
        PopulateLists();
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.DataSource = tasks;
        AddColumns();
    }

    // Populates the employees and tasks lists. 
    private void PopulateLists()
    {
        employees.Add(new Employee("Harry"));
        employees.Add(new Employee("Sally"));
        employees.Add(new Employee("Roy"));
        employees.Add(new Employee("Pris"));
        tasks.Add(new Task(1, employees[1]));
        tasks.Add(new Task(2));
        tasks.Add(new Task(3, employees[2]));
        tasks.Add(new Task(4));
    }

    // Configures columns for the DataGridView control.
    private void AddColumns()
    {
        DataGridViewTextBoxColumn idColumn = 
            new DataGridViewTextBoxColumn();
        idColumn.Name = "Task";
        idColumn.DataPropertyName = "Id";
        idColumn.ReadOnly = true;

        //<snippet110>
        DataGridViewComboBoxColumn assignedToColumn = 
            new DataGridViewComboBoxColumn();

        // Populate the combo box drop-down list with Employee objects. 
        foreach (Employee e in employees) assignedToColumn.Items.Add(e);

        // Add "unassigned" to the drop-down list and display it for 
        // empty AssignedTo values or when the user presses CTRL+0. 
        assignedToColumn.Items.Add("unassigned");
        assignedToColumn.DefaultCellStyle.NullValue = "unassigned";
        //</snippet110>

        assignedToColumn.Name = "Assigned To";
        assignedToColumn.DataPropertyName = "AssignedTo";
        assignedToColumn.AutoComplete = true;
        //<snippet115>
        assignedToColumn.DisplayMember = "Name";
        assignedToColumn.ValueMember = "Self";
        //</snippet115>

        // Add a button column. 
        DataGridViewButtonColumn buttonColumn = 
            new DataGridViewButtonColumn();
        buttonColumn.HeaderText = "";
        buttonColumn.Name = "Status Request";
        buttonColumn.Text = "Request Status";
        buttonColumn.UseColumnTextForButtonValue = true;

        dataGridView1.Columns.Add(idColumn);
        dataGridView1.Columns.Add(assignedToColumn);
        dataGridView1.Columns.Add(buttonColumn);

        // Add a CellClick handler to handle clicks in the button column.
        dataGridView1.CellClick +=
            new DataGridViewCellEventHandler(dataGridView1_CellClick);
    }

    // Reports on task assignments. 
    private void reportButton_Click(object sender, EventArgs e)
    {
        StringBuilder report = new StringBuilder();
        foreach (Task t in tasks)
        {
            String assignment = 
                t.AssignedTo == null ? 
                "unassigned" : "assigned to " + t.AssignedTo.Name;
            report.AppendFormat("Task {0} is {1}.", t.Id, assignment);
            report.Append(Environment.NewLine);
        }
        MessageBox.Show(report.ToString(), "Task Assignments");
    }

    // Calls the Employee.RequestStatus method.
    void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        // Ignore clicks that are not on button cells. 
        if (e.RowIndex < 0 || e.ColumnIndex !=
            dataGridView1.Columns["Status Request"].Index) return;

        // Retrieve the task ID.
        Int32 taskID = (Int32)dataGridView1[0, e.RowIndex].Value;

        //<snippet120>
        // Retrieve the Employee object from the "Assigned To" cell.
        Employee assignedTo = dataGridView1.Rows[e.RowIndex]
            .Cells["Assigned To"].Value as Employee;
        //</snippet120>

        // Request status through the Employee object if present. 
        if (assignedTo != null)
        {
            assignedTo.RequestStatus(taskID);
        }
        else
        {
            MessageBox.Show(String.Format(
                "Task {0} is unassigned.", taskID), "Status Request");
        }
    }

}
//</snippet100>

//<snippet200>
public class Task
{
    public Task(Int32 id)
    {
        idValue = id;
    }

    public Task(Int32 id, Employee assignedTo)
    {
        idValue = id;
        assignedToValue = assignedTo;
    }

    private Int32 idValue;
    public Int32 Id
    {
        get { return idValue; }
        set { idValue = value; }
    }

    private Employee assignedToValue;
    public Employee AssignedTo
    {
        get { return assignedToValue; }
        set { assignedToValue = value; }
    }
}
//</snippet200>

//<snippet300>
public class Employee
{
    public Employee(String name)
    {
        nameValue = name;
    }

    private String nameValue;
    public String Name
    {
        get { return nameValue; }
        set { nameValue = value; }
    }

    //<snippet310>
    public Employee Self 
    { 
        get { return this; } 
    }
    //</snippet310>

    public void RequestStatus(Int32 taskID)
    {
        MessageBox.Show(String.Format(
            "Status for task {0} has been requested from {1}.", 
            taskID, nameValue), "Status Request");
    }
}
//</snippet300>
//</snippet000>