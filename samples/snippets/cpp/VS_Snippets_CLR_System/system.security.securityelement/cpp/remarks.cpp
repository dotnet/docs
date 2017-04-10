
using namespace System;
using namespace System::Security;


public ref class SecurityElementTest
{
private:
    SecurityElement^ xmlRootElement;

public:
    SecurityElementTest()
    {
        xmlRootElement = gcnew SecurityElement("thetag", " ");

        xmlRootElement->AddAttribute("a", "123");
        xmlRootElement->AddAttribute("b", "456");
        xmlRootElement->AddAttribute("c", "789");

        xmlRootElement->AddChild(gcnew SecurityElement("first", "text1"));
        xmlRootElement->AddChild(gcnew SecurityElement("second", "text2"));
    }

    // <Snippet1>
    String^ SearchForTextOfTag(String^ tag)
    {
        SecurityElement^ element = this->SearchForChildByTag(tag);
        return element->Text;
    }
    // </Snippet1>

private:
    SecurityElement^ SearchForChildByTag(String^ tag)
    {
        return xmlRootElement->SearchForChildByTag(tag);
    }
};

int main()
{
    SecurityElementTest^ seTest = gcnew SecurityElementTest();

   Console::WriteLine("Found the text for <second>: " + seTest->SearchForTextOfTag("second"));
}
