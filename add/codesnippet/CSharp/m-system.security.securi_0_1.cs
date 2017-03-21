    string SearchForTextOfTag(string tag)
    {
        SecurityElement element = this.SearchForChildByTag(tag);
        return element.Text;
    }