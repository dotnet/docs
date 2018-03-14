// <Snippet2>
namespace Samples.AspNet.CS.Controls
{
  [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
  public class CustomADRotatorRender : System.Web.UI.WebControls.AdRotator
  {
    private const string ApplicationCachePrefix = "CustomAdRotatorCache: ";

    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
      string navigateUrl = System.String.Empty;
      string imageUrl = System.String.Empty;
      string alternateText = System.String.Empty;

      // If the value for the Advertisement File is not empty.
      if (this.AdvertisementFile.Length > 0 ) 
      {
        // Get a random ad.
        GetRandomAd(out imageUrl, out navigateUrl, out alternateText);
      }

      // Create and render a new HyperLink Web control.
      System.Web.UI.WebControls.HyperLink bannerLink = new System.Web.UI.WebControls.HyperLink();
      foreach(string key in this.Attributes.Keys) 
      {
        bannerLink.Attributes[key] = this.Attributes[key];
      }
      if (this.ID != null && this.ID.Length > 0) 
      {
        bannerLink.ID = this.ClientID;
      }
      bannerLink.NavigateUrl = navigateUrl; 
      bannerLink.Target = this.Target;
      bannerLink.AccessKey = this.AccessKey;
      bannerLink.Enabled = this.Enabled;
      bannerLink.TabIndex = this.TabIndex;
      bannerLink.RenderBeginTag(writer);

      // Create and render a new Image Web control.
      System.Web.UI.WebControls.Image bannerImage = new System.Web.UI.WebControls.Image();
      if (ControlStyleCreated) 
      {
        bannerImage.ApplyStyle(this.ControlStyle);
      }
      bannerImage.AlternateText = alternateText;   
      bannerImage.ImageUrl = imageUrl;   
      bannerImage.ToolTip = this.ToolTip;
      bannerImage.RenderControl(writer);
      bannerLink.RenderEndTag(writer);  
    }
    
    private void GetRandomAd(out string imageUrl, out string navigateUrl, out string alternateText) 
    {
      // Default output parameters values.
      imageUrl = System.String.Empty;
      navigateUrl = System.String.Empty;
      alternateText = System.String.Empty;

      // Try to get the Ads DataSet from the ASP.NET cache.
      string physicalPath = MapPathSecure(this.AdvertisementFile);
      string fileKey = ApplicationCachePrefix + physicalPath;
      System.Web.Caching.Cache cache = System.Web.HttpContext.Current.Cache;
      System.Data.DataSet dataSet = cache[fileKey] as System.Data.DataSet;

      // If the Ads DataSet was not found in the ASP.NET cache.
      if (dataSet == null) 
      {
        // Get the Ads from an XML file.
        dataSet =  new System.Data.DataSet();
        dataSet.ReadXml(physicalPath, System.Data.XmlReadMode.InferSchema);

        // Insert the DataSet into the Cache.
        // Make sure your AntiVirus software doesn't touch the XMLf file, 
        // or else the cache will be empty each time the Render method gets called.
        cache.Insert(fileKey, dataSet, new System.Web.Caching.CacheDependency(physicalPath));
      }
      
      // If Ads were found in the XML File.
      int totalAds = dataSet.Tables[0].Rows.Count;
      if (totalAds > 0)
      {
        // Select a random Ad.
        System.Random randomNumber = new System.Random();
        int selectedAdIndex = randomNumber.Next(totalAds);

        // Output the random Ad's values.
        imageUrl = dataSet.Tables[0].Rows[selectedAdIndex].ItemArray[0].ToString();
        navigateUrl = dataSet.Tables[0].Rows[selectedAdIndex].ItemArray[1].ToString();
        alternateText = dataSet.Tables[0].Rows[selectedAdIndex].ItemArray[2].ToString();
      }
    }
  }
}
// </Snippet2>