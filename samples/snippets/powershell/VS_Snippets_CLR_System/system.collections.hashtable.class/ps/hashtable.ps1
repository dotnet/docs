<#
.Synopsis
   PowerShell sample for the System.Collections.Hashtable class
.DESCRIPTION
   This is a PowerShell sample demonstrating operations on a hashtable.
.NOTES
   Submitted by:  DoctorDNS@Gmail.Com
.FUNCTIONALITY
   This sample duplicates the C# sample, adding in PowerShell specific syntax.
#>

#<snippet00>
# Create new hash table using PowerShell syntax
$OpenWith = @{}

# Add one element to the hash table using the Add method
$OpenWith.Add('txt', 'notepad.exe')

# Add three eleements using PowerShell syntax three different ways
$OpenWith.dib = 'paint.exe'

$KeyBMP = 'bmp'
$OpenWith[$KeyBMP] = 'paint.exe'

$OpenWith += @{'rtf' = 'wordpad.exe'}

# Display hash table
"There are {0} in the `$OpenWith hash table as follows:" -f $OpenWith.Count
''

# Display hashtable properties
'Count of items in the hashtable  : {0}' -f $OpenWith.Count
'Is hashtable fixed size?         : {0}' -f $OpenWith.IsFixedSize
'Is hashtable read-only?          : {0}' -f $OpenWith.IsReadonly
'Is hashtabale synchronised?      : {0}' -f $OpenWith.IsSynchronized
''
'Keys in hashtable:'
$OpenWith.Keys
''
'Values in hashtable:'
$OpenWith.Values
''

<#
This script produces the following output:

There are 4 in the $OpenWith hash table as follows:

Name                           Value                                                                            
----                           -----                                                                            
txt                            notepad.exe                                                                      
dib                            paint.exe                                                                        
bmp                            paint.exe                                                                        
rtf                            wordpad.exe                                                                      

Count of items in the hashtable  : 4
Is hashtable fixed size?         : False
Is hashtable read-only?          : False
Is hashtabale synchronised?      : False

Keys in hashtable:
txt
dib
bmp
rtf

Values in hashtable:
notepad.exe
paint.exe
paint.exe
wordpad.exe
#>
#</snippet00>