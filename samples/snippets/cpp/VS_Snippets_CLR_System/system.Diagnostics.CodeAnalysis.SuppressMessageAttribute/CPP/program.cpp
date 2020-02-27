// SuppressMessageAttribute.cpp : main project file.

#define CODE_ANALYSIS
using namespace System;
using namespace System::Diagnostics::CodeAnalysis;

ref class Library
{
    [SuppressMessage("Microsoft.Performance", "CA1801:ReviewUnusedParameters", MessageId = "isChecked")]
    [SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "fileIdentifier")]
    static void FileNode(String ^ name, bool isChecked)
        {
        String ^ fileIdentifier = name;
        String ^ fileName       = name;
        String ^ version        = "";
        };
};
