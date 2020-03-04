using namespace System;
using namespace System::Globalization;
 
void ShowZeroPlaceholder()
{
    // <Snippet1>
    double value;
    
    value = 123;
    Console::WriteLine(value.ToString("00000"));
    Console::WriteLine(String::Format("{0:00000}", value));
    // Displays 00123
    
    value = 1.2;
    Console::WriteLine(value.ToString("0.00", CultureInfo::InvariantCulture));
    Console::WriteLine(String::Format(CultureInfo::InvariantCulture, 
                      "{0:0.00}", value));
    // Displays 1.20

    Console::WriteLine(value.ToString("00.00", CultureInfo::InvariantCulture));
    Console::WriteLine(String::Format(CultureInfo::InvariantCulture, 
                                    "{0:00.00}", value));
    // Displays 01.20

    CultureInfo^ daDK = CultureInfo::CreateSpecificCulture("da-DK");
    Console::WriteLine(value.ToString("00.00", daDK)); 
    Console::WriteLine(String::Format(daDK, "{0:00.00}", value));
    // Displays 01,20
    
    value = .56;
    Console::WriteLine(value.ToString("0.0", CultureInfo::InvariantCulture));
    Console::WriteLine(String::Format(CultureInfo::InvariantCulture, 
                                    "{0:0.0}", value));
    // Displays 0.6

    value = 1234567890;
    Console::WriteLine(value.ToString("0,0", CultureInfo::InvariantCulture));	
    Console::WriteLine(String::Format(CultureInfo::InvariantCulture, 
                                    "{0:0,0}", value));	
    // Displays 1,234,567,890      
    
    CultureInfo^ elGR = CultureInfo::CreateSpecificCulture("el-GR");
    Console::WriteLine(value.ToString("0,0", elGR));	
    Console::WriteLine(String::Format(elGR, "{0:0,0}", value));	
    // Displays 1.234.567.890
    
    value = 1234567890.123456;
    Console::WriteLine(value.ToString("0,0.0", CultureInfo::InvariantCulture));	
    Console::WriteLine(String::Format(CultureInfo::InvariantCulture, 
                                    "{0:0,0.0}", value));	
    // Displays 1,234,567,890.1  
    
    value = 1234.567890;
    Console::WriteLine(value.ToString("0,0.00", CultureInfo::InvariantCulture));	
    Console::WriteLine(String::Format(CultureInfo::InvariantCulture, 
                                    "{0:0,0.00}", value));	
    // Displays 1,234.57 
    // </Snippet1>
}

void ShowDigitPlaceholder()
{
    // <Snippet2>
    double value;
    
    value = 1.2;
    Console::WriteLine(value.ToString("#.##", CultureInfo::InvariantCulture));
    Console::WriteLine(String::Format(CultureInfo::InvariantCulture, 
                                    "{0:#.##}", value));
    // Displays 1.2
    
    value = 123;
    Console::WriteLine(value.ToString("#####"));
    Console::WriteLine(String::Format("{0:#####}", value));
    // Displays 123

    value = 123456;
    Console::WriteLine(value.ToString("[##-##-##]"));      
    Console::WriteLine(String::Format("{0:[##-##-##]}", value));      
   // Displays [12-34-56]

    value = 1234567890;
    Console::WriteLine(value.ToString("#"));
    Console::WriteLine(String::Format("{0:#}", value));
    // Displays 1234567890
    
    Console::WriteLine(value.ToString("(###) ###-####"));
    Console::WriteLine(String::Format("{0:(###) ###-####}", value));
    // Displays (123) 456-7890
    // </Snippet2>  
}

void ShowDecimalPoint()
{
    // <Snippet3>
    double value;
    
    value = 1.2;
    Console::WriteLine(value.ToString("0.00", CultureInfo::InvariantCulture));
    Console::WriteLine(String::Format(CultureInfo::InvariantCulture, 
                                    "{0:0.00}", value));
    // Displays 1.20

    Console::WriteLine(value.ToString("00.00", CultureInfo::InvariantCulture));
    Console::WriteLine(String::Format(CultureInfo::InvariantCulture, 
                                    "{0:00.00}", value));
    // Displays 01.20

    Console::WriteLine(value.ToString("00.00", 
                      CultureInfo::CreateSpecificCulture("da-DK")));
    Console::WriteLine(String::Format(CultureInfo::CreateSpecificCulture("da-DK"),
                      "{0:00.00}", value));
    // Displays 01,20

    value = .086;
    Console::WriteLine(value.ToString("#0.##%", CultureInfo::InvariantCulture)); 
    Console::WriteLine(String::Format(CultureInfo::InvariantCulture, 
                                    "{0:#0.##%}", value)); 
    // Displays 8.6%
     
    value = 86000;
    Console::WriteLine(value.ToString("0.###E+0", CultureInfo::InvariantCulture));
    Console::WriteLine(String::Format(CultureInfo::InvariantCulture, 
                      "{0:0.###E+0}", value));
   // Displays 8.6E+4
    // </Snippet3>         
}

