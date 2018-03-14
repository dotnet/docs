using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace VbPowerPacksShapeTagCS
{
    public partial class ShapeTag : Form
    {
        public ShapeTag()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void Form1_Load(System.Object sender, System.EventArgs e)
        {
            // Declare an instance of a NodeInfo class.
            NodeInfo MyNode = new NodeInfo();
            // Assign the instance to the Tag property.
            rectangleShape1.Tag = MyNode;
        }

        private void rectangleShape1_Click(System.Object sender, System.EventArgs e)
        {
            // Declare an instance of a networkForm form.
            Form networkForm = new Form();
            // Assign the Tag property of the RectangleShape to the new form.
            // This passes the MyNode instance of the NodeInfo class to the
            // form.
            networkForm.Tag = rectangleShape1.Tag;
            // Show the new form.
            networkForm.Show();
        }
        // </Snippet1>
    }


}
