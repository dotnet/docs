// <Snippet1>
using System;
using System.Data;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Samples.AspNet.CS.Controls
{
	public class MyLoginViewA : LoginView
	{
		private ITemplate _anonymoustemplate;

		[Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(LoginView)),
		TemplateInstance(TemplateInstance.Single)
		]
		public override ITemplate AnonymousTemplate
		{
			get
			{
				return _anonymoustemplate;
			}
			set
			{
				_anonymoustemplate = value;
			}
		}
	}
}
// </Snippet1>
