using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class Test : MonoBehaviour
{
    [MenuItem("AB/ALL")]
    static void BuildAllAB()
    {
        string dir = "AB";
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.StandaloneWindows64);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("打包完毕！！！");
    }

}
