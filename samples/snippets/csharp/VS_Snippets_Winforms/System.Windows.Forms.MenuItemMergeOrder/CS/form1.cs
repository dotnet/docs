//<snippet1>
// The following code example demonstrates using the MenuItem 
// Merge-Order property to control the way a merged menu is displayed.



using System.Windows.Forms;

public class Form1:
	System.Windows.Forms.Form

	//Declare a MainMenu object and its items.
{
	internal System.Windows.Forms.MainMenu mainMenu1;
	internal System.Windows.Forms.MenuItem fileItem;
	internal System.Windows.Forms.MenuItem newItem;
	internal System.Windows.Forms.MenuItem openItem;
	internal System.Windows.Forms.MenuItem saveItem;
	internal System.Windows.Forms.MenuItem optionsMenu;
	internal System.Windows.Forms.MenuItem viewItem;
	internal System.Windows.Forms.MenuItem toolsItem;

	// Declare a ContextMenu object and its items.
	internal System.Windows.Forms.ContextMenu contextMenu1;
	internal System.Windows.Forms.MenuItem cutItem;
	internal System.Windows.Forms.MenuItem copyItem;
	internal System.Windows.Forms.MenuItem pasteItem;

	public Form1() : base()
	{        
		this.mainMenu1 = new System.Windows.Forms.MainMenu();
		this.fileItem = new System.Windows.Forms.MenuItem();
		this.newItem = new System.Windows.Forms.MenuItem();
		this.openItem = new System.Windows.Forms.MenuItem();
		this.saveItem = new System.Windows.Forms.MenuItem();

		this.viewItem = new System.Windows.Forms.MenuItem();
		this.toolsItem = new System.Windows.Forms.MenuItem();

		this.optionsMenu = new System.Windows.Forms.MenuItem();
		this.toolsItem = new System.Windows.Forms.MenuItem();
		this.viewItem = new System.Windows.Forms.MenuItem();

		this.contextMenu1 = new System.Windows.Forms.ContextMenu();
		this.cutItem = new System.Windows.Forms.MenuItem();
		this.copyItem = new System.Windows.Forms.MenuItem();
		this.pasteItem = new System.Windows.Forms.MenuItem();

		//Add file menu item and options menu item to the MainMenu.
		this.mainMenu1.MenuItems.AddRange(
			new System.Windows.Forms.MenuItem[]
			{this.fileItem, this.optionsMenu});

		// Initialize the file menu and its contents.
		this.fileItem.Index = 0;
		this.fileItem.Text = "File";
		this.newItem.Index = 0;
		this.newItem.Text = "New";
		this.openItem.Index = 1;
		this.openItem.Text = "Open";
		this.saveItem.Index = 2;
		this.saveItem.Text = "Save";


		// Set the merge order of fileItem to 2 so it has a lower priority 
		// on the merged menu.
		this.fileItem.MergeOrder = 2;

		//Add the new items to the fileItem menu item collection.
		this.fileItem.MenuItems.AddRange(new MenuItem[]
			{this.newItem, this.openItem, this.saveItem});
		

		// Initalize the optionsMenu item and its contents.
		this.optionsMenu.Index = 1;
		this.optionsMenu.Text = "Options";

		this.viewItem.Index = 0;
		this.viewItem.Text = "View";
		this.toolsItem.Index = 1;
		this.toolsItem.Text = "Tools";

		// Set mergeOrder property to 1, so it has a higher priority than
		// the fileItem on the merged menu.
		this.optionsMenu.MergeOrder = 1;

		//Add view and tool items to the optionsItem menu item.
		this.optionsMenu.MenuItems.AddRange(new MenuItem[]
			{this.viewItem, this.toolsItem});

		// Initialize the menu items for the shortcut menu.
		this.cutItem.Index = 0;
		this.cutItem.Text = "Cut";
		this.cutItem.MergeOrder = 0;
		this.copyItem.Index = 1;
		this.copyItem.Text = "Copy";
		this.copyItem.MergeOrder = 0;
		this.pasteItem.Index = 2;
		this.pasteItem.Text = "Paste";
		this.pasteItem.MergeOrder = 0;

		// Add menu items to the shortcut menu.
		this.contextMenu1.MenuItems.AddRange(new MenuItem[]
			{cutItem, copyItem, pasteItem});

		// Add the mainMenu1 items to the shortcut menu as well, by
		// calling the MergeMenu method.
		contextMenu1.MergeMenu(mainMenu1);

		//Initialize the form.
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Name = "Form1";
		this.Text = "Right click on form for merged menu.";
		
		// Associate the event-handling method with the
		// MouseDown event.
		this.MouseDown +=new MouseEventHandler(Form1_MouseDown);

		// Add mainMenu1 to the form.
		this.Menu = mainMenu1;
	}

	private void Form1_MouseDown(object sender, MouseEventArgs e)
	{

		// Check for a right mouse click.
		if (e.Button==MouseButtons.Right)

			// Display a merged menu containing items from mainMenu1 
			// and contextMenu1.
		{
			contextMenu1.Show(this, new System.Drawing.Point(30, 30));
		}
	}

	[System.STAThreadAttribute]
	public static void Main()
	{
		Application.Run(new Form1());
	}


}
//</snippet1>

