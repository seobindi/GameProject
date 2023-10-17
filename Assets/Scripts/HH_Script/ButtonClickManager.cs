using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float AlphaThreshold = 0.1f;
    void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = AlphaThreshold;
    }

    // Update is called once per frame
    
}
