using System.Collections.Generic;
using System.IO;
using Microsoft.ML.Data;

public static class Example1
{
    // <LoadImagesModel>
    public class ImageData
    {
        [LoadColumn(0)]
        public string ImagePath;

        [LoadColumn(1)]
        public string Label;
    }

    public static IEnumerable<ImageData> LoadImagesFromDirectory(string folder,
                bool useFolderNameAsLabel = true)
    {
        string[] files = Directory.GetFiles(folder, "*", searchOption: SearchOption.AllDirectories);

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

            yield return new ImageData()
            {
                ImagePath = file,
                Label = label
            };
        }
    }
    // </LoadImagesModel>

    public static void Main()
    {
        // <LoadImages>
        IEnumerable<ImageData> images = LoadImagesFromDirectory(
                        folder: "your-image-directory-path",
                        useFolderNameAsLabel: true
                        );
        // </LoadImages>
    }
}
