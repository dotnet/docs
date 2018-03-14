using System;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace DataSourceTypeConverterExamples
{
	public class DataSourceTypeConverterExampleControl : System.Web.UI.WebControls.WebControl
	{        
        //<Snippet1>
        // Associates the DataBindingCollectionConverter 
        // with a DataBindingCollection property.
        [TypeConverterAttribute(typeof(DataBindingCollectionConverter))]
        public DataBindingCollection dataBindings
        {
            get
            {
                return bindings;
            }
            set
            {
                bindings = value;
            }
        }
        private DataBindingCollection bindings;
        //</Snippet1>       
        
        //<Snippet2>
        // Associates the DataMemberConverter with a string property.
        [TypeConverterAttribute(typeof(DataMemberConverter))]
        public string dataMember
        {
            get
            {
                return member;
            }
            set
            {
                member = value;
            }
        }
        private string member;
        //</Snippet2>        

        //<Snippet3>
        // Associates the DataFieldConverter with a string property.
        [TypeConverterAttribute(typeof(DataMemberConverter))]
        public string dataField
        {
            get
            {
                return field;
            }
            set
            {
                field = value;
            }
        }
        private string field;
        //</Snippet3>        
        
        //<Snippet4>
        // Associates the DataSourceConverter with an object property.
        [TypeConverterAttribute(typeof(DataSourceConverter))]
        public object dataSource
        {
            get
            {
                return source;
            }
            set
            {
                source = value;
            }
        }
        private object source;
        //</Snippet4>        
        
		[Bindable(true),
			Category("Appearance"),
			DefaultValue("")]
		public string Text
		{
			get
			{
				return text;
			}

			set
			{
				text = value;
			}
		}
        private string text;

		protected override void Render(HtmlTextWriter output)
		{
			output.Write(Text);           
		}
	}
}
