public class Form1 : Form
{
    private MenuStrip menuStrip1 = new MenuStrip();
    private ToolStripMenuItem mainToolStripMenuItem = new ToolStripMenuItem();
    private ToolStripMenuItem toolStripMenuItem1 = new ToolStripMenuItem();
    private ToolStripRadioButtonMenuItem toolStripRadioButtonMenuItem1 = 
        new ToolStripRadioButtonMenuItem();
    private ToolStripRadioButtonMenuItem toolStripRadioButtonMenuItem2 = 
        new ToolStripRadioButtonMenuItem();
    private ToolStripRadioButtonMenuItem toolStripRadioButtonMenuItem3 = 
        new ToolStripRadioButtonMenuItem();
    private ToolStripRadioButtonMenuItem toolStripRadioButtonMenuItem4 = 
        new ToolStripRadioButtonMenuItem();
    private ToolStripRadioButtonMenuItem toolStripRadioButtonMenuItem5 = 
        new ToolStripRadioButtonMenuItem();
    private ToolStripRadioButtonMenuItem toolStripRadioButtonMenuItem6 = 
        new ToolStripRadioButtonMenuItem();

    public Form1()
    {
        mainToolStripMenuItem.Text = "main";
        toolStripRadioButtonMenuItem1.Text = "option 1";
        toolStripRadioButtonMenuItem2.Text = "option 2";
        toolStripRadioButtonMenuItem3.Text = "option 2-1";
        toolStripRadioButtonMenuItem4.Text = "option 2-2";
        toolStripRadioButtonMenuItem5.Text = "option 3-1";
        toolStripRadioButtonMenuItem6.Text = "option 3-2";
        toolStripMenuItem1.Text = "toggle";
        toolStripMenuItem1.CheckOnClick = true;

        mainToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            toolStripRadioButtonMenuItem1, toolStripRadioButtonMenuItem2,
            toolStripMenuItem1});
        toolStripRadioButtonMenuItem2.DropDownItems.AddRange(
            new ToolStripItem[] {toolStripRadioButtonMenuItem3, 
            toolStripRadioButtonMenuItem4});
        toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] {
            toolStripRadioButtonMenuItem5, toolStripRadioButtonMenuItem6});

        menuStrip1.Items.AddRange(new ToolStripItem[] {mainToolStripMenuItem});
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        Text = "ToolStripRadioButtonMenuItem demo";
    }
}

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }
}