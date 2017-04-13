

//<snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
 
namespace BindToWebService {
	class Form1: Form

	{
		[STAThread]
		public static void Main()
		{
			Application.EnableVisualStyles();
			Application.Run(new Form1());
		}

		private BindingSource BindingSource1 = new BindingSource();
		private TextBox textBox1 = new TextBox();
		private TextBox textBox2 = new TextBox();
		private Button button1 = new Button();

		public Form1()
		{
			this.Load += new EventHandler(Form1_Load);
			textBox1.Location = new System.Drawing.Point(118, 131);
			textBox1.ReadOnly = true;
			button1.Location = new System.Drawing.Point(133, 60);
			button1.Click += new EventHandler(button1_Click);
			button1.Text = "Get zipcode";
			ClientSize = new System.Drawing.Size(292, 266);
			Controls.Add(this.button1);
			Controls.Add(this.textBox1);
		}

		private void button1_Click(object sender, EventArgs e)
		{

			textBox1.Text = "Calling Web service..";
			ZipCodeResolver resolver = new ZipCodeResolver();
			BindingSource1.Add(resolver.CorrectedAddressXml("0",
					"One Microsoft Way", "Redmond", "WA"));
						
		}

		public void Form1_Load(object sender, EventArgs e)
		{
			//<snippet2>
			BindingSource1.DataSource = typeof(USPSAddress);
			//</snippet2>
			//<snippet3>
			textBox1.DataBindings.Add("Text", this.BindingSource1, "FullZIP", true);
			//</snippet3>
		}
	}

	[System.Web.Services.WebServiceBindingAttribute(Name="ZipCodeResolverSoap",
		Namespace="http://webservices.eraserver.net/")]
	public class ZipCodeResolver:
		System.Web.Services.Protocols.SoapHttpClientProtocol

	{
		
		public ZipCodeResolver() : base()
		{        
			this.Url = 
				"http://webservices.eraserver.net/zipcoderesolver/zipcoderesolver.asmx";
		}

	
		//''<remarks/>
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute
			("http://webservices.eraserver.net/CorrectedAddressXml", 
			RequestNamespace="http://webservices.eraserver.net/", 
			ResponseNamespace="http://webservices.eraserver.net/", 
			Use=System.Web.Services.Description.SoapBindingUse.Literal, 
			ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public USPSAddress CorrectedAddressXml(string accessCode, 
			string address, string city, string state)
		{
			object[] results = this.Invoke("CorrectedAddressXml", 
				new object[]{accessCode, address, city, state});
			return ((USPSAddress) results[0]);
		}

		//''<remarks/>
		public System.IAsyncResult BeginCorrectedAddressXml(string accessCode,
			string address, string city, string state, 
			System.AsyncCallback callback, object asyncState)
		{

			return this.BeginInvoke("CorrectedAddressXml", 
				new object[]{accessCode, address, city, state}, callback, asyncState);
		}


		public USPSAddress EndCorrectedAddressXml(System.IAsyncResult asyncResult)
		{
			object[] results = this.EndInvoke(asyncResult);
			return ((USPSAddress) results[0]);
		}

	}


//<snippet4>
	[System.SerializableAttribute, System.Xml.Serialization.XmlTypeAttribute(
		Namespace="http://webservices.eraserver.net/")]
	public class USPSAddress
	{

		private string streetField;

		private string cityField;

		private string stateField;

		private string shortZIPField;

		private string fullZIPField;


		public string Street    
		{
			get
			{
				return this.streetField;
			}
			set
			{
				this.streetField = value;
			}
		}


		public string City    
		{
			get
			{
				return this.cityField;
			}
			set
			{
				this.cityField = value;
			}
		}

		public string State    
		{
			get
			{
				return this.stateField;
			}
			set
			{
				this.stateField = value;
			}
		}


		public string ShortZIP    
		{
			get
			{
				return this.shortZIPField;
			}
			set
			{
				this.shortZIPField = value;
			}
		}


		public string FullZIP    
		{
			get
			{
				return this.fullZIPField;
			}
			set
			{
				this.fullZIPField = value;
			}
		}
	}
//</snippet4>

	public delegate void CorrectedAddressXmlCompletedEventHandler(object sender,
		CorrectedAddressXmlCompletedEventArgs args);


	public class CorrectedAddressXmlCompletedEventArgs:
    System.ComponentModel.AsyncCompletedEventArgs

	{
		private object[] results;

		internal CorrectedAddressXmlCompletedEventArgs(object[] results,
			System.Exception exception, bool cancelled, object userState) :
			base(exception, cancelled, userState)
		{        
			this.results = results;
		}


		public USPSAddress Result    
		{
			get
			{
				this.RaiseExceptionIfNecessary();
				return ((USPSAddress) this.results[0]);
			}
		}
	}
 }
//</snippet1>







