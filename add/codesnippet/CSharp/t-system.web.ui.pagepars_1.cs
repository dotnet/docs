namespace Samples.AspNet.CS
{
    [PermissionSet(SecurityAction.Demand, Unrestricted = true)]
    public class CustomPageParserFilter : PageParserFilter
    {
        public override bool AllowCode
        {
            get 
            {
                return false;
            }
        }
    }
}