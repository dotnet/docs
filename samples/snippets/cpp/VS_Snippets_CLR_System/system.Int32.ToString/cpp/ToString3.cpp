// <Snippet3>
using namespace System;

void main()
{
    int value = -16325;
    String^ specifier;
    
    // Use standard numeric format specifiers.
    specifier = "G";
    Console::WriteLine("{0}: {1}", specifier, value.ToString(specifier));

    specifier = "C";
    Console::WriteLine("{0}: {1}", specifier, value.ToString(specifier));

    specifier = "D8";
    Console::WriteLine("{0}: {1}", specifier, value.ToString(specifier));

    specifier = "E4";
    Console::WriteLine("{0}: {1}", specifier, value.ToString(specifier));

    specifier = "e3";
    Console::WriteLine("{0}: {1}", specifier, value.ToString(specifier));

    specifier = "F";
    Console::WriteLine("{0}: {1}", specifier, value.ToString(specifier));

    specifier = "N";
    Console::WriteLine("{0}: {1}", specifier, value.ToString(specifier));

    specifier = "P";
    Console::WriteLine("{0}: {1}", specifier, (value/100000).ToString(specifier));

    specifier = "X";
    Console::WriteLine("{0}: {1}", specifier, value.ToString(specifier));
    
    // Use custom numeric format specifiers.
    specifier = "0,0.000";
    Console::WriteLine("{0}: {1}", specifier, value.ToString(specifier));

    specifier = "#,#.00#;(#,#.00#)";
    Console::WriteLine("{0}: {1}", specifier, (value*-1).ToString(specifier));
}   
// The example displays the following output:
//     G: -16325
//     C: ($16,325.00)
//     D8: -00016325
//     E4: -1.6325E+004
//     e3: -1.633e+004
//     F: -16325.00
//     N: -16,325.00
//     P: 0.00 %
//     X: FFFFC03B
//     0,0.000: -16,325.000
//     #,#.00#;(#,#.00#): 16,325.00
// </Snippet3>
