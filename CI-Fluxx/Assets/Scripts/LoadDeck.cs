using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDeck : MonoBehaviour
{

    public static LoadDeck instances;
    public Sprite[] Deck_Arr;

    // Start is called before the first frame update
    void Start()
    {
        //shuffle deck
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if(instances == null)
        {
            instances = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
}
