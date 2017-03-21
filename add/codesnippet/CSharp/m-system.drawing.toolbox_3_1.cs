[System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.Button))]
public class StopSignControl3:
    System.Windows.Forms.UserControl

{
    internal System.Windows.Forms.Label Label1;
    internal System.Windows.Forms.Button Button1;

    public StopSignControl3() : base()
    {        
        this.Label1 = new System.Windows.Forms.Label();
        this.Button1 = new System.Windows.Forms.Button();

        this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 
            12.0F, System.Drawing.FontStyle.Regular, 
            System.Drawing.GraphicsUnit.Point, ((byte) 0));
        this.Label1.ForeColor = System.Drawing.Color.Red;
        this.Label1.Location = new System.Drawing.Point(24, 56);
        this.Label1.Name = "Label1";
        this.Label1.TabIndex = 0;
        this.Label1.Text = "Stop!";
        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        this.Button1.Enabled = false;
        this.Button1.Location = new System.Drawing.Point(56, 88);
        this.Button1.Name = "Button1";
        this.Button1.Size = new System.Drawing.Size(40, 32);
        this.Button1.TabIndex = 1;
        this.Button1.Text = "stop";
        this.Controls.Add(this.Button1);
        this.Controls.Add(this.Label1);
        this.Name = "StopSignControl";

    }

    private void StopSignControl_MouseEnter(object sender, System.EventArgs e)
    {
        Label1.Text.ToUpper();
        Label1.Font = new System.Drawing.Font(Label1.Font.FontFamily,
	    14.0F, System.Drawing.FontStyle.Bold);
        Button1.Enabled = true;
    }

    private void StopSignControl_MouseLeave(object sender, System.EventArgs e)
    {
        Label1.Text.ToLower();
        Label1.Font = new System.Drawing.Font(Label1.Font.FontFamily, 
	    12.0F, System.Drawing.FontStyle.Regular);
        Button1.Enabled = false;
    }

}