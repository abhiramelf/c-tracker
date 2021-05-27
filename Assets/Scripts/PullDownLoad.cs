using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PullToRefresh;

public class PullDownLoad : MonoBehaviour
{
    // Reference for controlling refresh actions
    [SerializeField]
    private UIRefreshControl refreshControl;

    private void Start()
    {
        //Add listener to call RefreshApp while UI swiped down
        refreshControl.OnRefresh.AddListener(RefreshApp);
    }

    public void RefreshApp()
    {
        StartCoroutine(RefreshFetch());
    }

    private IEnumerator RefreshFetch()
    {
        // TODO: Replace with code for fetching covid data
        yield return new WaitForSeconds(2);

        // When refresh is over
        refreshControl.EndRefreshing();
    }


}
