using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrexAnimationController : MonoBehaviour
{
    private Animator animator;
    private string EatStr = "isEat";

    [SerializeField]
    PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        pc = transform.root.gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pc.Scale)
        {
            StartCoroutine(TrexAnimation());
        }
    }

    IEnumerator TrexAnimation()
    {
        this.animator.SetBool(EatStr, true);
        pc.Eating = true;

        yield return new WaitForSecondsRealtime(pc.EatTime);

        pc.Eating = false;
        Destroy(pc.EatObject);
        this.animator.SetBool(EatStr, false);
        pc.Scale = false;
        if(pc.EatObject.CompareTag("Buffalo"))
        {
            pc.ChangeTrikera = true;
        }
        if(pc.EatObject.CompareTag("Flamingo"))
        {
            pc.ChangePtera = true;
        }
        if (pc.EatObject.CompareTag("Tiger"))
        {
            pc.EatTime = pc.EatTime * 1.05f;
        }
    }
}
