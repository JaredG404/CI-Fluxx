using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDeck : MonoBehaviour
{
    public static LoadDeck instance;
    public Sprite[] deckArr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
}
