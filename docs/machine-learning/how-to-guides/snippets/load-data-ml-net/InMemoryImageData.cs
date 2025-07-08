using Microsoft.ML.Data;
using System.Collections.Generic;
using System.IO;

public class Example2
{
    // <RawImage>
    public class InMemoryImageData
    {
        [LoadColumn(0)]
        public byte[] Image;

        [LoadColumn(1)]
        public string Label;
    }

    static IEnumerable<InMemoryImageData> LoadInMemoryImagesFromDirectory(
        string folder,
        bool useFolderNameAsLabel = true
        )
    {
        string[] files = Directory.GetFiles(folder, "*",
            searchOption: SearchOption.AllDirectories);
        foreach (string file in files)
        {
            if (Path.GetExtension(file) != ".jpg")
                continue;

            string label = Path.GetFileName(file);
            if (useFolderNameAsLabel)
                label = Directory.GetParent(file).Name;
            else
            {
                for (int index = 0; index < label.Length; index++)
                {
                    if (!char.IsLetter(label[index]))
                    {
                        label = label.Substring(0, index);
                        break;
                    }
                }
            }

            yield return new InMemoryImageData()
            {
                Image = File.ReadAllBytes(file),
                Label = label
            };

        }
    }
    // </RawImage>
}
