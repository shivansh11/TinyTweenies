using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragAdapt : MonoBehaviour {

    public int baseThresh = 5;

    void Start () {
        GetComponent<EventSystem>().pixelDragThreshold = (int)(baseThresh * Screen.dpi / 160f);
    }

}
