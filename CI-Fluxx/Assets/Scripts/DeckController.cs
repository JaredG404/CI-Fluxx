using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    public GameObject cards;
    public Transform transform_boxCard;
    public Transform[] PlayerHand, AIHand;
    public List<GameObject> listCard;
    // Start is called before the first frame update
    void Start()
    {
        InstanceCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InstanceCard()
    {
        for (int i = 0; i < LoadDeck.instance.Deck_Arr.Length; i++)
        {
            GameObject _cards = Instantiate(cards, transform_boxCard.position, Quaternion.identity);
            _cards.transform.SetParent(transform_boxCard, true);
            _cards.GetComponent<UICards>().image_cards.sprite = LoadDeck.instance.Deck_Arr[i];
            listCard.Add(_cards);
        }
        StartCoroutine(SplitCards());
    }

    IEnumerator SplitCards()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
            int rdPlayer = Random.Range(0,listCard.Count-1);
            listCard[rdPlayer].transform.SetParent(PlayerHand[i], true);
            iTween.MoveTo(listCard[rdPlayer], iTween.Hash("position", PlayerHand[i].position, "easeType", "Linear", "loopType", "none", "time", 0.4f));

            listCard.RemoveAt(rdPlayer);
            yield return new WaitForSeconds(0.5f);
            int rdAI = Random.Range(0,listCard.Count-1);
            listCard[rdAI].transform.SetParent(AIHand[i], true);
            iTween.MoveTo(listCard[rdAI], iTween.Hash("position", AIHand[i].position, "easeType", "Linear", "loopType", "none", "time", 0.4f));
        }
    }
}
