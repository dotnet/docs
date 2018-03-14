//AppSettingsSample C# sample, flattened to one file for Parsnip.

        //<SNIPPET1>

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Drawing;
using namespace System::Configuration;
using namespace System::Windows::Forms;

namespace AppSettingsSample
{
    //<SNIPPET9>
    //Application settings wrapper class
    ref class FormSettings sealed: public ApplicationSettingsBase
    {
    public:
        [UserScopedSettingAttribute()]
        property String^ FormText
        {
            String^ get()
            {
                return (String^)this["FormText"];
            }
            void set( String^ value )
            {
                this["FormText"] = value;
            }
        }

        //<SNIPPET10>
    public:
        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("0, 0")]
        property Point FormLocation
        {
            Point get()
            {
                return (Point)(this["FormLocation"]);
            }
            void set( Point value )
            {
                this["FormLocation"] = value;
            }
        }
        //</SNIPPET10>

    public:
        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("225, 200")]
        property Size FormSize
        {
            Size get()
            {
                return (Size)this["FormSize"];
            }
            void set( Size value )
            {
                this["FormSize"] = value;
            }
        }

    public:
        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("LightGray")]
        property Color FormBackColor
        {
            Color get()
            {
                return (Color)this["FormBackColor"];
            }
            void set(Color value)
            {
                this["FormBackColor"] = value;
            }
        }

    };
    //</SNIPPET9>

    ref class AppSettingsForm : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
    private:
        System::ComponentModel::IContainer^ components;

        /// <summary>
        /// Clean up any resources being used. The Dispose(true) 
		/// pattern for embedded objects is implemented with this
		/// code that just contains a destructor 
        /// </summary>
    public:
		~AppSettingsForm()
		{
			if (components != nullptr)
			{
				delete components;
			}
		}

#pragma region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
    private:
        void InitializeComponent()
        {
            this->components = nullptr;
            this->colorDialog = gcnew System::Windows::Forms::ColorDialog();
            this->backColorButton = gcnew System::Windows::Forms::Button();
            this->resetButton = gcnew System::Windows::Forms::Button();
            this->statusDisplay = gcnew System::Windows::Forms::TextBox();
            this->reloadButton = gcnew System::Windows::Forms::Button();
            this->SuspendLayout();
            //
            // backColorButton
            //
            this->backColorButton->Location = System::Drawing::Point(26, 24);
            this->backColorButton->Name = "backColorButton";
            this->backColorButton->Size = System::Drawing::Size(159, 23);
            this->backColorButton->TabIndex = 0;
            this->backColorButton->Text = "Change Background Color";
            this->backColorButton->Click += gcnew System::EventHandler
                (this,&AppSettingsForm::BackColorButton_Click);
            //
            // resetButton
            //
            this->resetButton->Location = System::Drawing::Point(26, 90);
            this->resetButton->Name = "resetButton";
            this->resetButton->Size = System::Drawing::Size(159, 23);
            this->resetButton->TabIndex = 1;
            this->resetButton->Text = "Reset to Defaults";
            this->resetButton->Click += gcnew System::EventHandler
                (this,&AppSettingsForm::ResetButton_Click);
            //
            // statusDisplay
            //
            this->statusDisplay->Location = System::Drawing::Point(26, 123);
            this->statusDisplay->Name = "statusDisplay";
            this->statusDisplay->Size = System::Drawing::Size(159, 20);
            this->statusDisplay->TabIndex = 2;
            //
            // reloadButton
            //
            this->reloadButton->Location = System::Drawing::Point(26, 57);
            this->reloadButton->Name = "reloadButton";
            this->reloadButton->Size = System::Drawing::Size(159, 23);
            this->reloadButton->TabIndex = 3;
            this->reloadButton->Text = "Reload from Storage";
            this->reloadButton->Click += gcnew System::EventHandler
                (this,&AppSettingsForm::ReloadButton_Click);
            //
            // AppSettingsForm
            //
            this->ClientSize = System::Drawing::Size(217, 166);
            this->Controls->Add(this->reloadButton);
            this->Controls->Add(this->statusDisplay);
            this->Controls->Add(this->resetButton);
            this->Controls->Add(this->backColorButton);
            this->Name = "AppSettingsForm";
            this->Text = "App Settings";
            this->FormClosing += gcnew
                System::Windows::Forms::FormClosingEventHandler
                (this,&AppSettingsForm::AppSettingsForm_FormClosing);
            this->Load += gcnew System::EventHandler(this,
                &AppSettingsForm::AppSettingsForm_Load);
            this->ResumeLayout(false);
            this->PerformLayout();

        }

