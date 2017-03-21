    String^ SearchForTextOfTag(String^ tag)
    {
        SecurityElement^ element = this->SearchForChildByTag(tag);
        return element->Text;
    }