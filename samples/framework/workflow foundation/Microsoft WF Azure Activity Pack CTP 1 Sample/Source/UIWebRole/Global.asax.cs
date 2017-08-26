using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.WindowsAzure.StorageClient;

namespace UIWebRole
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "File", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);

			SetDefaultBlobBaseAddress();
		}

		private static void SetDefaultBlobBaseAddress()
		{
			SharedLib.StorageHelper.DefaultBlobBaseAddress = SharedLib.StorageHelper.GetCloudStorageAccount().CreateCloudBlobClient().BaseUri.OriginalString;
		}
	}
}