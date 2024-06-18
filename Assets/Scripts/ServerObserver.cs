using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class ServerObserver : MonoBehaviour
{
    private const string _requestUrl = "https://yandex.com/time/sync.json";

    public async Task<DateTime> GetServerTime()
    {
        UnityWebRequest request = UnityWebRequest.Get(_requestUrl);
        request.SendWebRequest();

        while (!request.isDone)
        {
            await Task.Yield();
        }

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
            return DateTime.MinValue;
        }

        var json = JsonUtility.FromJson<JsonableTime>(request.downloadHandler.text);
        return DateTimeOffset.FromUnixTimeMilliseconds(json.time).DateTime;
    }

    [Serializable]
    private struct JsonableTime {
        public long time;
        public object clocks;

        public JsonableTime(long jsonTime, object jsonClocks) {
            time = jsonTime;
            clocks = jsonClocks;
        }
    }
}
