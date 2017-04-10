// <Snippet10>

using System;
using System.Text;
using System.Web;
using System.Web.Caching;

public static class ReportManager
{
    private static string _lastRemoved = "";

    public static String GetReport()
    {
        string report = HttpRuntime.Cache["MyReport"] as string;
        if (report == null)
        {
            report = GenerateAndCacheReport();
        }
        return report;
    }

    private static string GenerateAndCacheReport()
    {
        string report = "Report Text. " + _lastRemoved.ToString();

        HttpRuntime.Cache.Insert(
            "MyReport",
            report, 
            null,
            Cache.NoAbsoluteExpiration,
            new TimeSpan(0, 0, 15),
            CacheItemPriority.Default,
            new CacheItemRemovedCallback(ReportRemovedCallback));

        return report;
    }

    public static void ReportRemovedCallback(String key, object value,
        CacheItemRemovedReason removedReason)
    {
        _lastRemoved = "Re-created " + DateTime.Now.ToString();
    }
}
// </Snippet10>