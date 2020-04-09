
//<snippet1>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Web.Services.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Collections::Generic;
using namespace System::ComponentModel;
using namespace System::Drawing;
using namespace System::Windows::Forms;
 
namespace BindToWebService {

//<snippet4>
	[System::SerializableAttribute, System::Xml::Serialization::XmlTypeAttribute(
		Namespace="http://webservices.eraserver.net/")]
	public ref class USPSAddress
	{

private:
		String^ streetField;

		String^ cityField;

		String^ stateField;

		String^ shortZIPField;

		String^ fullZIPField;


public:
		property String^ Street    
		{
			String^ get()
			{
				return this->streetField;
			}
			void set( String^ value )
			{
				this->streetField = value;
			}
		}


		property String^ City    
		{
			String^ get()
			{
				return this->cityField;
			}
			void set( String^ value )
			{
				this->cityField = value;
			}
		}
		property String^ State    
		{
			String^ get()
			{
				return this->stateField;
			}
			void set( String^ value )
			{
				this->stateField = value;
			}
		}

		property String^ ShortZIP    
		{
			String^ get()
			{
				return this->shortZIPField;
			}
			void set( String^ value )
			{
				this->shortZIPField = value;
			}
		}

		property String^ FullZIP    
		{
			String^ get()
			{
				return this->fullZIPField;
			}
			void set( String^ value )
			{
				this->fullZIPField = value;
			}
		}
	};
//</snippet4>


	[System::Web::Services::WebServiceBindingAttribute(Name="ZipCodeResolverSoap",
		Namespace="http://webservices.eraserver.net/")]
	public ref class ZipCodeResolver:
		public System::Web::Services::Protocols::SoapHttpClientProtocol

	{
		
public:
		ZipCodeResolver() : SoapHttpClientProtocol()
		{        
			this->Url = 
				"http://webservices.eraserver.net/zipcoderesolver/zipcoderesolver.asmx";
		}

	
		//''<remarks/>
		[System::Web::Services::Protocols::SoapDocumentMethodAttribute
			("http://webservices.eraserver.net/CorrectedAddressXml", 
			RequestNamespace="http://webservices.eraserver.net/", 
			ResponseNamespace="http://webservices.eraserver.net/", 
			Use=System::Web::Services::Description::SoapBindingUse::Literal, 
			ParameterStyle=System::Web::Services::Protocols::SoapParameterStyle::Wrapped)]
		USPSAddress^ CorrectedAddressXml(String^ accessCode, 
			String^ address, String^ city, String^ state)
		{
			array<Object^>^ results = this->Invoke("CorrectedAddressXml", 
				gcnew array<Object^>{accessCode, address, city, state});
			return ((USPSAddress^) results[0]);
		}

		//''<remarks/>
		System::IAsyncResult^ BeginCorrectedAddressXml(String^ accessCode,
			String^ address, String^ city, String^ state, 
			System::AsyncCallback^ callback, Object^ asyncState)
		{

			return this->BeginInvoke("CorrectedAddressXml", 
				gcnew array<Object^>{accessCode, address, city, state}, callback, asyncState);
		}


		USPSAddress^ EndCorrectedAddressXml(System::IAsyncResult^ asyncResult)
		{
			array<Object^>^ results = this->EndInvoke(asyncResult);
			return ((USPSAddress^) results[0]);
		}

	};

	ref class Form1: public Form
	{
public:
		[STAThread]
		static void Main()
		{
			Application::EnableVisualStyles();
			Application::Run(gcnew Form1());
		}

private:
		BindingSource^ BindingSource1;

		TextBox^ textBox1;

		TextBox^ textBox2;

		Button^ button1;


public:
		Form1()
		{
			this->Load += gcnew EventHandler(this, &Form1::Form1_Load);
			textBox1->Location = System::Drawing::Point(118, 131);
			textBox1->ReadOnly = true;
			button1->Location = System::Drawing::Point(133, 60);
			button1->Click += gcnew EventHandler(this, &Form1::button1_Click);
			button1->Text = "Get zipcode";
			ClientSize = System::Drawing::Size(292, 266);
			Controls->Add(this->button1);
			Controls->Add(this->textBox1);
                        BindingSource1 = gcnew BindingSource();
                        textBox1 = gcnew TextBox();
                        textBox2 = gcnew TextBox();
                        button1 = gcnew Button();
		}

private:
		void button1_Click(Object^ sender, EventArgs^ e)
		{
			textBox1->Text = "Calling Web service..";
			ZipCodeResolver^ resolver = gcnew ZipCodeResolver();
			BindingSource1->Add(resolver->CorrectedAddressXml("0",
					"One Microsoft Way", "Redmond", "WA"));
						
		}

public:
		void Form1_Load(Object^ sender, EventArgs^ e)
		{
			//<snippet2>
			BindingSource1->DataSource = USPSAddress::typeid;
			//</snippet2>
			//<snippet3>
			textBox1->DataBindings->Add("Text", this->BindingSource1, "FullZIP", true);
			//</snippet3>
		}
	};




	public ref class CorrectedAddressXmlCompletedEventArgs:
    public System::ComponentModel::AsyncCompletedEventArgs

	{
private:
		array<Object^>^ results;

internal:
		CorrectedAddressXmlCompletedEventArgs(array<Object^>^ results,
			System::Exception^ exception, bool cancelled, Object^ userState) :
			AsyncCompletedEventArgs(exception, cancelled, userState)
		{        
			this->results = results;
		}


public:
		property USPSAddress^ Result    
		{
			USPSAddress^ get()
			{
				this->RaiseExceptionIfNecessary();
				return ((USPSAddress^) this->results[0]);
			}
		}

	 delegate void CorrectedAddressXmlCompletedEventHandler(Object^ sender,
		CorrectedAddressXmlCompletedEventArgs^ args);

	};
}

int main()
{
	BindToWebService::Form1::Main();
	return 1;
}
//</snippet1>
