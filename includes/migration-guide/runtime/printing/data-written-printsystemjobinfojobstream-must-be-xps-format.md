### Data written to PrintSystemJobInfo.JobStream must be in XPS format

#### Details

The <xref:System.Printing.PrintSystemJobInfo.JobStream> property exposes the stream of a print job. The user can send raw data to the underlying operating system printing components by writing to this stream.Starting with the .NET Framework 4.5 on Windows 8 and later versions of the Windows operating system, data written to this stream must be in XPS format as a package stream.

#### Suggestion

To output print content, you can do either of the following:

- Use the <xref:System.Windows.Xps.XpsDocumentWriter> class to output print content. This is the recommended alternative.
- Ensure that the data sent to the stream returned by the <xref:System.Printing.PrintSystemJobInfo.JobStream> property is in XPS format as a package stream.

| Name    | Value   |
| :------ | :------ |
| Scope   | Minor   |
| Version | 4.5     |
| Type    | Runtime |

#### Affected APIs

- <xref:System.Printing.PrintSystemJobInfo.JobStream?displayProperty=nameWithType>

<!--

#### Affected APIs

- `P:System.Printing.PrintSystemJobInfo.JobStream`

-->
