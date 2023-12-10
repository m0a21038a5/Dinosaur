using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //移動速度
    [SerializeField]
    float MoveSpeed;
    //ティラノサウルス
    public GameObject Trex;
    //プテラノドン
    public GameObject Ptera;
    //トリケラトプス
    public GameObject Trikera;

    //恐竜の大きさ
    public bool Scale;
    public int ScaleCount;
    public int EatCount;

    private bool ScaleChange;

    //食べられるオブジェクト
    public GameObject EatObject;

    //トリケラトプスへ
    public bool ChangeTrikera;
    //プテラノドンへ
    public bool ChangePtera;
    //ティラノサウルスへ
    public bool BackToTRex;

    public bool Eating;
    //食べている時間
    public float EatTime;

    // Start is called before the first frame update
    void Start()
    {
        EatTime = 6.5f;
        Trex.SetActive(true);
        Ptera.SetActive(false);
        Trikera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Eating)
        {
            transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + MoveSpeed * Time.deltaTime);
        }
        //3回食べると大きくなる最大5回
        if(EatCount >= 3)
        {
            ScaleCount++;
            ScaleChange = true;
            EatCount = 0;
        }
        if(ScaleChange && ScaleCount <= 5)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x + 0.2f, this.transform.localScale.y + 0.2f, this.transform.localScale.z + 0.2f);
            ScaleChange = false;
        }
        
        if(ChangePtera)
        {
            StartCoroutine(ChangeToPtera());
        }

        if(ChangeTrikera)
        {
            Trex.SetActive(false);
            Trikera.SetActive(true);
            Ptera.SetActive(false);
            ChangeTrikera = false;
        }

        if(BackToTRex)
        {
            Trex.SetActive(true);
            Trikera.SetActive(false);
            Ptera.SetActive(false);
            BackToTRex = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //イノシシを食べた場合
        if(other.gameObject.CompareTag("Boar"))
        {
            Scale = true;
            EatCount++;
            EatObject = other.gameObject;
        }
        //トラを食べた場合
        if (other.gameObject.CompareTag("Tiger"))
        {
            Scale = true;
            EatCount++;
            MoveSpeed = MoveSpeed * 1.5f;
            EatObject = other.gameObject;
        }
        //岩にぶつかった場合
        if(other.gameObject.CompareTag("Rock"))
        {
            if (ScaleCount != 0 && Trex.activeSelf == true)
            {
                this.transform.localScale = new Vector3(this.transform.localScale.x - 0.2f, this.transform.localScale.y - 0.2f, this.transform.localScale.z - 0.2f);
                ScaleCount -= 1;
            }
            if(Trikera.activeSelf == true)
            {
                Scale = true;
                EatObject = other.gameObject;
            }
        }
        //フラミンゴを食べた場合
        if(other.gameObject.CompareTag("Flamingo"))
        {
            if (Trex.activeSelf == true)
            {
                EatCount++;
                Scale = true;
                EatObject = other.gameObject;
            }
        }
        //バッファローを食べた場合
        if(other.gameObject.CompareTag("Buffalo"))
        {
            if (Trex.activeSelf == true)
            {
                EatCount++;
                Scale = true;
                EatObject = other.gameObject;
            }
        }
    }

    /// <summary>
    /// プテラノドンへ変化するコルーチン
    /// </summary>
    /// <returns></returns>
    IEnumerator ChangeToPtera()
    {
        Trex.SetActive(false);
        Trikera.SetActive(false);
        Ptera.SetActive(true);
        ChangePtera = false;

        yield return new WaitForSecondsRealtime(14f);

        Trex.SetActive(true);
        Trikera.SetActive(false);
        Ptera.SetActive(false);
    }
}
