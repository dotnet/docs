public ref class Example_Headers
{
public:

   [MatchAttribute("TITLE>(.*?)<")]
   String^ Title;

   [MatchAttribute("",Pattern="h1>(.*?)<",IgnoreCase=true)]
   String^ H1;

   [MatchAttribute("H2>((([^<,]*),?)+)<",Group=3,Capture=4)]
   String^ Element;

   [MatchAttribute("H2>((([^<,]*),?){2,})<",Group=3,MaxRepeats=0)]
   array<String^>^ Elements1;

   [MatchAttribute("H2>((([^<,]*),?){2,})<",Group=3,MaxRepeats=1)]
   array<String^>^ Elements2;

   [MatchAttribute("H3 ([^=]*)=([^>]*)",Group=1)]
   String^ Attribute;

   [MatchAttribute("H3 ([^=]*)=([^>]*)",Group=2)]
   String^ Value;
};