// This is a custom TextBox control that overrides the OnClick method
// to allow one-click selection of the text in the text box.

public class SingleClickTextBox: TextBox

{
	protected override void OnClick(EventArgs e)
	{
		this.SelectAll();
		base.OnClick(e);
	}


}