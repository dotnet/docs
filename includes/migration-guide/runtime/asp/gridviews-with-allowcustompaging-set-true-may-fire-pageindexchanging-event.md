### GridViews with AllowCustomPaging set to true may fire the PageIndexChanging event when leaving the final page of the view

|   |   |
|---|---|
|Details|A bug in the .NET Framework 4.5 causes <xref:System.Web.UI.WebControls.GridView.PageIndexChanging?displayProperty=name> to sometimes not fire for <xref:System.Web.UI.WebControls.GridView?displayProperty=name>s that have enabled <xref:System.Web.UI.WebControls.GridView.AllowCustomPaging?displayProperty=name>.|
|Suggestion|This issue has been fixed in the .NET Framework 4.6 and may be addressed by upgrading to that version of the .NET Framework. As a work-around, the app can do an explicit BindGrid on any <code>Page_Load</code> that would hit these conditions (the <xref:System.Web.UI.WebControls.GridView?displayProperty=name> is on the last page and Last<xref:System.Web.UI.WebControls.GridView.PageSize?displayProperty=name> is different from <xref:System.Web.UI.WebControls.GridView.PageSize?displayProperty=name>). Alternatively, the app can be modified to allow paging (instead of custom paging), as that scenario does not demonstrate the problem.|
|Scope|Minor|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Web.UI.WebControls.GridView.AllowCustomPaging?displayProperty=nameWithType></li></ul>|
