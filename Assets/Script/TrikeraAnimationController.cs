using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrikeraAnimationController : MonoBehaviour
{
    private Animator animator;
    private string AttackStr = "isAttacking";

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
        if (pc.Scale)
        {
            StartCoroutine(TrikeraAnimation());
        }
    }

    IEnumerator TrikeraAnimation()
    {
        this.animator.SetBool(AttackStr, true);
        pc.Eating = true;

        yield return new WaitForSecondsRealtime(1.5f);

        pc.Eating = false;
        Destroy(pc.EatObject);
        this.animator.SetBool(AttackStr, false);
        pc.Scale = false;
        pc.BackToTRex = true;
    }
}
