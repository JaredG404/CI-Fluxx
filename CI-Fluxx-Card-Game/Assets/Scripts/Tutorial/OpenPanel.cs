using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour {
    public GameObject Panel;
    public GameObject[] objs;

    public void DeactivateAllButtons () {
        objs = GameObject.FindGameObjectsWithTag ("TutorialPanel");
        foreach (GameObject panel in objs) {
            panel.SetActive (false);
        }
    }

    public void Open () {
        if (Panel != null) {
            bool active = Panel.activeSelf;
            if (!active) {
                DeactivateAllButtons ();
            }
            Panel.SetActive (!active);
        }
    }
}