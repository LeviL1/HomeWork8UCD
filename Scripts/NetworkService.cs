using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
public class NetworkService
{
  private const string xmlApi = "api.openweathermap.org/data/2.5/weather?q={Chicago},us&mode=xml&appid=ce92f71b51d0c4de713bd982daf86c27";

  private IEnumerator CallApi(string url, Action<string> callback)
  {
    using (UnityWebRequest request = UnityWebRequest.Get(url))
    {
      yield return request.Send();

      if (request.isNetworkError)
      {
        Debug.Log("network problem: " + request.error);
      }
      else if(request.responseCode != (long)System.Net.HttpStatusCode.OK)
      {
        Debug.Log("response error: " + request.responseCode);
      }
      else
      {
        callback(request.downloadHandler.text);
      }
    }
  }
  public IEnumerator GetWeatherXML(Action<string> callback)
  {
    return CallApi(xmlApi, callback);
  }
}

