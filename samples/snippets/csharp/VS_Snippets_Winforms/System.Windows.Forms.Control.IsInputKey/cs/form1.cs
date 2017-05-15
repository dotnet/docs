//<snippet0>
using System.Windows.Forms;

public class Form1 : Form
{
    public Form1()
    {
        FlowLayoutPanel panel = new FlowLayoutPanel();

        TabTextBox tabTextBox1 = new TabTextBox();
        tabTextBox1.Text = "TabTextBox";
        panel.Controls.Add(tabTextBox1);

        TextBox textBox1 = new TextBox();
        textBox1.Text = "Normal TextBox";
        panel.Controls.Add(textBox1);

        this.Controls.Add(panel);
    }
}

class TabTextBox : TextBox
{
    protected override bool IsInputKey(Keys keyData)
    {
        if (keyData == Keys.Tab)
        {
            return true;
        }
        else
        {
            return base.IsInputKey(keyData);
        }
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.KeyData == Keys.Tab)
        {
            this.SelectedText = "    ";                
        }
        else
        {
            base.OnKeyDown(e);
        }
    }
}
//</snippet0>