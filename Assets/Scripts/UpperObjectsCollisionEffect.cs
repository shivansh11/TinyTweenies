using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperObjectsCollisionEffect : MonoBehaviour {
    public GameObject TT1, TT2, TT1Stars, TT2Stars, ActionController;

    void Start () {
        TT1 = GameObject.Find("TT1");
        TT2 = GameObject.Find("TT2");
        ActionController = GameObject.Find("ActionController");
    }

    private void OnCollisionEnter2D(Collision2D collision){
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        if (collision.gameObject.name == "TT1"){
            ActionController.GetComponent<Actions>().StarsTT1();
        }

        if (collision.gameObject.name == "TT2")
        {
            ActionController.GetComponent<Actions>().StarsTT1();
        }

    }
}
