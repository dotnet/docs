// <snippet1>
using System;
using System.IO;

namespace DirectoryInfoCS2
{
    class Class1
    {
        // Copy a source directory to a target directory.
        static public void CopyDirectory(string SourceDirectory, string TargetDirectory)
        {
            DirectoryInfo	source = new DirectoryInfo(SourceDirectory);
            DirectoryInfo	target = new DirectoryInfo(TargetDirectory);
			
            //Determine whether the source directory exists.
            if(!source.Exists)
                return;
            if(!target.Exists)
                target.Create();
			
            //Copy files.
            FileInfo[] sourceFiles = source.GetFiles();	
            for(int i = 0; i < sourceFiles.Length; ++i)
                File.Copy(sourceFiles[i].FullName, target.FullName + "\\" + sourceFiles[i].Name,true);
			
            //Copy directories.
            DirectoryInfo[] sourceDirectories = source.GetDirectories();	
            for(int j = 0; j < sourceDirectories.Length; ++j)
                CopyDirectory(sourceDirectories[j].FullName,target.FullName +"\\" + sourceDirectories[j].Name);
        }
        
        static void Main(string[] args)
        {
            CopyDirectory("D:\\Tools","D:\\NewTools");
        }
    }
}
// </snippet1>