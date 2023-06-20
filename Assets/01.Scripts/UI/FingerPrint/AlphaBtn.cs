using UnityEngine;
using UnityEngine.UI;

public class AlphaBtn : MonoBehaviour 
{
    private float AlphaThreshold = 0.1f;

    private void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = AlphaThreshold;
    }
}