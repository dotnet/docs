namespace LoggingSampleApp.Pages
{
    // <FetchServiceAndStart>
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Azure;

    public class IndexModel : PageModel
    {
        public IndexModel(AzureEventSourceLogForwarder logForwarder) =>
            logForwarder.Start();
        // </FetchServiceAndStart>

        public void OnGet()
        {
        }
    }
}
