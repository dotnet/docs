
// The following code example checks the values of the Boolean properties of each encoding.
// <Snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   
   // Print the header.
   Console::Write( "CodePage identifier and name     " );
   Console::Write( "BrDisp   BrSave   " );
   Console::Write( "MNDisp   MNSave   " );
   Console::WriteLine( "1-Byte   ReadOnly " );
   
   // For every encoding, get the property values.
   System::Collections::IEnumerator^ myEnum = Encoding::GetEncodings()->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      EncodingInfo ^ ei = safe_cast<EncodingInfo ^>(myEnum->Current);
      Encoding^ e = ei->GetEncoding();
      Console::Write( "{0,-6} {1,-25} ", ei->CodePage, ei->Name );
      Console::Write( "{0,-8} {1,-8} ", e->IsBrowserDisplay, e->IsBrowserSave );
      Console::Write( "{0,-8} {1,-8} ", e->IsMailNewsDisplay, e->IsMailNewsSave );
      Console::WriteLine( "{0,-8} {1,-8} ", e->IsSingleByte, e->IsReadOnly );
   }
}

/* 
This code produces the following output.

CodePage identifier and name     BrDisp   BrSave   MNDisp   MNSave   1-Byte   ReadOnly 
37     IBM037                    False    False    False    False    True     True     
437    IBM437                    False    False    False    False    True     True     
500    IBM500                    False    False    False    False    True     True     
708    ASMO-708                  True     True     False    False    True     True     
720    DOS-720                   True     True     False    False    True     True     
737    ibm737                    False    False    False    False    True     True     
775    ibm775                    False    False    False    False    True     True     
850    ibm850                    False    False    False    False    True     True     
852    ibm852                    True     True     False    False    True     True     
855    IBM855                    False    False    False    False    True     True     
857    ibm857                    False    False    False    False    True     True     
858    IBM00858                  False    False    False    False    True     True     
860    IBM860                    False    False    False    False    True     True     
861    ibm861                    False    False    False    False    True     True     
862    DOS-862                   True     True     False    False    True     True     
863    IBM863                    False    False    False    False    True     True     
864    IBM864                    False    False    False    False    True     True     
865    IBM865                    False    False    False    False    True     True     
866    cp866                     True     True     False    False    True     True     
869    ibm869                    False    False    False    False    True     True     
870    IBM870                    False    False    False    False    True     True     
874    windows-874               True     True     True     True     True     True     
875    cp875                     False    False    False    False    True     True     
932    shift_jis                 True     True     True     True     False    True     
936    gb2312                    True     True     True     True     False    True     
949    ks_c_5601-1987            True     True     True     True     False    True     
950    big5                      True     True     True     True     False    True     
1026   IBM1026                   False    False    False    False    True     True     
1047   IBM01047                  False    False    False    False    True     True     
1140   IBM01140                  False    False    False    False    True     True     
1141   IBM01141                  False    False    False    False    True     True     
1142   IBM01142                  False    False    False    False    True     True     
1143   IBM01143                  False    False    False    False    True     True     
1144   IBM01144                  False    False    False    False    True     True     
1145   IBM01145                  False    False    False    False    True     True     
1146   IBM01146                  False    False    False    False    True     True     
1147   IBM01147                  False    False    False    False    True     True     
1148   IBM01148                  False    False    False    False    True     True     
1149   IBM01149                  False    False    False    False    True     True     
1200   utf-16                    False    True     False    False    False    True     
1201   unicodeFFFE               False    False    False    False    False    True     
1250   windows-1250              True     True     True     True     True     True     
1251   windows-1251              True     True     True     True     True     True     
1252   Windows-1252              True     True     True     True     True     True     
1253   windows-1253              True     True     True     True     True     True     
1254   windows-1254              True     True     True     True     True     True     
1255   windows-1255              True     True     True     True     True     True     
1256   windows-1256              True     True     True     True     True     True     
1257   windows-1257              True     True     True     True     True     True     
1258   windows-1258              True     True     True     True     True     True     
1361   Johab                     False    False    False    False    False    True     
10000  macintosh                 False    False    False    False    True     True     
10001  x-mac-japanese            False    False    False    False    False    True     
10002  x-mac-chinesetrad         False    False    False    False    False    True     
10003  x-mac-korean              False    False    False    False    False    True     
10004  x-mac-arabic              False    False    False    False    True     True     
10005  x-mac-hebrew              False    False    False    False    True     True     
10006  x-mac-greek               False    False    False    False    True     True     
10007  x-mac-cyrillic            False    False    False    False    True     True     
10008  x-mac-chinesesimp         False    False    False    False    False    True     
10010  x-mac-romanian            False    False    False    False    True     True     
10017  x-mac-ukrainian           False    False    False    False    True     True     
10021  x-mac-thai                False    False    False    False    True     True     
10029  x-mac-ce                  False    False    False    False    True     True     
10079  x-mac-icelandic           False    False    False    False    True     True     
10081  x-mac-turkish             False    False    False    False    True     True     
10082  x-mac-croatian            False    False    False    False    True     True     
12000  utf-32                    False    False    False    False    False    True     
12001  utf-32BE                  False    False    False    False    False    True     
20000  x-Chinese-CNS             False    False    False    False    False    True     
20001  x-cp20001                 False    False    False    False    False    True     
20002  x-Chinese-Eten            False    False    False    False    False    True     
20003  x-cp20003                 False    False    False    False    False    True     
20004  x-cp20004                 False    False    False    False    False    True     
20005  x-cp20005                 False    False    False    False    False    True     
20105  x-IA5                     False    False    False    False    True     True     
20106  x-IA5-German              False    False    False    False    True     True     
20107  x-IA5-Swedish             False    False    False    False    True     True     
20108  x-IA5-Norwegian           False    False    False    False    True     True     
20127  us-ascii                  False    False    True     True     True     True     
20261  x-cp20261                 False    False    False    False    False    True     
20269  x-cp20269                 False    False    False    False    True     True     
20273  IBM273                    False    False    False    False    True     True     
20277  IBM277                    False    False    False    False    True     True     
20278  IBM278                    False    False    False    False    True     True     
20280  IBM280                    False    False    False    False    True     True     
20284  IBM284                    False    False    False    False    True     True     
20285  IBM285                    False    False    False    False    True     True     
20290  IBM290                    False    False    False    False    True     True     
20297  IBM297                    False    False    False    False    True     True     
20420  IBM420                    False    False    False    False    True     True     
20423  IBM423                    False    False    False    False    True     True     
20424  IBM424                    False    False    False    False    True     True     
20833  x-EBCDIC-KoreanExtended   False    False    False    False    True     True     
20838  IBM-Thai                  False    False    False    False    True     True     
20866  koi8-r                    True     True     True     True     True     True     
20871  IBM871                    False    False    False    False    True     True     
20880  IBM880                    False    False    False    False    True     True     
20905  IBM905                    False    False    False    False    True     True     
20924  IBM00924                  False    False    False    False    True     True     
20932  EUC-JP                    False    False    False    False    False    True     
20936  x-cp20936                 False    False    False    False    False    True     
20949  x-cp20949                 False    False    False    False    False    True     
21025  cp1025                    False    False    False    False    True     True     
21866  koi8-u                    True     True     True     True     True     True     
28591  iso-8859-1                True     True     True     True     True     True     
28592  iso-8859-2                True     True     True     True     True     True     
28593  iso-8859-3                False    False    True     True     True     True     
28594  iso-8859-4                True     True     True     True     True     True     
28595  iso-8859-5                True     True     True     True     True     True     
28596  iso-8859-6                True     True     True     True     True     True     
28597  iso-8859-7                True     True     True     True     True     True     
28598  iso-8859-8                True     True     False    False    True     True     
28599  iso-8859-9                True     True     True     True     True     True     
28603  iso-8859-13               False    False    True     True     True     True     
28605  iso-8859-15               False    True     True     True     True     True     
29001  x-Europa                  False    False    False    False    True     True     
38598  iso-8859-8-i              True     True     True     True     True     True     
50220  iso-2022-jp               False    False    True     True     False    True     
50221  csISO2022JP               False    True     True     True     False    True     
50222  iso-2022-jp               False    False    False    False    False    True     
50225  iso-2022-kr               False    False    True     False    False    True     
50227  x-cp50227                 False    False    False    False    False    True     
51932  euc-jp                    True     True     True     True     False    True     
51936  EUC-CN                    False    False    False    False    False    True     
51949  euc-kr                    False    False    True     True     False    True     
52936  hz-gb-2312                True     True     True     True     False    True     
54936  GB18030                   True     True     True     True     False    True     
57002  x-iscii-de                False    False    False    False    False    True     
57003  x-iscii-be                False    False    False    False    False    True     
57004  x-iscii-ta                False    False    False    False    False    True     
57005  x-iscii-te                False    False    False    False    False    True     
57006  x-iscii-as                False    False    False    False    False    True     
57007  x-iscii-or                False    False    False    False    False    True     
57008  x-iscii-ka                False    False    False    False    False    True     
57009  x-iscii-ma                False    False    False    False    False    True     
57010  x-iscii-gu                False    False    False    False    False    True     
57011  x-iscii-pa                False    False    False    False    False    True     
65000  utf-7                     False    False    True     True     False    True     
65001  utf-8                     True     True     True     True     False    True     

*/
// </Snippet1>
