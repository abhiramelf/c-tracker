using UnityEngine;
using PullToRefresh;
using CTracker;

public class PullDownLoad : MonoBehaviour
{
    // Reference for controlling refresh actions
    [SerializeField]
    private UIRefreshControl refreshControl;

    // Reference to interface and implementation
    private GetData data;
    private IRefreshData refreshData;

    private void Start()
    {
        // Add listener to call RefreshApp while UI swiped down
        refreshControl.OnRefresh.AddListener(RefreshFetch);

        // Object of GetData() assigned to interface
        data = new GetData();
        refreshData = data;
    }

    // Fetch the global data
    public void RefreshFetch()
    {
        StartCoroutine(refreshData.GetGlobalData()); 
    }

    // When refresh is over
    public void EndRefresh()
    {
        refreshControl.EndRefreshing();
    }

}

