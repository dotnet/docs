// C:\sdtree\Orcas\Web.NET\System.Web.DynamicData.TableNameAttribute\cs
// C:\_ricka08\code\DD\Snippet\DynamicControlParameter\cs_bldPrj\ClassLibrary1  proj and prop files
// build tested in C:\_ricka08\code\DD\Snippet\DynamicControlParameter\cs_bldPrj\ClassLibrary1
// <snippet11>
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;


[MetadataType(typeof(ProductModelProductDescriptionMetaData))]
//[TableName(""Prod Model Desc")]
[DisplayName("Prod Model Desc")]
public partial class ProductModelProductDescription {

}


public class ProductModelProductDescriptionMetaData {

    [DisplayName("Modified")]
    [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
    public object ModifiedDate { get; set; }

    [DisplayName("Description")]
    public object ProductDescription { get; set; } 

}
// </snippet11>