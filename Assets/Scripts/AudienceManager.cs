using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceManager : MonoBehaviour
{
    public Animator audience1;
    public Animator audience2;
    public Animator audience3;

    public Animator audience4;
    public Animator audience5;

    public bool hit;
    // Start is called before the first frame update
    void Start()
    {
        audience1 = GameObject.Find("Audience1").GetComponent<Animator>();
        audience2 = GameObject.Find("Audience2").GetComponent<Animator>();
        audience3 = GameObject.Find("Audience3").GetComponent<Animator>();
        audience4 = GameObject.Find("Audience4").GetComponent<Animator>();
        audience5 = GameObject.Find("Audience5").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Dance());
    }

    IEnumerator Dance()
    {
        if (hit)
        {
            audience1.SetBool("Dance", true);
            audience2.SetBool("Dance", true);
            audience3.SetBool("Dance", true);
            audience4.SetBool("Dance", true);
            audience5.SetBool("Dance", true);

            yield return new WaitForSeconds(5);
            hit = false;
        }
        else
        {
            audience1.SetBool("Dance", false);
            audience2.SetBool("Dance", false);
            audience3.SetBool("Dance", false);
            audience4.SetBool("Dance", false);
            audience5.SetBool("Dance", false);
        }

    }
}
