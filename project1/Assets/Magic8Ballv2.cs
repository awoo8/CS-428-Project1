using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Magic8Ballv2 : MonoBehaviour
{
    private string[] positive = {"For sure", "You Bet", "100%"};
    private string[] unclear = {"Ehhhhhh", "Come Again?", "¯\\_(\'_\')_/¯", "idk"};
    private string[] negative = {"Better start praying", "Let's not talk about it", "Nah"};
    public GameObject magic8BallTextObject;
    public AudioSource audioSource;
    private int flipFlag = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("flipCheck", 2f, 1f);
    }

    // Update is called once per frame
    void flipCheck()
    {
        
        Debug.Log("y: " + transform.up.y);
        if(transform.up.y < 0f){
            flipFlag = 1;
        }
        if(transform.up.y > 0f && flipFlag == 1){
            flipFlag = 0;
            int random = Random.Range(0,3);
            string saying;
            
            if(random == 0)
                saying = positive[Random.Range(0, positive.Length)];
            else if(random == 1)
                saying = unclear[Random.Range(0, unclear.Length)];
            else
                saying = negative[Random.Range(0, negative.Length)];

            magic8BallTextObject.GetComponent<TextMeshPro>().text = saying;
            audioSource.Play();
        }
    }
}
