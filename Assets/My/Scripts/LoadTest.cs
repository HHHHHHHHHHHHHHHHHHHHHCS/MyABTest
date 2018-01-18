using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class LoadTest : MonoBehaviour
{
    private const string path = @"AB/ab1";

    private void Awake()
    {
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        //1
        //AssetBundleCreateRequest abcr1 = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));

        //2
        //AssetBundle ab = AssetBundle.LoadFromFile(path);

        //3
        //AssetBundleCreateRequest abcr2 = AssetBundle.LoadFromFileAsync(path);

        //4
        //WWW www = WWW.LoadFromCacheOrDownload(path,1);//file:///E:??????

        //5
        //UnityWebRequest uwr = UnityWebRequest.Get(path);

        //Caching.CleanCache();
        //WWW www = WWW.LoadFromCacheOrDownload(@"http://localhost/ab1",0);
        //yield return www;
        //Debug.Log(www.assetBundle.GetAllAssetNames()[0]);



        //UnityWebRequest uwr = UnityWebRequest.GetAssetBundle(@"http://localhost/ab1");
        //yield return uwr.Send();
        //AssetBundle ab = DownloadHandlerAssetBundle.GetContent(uwr);//(uwr.downloadHandler as DownloadHandlerAssetBundle).assetBundle;//
        //Debug.Log(ab.GetAllAssetNames()[0]);


        AssetBundle objAB = AssetBundle.LoadFromFile("AB/gameobjects1");
        AssetBundle sprAB = AssetBundle.LoadFromFile("AB/sprites1");
        AssetBundle matAB = AssetBundle.LoadFromFile("AB/materials1");


        foreach(var item in objAB.LoadAllAssets())
        {
            Instantiate(item);
        }
        Debug.Log(objAB);
        AssetBundleManifest manifest = objAB.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        Debug.Log(manifest);
        string[] dependencies = manifest.GetAllAssetBundles(); //Pass the name of the bundle you want the dependencies for.
        foreach (string _name in dependencies)
        {
            print(_name);
            AssetBundle.LoadFromFile("AB/" + _name);
        }
        yield break;


    }
}
