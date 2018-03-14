//<snippet5>
using namespace System;
using namespace System::IO;
using namespace System::Text;

public ref class BinReadWrite
{
public:
    static void Main()
    {
        String^ testfile = "C:\\temp\\testfile.bin";

        // create a test file using BinaryWriter
        FileStream^ fs = File::Create(testfile);
        UTF8Encoding^ utf8 = gcnew UTF8Encoding();

        BinaryWriter^ bw = gcnew BinaryWriter(fs, utf8);
        // write a series of bytes to the file, each time incrementing
        // the value from 0 - 127
        int pos;

        for (pos = 0; pos < 128; pos++)
        {
            bw->Write((Byte)pos);
        }

        // reset the stream position for the next write pass
        bw->Seek(0, SeekOrigin::Begin);
        // write marks in file with the value of 255 going forward
        for (pos = 0; pos < 120; pos += 8)
        {
            bw->Seek(7, SeekOrigin::Current);
            bw->Write((Byte)255);
        }

        // reset the stream position for the next write pass
        bw->Seek(0, SeekOrigin::End);
        // write marks in file with the value of 254 going backward
        for (pos = 128; pos > 6; pos -= 6)
        {
            bw->Seek(-6, SeekOrigin::Current);
            bw->Write((Byte)254);
            bw->Seek(-1, SeekOrigin::Current);
        }

        // now dump the contents of the file using the original file stream
        fs->Seek(0, SeekOrigin::Begin);
        array<Byte>^ rawbytes = gcnew array<Byte>(fs->Length);
        fs->Read(rawbytes, 0, (int)fs->Length);

        int i = 0;
        for each (Byte b in rawbytes)
        {
             switch (b)
             {
                 case 254:
                 {
                     Console::Write("-%- ");
                 }
                 break;

                 case 255:
                 {
                     Console::Write("-*- ");
                 }
                 break;

                 default:
                 {
                     Console::Write("{0:d3} ", b);
                 }
                 break;
             }
             i++;
             if (i == 16)
             {
                 Console::WriteLine();
                 i = 0;
             }
        }
        fs->Close();
    }
};

int main()
{
    BinReadWrite::Main();
}

//The output from the program is this:
//
// 000 001 -%- 003 004 005 006 -*- -%- 009 010 011 012 013 -%- -*-
// 016 017 018 019 -%- 021 022 -*- 024 025 -%- 027 028 029 030 -*-
// -%- 033 034 035 036 037 -%- -*- 040 041 042 043 -%- 045 046 -*-
// 048 049 -%- 051 052 053 054 -*- -%- 057 058 059 060 061 -%- -*-
// 064 065 066 067 -%- 069 070 -*- 072 073 -%- 075 076 077 078 -*-
// -%- 081 082 083 084 085 -%- -*- 088 089 090 091 -%- 093 094 -*-
// 096 097 -%- 099 100 101 102 -*- -%- 105 106 107 108 109 -%- -*-
// 112 113 114 115 -%- 117 118 -*- 120 121 -%- 123 124 125 126 127
//</snippet5>
