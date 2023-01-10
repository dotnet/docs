using System;
using System.ServiceModel;
using System.Security.Permissions;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security.Tokens;
using System.Data;
using System.Xml;
using System.IO;
using System.Text;

namespace Example
{
    public class Test
    {
        //<snippet1>
        private Binding CreateBinding()
        {
            BindingElementCollection bindings = new BindingElementCollection();
            KerberosSecurityTokenParameters tokens = new KerberosSecurityTokenParameters();
            SymmetricSecurityBindingElement security =
              new SymmetricSecurityBindingElement(tokens);

            // Require that every request and return be correlated.
            security.RequireSignatureConfirmation = true;

            bindings.Add(security);
            TextMessageEncodingBindingElement encoding = new TextMessageEncodingBindingElement();
            bindings.Add(encoding );
            HttpTransportBindingElement transport = new HttpTransportBindingElement();
            bindings.Add(transport);
            CustomBinding myBinding = new CustomBinding(bindings);
            return myBinding;
        }
        //</snippet1>

        private void Create()
        {
            //<snippet2>
            SymmetricSecurityBindingElement sec = (SymmetricSecurityBindingElement)
                SecurityBindingElement.CreateMutualCertificateBindingElement();
            //</snippet2>
         }
        static void Main()
        {
            // Empty
        }
    }
}
