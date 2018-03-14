// <Snippet1>
using System.Windows.Forms;

namespace ComboBox_DataSource_Sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // Initialize an array with data to bind to the combo box.
            var daysOfWeek =
                new[] { "Monday", "Tuesday", "Wednesday", 
                        "Thursday", "Friday", "Saturday", 
                        "Sunday" };

            // Initialize combo box
            var comboBox = new ComboBox
                                {
                                    DataSource = daysOfWeek,
                                    Location = new System.Drawing.Point(12, 12),
                                    Name = "comboBox",
                                    Size = new System.Drawing.Size(166, 21),
                                    DropDownStyle = ComboBoxStyle.DropDownList
                                };

            // Add the combo box to the form.
            this.Controls.Add(comboBox);
        }
    }
}
// </Snippet1>