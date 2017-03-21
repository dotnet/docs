    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Cache[ObjectDataSource2.CacheKeyDependency] = "CacheExample";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Cache.Remove(ObjectDataSource2.CacheKeyDependency);
        Cache[ObjectDataSource2.CacheKeyDependency] = "CacheExample";
        DetailsView1.DataBind();
    }