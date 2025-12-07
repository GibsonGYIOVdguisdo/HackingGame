using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class FileManager
{
    public static string ReadFile(string fileName)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(fileName);

        if (textAsset != null)
        {
            return textAsset.text;
        }

        return "";
    }

    public static string[] ReadSeperatedValuesFromFile(string fileName, string seperator = "---")
    {
        string fileText = ReadFile(fileName);
        string[] splitFile = fileText.Split(seperator);
        for (int i = 0; i < splitFile.Length; i++)
        {
            splitFile[i] = splitFile[i].Trim();
        }
        return splitFile;
    }
}
