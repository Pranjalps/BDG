using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;


public class HintScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float waitTime=1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
    public void Hint()
    {
        text.enabled = true;
        StartCoroutine(Wait());
        text.enabled = false;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
    }
}
