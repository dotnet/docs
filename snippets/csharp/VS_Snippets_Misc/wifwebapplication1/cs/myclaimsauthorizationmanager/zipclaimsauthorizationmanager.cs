using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml;
using System.IdentityModel.Configuration;
using System.Security.Claims;
using System.Web;



namespace MyClaimsAuthorizationManager
{
    class ZipClaimsAuthorizationManager : ClaimsAuthorizationManager
    {
        private static Dictionary<string, int> m_policies = new Dictionary<string, int>();

        //public ZipClaimsAuthorizationManager()
        //{ }


        public override void LoadCustomConfiguration(XmlNodeList config)
        {
            XmlNodeList nodes = config as XmlNodeList;
            foreach (XmlNode node in nodes)
            {
                {
                    //FIND ZIP CLAIM IN THE POLICY IN WEB.CONFIG AND GET ITS VALUE 
                    //ADD THE VALUE TO MODULE SCOPE m_policies 
                    XmlTextReader reader = new XmlTextReader(new StringReader(node.OuterXml));
                    reader.MoveToContent();
                    string resource = reader.GetAttribute("resource");
                    reader.Read();
                    string claimType = reader.GetAttribute("claimType");
                    if (claimType.CompareTo(ClaimTypes.PostalCode) != 0)
                    {
                        throw new ArgumentNullException("Zip Authorization is not specified in policy in web.config");
                    }
                    int zip = -1;
                    bool success = int.TryParse(reader.GetAttribute("Zip"), out zip);
                    if (!success)
                    {
                        throw new ArgumentException("Specified Zip code is invalid - check your web.config");
                    }
                    m_policies[resource] = zip;
                }
            }            
        }
        public override bool CheckAccess(AuthorizationContext context)
        {
            //GET THE IDENTITY 
            //FIND THE POSTALCODE CLAIM'S VALUE IN IT 
            //COMPARE WITH THE POLICY 
            int allowedZip = -1;
            int requestedZip = -1;
            Uri webPage = new Uri(context.Resource.First().Value);
            ClaimsPrincipal principal = HttpContext.Current.User as ClaimsPrincipal;
            if (principal == null)
            {
                throw new InvalidOperationException("Principal is not populated in the context - check configuration");
            }
            ClaimsIdentity identity = principal.Identity as ClaimsIdentity;
            if (m_policies.ContainsKey(webPage.PathAndQuery))
            {
                allowedZip = m_policies[webPage.PathAndQuery];
                requestedZip = -1;
                int.TryParse((from c in identity.Claims
                              where c.Type == ClaimTypes.PostalCode
                              select c.Value).FirstOrDefault(), out requestedZip);
            }
            if (requestedZip != allowedZip)
            {
                return false;
            }
            return true;
        }
    } 

}
