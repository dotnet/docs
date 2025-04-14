using Microsoft.Extensions.Diagnostics.Metrics;

namespace MetricsGen;
public class MetricTags : MetricParentTags
{
    [TagName("Dim1DimensionName")]
    public string? Dim1;                      // custom tag name via attribute
    public Operations Operation { get; set; } // tag name defaults to "Operation"
    public MetricChildTags? ChildTagsObject { get; set; }
}

public enum Operations
{
    Unknown = 0,
    Operation1 = 1,
}

public class MetricParentTags
{
    [TagName("DimensionNameOfParentOperation")]
    public string? ParentOperationName { get; set; }  // custom tag name via attribute
    public MetricTagsStruct ChildTagsStruct { get; set; }
}

public class MetricChildTags
{
    public string? Dim2 { get; set; }  // tag name defaults to "Dim2"
}

public struct MetricTagsStruct
{
    public string Dim3 { get; set; }   // tag name defaults to "Dim3"
}
