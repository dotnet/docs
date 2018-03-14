// This sample can go in the VisualStyleElement class overview or a conceptual
// topic to give the new user a chance to view what each of the defined
// elements looks like. This sample also gives them the ability to preview each
// element at three different sizes.

// <Snippet0>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>

using namespace System;
using namespace System::Text;
using namespace System::Drawing;
using namespace System::Collections::Generic;
using namespace System::Reflection;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::VisualStyles;

namespace VisualStyleElementViewer
{
    public ref class ElementViewer : public UserControl
    {
    private:
        VisualStyleElement^ element;
        VisualStyleRenderer^ renderer;
        Dictionary<String^, VisualStyleElement^>^ elementDictionary;
        Rectangle descriptionRect;
        Rectangle displayRect;
        Rectangle displayRectFull;
        System::Drawing::Size currentTrueSize;
        StringBuilder^ elementDescription;
        Label^ infoLabel;
        TreeView^ treeView;
        DomainUpDown^ domainUpDown;
        bool drawElement;

    public:
        ElementViewer():UserControl()
        {
            elementDictionary = 
                gcnew Dictionary<String^, VisualStyleElement^>();
            currentTrueSize = System::Drawing::Size();
            elementDescription = gcnew StringBuilder();
            infoLabel = gcnew Label();
            treeView = gcnew TreeView();
            domainUpDown = gcnew DomainUpDown();

            this->Location = Point(10, 10);
            this->Size = System::Drawing::Size(650, 500);
            this->Text = "VisualStyleElement Viewer";
            this->Font = SystemFonts::IconTitleFont;
            this->BackColor = Color::White;
            this->BorderStyle = System::Windows::Forms::BorderStyle::Fixed3D;
            this->AutoSize = true;
            this->Load += gcnew EventHandler(this, 
                &ElementViewer::ElementViewer_Load);
        }

    private:
        void ElementViewer_Load(Object^ sender, EventArgs^ e)
        {
            // Make sure the visual styles are enabled before
            // going any further.
            if (!Application::RenderWithVisualStyles)
            {
                return;
            }

            infoLabel->Location = Point(320, 10);
            infoLabel->Size = System::Drawing::Size(300, 60);
            infoLabel->Text = "Expand the element class nodes " +
                "in the tree view to access visual style elements. " +
                "Click an element name to draw the element below. To " +
                "change the size of a resizable element, use the " +
                "spin control.";

            domainUpDown->Location = Point(320, 80);
            domainUpDown->Size = System::Drawing::Size(70, 30);
            domainUpDown->ReadOnly = true;
            domainUpDown->Items->Add(elementSizes::Large);
            domainUpDown->Items->Add(elementSizes::Medium);
            domainUpDown->Items->Add(elementSizes::TrueSize);
            domainUpDown->SelectedIndex = 2;
            domainUpDown->SelectedItemChanged +=
                gcnew EventHandler(this, 
                    &ElementViewer::DomainUpDown_SelectedItemChanged);
            domainUpDown->DownButton();

            descriptionRect = Rectangle(320, 120, 250, 50);
            displayRect = Rectangle(320, 160, 0, 0);
            displayRectFull = Rectangle(320, 160, 300, 200);

            // Initialize the element and renderer to known good values.
            element = VisualStyleElement::Button::PushButton::Normal;
            renderer = gcnew VisualStyleRenderer(element);

            SetupElementCollection();
            SetupTreeView();

            this->Controls->AddRange(gcnew array<Control^>{treeView,
                domainUpDown, infoLabel });
        }

        // Use reflection to build a Dictionary of all
        // VisualStyleElement objects exposed in the
        // System.Windows.Forms.VisualStyles namespace.
    private:
        void SetupElementCollection()
        {
            StringBuilder^ elementName = gcnew StringBuilder();
            VisualStyleElement^ currentElement;
            int plusSignIndex = 0;

            // Get array of first-level nested types within
            // VisualStyleElement; these are the element classes.
            array<Type^>^ elementClasses =
                VisualStyleElement::typeid->GetNestedTypes();

            for each (Type^ elementClass in elementClasses)
            {
                // Get an array of second-level nested types within
                // VisualStyleElement; these are the element parts.
                array<Type^>^ elementParts = elementClass->GetNestedTypes();

                // Get the index of the first '+' character in
                // the full element class name.
                plusSignIndex = elementClass->FullName->IndexOf('+');

                for each (Type^ elementPart in elementParts)
                {
                    // Get an array of static property details
                    // for  the current type. Each of these types have
                    // properties that return VisualStyleElement objects.
                    array<PropertyInfo^>^ elementProperties =
                        elementPart->GetProperties(BindingFlags::Static |
                        BindingFlags::Public);

                    // For each property, insert the unique full element
                    // name and the element into the collection.
                    for each(PropertyInfo^ elementProperty in
                        elementProperties)
                    {
                        // Get the element.
                        currentElement =
                            (VisualStyleElement^)elementProperty->
                            GetValue(nullptr, BindingFlags::Static, nullptr,
                            nullptr, nullptr);

                        // Append the full element name.
                        elementName->Append(elementClass->FullName,
                            plusSignIndex + 1,
                            elementClass->FullName->Length -
                            plusSignIndex - 1);
                        elementName->Append("." +
                            elementPart->Name + "." +
                            elementProperty->Name);

                        // Add the element and element name to
                        // the Dictionary.
                        elementDictionary->Add(elementName->ToString(),
                            currentElement);

                        // Clear the element name for the
                        // next iteration.
                        elementName->Remove(0, elementName->Length);
                    }
                }
            }
        }

        // Initialize the tree view with the element names.
    private:
        void SetupTreeView()
        {
            treeView->Location = Point(10, 10);
            treeView->Size = System::Drawing::Size(300, 450);
            //    treeView->BorderStyle = BorderStyle.FixedSingle;
            treeView->BackColor = Color::WhiteSmoke;
            treeView->SelectedNode = nullptr;
            treeView->AfterSelect +=
                gcnew TreeViewEventHandler(this, 
                &ElementViewer::TreeView_AfterSelect);

            treeView->BeginUpdate();

            // An index into the top-level tree nodes.
            int nodeIndex = 0;

            // An index into the first '.' character in an element name.
            int firstDotIndex = 0;

            // Initialize the element class name to compare
            // with the class name of the first element
            // in the Dictionary, and set this name to the first
            // top-level node.
            StringBuilder^ compareClassName =
                gcnew StringBuilder("Button");
            treeView->Nodes->Add(
                gcnew TreeNode(compareClassName->ToString()));

            // The current element class name.
            StringBuilder^ currentClassName = gcnew StringBuilder();

            // The text for each second-level node.
            StringBuilder^ nodeText = gcnew StringBuilder();

            for each(KeyValuePair<String^, VisualStyleElement^>^ entry 
                in elementDictionary)
            {
                // Isolate the class name of the current element.
                firstDotIndex = entry->Key->IndexOf('.');
                currentClassName->Append(entry->Key, 0, firstDotIndex);

                // Determine whether we need to increment to the next
                // element class.
                if (currentClassName->ToString() !=
                    compareClassName->ToString())
                {
                    // Increment the index to the next top-level node
                    // in the tree view.
                    nodeIndex++;

                    // Get the new class name to compare with.
                    compareClassName->Remove(0, compareClassName->Length);
                    compareClassName->Append(entry->Key);
                    compareClassName->Remove(firstDotIndex,
                        compareClassName->Length - firstDotIndex);

                    // Add a new top-level node to the tree view.
                    treeView->Nodes->Add(
                        gcnew TreeNode(compareClassName->ToString()));
                }

                // Get the text for the new second-level node.
                nodeText->Append(entry->Key, firstDotIndex + 1,
                    entry->Key->Length - firstDotIndex - 1);

                // Create and insert the new second-level node.
                TreeNode^ newNode = gcnew TreeNode(nodeText->ToString());
                newNode->Name = entry->Key;
                treeView->Nodes[nodeIndex]->Nodes->Add(newNode);

                currentClassName->Remove(0, currentClassName->Length);
                nodeText->Remove(0, nodeText->Length);
            }
            treeView->EndUpdate();
        }

    protected:
        virtual void OnPaint(PaintEventArgs^ e) override
        {
            __super::OnPaint(e);

            // Do nothing further if visual styles are disabled.
            if (!Application::RenderWithVisualStyles)
            {
                this->Text = "Visual styles are disabled.";
                TextRenderer::DrawText(e->Graphics, this->Text, this->Font,
                    this->Location, this->ForeColor);
                return;
            }

            // Draw the element description.
            TextRenderer::DrawText(e->Graphics, elementDescription->ToString(),
                this->Font, descriptionRect, this->ForeColor,
                TextFormatFlags::WordBreak);

            // Draw the element, if an element is selected.
            if (drawElement)
            {
                renderer->DrawBackground(e->Graphics, this->displayRect);
            }
        }

        // Set the element to draw.
    private:
        void TreeView_AfterSelect(Object^ sender, TreeViewEventArgs^ e)
        {
            // Clear the element description.
            elementDescription->Remove(0, elementDescription->Length);

            // If the user clicked a first-level node, disable drawing.
            if (e->Node->Nodes->Count > 0)
            {
                drawElement = false;
                elementDescription->Append("No element is selected");
                domainUpDown->Enabled = false;
            }

            // The user clicked an element node.
            else
            {
                // Add the element name to the description.
                elementDescription->Append(e->Node->Text);

                // Get the element that corresponds to the selected
                // node's name.
                String^ key = e->Node->Name;
                element = elementDictionary[key];

                // Disable resizing if the element is not defined.
                if (!VisualStyleRenderer::IsElementDefined(element))
                {
                    drawElement = false;
                    elementDescription->Append(" is not defined.");
                    domainUpDown->Enabled = false;
                }
                else
                {
                    // Set the element to the renderer.
                    drawElement = true;
                    renderer->SetParameters(element);
                    elementDescription->Append(" is defined.");

                    // Get the system-defined size of the element.
                    Graphics^ g = this->CreateGraphics();
                    currentTrueSize = renderer->GetPartSize(g,
                        ThemeSizeType::True);
                    delete g;
                    displayRect.Size = currentTrueSize;

                    domainUpDown->Enabled = true;
                    domainUpDown->SelectedIndex = 2;
                }
            }

            Invalidate();
        }

        // Resize the element display area.
    private:
        void DomainUpDown_SelectedItemChanged(Object^ sender,
            EventArgs^ e)
        {
            switch ((int)domainUpDown->SelectedItem)
            {
            case this->elementSizes::TrueSize:
                displayRect.Size = currentTrueSize;
                break;
            case this->elementSizes::Medium:
                displayRect.Size = 
                    System::Drawing::Size(displayRectFull.Width / 2, 
                        displayRectFull.Height / 2);
                break;
            case this->elementSizes::Large:
                displayRect.Size = displayRectFull.Size;
                break;
            }

            Invalidate();
        }

        // These values represent the options in the UpDown control.
    private:
        enum class elementSizes
        {
            TrueSize,
            Medium,
            Large
        };
    };
    public ref class ElementViewerForm : public Form
    {
    public:
        ElementViewerForm()
        {
            ElementViewer^ elementViewer = gcnew ElementViewer();
            this->Controls->Add(elementViewer);
            this->Text = elementViewer->Text;
            this->Size = System::Drawing::Size(700, 550);
        }
    };
}

using namespace VisualStyleElementViewer;

[STAThread]
int main()
{
    Application::EnableVisualStyles();
    Application::Run(gcnew ElementViewerForm());
}

// </Snippet0>
