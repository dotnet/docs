private void textBox1_KeyDown(object sender, KeyEventArgs e)
{
    if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 && e.Modifiers != Keys.Shift)
    {
        e.SuppressKeyPress = true;
    }
}