public class myForm:
    Form

{
    protected override void OnClosed(EventArgs e)
    {
        MessageBox.Show("The form is now closing.", 
            "Close Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        base.OnClosed(e);
    }

    public myForm() : base()
    {        
    }

}
