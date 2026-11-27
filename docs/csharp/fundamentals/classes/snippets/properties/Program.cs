// <AutoUsage>
var untitled = new AudioClip();
Console.WriteLine(untitled.Title); // => Untitled

var clip = new AudioClip { Title = "Birdsong", DurationSeconds = 12 };
Console.WriteLine(clip.Title); // => Birdsong

clip.Title = "Morning birds";
Console.WriteLine(clip.Title); // => Morning birds
// </AutoUsage>

// <CompoundUsage>
clip.DurationSeconds += 3;
Console.WriteLine(clip.DurationSeconds); // => 15
// </CompoundUsage>

// <ComputedUsage>
var rectangle = new Rectangle { Width = 3, Height = 4 };
Console.WriteLine(rectangle.Area); // => 12

rectangle.Width = 5;
Console.WriteLine(rectangle.Area); // => 20
// </ComputedUsage>

// <FieldUsage>
var volume = new Volume();
Console.WriteLine(volume.Percent); // => 50

volume.Percent = 75;
Console.WriteLine(volume.Percent); // => 75

try
{
    volume.Percent = -1;
}
catch (ArgumentOutOfRangeException)
{
    Console.WriteLine(volume.Percent); // => 75
}
// </FieldUsage>

// <PrivateSetUsage>
var counter = new Counter();
counter.Increment();
Console.WriteLine(counter.Count); // => 1
// </PrivateSetUsage>

// <InitUsage>
var export = new ExportOptions { Format = "svg" };
Console.WriteLine(export.Format); // => svg
Console.WriteLine(export.Extension); // => .svg
Console.WriteLine(new ExportOptions().Format); // => png
// </InitUsage>

// <RequiredUsage>
var playlist = new Playlist { Title = "Focus" };
Console.WriteLine(playlist.Title); // => Focus

var emptyTitle = new Playlist { Title = "" };
Console.WriteLine(emptyTitle.Title.Length); // => 0
// </RequiredUsage>

// <RequiredNullable>
var caption = new Caption { Text = null };
Console.WriteLine(caption.Text is null); // => True
// </RequiredNullable>

// <ValidatedInitUsage>
var label = new Label { Text = "  Draft  " };
Console.WriteLine(label.Text); // => Draft
// </ValidatedInitUsage>

// <AutoDeclaration>
public class AudioClip
{
    public string Title { get; set; } = "Untitled";
    public int DurationSeconds { get; set; }
}
// </AutoDeclaration>

// <ComputedDeclaration>
public class Rectangle
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int Area => Width * Height;
}
// </ComputedDeclaration>

// <FieldDeclaration>
public class Volume
{
    public int Percent
    {
        get;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value, 100);
            field = value;
        }
    } = 50;
}
// </FieldDeclaration>

// <PrivateSetDeclaration>
public class Counter
{
    public int Count { get; private set; }

    public void Increment() => Count++;
}
// </PrivateSetDeclaration>

// <InitDeclaration>
public class ExportOptions
{
    public string Format { get; init; } = "png";
    public string Extension => $".{Format}";
}
// </InitDeclaration>

// <RequiredDeclaration>
public class Playlist
{
    public required string Title { get; init; }
}
// </RequiredDeclaration>

// <RequiredNullableDeclaration>
public class Caption
{
    public required string? Text { get; init; }
}
// </RequiredNullableDeclaration>

// <ValidatedInitDeclaration>
public class Label
{
    public required string Text
    {
        get => field;
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            field = value.Trim();
        }
    }
}
// </ValidatedInitDeclaration>
