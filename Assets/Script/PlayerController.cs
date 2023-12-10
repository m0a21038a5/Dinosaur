using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�ړ����x
    [SerializeField]
    float MoveSpeed;
    //�e�B���m�T�E���X
    public GameObject Trex;
    //�v�e���m�h��
    public GameObject Ptera;
    //�g���P���g�v�X
    public GameObject Trikera;

    //�����̑傫��
    public bool Scale;
    public int ScaleCount;
    public int EatCount;

    private bool ScaleChange;

    //�H�ׂ���I�u�W�F�N�g
    public GameObject EatObject;

    //�g���P���g�v�X��
    public bool ChangeTrikera;
    //�v�e���m�h����
    public bool ChangePtera;
    //�e�B���m�T�E���X��
    public bool BackToTRex;

    public bool Eating;
    //�H�ׂĂ��鎞��
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
        //3��H�ׂ�Ƒ傫���Ȃ�ő�5��
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
        //�C�m�V�V��H�ׂ��ꍇ
        if(other.gameObject.CompareTag("Boar"))
        {
            Scale = true;
            EatCount++;
            EatObject = other.gameObject;
        }
        //�g����H�ׂ��ꍇ
        if (other.gameObject.CompareTag("Tiger"))
        {
            Scale = true;
            EatCount++;
            MoveSpeed = MoveSpeed * 1.5f;
            EatObject = other.gameObject;
        }
        //��ɂԂ������ꍇ
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
        //�t���~���S��H�ׂ��ꍇ
        if(other.gameObject.CompareTag("Flamingo"))
        {
            if (Trex.activeSelf == true)
            {
                EatCount++;
                Scale = true;
                EatObject = other.gameObject;
            }
        }
        //�o�b�t�@���[��H�ׂ��ꍇ
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
    /// �v�e���m�h���֕ω�����R���[�`��
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
