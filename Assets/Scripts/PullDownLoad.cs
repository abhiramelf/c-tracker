using UnityEngine;
using TMPro;
using PullToRefresh;
using CTracker;

public class PullDownLoad : MonoBehaviour
{
    // Reference for controlling refresh actions
    [SerializeField]
    private UIRefreshControl refreshControl;

    [SerializeField]
    private TextMeshProUGUI casesUI;
    [SerializeField]
    private TextMeshProUGUI confirmedUI;
    [SerializeField]
    private TextMeshProUGUI criticalUI;
    [SerializeField]
    private TextMeshProUGUI deathsUI;
    [SerializeField]
    private TextMeshProUGUI recoveredUI;

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

        // Fetch the global data at app start
        StartCoroutine(refreshData.GetGlobalData());
    }

    // Fetch the global data upon refresh
    public void RefreshFetch()
    {
        StartCoroutine(refreshData.GetGlobalData()); 
    }

    // Display the fetched data
    public void DisplayData(GlobalData gD)
    {
        casesUI.text = gD.cases.ToString();
        confirmedUI.text = gD.active.ToString();
        criticalUI.text = gD.critical.ToString();
        deathsUI.text = gD.deaths.ToString();
        recoveredUI.text = gD.recovered.ToString();
    }

    // When refresh is over
    public void EndRefresh()
    {
        refreshControl.EndRefreshing();
    }

}

