using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace CTracker
{
    public class GetData : IRefreshData
    {
        //Reference to PullDownLoad class
        PullDownLoad mainClass = Object.FindObjectOfType<PullDownLoad>();

        private GlobalData globalData;

        //Interface implementation
        //Gets the global covid stats
        public IEnumerator GetGlobalData()
        {
            UnityWebRequest req = UnityWebRequest.Get("https://disease.sh/v3/covid-19/all");

            yield return req.SendWebRequest();

            mainClass.EndRefresh();

            if (req.error != null)
            {
                Debug.LogError("Error while fetching data! ERROR: " + req.error);
            }
            else
            {
                globalData = JsonUtility.FromJson<GlobalData>(req.downloadHandler.text);

                mainClass.DisplayData(globalData);
            }
        }

        //Interface implementation
        //Gets the covid stats country-wise
        public IEnumerator GetCountryData()
        {
            yield return null;
        }
    }

    [System.Serializable]
    public class GlobalData
    {
        public long cases;
        public long active;
        public long critical;
        public long deaths;
        public long recovered;
    }
}