#pragma endregion

        //<SNIPPET20>
    private:
        System::Windows::Forms::ColorDialog^ colorDialog;

        System::Windows::Forms::Button^ backColorButton;

        System::Windows::Forms::Button^ resetButton;

        System::Windows::Forms::TextBox^ statusDisplay;

        System::Windows::Forms::Button^ reloadButton;
        //</SNIPPET20>



        FormSettings ^ formSettings;

    public:
        AppSettingsForm()
        {
            formSettings = gcnew FormSettings;
            InitializeComponent();
        }

        //<SNIPPET2>
    private:
        void AppSettingsForm_Load(Object^ sender, EventArgs^ e)
        {
            //<SNIPPET11>
            //Associate settings property event handlers.
            formSettings->SettingChanging += gcnew SettingChangingEventHandler(
                this, &AppSettingsForm::FormSettings_SettingChanging);
            formSettings->SettingsSaving += gcnew SettingsSavingEventHandler(
                this,&AppSettingsForm::FormSettings_SettingsSaving);
            //</SNIPPET11>

            //<SNIPPET12>
            //Data bind settings properties with straightforward associations.
            Binding^ backColorBinding = gcnew Binding("BackColor", 
                formSettings, "FormBackColor", true, 
                DataSourceUpdateMode::OnPropertyChanged);
            this->DataBindings->Add(backColorBinding);
            Binding^ sizeBinding = gcnew Binding("Size", formSettings,
                "FormSize", true, DataSourceUpdateMode::OnPropertyChanged);
            this->DataBindings->Add(sizeBinding);
            Binding^ locationBinding = gcnew Binding("Location", formSettings,
                "FormLocation", true, DataSourceUpdateMode::OnPropertyChanged);
            this->DataBindings->Add(locationBinding);

            //For more complex associations, manually assign associations.
            String^ savedText = formSettings->FormText;
            //Since there is no default value for FormText.
            if (savedText != nullptr)
            {
                this->Text = savedText;
            }
            //</SNIPPET12>
        }
        //</SNIPPET2>

        //<SNIPPET3>
    private:
        void AppSettingsForm_FormClosing(Object^ sender,
            FormClosingEventArgs^ e)
        {
            //Synchronize manual associations first.
            formSettings->FormText = this->Text + '.';
            formSettings->Save();
        }
        //</SNIPPET3>

        //<SNIPPET4>
    private:
        void BackColorButton_Click(Object^ sender, EventArgs^ e)
        {
            if (::DialogResult::OK == colorDialog->ShowDialog())
            {
                Color color = colorDialog->Color;
                this->BackColor = color;
            }
        }
        //</SNIPPET4>

        //<SNIPPET5>
    private:
        void ResetButton_Click(Object^ sender, EventArgs^ e)
        {
            formSettings->Reset();
            this->BackColor = SystemColors::Control;
        }
        //</SNIPPET5>

        //<SNIPPET6>
    private:
        void ReloadButton_Click(Object^ sender, EventArgs^ e)
        {
            formSettings->Reload();
        }
        //</SNIPPET6>

        //<SNIPPET7>
    private:
        void FormSettings_SettingChanging(Object^ sender,
            SettingChangingEventArgs^ e)
        {
            statusDisplay->Text = e->SettingName + ": " + e->NewValue;
        }
        //</SNIPPET7>

        //<SNIPPET8>
    private:
        void FormSettings_SettingsSaving(Object^ sender,
            CancelEventArgs^ e)
        {
            //Should check for settings changes first.
            ::DialogResult^ dialogResult = MessageBox::Show(
                "Save current values for application settings?",
                "Save Settings", MessageBoxButtons::YesNo);
            if (::DialogResult::No == dialogResult)
            {
                e->Cancel = true;
            }
        }
        //</SNIPPET8>
    };
    //</SNIPPET1>
}

/// <summary>
/// The main entry point for the application.
/// </summary>
[STAThread]
int main()
{
    Application::EnableVisualStyles();
    Application::Run(gcnew AppSettingsSample::AppSettingsForm());

};


