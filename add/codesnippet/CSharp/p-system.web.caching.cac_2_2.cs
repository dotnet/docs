private void cmdAdd_Click(Object objSender, EventArgs objArgs)
{
    if (txtName.Text != "")
    {
        // Add this item to the cache.
        Cache[txtName.Text] = txtValue.Text;
    }
}
        