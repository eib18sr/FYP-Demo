using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.Networking;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class PositionController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI weatherText;

    IEnumerator GetRequest(string url, Action<UnityWebRequest> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            // Send the request and wait for a response
            yield return request.SendWebRequest();
            callback(request);
        }
    }

    public void GetPositionData(string city)
    {
        var path = "https://www.gps-coordinates.net/api/" + city;
        StartCoroutine(GetRequest(path, (UnityWebRequest req) =>
        {
            if (req.result == UnityWebRequest.Result.ProtocolError || req.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log($"{req.error}: {req.downloadHandler.text}");
                weatherText.text = $"{req.error} : {req.downloadHandler.text}";
            }
            else
            {
                var obj = JsonConvert.DeserializeObject<PositionData>(req.downloadHandler.text);

                weatherText.text = obj.ToString();
            }
        }));
    }
}
