using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragAdapt : MonoBehaviour {

    public int baseThresh = 6;
    public int basePPI = 210;

    void Start () {
        GetComponent<EventSystem>().pixelDragThreshold = baseThresh * (int)Screen.dpi / basePPI;
    }

}
