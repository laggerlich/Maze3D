using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class showPath : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        exitShow();
    }

    public async void exitShow()
    {
        ExitRenderer.componentLineRenderer.gameObject.SetActive(true);
        await Task.Delay(3000);
        ExitRenderer.componentLineRenderer.gameObject.SetActive(false);
    }
}
