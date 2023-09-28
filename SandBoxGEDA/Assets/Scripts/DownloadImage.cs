using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DownloadImage : MonoBehaviour
{
    public Image[] targetImage;
    public string imageUrl = "https://example.com/your-image.png";

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(DownloadAndSetImage());
    }

    IEnumerator DownloadAndSetImage()
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;

            for(int i = 0; i < targetImage.Length; i++)
            {
                targetImage[i].sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

            }
        }
        else
        {
            Debug.LogError("Failed to download image: " + request.error);
        }
    }
}

