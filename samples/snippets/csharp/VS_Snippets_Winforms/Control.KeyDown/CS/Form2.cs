using System.Windows.Forms;

namespace WindowsFormsApp1
{

	//<Snippet1>
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
			textBox2.Multiline = true;
			textBox2.ScrollBars = ScrollBars.Both;

			//Setup events that listens on keypress
			textBox1.KeyDown += TextBox1_KeyDown;
			textBox1.KeyPress += TextBox1_KeyPress;
			textBox1.KeyUp += TextBox1_KeyUp;
		}

		// Handle the KeyUp event to print the type of character entered into the control.
		private void TextBox1_KeyUp(object sender, KeyEventArgs e)
		{
			textBox2.AppendText( $"KeyUp code: {e.KeyCode}, value: {e.KeyValue}, modifiers: {e.Modifiers}" + "\r\n");
		}

		// Handle the KeyPress event to print the type of character entered into the control.
		private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			textBox2.AppendText( $"KeyPress keychar: {e.KeyChar}" + "\r\n");
		}

		// Handle the KeyDown event to print the type of character entered into the control.
		private void TextBox1_KeyDown(object sender, KeyEventArgs e)
		{
			textBox2.AppendText( $"KeyDown code: {e.KeyCode}, value: {e.KeyValue}, modifiers: {e.Modifiers}" + "\r\n");
		}
	}
	//</Snippet1>
}
