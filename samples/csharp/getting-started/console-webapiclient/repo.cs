using System.Runtime.Serialization;
using System;
using System.Globalization;

namespace WebAPIClient
{
    [DataContract(Name="repo")]
    public class Repository
    {
        [DataMember(Name="name")]
        public string Name { get; set; }
        
        [DataMember(Name="description")]
        public string Description { get; set; }
        
        [DataMember(Name="html_url")]
        public Uri GitHubHomeUrl { get; set; }
        
        [DataMember(Name="homepage")]
        public Uri Homepage { get; set; }
        
        [DataMember(Name="watchers")]
        public int Watchers { get; set; }
        
        [DataMember(Name="pushed_at")]
        private string JsonDate { get; set; }
        
        [IgnoreDataMember]
        public DateTime LastPush
        {
            get
            {
                return DateTime.ParseExact(JsonDate, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            }
        }
    }
}