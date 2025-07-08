using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;
using System.Net.Cache;
using System.Net.Http.Headers;
using System.Net.Sockets;

// <CachePolicy>
public static class CachePolicy
{
    public static void AddCacheControlHeaders(HttpRequestMessage request, RequestCachePolicy policy)
// </CachePolicy>
    {
        if (policy != null && policy.Level != RequestCacheLevel.BypassCache)
        {
            CacheControlHeaderValue? cacheControl = null;
            HttpHeaderValueCollection<NameValueHeaderValue> pragmaHeaders = request.Headers.Pragma;

            if (policy is HttpRequestCachePolicy httpRequestCachePolicy)
            {
                switch (httpRequestCachePolicy.Level)
                {
                    case HttpRequestCacheLevel.NoCacheNoStore:
                        cacheControl = new CacheControlHeaderValue
                        {
                            NoCache = true,
                            NoStore = true
                        };
                        pragmaHeaders.Add(new NameValueHeaderValue("no-cache"));
                        break;
                    case HttpRequestCacheLevel.Reload:
                        cacheControl = new CacheControlHeaderValue
                        {
                            NoCache = true
                        };
                        pragmaHeaders.Add(new NameValueHeaderValue("no-cache"));
                        break;
                    case HttpRequestCacheLevel.CacheOnly:
                        throw new WebException("CacheOnly is not supported!");
                    case HttpRequestCacheLevel.CacheOrNextCacheOnly:
                        cacheControl = new CacheControlHeaderValue
                        {
                            OnlyIfCached = true
                        };
                        break;
                    case HttpRequestCacheLevel.Default:
                        cacheControl = new CacheControlHeaderValue();

                        if (httpRequestCachePolicy.MinFresh > TimeSpan.Zero)
                        {
                            cacheControl.MinFresh = httpRequestCachePolicy.MinFresh;
                        }

                        if (httpRequestCachePolicy.MaxAge != TimeSpan.MaxValue)
                        {
                            cacheControl.MaxAge = httpRequestCachePolicy.MaxAge;
                        }

                        if (httpRequestCachePolicy.MaxStale > TimeSpan.Zero)
                        {
                            cacheControl.MaxStale = true;
                            cacheControl.MaxStaleLimit = httpRequestCachePolicy.MaxStale;
                        }

                        break;
                    case HttpRequestCacheLevel.Refresh:
                        cacheControl = new CacheControlHeaderValue
                        {
                            MaxAge = TimeSpan.Zero
                        };
                        pragmaHeaders.Add(new NameValueHeaderValue("no-cache"));
                        break;
                }
            }
            else
            {
                switch (policy.Level)
                {
                    case RequestCacheLevel.NoCacheNoStore:
                        cacheControl = new CacheControlHeaderValue
                        {
                            NoCache = true,
                            NoStore = true
                        };
                        pragmaHeaders.Add(new NameValueHeaderValue("no-cache"));
                        break;
                    case RequestCacheLevel.Reload:
                        cacheControl = new CacheControlHeaderValue
                        {
                            NoCache = true
                        };
                        pragmaHeaders.Add(new NameValueHeaderValue("no-cache"));
                        break;
                    case RequestCacheLevel.CacheOnly:
                        throw new Exception("CacheOnly is not supported!");
                }
            }

            if (cacheControl != null)
            {
                request.Headers.CacheControl = cacheControl;
            }
        }
    }
}