void ShowThousandSpecifier()
{
    // <Snippet4>
    double value = 1234567890;
    Console::WriteLine(value.ToString("#,#", CultureInfo::InvariantCulture));
    Console::WriteLine(String::Format(CultureInfo::InvariantCulture, 
                                    "{0:#,#}", value));
    // Displays 1,234,567,890      

    Console::WriteLine(value.ToString("#,##0,,", CultureInfo::InvariantCulture));
    Console::WriteLine(String::Format(CultureInfo::InvariantCulture, 
                                    "{0:#,##0,,}", value));
    // Displays 1,235      	
    // </Snippet4>
}
 
void ShowScalingSpecifier()
{
    // <Snippet5>
    double value = 1234567890;
    Console::WriteLine(value.ToString("#,,", CultureInfo::InvariantCulture));	
    Console::WriteLine(String::Format(CultureInfo::InvariantCulture, 
                                    "{0:#,,}", value));	
    // Displays 1235   
    
    Console::WriteLine(value.ToString("#,,,", CultureInfo::InvariantCulture));
    Console::WriteLine(String::Format(CultureInfo::InvariantCulture, 
                                    "{0:#,,,}", value));
  // Displays 1  
    
    Console::WriteLine(value.ToString("#,##0,,", CultureInfo::InvariantCulture));       
    Console::WriteLine(String::Format(CultureInfo::InvariantCulture, 
                                    "{0:#,##0,,}", value));       
  // Displays 1,235
    // </Snippet5>
}

void ShowPercentagePlaceholder()
{
    // <Snippet6>
    double value = .086;
    Console::WriteLine(value.ToString("#0.##%", CultureInfo::InvariantCulture));
    Console::WriteLine(String::Format(CultureInfo::InvariantCulture, 
                                    "{0:#0.##%}", value));
    // Displays 8.6%      
    // </Snippet6>
}
 
void ShowScientificNotation()
{
    // <Snippet7>
    double value = 86000;
    Console::WriteLine(value.ToString("0.###E+0", CultureInfo::InvariantCulture));
    Console::WriteLine(String::Format(CultureInfo::InvariantCulture, 
                                    "{0:0.###E+0}", value));
    // Displays 8.6E+4
    
    Console::WriteLine(value.ToString("0.###E+000", CultureInfo::InvariantCulture));
    Console::WriteLine(String::Format(CultureInfo::InvariantCulture, 
                                    "{0:0.###E+000}", value));
    // Displays 8.6E+004
    
    Console::WriteLine(value.ToString("0.###E-000", CultureInfo::InvariantCulture));
    Console::WriteLine(String::Format(CultureInfo::InvariantCulture, 
                                    "{0:0.###E-000}", value));
    // Displays 8.6E004
    // </Snippet7>
}

void ShowSectionSpecifier()
{
    // <Snippet8>
    double posValue = 1234;
    double negValue = -1234;
    double zeroValue = 0;

    String^ fmt2 = "##;(##)";
    String^ fmt3 = "##;(##);**Zero**";

    Console::WriteLine(posValue.ToString(fmt2));  
    Console::WriteLine(String::Format("{0:" + fmt2 + "}", posValue));    
    // Displays 1234

    Console::WriteLine(negValue.ToString(fmt2));  
    Console::WriteLine(String::Format("{0:" + fmt2 + "}", negValue));    
    // Displays (1234)
    
    Console::WriteLine(zeroValue.ToString(fmt3)); 
    Console::WriteLine(String::Format("{0:" + fmt3 + "}", zeroValue));
    // Displays **Zero**
    // </Snippet8>
}

void ShowPerMillePlaceholder()
{
    // <Snippet9>
    double value = .00354;
    String^ perMilleFmt = "#0.## " + '\u2030';
    Console::WriteLine(value.ToString(perMilleFmt, CultureInfo::InvariantCulture));
    Console::WriteLine(String::Format(CultureInfo::InvariantCulture, 
                                    "{0:" + perMilleFmt + "}", value));
    // Displays 3.54‰      
    // </Snippet9>
}

void main()
{
    Console::WriteLine("Zero Placeholder:");
    ShowZeroPlaceholder();
    Console::WriteLine();
    Console::WriteLine("Digit Placeholder:");
    ShowDigitPlaceholder();
    Console::WriteLine();
    Console::WriteLine("Decimal Point:");
    ShowDecimalPoint();
    Console::WriteLine();
    Console::WriteLine("Thousand Specifier:");
    ShowThousandSpecifier();
    Console::WriteLine();
    Console::WriteLine("Scaling Specifier:");
    ShowScalingSpecifier();
    Console::WriteLine();
    Console::WriteLine("Percentage Placeholder:");
    ShowPercentagePlaceholder();
    Console::WriteLine();
    Console::WriteLine("Scientific Notation:");
    ShowScientificNotation();
    Console::WriteLine();
    Console::WriteLine("Section Specifier:");
    ShowSectionSpecifier();
    Console::WriteLine();
    Console::WriteLine("Per Mille Placeholder:");
    ShowPerMillePlaceholder();
}

