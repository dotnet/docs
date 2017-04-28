//<SNIPPET1>

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;




namespace Microsoft.Samples.MoveTo.CS 
{

	class Program 
	{
		private static string sourcePath = Environment.GetFolderPath
			(Environment.SpecialFolder.MyDocuments) + 
			@"\FileInfoTestDirectory\MoveFrom\FromFile.xml";
		
		private static string destPath = Environment.GetFolderPath
			(Environment.SpecialFolder.MyDocuments) + 
			@"\FileInfoTestDirectory\DestFile.xml";
		//
		// The main entry point for the application.
		//
		[STAThread()] static void Main () 
		{
			// Change Console properties to make it obvious that 
			// the application is starting.
			Console.Clear();
			// Move it to the upper left corner of the screen.
			Console.SetWindowPosition(0, 0);
			// Make it very large.
			Console.SetWindowSize(Console.LargestWindowWidth - 24,
				Console.LargestWindowHeight - 16);
			Console.WriteLine("Welcome.");
			Console.WriteLine("This application demonstrates the FileInfo.MoveTo method.");
			Console.WriteLine("Press any key to start.");
			string s = Console.ReadLine();
			Console.Write("    Checking whether ");
			Console.Write(sourcePath);
			Console.WriteLine(" exists.");
			FileInfo fInfo = new FileInfo (sourcePath);
			EnsureSourceFileExists();
			DisplayFileProperties(fInfo);
			Console.WriteLine("Preparing to move the file to ");
			Console.Write(destPath);
			Console.WriteLine(".");
			MoveFile(fInfo);
			DisplayFileProperties(fInfo);
			Console.WriteLine("Preparing to delete directories.");
			DeleteFiles();
			Console.WriteLine("Press the ENTER key to close this application.");
			s = Console.ReadLine();
		}
		//
		// Moves the supplied FileInfo instance to destPath.
		//
		private static void MoveFile(FileInfo fInfo) 
		{
			try 
			{
				fInfo.MoveTo(destPath);
				Console.WriteLine("File moved to ");
				Console.WriteLine(destPath);
			} catch (Exception ex) {
				DisplayException(ex);
			}
		}
		//
		// Ensures that the test directories 
		// and the file FromFile.xml all exist.
		// 
		private static void EnsureSourceFileExists() 
		{
			FileInfo fInfo = new FileInfo(sourcePath);
			string dirPath = fInfo.Directory.FullName;
			if (!Directory.Exists(dirPath)) 
			{
				Directory.CreateDirectory(dirPath);
			}
			if (File.Exists(destPath)) 
			{
				File.Delete(destPath);
			}
			Console.Write("Creating file ");
			Console.Write(fInfo.FullName);
			Console.WriteLine(".");
			try 
			{
				if (!fInfo.Exists) 
				{
					Console.WriteLine("Adding data to the file.");
					WriteFileContent(10);
					Console.WriteLine("Successfully created the file.");
				}
			} 
			catch (Exception ex) 
			{
				DisplayException(ex);
			} 
			finally 
			{
				dirPath = null;
			}
		}
		//
		// Creates and saves an Xml file to sourcePath.
		//
		private static void WriteFileContent(int totalElements) 
		{
			XmlDocument doc = new XmlDocument();
			doc.PreserveWhitespace = true;
			doc.AppendChild(doc.CreateXmlDeclaration("1.0", null, "yes"));
			doc.AppendChild(doc.CreateWhitespace("\r\n"));
			XmlElement root = doc.CreateElement("FileInfo.MoveTo");
			root.AppendChild(doc.CreateWhitespace("\r\n"));
			int index = 0;
			XmlElement elem;
			while (index < totalElements) 
			{
				
				elem = doc.CreateElement("MyElement");
				elem.SetAttribute("Index", index.ToString());
				elem.AppendChild(doc.CreateWhitespace("\r\n"));
				elem.AppendChild(doc.CreateTextNode(String.Format
					("MyElement at position {0}.", index)));
				elem.AppendChild(doc.CreateWhitespace("\r\n"));
				root.AppendChild(elem);
				root.AppendChild(doc.CreateWhitespace("\r\n"));
				index++;
			}
			doc.AppendChild(root);
			doc.AppendChild(doc.CreateWhitespace("\r\n"));
			doc.Save(sourcePath);
			elem = null;
			root = null;
			doc = null;
		}
		//
		// Displays FullName, CreationTime, and LastWriteTime of the supplied
		// FileInfo instance, then displays the text of the file.
		//
		private static void DisplayFileProperties(FileInfo fInfo) 
		{
			Console.WriteLine("The FileInfo instance shows these property values.");
			StreamReader reader = null;
			try 
			{
				Console.Write("FullName: ");
				Console.WriteLine(fInfo.FullName);
				Console.Write("CreationTime: ");
				Console.WriteLine(fInfo.CreationTime);
				Console.Write("LastWriteTime: ");
				Console.WriteLine(fInfo.LastWriteTime);
				Console.WriteLine();
				Console.WriteLine("File contents:");
				Console.WriteLine();
				reader = new StreamReader(fInfo.FullName);
				while (!reader.EndOfStream) 
				{
					Console.WriteLine(reader.ReadLine());
				}
				Console.WriteLine();
			} 
			catch (Exception ex) 
			{
				DisplayException(ex);
			} 
			finally 
			{
				if (reader != null) 
				{
					reader.Close();
				}
				reader = null;
			}
		}
		//
		// Deletes the test directory and all its files and subdirectories.
		//
		private static void DeleteFiles() 
		{
			try 
			{
				DirectoryInfo dInfo = new DirectoryInfo(Environment.GetFolderPath
					(Environment.SpecialFolder.MyDocuments) + "\\FileInfoTestDirectory");
				if (dInfo.Exists) 
				{
					dInfo.Delete(true);
					Console.WriteLine("Successfully deleted directories and files.");
				}
				dInfo = null;
			} 
			catch (Exception ex) 
			{
				DisplayException(ex);
			}
		}
		//
		// Displays information about the supplied Exception. This
		// code is not suitable for production applications.
		//
		private static void DisplayException(Exception ex) 
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("An exception of type \"");
			sb.Append(ex.GetType().FullName);
			sb.Append("\" has occurred.\r\n");
			sb.Append(ex.Message);
			sb.Append("\r\nStack trace information:\r\n");
			MatchCollection matchCol = Regex.Matches(ex.StackTrace,
@"(at\s)(.+)(\.)([^\.]*)(\()([^\)]*)(\))((\sin\s)(.+)(:line )([\d]*))?");
			int L = matchCol.Count;
			string[] argList;
			Match matchObj;
			int y, K;
			for(int x = 0; x < L; x++) 
			{
				matchObj = matchCol[x];
				sb.Append(matchObj.Result("\r\n\r\n$1 $2$3$4$5"));
				argList = matchObj.Groups[6].Value.Split(new char[] { ',' });
				K = argList.Length;
				for (y = 0; y < K; y++) 
				{
					sb.Append("\r\n    ");
					sb.Append(argList[y].Trim().Replace(" ", "        "));
					sb.Append(',');
				}
				sb.Remove(sb.Length - 1, 1);
				sb.Append("\r\n)");
				if (0 < matchObj.Groups[8].Length) 
				{
					sb.Append(matchObj.Result("\r\n$10\r\nline $12"));
				}
			}
			argList = null;
			matchObj = null;
			matchCol = null;
			Console.WriteLine(sb.ToString());
			sb = null;
		}
	}
}
//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
// Welcome.
// This application demonstrates the FileInfo.MoveTo method.
// Press any key to start.
//
//     Checking whether C:\Documents and Settings\MyComputer\My Documents\FileInfoTestDirectory\MoveFrom\FromFile.xml exists.
// Creating file C:\Documents and Settings\MyComputer\My Documents\FileInfoTestDirectory\MoveFrom\FromFile.xml.
// Adding data to the file.
// Successfully created the file.
// The FileInfo instance shows these property values.
// FullName: C:\Documents and Settings\MyComputer\My Documents\FileInfoTestDirectory\MoveFrom\FromFile.xml
// CreationTime: 4/18/2006 1:24:19 PM
// LastWriteTime: 4/18/2006 1:24:19 PM
//
// File contents:
//
// <?xml version="1.0" standalone="yes"?>
// <FileInfo.MoveTo>
// <MyElement Index="0">
// MyElement at position 0.
// </MyElement>
// <MyElement Index="1">
// MyElement at position 1.
// </MyElement>
// <MyElement Index="2">
// MyElement at position 2.
// </MyElement>
// <MyElement Index="3">
// MyElement at position 3.
// </MyElement>
// <MyElement Index="4">
// MyElement at position 4.
// </MyElement>
// <MyElement Index="5">
// MyElement at position 5.
// </MyElement>
// <MyElement Index="6">
// MyElement at position 6.
// </MyElement>
// <MyElement Index="7">
// MyElement at position 7.
// </MyElement>
// <MyElement Index="8">
// MyElement at position 8.
// </MyElement>
// <MyElement Index="9">
// MyElement at position 9.
// </MyElement>
// </FileInfo.MoveTo>

