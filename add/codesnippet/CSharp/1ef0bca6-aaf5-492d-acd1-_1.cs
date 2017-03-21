    protected override void ExtractValues(IOrderedDictionary dictionary) {
        dictionary[Column.Name] = ConvertEditedValue(TextBox1.Text.Trim());
        // dictionary[Column.Name] = ConvertEditedValue(TextBox1.Text);
    } 