//<Snippet1>
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

public class Form1 : System.Windows.Forms.Form
{
	RichTextBox rtb = new RichTextBox();
	public Form1()
	{
		this.Controls.Add(rtb);
		rtb.Dock = DockStyle.Fill;
		this.InputLanguageChanged += new InputLanguageChangedEventHandler(languageChange);
	}
	private void languageChange(Object sender, InputLanguageChangedEventArgs e)
	{
		// If the input language is Japanese.
		// set the initial IMEMode to Katakana.
		if (e.InputLanguage.Culture.TwoLetterISOLanguageName.Equals("ja"))
		{
			rtb.ImeMode = System.Windows.Forms.ImeMode.Katakana;
		}
	}
	public static void Main(string[] args)
	{
		Application.Run(new Form1());
	}
}
//</Snippet1>