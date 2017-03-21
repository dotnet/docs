void Page_Load(Object sender, EventArgs ev) {
    BasePartialCachingControl c = Parent as BasePartialCachingControl;
    if (c != null) {
      c.Dependency = new CacheDependency(MapPath("dep1.txt"));
    }
}