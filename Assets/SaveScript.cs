using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveScript : MonoBehaviour
{
    public RenderTexture RTexture;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        StartCoroutine(CoSave());
        
    }

    private IEnumerator CoSave()
    {
        yield return new WaitForEndOfFrame();
        Debug.Log(Application.dataPath + "/saveImage.png");

        RenderTexture.active = RTexture;
        var texture2D = new Texture2D(RTexture.width, RTexture.height);
        texture2D.ReadPixels(new Rect(0,0,RTexture.width,RTexture.height),0,0);
        texture2D.Apply();

        var data = texture2D.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/saveImage.png", data);
    }
}
