//<Snippet1>
<%@WebService class="Streaming" language="C#"%>

using System;
using System.IO;
using System.Collections;
using System.Xml.Serialization;
using System.Web.Services;
using System.Web.Services.Protocols;

public class Streaming {

    [WebMethod(BufferResponse=false)]
    public TextFile GetTextFile(string filename) {
        return new TextFile(filename);
    }

    [WebMethod]
    public void CreateTextFile(TextFile contents) {
        contents.Close();
    }

}

public class TextFile {
    public string filename;
    private TextFileReaderWriter readerWriter;

    public TextFile() {
    }

    public TextFile(string filename) {
        this.filename = filename;
    }

    [XmlArrayItem("line")]
    public TextFileReaderWriter contents {
        get {
            readerWriter = new TextFileReaderWriter(filename);
            return readerWriter;
        }
    }

    public void Close() {
        if (readerWriter != null) readerWriter.Close();
    }
}

public class TextFileReaderWriter : IEnumerable {

    public string Filename;
    private StreamWriter writer;

    public TextFileReaderWriter() {
    }

    public TextFileReaderWriter(string filename) {
        Filename = filename;
    }

    public TextFileEnumerator GetEnumerator() {
        StreamReader reader = new StreamReader(Filename);
        return new TextFileEnumerator(reader);
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    public void Add(string line) {
        if (writer == null)
            writer = new StreamWriter(Filename);
        writer.WriteLine(line);
    }

    public void Close() {
        if (writer != null) writer.Close();
    }

}

public class TextFileEnumerator : IEnumerator {
    private string currentLine;
    private StreamReader reader;

    public TextFileEnumerator(StreamReader reader) {
        this.reader = reader;
    }

    public bool MoveNext() {
        currentLine = reader.ReadLine();
        if (currentLine == null) {
            reader.Close();
            return false;
        }
        else
            return true;
    }

    public void Reset() {
        reader.BaseStream.Position = 0;
    }

    public string Current {
        get {
            return currentLine;
        }
    }

    object IEnumerator.Current {
        get {
            return Current;
        }
    }
}
//</Snippet1>