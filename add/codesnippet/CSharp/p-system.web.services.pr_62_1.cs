public class Example_Headers 
{    
	[MatchAttribute("TITLE>(.*?)<")]
	public string Title;
        
	[MatchAttribute("", Pattern="h1>(.*?)<", IgnoreCase=true)]
	public string H1;

	[MatchAttribute("H2>((([^<,]*),?)+)<", Group=3, Capture=4)] 
	public string Element;

	[MatchAttribute("H2>((([^<,]*),?){2,})<", Group=3, MaxRepeats=0)] 
	public string[] Elements1;

	[MatchAttribute("H2>((([^<,]*),?){2,})<", Group=3, MaxRepeats=1)] 
	public string[] Elements2;

	[MatchAttribute("H3 ([^=]*)=([^>]*)", Group=1)]
	public string Attribute;

	[MatchAttribute("H3 ([^=]*)=([^>]*)", Group=2)]
	public string Value;
}