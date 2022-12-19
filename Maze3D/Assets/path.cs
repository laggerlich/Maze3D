using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class path : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        pathDraw(3000);
    }

    private async void pathDraw(int duration)
    {
        ExitRenderer.componentLineRenderer.gameObject.SetActive(true);
        await Task.Delay(duration);
        ExitRenderer.componentLineRenderer.gameObject.SetActive(false);
    }
}
