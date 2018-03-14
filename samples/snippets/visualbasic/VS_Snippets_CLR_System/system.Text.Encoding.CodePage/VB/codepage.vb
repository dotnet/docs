' The following code example determines the Windows code page that most closely corresponds to each encoding.

' <Snippet1>
Imports System
Imports System.Text

Public Class SamplesEncoding   

   Public Shared Sub Main()

      ' Print the header.
      Console.Write("CodePage identifier and name     ")
      Console.WriteLine("WindowsCodePage")

      ' For every encoding, get the Windows code page for it.
      Dim ei As EncodingInfo
      For Each ei In  Encoding.GetEncodings()
         Dim e As Encoding = ei.GetEncoding()
         
         Console.Write("{0,-6} {1,-25} ", ei.CodePage, ei.Name)
         Console.Write("{0,-6} ", e.WindowsCodePage)
         
         ' Mark the ones that are different.
         If ei.CodePage <> e.WindowsCodePage Then
            Console.Write("*")
         End If 
         Console.WriteLine()

      Next ei

   End Sub 'Main 

End Class 'SamplesEncoding


'This code produces the following output.
'
'CodePage identifier and name     WindowsCodePage
'37     IBM037                    1252   *
'437    IBM437                    1252   *
'500    IBM500                    1252   *
'708    ASMO-708                  1256   *
'720    DOS-720                   1256   *
'737    ibm737                    1253   *
'775    ibm775                    1257   *
'850    ibm850                    1252   *
'852    ibm852                    1250   *
'855    IBM855                    1252   *
'857    ibm857                    1254   *
'858    IBM00858                  1252   *
'860    IBM860                    1252   *
'861    ibm861                    1252   *
'862    DOS-862                   1255   *
'863    IBM863                    1252   *
'864    IBM864                    1256   *
'865    IBM865                    1252   *
'866    cp866                     1251   *
'869    ibm869                    1253   *
'870    IBM870                    1250   *
'874    windows-874               874    
'875    cp875                     1253   *
'932    shift_jis                 932    
'936    gb2312                    936    
'949    ks_c_5601-1987            949    
'950    big5                      950    
'1026   IBM1026                   1254   *
'1047   IBM01047                  1252   *
'1140   IBM01140                  1252   *
'1141   IBM01141                  1252   *
'1142   IBM01142                  1252   *
'1143   IBM01143                  1252   *
'1144   IBM01144                  1252   *
'1145   IBM01145                  1252   *
'1146   IBM01146                  1252   *
'1147   IBM01147                  1252   *
'1148   IBM01148                  1252   *
'1149   IBM01149                  1252   *
'1200   utf-16                    1200   
'1201   unicodeFFFE               1200   *
'1250   windows-1250              1250   
'1251   windows-1251              1251   
'1252   Windows-1252              1252   
'1253   windows-1253              1253   
'1254   windows-1254              1254   
'1255   windows-1255              1255   
'1256   windows-1256              1256   
'1257   windows-1257              1257   
'1258   windows-1258              1258   
'1361   Johab                     949    *
'10000  macintosh                 1252   *
'10001  x-mac-japanese            932    *
'10002  x-mac-chinesetrad         950    *
'10003  x-mac-korean              949    *
'10004  x-mac-arabic              1256   *
'10005  x-mac-hebrew              1255   *
'10006  x-mac-greek               1253   *
'10007  x-mac-cyrillic            1251   *
'10008  x-mac-chinesesimp         936    *
'10010  x-mac-romanian            1250   *
'10017  x-mac-ukrainian           1251   *
'10021  x-mac-thai                874    *
'10029  x-mac-ce                  1250   *
'10079  x-mac-icelandic           1252   *
'10081  x-mac-turkish             1254   *
'10082  x-mac-croatian            1250   *
'12000  utf-32                    1200   *
'12001  utf-32BE                  1200   *
'20000  x-Chinese-CNS             950    *
'20001  x-cp20001                 950    *
'20002  x-Chinese-Eten            950    *
'20003  x-cp20003                 950    *
'20004  x-cp20004                 950    *
'20005  x-cp20005                 950    *
'20105  x-IA5                     1252   *
'20106  x-IA5-German              1252   *
'20107  x-IA5-Swedish             1252   *
'20108  x-IA5-Norwegian           1252   *
'20127  us-ascii                  1252   *
'20261  x-cp20261                 1252   *
'20269  x-cp20269                 1252   *
'20273  IBM273                    1252   *
'20277  IBM277                    1252   *
'20278  IBM278                    1252   *
'20280  IBM280                    1252   *
'20284  IBM284                    1252   *
'20285  IBM285                    1252   *
'20290  IBM290                    932    *
'20297  IBM297                    1252   *
'20420  IBM420                    1256   *
'20423  IBM423                    1253   *
'20424  IBM424                    1255   *
'20833  x-EBCDIC-KoreanExtended   949    *
'20838  IBM-Thai                  874    *
'20866  koi8-r                    1251   *
'20871  IBM871                    1252   *
'20880  IBM880                    1251   *
'20905  IBM905                    1254   *
'20924  IBM00924                  1252   *
'20932  EUC-JP                    932    *
'20936  x-cp20936                 936    *
'20949  x-cp20949                 949    *
'21025  cp1025                    1251   *
'21866  koi8-u                    1251   *
'28591  iso-8859-1                1252   *
'28592  iso-8859-2                1250   *
'28593  iso-8859-3                1254   *
'28594  iso-8859-4                1257   *
'28595  iso-8859-5                1251   *
'28596  iso-8859-6                1256   *
'28597  iso-8859-7                1253   *
'28598  iso-8859-8                1255   *
'28599  iso-8859-9                1254   *
'28603  iso-8859-13               1257   *
'28605  iso-8859-15               1252   *
'29001  x-Europa                  1252   *
'38598  iso-8859-8-i              1255   *
'50220  iso-2022-jp               932    *
'50221  csISO2022JP               932    *
'50222  iso-2022-jp               932    *
'50225  iso-2022-kr               949    *
'50227  x-cp50227                 936    *
'51932  euc-jp                    932    *
'51936  EUC-CN                    936    *
'51949  euc-kr                    949    *
'52936  hz-gb-2312                936    *
'54936  GB18030                   936    *
'57002  x-iscii-de                57002  
'57003  x-iscii-be                57003  
'57004  x-iscii-ta                57004  
'57005  x-iscii-te                57005  
'57006  x-iscii-as                57006  
'57007  x-iscii-or                57007  
'57008  x-iscii-ka                57008  
'57009  x-iscii-ma                57009  
'57010  x-iscii-gu                57010  
'57011  x-iscii-pa                57011  
'65000  utf-7                     1200   *
'65001  utf-8                     1200   *
'
' </Snippet1>