// Preparing to move the file to
// C:\Documents and Settings\MYComputer\My Documents\FileInfoTestDirectory\DestFile.xml.
// File moved to
// C:\Documents and Settings\MYComputer\My Documents\FileInfoTestDirectory\DestFile.xml
// The FileInfo instance shows these property values.
// FullName: C:\Documents and Settings\MYComputer\My Documents\FileInfoTestDirectory\DestFile.xml
// CreationTime: 4/18/2006 1:24:19 PM
// LastWriteTime: 4/18/2006 1:24:19 PM
// 
// File contents:
// 
// <?xml version="1.0" standalone="yes"?>
// <FileInfo.MoveTo>
// <MyElement Index="0">
// MyElement at position 0.
// </MyElement>
// <MyElement Index="1">
// MyElement at position 1.
// </MyElement>
// <MyElement Index="2">
// MyElement at position 2.
// </MyElement>
// <MyElement Index="3">
// MyElement at position 3.
// </MyElement>
// <MyElement Index="4">
// MyElement at position 4.
// </MyElement>
// <MyElement Index="5">
// MyElement at position 5.
// </MyElement>
// <MyElement Index="6">
// MyElement at position 6.
// </MyElement>
// <MyElement Index="7">
// MyElement at position 7.
// </MyElement>
// <MyElement Index="8">
// MyElement at position 8.
// </MyElement>
// <MyElement Index="9">
// MyElement at position 9.
// </MyElement>
// </FileInfo.MoveTo>
// 
// Preparing to delete directories.
// Successfully deleted directories and files.
// Press the ENTER key to close this application.
//</SNIPPET1>