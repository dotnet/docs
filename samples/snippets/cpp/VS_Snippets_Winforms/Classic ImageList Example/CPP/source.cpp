#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

    using namespace System;
    using namespace System::Drawing;
    using namespace System::ComponentModel;
    using namespace System::Windows::Forms;

//<snippet1>
namespace myImageRotator
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
{
    using namespace System;
    using namespace System::Drawing;
    using namespace System::ComponentModel;
    using namespace System::Windows::Forms;

    public ref class Form1 : public System::Windows::Forms::Form
    {
    private:
        System::ComponentModel::IContainer^ components;
    private:
        System::Windows::Forms::ListBox^ listBox1;
    private:
        System::Windows::Forms::Label^ label3;
    private:
        System::Windows::Forms::Button^ button1;
    private:
        System::Windows::Forms::Button^ button2;
    private:
        System::Windows::Forms::Button^ button3;
    private:
        System::Windows::Forms::Button^ button4;
    private:
        System::Windows::Forms::PictureBox^ pictureBox1;
    private:
        System::Windows::Forms::ImageList^ imageList1;
    private:
        System::Windows::Forms::OpenFileDialog^ openFileDialog1;
    protected:
        Graphics^ myGraphics;
    private:
        System::Windows::Forms::Panel^ panel1;
    private:
        System::Windows::Forms::Label^ label5;
    private:
        int currentImage;

    public:
        Form1()
        {
            InitializeComponent();
            imageList1 = gcnew ImageList () ;
            currentImage = 0;

            // The default image size is 16 x 16, which sets up a larger
            // image size. 
            imageList1->ImageSize = System::Drawing::Size(255,255);
            imageList1->TransparentColor = Color::White;

            // Assigns the graphics object to use in the draw options.
            myGraphics = Graphics::FromHwnd(panel1->Handle);
        }

    private:
        void InitializeComponent()
        {
            this->components = gcnew System::ComponentModel::Container();
            this->listBox1 = gcnew System::Windows::Forms::ListBox();
            this->label3 = gcnew System::Windows::Forms::Label();
            this->button1 = gcnew System::Windows::Forms::Button();
            this->button2 = gcnew System::Windows::Forms::Button();
            this->button3 = gcnew System::Windows::Forms::Button();
            this->button4 = gcnew System::Windows::Forms::Button();
            this->pictureBox1 = gcnew System::Windows::Forms::PictureBox();
            this->imageList1 = gcnew System::Windows::Forms::ImageList(this->components);
            this->openFileDialog1 = gcnew System::Windows::Forms::OpenFileDialog();
            this->panel1 = gcnew System::Windows::Forms::Panel();
            this->label5 = gcnew System::Windows::Forms::Label();
            this->SuspendLayout();

            this->listBox1->Location = System::Drawing::Point(16, 16);
            this->listBox1->Size = System::Drawing::Size(400, 95);
            this->listBox1->TabIndex = 0;

            this->label3->Location = System::Drawing::Point(24, 168);
            this->label3->Text = "label3";

            this->button1->Location = System::Drawing::Point(96, 128);
            this->button1->Size = System::Drawing::Size(104, 23);
            this->button1->Text = "Show Next Image";
            this->button1->Click += gcnew System::EventHandler(this,&Form1::button1_Click);

            this->button2->Location = System::Drawing::Point(208, 128);
            this->button2->Size = System::Drawing::Size(104, 23);
            this->button2->Text = "Remove Image";
            this->button2->Click += gcnew System::EventHandler(this,&Form1::button2_Click);

            this->button3->Location = System::Drawing::Point(320, 128);
            this->button3->Text = "Clear List";
            this->button3->Click += gcnew System::EventHandler(this,&Form1::button3_Click);

            this->button4->Location = System::Drawing::Point(16, 128);
            this->button4->Text = "Open Image";
            this->button4->Click += gcnew System::EventHandler(this,&Form1::button4_Click);

            this->pictureBox1->Location = System::Drawing::Point(328, 232);
            this->pictureBox1->Size = System::Drawing::Size(336, 192);

            this->imageList1->ImageSize = System::Drawing::Size(16, 16);
            this->imageList1->TransparentColor = System::Drawing::Color::Transparent;

            this->panel1->Location = System::Drawing::Point(8, 240);
            this->panel1->Size = System::Drawing::Size(296, 184);

            this->label5->Location = System::Drawing::Point(168, 168);
            this->label5->Size = System::Drawing::Size(312, 40);
            this->label5->Text = "label5";

            this->ClientSize = System::Drawing::Size(672, 461);
            this->Controls->Add(this->label5);
            this->Controls->Add(this->panel1);
            this->Controls->Add(this->pictureBox1);
            this->Controls->Add(this->button4);
            this->Controls->Add(this->button3);
            this->Controls->Add(this->button2);
            this->Controls->Add(this->button1);
            this->Controls->Add(this->label3);
            this->Controls->Add(this->listBox1);
            this->ResumeLayout(false);
        }

        // Display the image.
    private:
        void button1_Click (Object^ /*sender*/, System::EventArgs^ /*e*/)
        {
            if(imageList1->Images->Empty != true)
            {
                if(imageList1->Images->Count-1 > currentImage)
                {
                    currentImage++;
                }
                else
                {
                    currentImage=0;
                }
                panel1->Refresh();

                // Draw the image in the panel.
                imageList1->Draw(myGraphics,10,10,currentImage);

                // Show the image in the PictureBox.
                pictureBox1->Image = imageList1->Images[currentImage];
                label3->Text = "Current image is " + currentImage ;
                listBox1->SelectedIndex = currentImage;
                //				label5->Text = "Image is " + listBox1->Text ;
                label5->Text = String::Concat("Image is ",listBox1->Text);
            }
        }

        // Remove the image.
    private:
        void button2_Click (Object^ /*sender*/, System::EventArgs^ /*e*/)
        {
            imageList1->Images->RemoveAt(listBox1->SelectedIndex);
            listBox1->Items->Remove(listBox1->SelectedItem);
        }

        // Clear all images.
    private:
        void button3_Click (Object^ /*sender*/, System::EventArgs^ /*e*/)
        {
            imageList1->Images->Clear();
            listBox1->Items->Clear();
        }

        // Find an image.
    private:
        void button4_Click (Object^ /*sender*/, System::EventArgs^ /*e*/)
        {
            openFileDialog1->Multiselect = true ;
            if(openFileDialog1->ShowDialog() == System::Windows::Forms::DialogResult::OK)
            {
                if (openFileDialog1->FileNames != nullptr)
                {
                    for(int i =0 ; i < openFileDialog1->FileNames->Length ; i++ )
                    {
                        addImage(openFileDialog1->FileNames[i]);
                    }
                }
                else
                    addImage(openFileDialog1->FileName);
            }
           
        }

    private:
        void addImage(String^ imageToLoad)
        {
            if (imageToLoad != "")
            {
                imageList1->Images->Add(Image::FromFile(imageToLoad));
                listBox1->BeginUpdate();
                listBox1->Items->Add(imageToLoad);
                listBox1->EndUpdate();
            }
        }

    public:
        static void Main(array<String^>^ /*args*/) 
        {
            Application::Run(gcnew Form1());
        }
    };

}
[STAThreadAttribute] 
int main(){
    myImageRotator::Form1::Main(nullptr);
}
//</snippet1>
