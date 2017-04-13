
// The following code example demonstrates using 
// the following members: LostFocus, OpenFileDialog.Multiselect, 
// FileNames, Title, ErrorProvider.GetError, PictureBox.Image,
// Application.DoEvents, and System.Drawing.Image.FromStream.




using System.Windows.Forms;

public class Form1:
	System.Windows.Forms.Form

{
	public Form1() : base()
	{        
		InitializePictureBox();
		InitializeOpenFileDialog();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.button1 = new System.Windows.Forms.Button();
		this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
		this.label2 = new System.Windows.Forms.Label();
		this.fileButton = new Button();

		this.SuspendLayout();
		this.openFileDialog1.Filter = "Images " +
			"(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
		this.openFileDialog1.Multiselect = true;
		this.openFileDialog1.Title = "My Image Browser";
		this.textBox1.Location = new System.Drawing.Point(16, 56);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(150, 20);
		this.textBox1.TabIndex = 2;
		this.textBox1.Text = "";
		this.button1.Location = new System.Drawing.Point(184, 48);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(88, 32);
		this.button1.TabIndex = 1;
		this.button1.Text = "Find pictures";
		this.fileButton.Location = new System.Drawing.Point(80, 40);
		this.fileButton.Name = "fileButton";
		this.fileButton.TabIndex = 0;
		this.fileButton.Text = "Button2";
		this.errorProvider1.ContainerControl = this;
		this.label2.Location = new System.Drawing.Point(24, 34);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(150, 23);
		this.label2.TabIndex = 5;
		this.label2.Text = "Enter image file directory:";
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.pictureBox1);
		this.Controls.Add(this.label2);
		this.Controls.Add(this.textBox1);
		this.Controls.Add(this.button1);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);
		
		this.button1.Click += new System.EventHandler(button1_Click);
		this.fileButton.Click +=new System.EventHandler(fileButton_Click);
		this.textBox1.LostFocus += new System.EventHandler(textBox1_LostFocus);
		this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(textBox1_Validating);
	
		// Associate the event-handling method with the FileOk
		// event.
		this.openFileDialog1.FileOk += 
			new System.ComponentModel.CancelEventHandler
			(openFileDialog1_FileOk);
	}
	

	internal System.Windows.Forms.OpenFileDialog openFileDialog1;
	internal System.Windows.Forms.Button button1;
	internal System.Windows.Forms.TextBox textBox1;
	internal System.Windows.Forms.ErrorProvider errorProvider1;
	internal System.Windows.Forms.Label label2;
	internal System.Windows.Forms.Button fileButton;
	internal System.Windows.Forms.PictureBox pictureBox1;

	public static void Main()
	{
		Application.Run(new Form1());
	}
    
	//<snippet3>
	//<snippet2>
	private void textBox1_Validating(object sender, 
		System.ComponentModel.CancelEventArgs e)
	{
		// If nothing is entered,
		// an ArgumentException is caught; if an invalid directory is entered, 
		// a DirectoryNotFoundException is caught. An appropriate error message 
		// is displayed in either case.
		try
		{
			System.IO.DirectoryInfo directory = 
				new System.IO.DirectoryInfo(textBox1.Text);
			directory.GetFiles();
			errorProvider1.SetError(textBox1, "");

		}
		catch(System.ArgumentException ex1)
		{
			errorProvider1.SetError(textBox1, "Please enter a directory");

		}
		catch(System.IO.DirectoryNotFoundException ex2)
		{
			errorProvider1.SetError(textBox1, "The directory does not exist." +
				"Try again with a different directory.");
		}

	}
	//</snippet3>

	// This method handles the LostFocus event for textBox1 by setting the 
	// dialog's InitialDirectory property to the text in textBox1.
	private void textBox1_LostFocus(object sender, System.EventArgs e)
	{
		openFileDialog1.InitialDirectory = textBox1.Text;
	}

	// This method demonstrates using the ErrorProvider.GetError method 
	// to check for an error before opening the dialog box.
	private void button1_Click(System.Object sender, System.EventArgs e)
	{
		//If there is no error, then open the dialog box.
		if (errorProvider1.GetError(textBox1)=="")
		{
			DialogResult dialogResult = openFileDialog1.ShowDialog();
		}
	}
	//</snippet2>

	// These methods demonstrate  the handling of the FileOk event and the 
	// use of the Application.DoEvents method.  
	// A user selects graphics files from an OpenFileDialog object.  
	// The files are displayed in the form.  The Application.DoEvents
	// method forces a repaint of the form for each graphics file opened.
	//<snippet1>
	private void InitializePictureBox()
	{
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.pictureBox1.BorderStyle = 
			System.Windows.Forms.BorderStyle.FixedSingle;
		this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
		this.pictureBox1.Location = new System.Drawing.Point(72, 112);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(160, 136);
		this.pictureBox1.TabIndex = 6;
		this.pictureBox1.TabStop = false;
	}

	//<snippet6>
	private void InitializeOpenFileDialog()
	{
		this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();

		// Set the file dialog to filter for graphics files.
		this.openFileDialog1.Filter = 
			"Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + 
			"All files (*.*)|*.*";

		// Allow the user to select multiple images.
		this.openFileDialog1.Multiselect = true;
		this.openFileDialog1.Title = "My Image Browser";
		
	}

	private void fileButton_Click(System.Object sender, System.EventArgs e)
	{
		openFileDialog1.ShowDialog();
	}

	//</snippet6>

	// This method handles the FileOK event.  It opens each file 
	// selected and loads the image from a stream into pictureBox1.
	private void openFileDialog1_FileOk(object sender, 
		System.ComponentModel.CancelEventArgs e)
	{

		this.Activate();
		 string[] files = openFileDialog1.FileNames;

		// Open each file and display the image in pictureBox1.
		// Call Application.DoEvents to force a repaint after each
		// file is read.        
		foreach (string file in files )
		{
			System.IO.FileInfo fileInfo = new System.IO.FileInfo(file);
			System.IO.FileStream fileStream = fileInfo.OpenRead();
			pictureBox1.Image = System.Drawing.Image.FromStream(fileStream);
			Application.DoEvents();
			fileStream.Close();

			// Call Sleep so the picture is briefly displayed, 
			//which will create a slide-show effect.
			System.Threading.Thread.Sleep(2000);
		}
		pictureBox1.Image = null;
	}
	//</snippet1>

}



