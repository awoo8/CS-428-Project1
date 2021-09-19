using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Magic8Ball : MonoBehaviour
{
    private string[] positive = {"It is Certain", "It is decidedly so", "Without a doubt", "Yes definitely", "You may rely on it", "As I see it, yes.", "Most likely", "Outlook good", "Yes", "Signs point to yes"};
    private string[] unclear = {"Reply hazy, try again", "Ask again later", "Better not tell you now", "Cannot predict now", "Concentrate and ask again"};
    private string[] negative = {"Don't count on it", "My reply is no", "My sources say no", "Outlook not so good", "Very doubtful"};
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
