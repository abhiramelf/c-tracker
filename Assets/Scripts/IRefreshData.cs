using System.Collections;

namespace CTracker
{
    public interface IRefreshData
    {
        //Get Global Data
        public IEnumerator GetGlobalData();

        //Get Country-wise Data
        public IEnumerator GetCountryData();
    }
}
