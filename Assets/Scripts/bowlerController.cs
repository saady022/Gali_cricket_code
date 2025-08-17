using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowlerController : MonoBehaviour
{
    static public Animator myAnimator2;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator2 = GetComponent<Animator>();
      //  bowlerController.myAnimator2.SetBool("pitch", true);
        StartCoroutine(PlayAnimation());

    }
    IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(2f);
        bowlerController.myAnimator2.SetBool("pitch", true);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
