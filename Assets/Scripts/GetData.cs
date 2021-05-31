using System.Collections;
using UnityEngine;

namespace CTracker
{
    public class GetData : IRefreshData
    {
        //Reference to PullDownLoad class
        PullDownLoad mainClass = Object.FindObjectOfType<PullDownLoad>();

        //Interface implementation
        //Gets the global covid stats
        public IEnumerator GetGlobalData()
        {
            yield return new WaitForSeconds(2.0f);
            Debug.Log("Worked!");
            mainClass.EndRefresh();
        }

        //Interface implementation
        //Gets the covid stats country-wise
        public IEnumerator GetCountryData()
        {
            yield return null;
        }
    }
}
