    private void AllFields_Click(object sender, EventArgs e)
    {
        ActiveForm = Form5;
        string spec = "{0}: {1}<br/>";
        IObjectListFieldCollection flds = List1.AllFields;
        for (int i = 0; i < flds.Count; i++)
            TextView1.Text += 
                String.Format(spec, (i + 1), flds[i].Title);
    }