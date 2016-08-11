using UnityEngine;
using System.Collections;

public static class Extensions {
    public static string LoadResourceTextfile(string path)
    {

        string filePath = path.Replace(".json", "");
        TextAsset targetFile = Resources.Load<TextAsset>(filePath);
        return targetFile.text;
    }
    public static string stringJSONclean(JSONObject json)
    {
        string jsonString = "";
        try
        {
            jsonString = json.ToString().Replace("\"", "");
            return jsonString;
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
