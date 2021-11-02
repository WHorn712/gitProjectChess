using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainTela : MonoBehaviour
{
    

    [SerializeField]
    private GameObject lixeira;
    [SerializeField]
    private GameObject images;
    public int testePosicoesIndex;
    private int typeIncert;
    [SerializeField]
    private GameObject LxC;
    [SerializeField]
    private GameObject imageSelect;
    private int reiSelectLinha = 0;
    private int reiSelectColuna = 0;
    private int typeReiSelect = -1;

    [SerializeField]
    private Sprite peaoBranco;
    [SerializeField]
    private Sprite cavaloBranco;
    [SerializeField]
    private Sprite bispoBranco;
    [SerializeField]
    private Sprite torreBranco;
    [SerializeField]
    private Sprite damaBranco;
    [SerializeField]
    private Sprite reiBranco;
    [SerializeField]
    private Sprite peaoPreto;
    [SerializeField]
    private Sprite cavaloPreto;
    [SerializeField]
    private Sprite bispoPreto;
    [SerializeField]
    private Sprite torrePreto;
    [SerializeField]
    private Sprite damaPreto;
    [SerializeField]
    private Sprite reiPreto;

    List<int> peaoBrancoPosi = new List<int>();
    List<int> peaoPretoPosi = new List<int>();
    List<int> cavaloBrancoPosi = new List<int>();
    List<int> cavaloPretoPosi = new List<int>();
    List<int> bispoBrancoPosi = new List<int>();
    List<int> bispoPretoPosi = new List<int>();
    List<int> torreBrancoPosi = new List<int>();
    List<int> torrePretoPosi = new List<int>();
    List<int> damaBrancoPosi = new List<int>();
    List<int> damaPretoPosi = new List<int>();
    List<int> reiBrancoPosi = new List<int>();
    List<int> reiPretoPosi = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        typeIncert = -2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<int> PeaoBrancoPosi
    {
        get
        {
            return peaoBrancoPosi;
        }
    }
    public List<int> PeaoPretoPosi
    {
        get
        {
            return peaoPretoPosi;
        }
    }
    public List<int> CavaloBrancoPosi
    {
        get
        {
            return cavaloBrancoPosi;
        }
    }
    public List<int> CavaloPretoPosi
    {
        get
        {
            return cavaloPretoPosi;
        }
    }
    public List<int> BispoBrancoPosi
    {
        get
        {
            return bispoBrancoPosi;
        }
    }
    public List<int> BispoPretoPosi
    {
        get
        {
            return bispoPretoPosi;
        }
    }
    public List<int> TorreBrancoPosi
    {
        get
        {
            return torreBrancoPosi;
        }
    }
    public List<int> TorrePretoPosi
    {
        get
        {
            return torrePretoPosi;
        }
    }
    public List<int> DamaBrancoPosi
    {
        get
        {
            return damaBrancoPosi;
        }
    }
    public List<int> DamaPretoPosi
    {
        get
        {
            return damaPretoPosi;
        }
    }
    public List<int> ReiBrancoPosi
    {
        get
        {
            return reiBrancoPosi;
        }
    }
    public List<int> ReiPretoPosi
    {
        get
        {
            return reiPretoPosi;
        }
    }


    private void Desmark()
    {
        lixeira.GetComponent<Image>().color = new Color(0.16f, 0.01f, 0.01f, 1);
        for (int i = 0; i < images.transform.childCount; i++)
        {
            images.transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
    }

    public void ClickPositionStart(GameObject go)
    {

        ////c=0 peaobranco c=1 peaopreto c=2 cavalobranco ...
        int x = go.transform.GetSiblingIndex();
        if (typeIncert == -3)
        {
            if (go.layer == 10)
            {
                int l = go.transform.GetSiblingIndex();
                int c = go.transform.parent.GetSiblingIndex();
                LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                imageSelect.transform.GetChild(reiSelectColuna).transform.GetChild(reiSelectLinha).gameObject.SetActive(false);

                LxC.transform.GetChild(reiSelectColuna).transform.GetChild(reiSelectLinha).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                LxC.transform.GetChild(reiSelectColuna).transform.GetChild(reiSelectLinha).gameObject.GetComponent<Image>().sprite = null;
                LxC.transform.GetChild(reiSelectColuna).transform.GetChild(reiSelectLinha).gameObject.tag = "-1";
                if (typeReiSelect == 0)
                {
                    LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = reiBranco;
                    LxC.transform.GetChild(c).transform.GetChild(l).gameObject.tag = "10";
                }
                else
                {
                    LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = reiPreto;
                    LxC.transform.GetChild(c).transform.GetChild(l).gameObject.tag = "11";
                }
                typeIncert = -2;
            }
            else
            {
                imageSelect.transform.GetChild(reiSelectColuna).transform.GetChild(reiSelectLinha).gameObject.SetActive(false);
                typeIncert = -2;
            }
        }
        else if (go.layer == 8)
        {
            Desmark();
            lixeira.GetComponent<Image>().color = new Color(0.92f, 0.87f, 0.63f, 1);
            typeIncert = -1;
        }
        else if (go.layer == 9)
        {
            Desmark();
            images.transform.GetChild(x).gameObject.GetComponent<Image>().color = new Color(0.92f, 0.87f, 0.63f, 1);
            typeIncert = x;
        }
        else if (go.layer == 10)
        {
            int l = go.transform.GetSiblingIndex();
            int c = go.transform.parent.GetSiblingIndex();
            if (typeIncert > -2 && (LxC.transform.GetChild(c).transform.GetChild(l).gameObject.tag != "10" && LxC.transform.GetChild(c).transform.GetChild(l).gameObject.tag != "11"))
            {
                switch (typeIncert)
                {
                    case -1:
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = null;
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.tag = "-1";
                        break;
                    case 0:
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = peaoBranco;
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.tag = "0";
                        break;
                    case 1:
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = peaoPreto;
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.tag = "1";
                        break;
                    case 2:
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = cavaloBranco;
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.tag = "2";
                        break;
                    case 3:
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = cavaloPreto;
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.tag = "3";
                        break;
                    case 4:
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = bispoBranco;
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.tag = "4";
                        break;
                    case 5:
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = bispoPreto;
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.tag = "5";
                        break;
                    case 6:
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = torreBranco;
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.tag = "6";
                        break;
                    case 7:
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = torrePreto;
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.tag = "7";
                        break;
                    case 8:
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = damaBranco;
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.tag = "8";
                        break;
                    case 9:
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = damaPreto;
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.tag = "9";
                        break;
                    default:
                        break;
                }
            }
            else if (LxC.transform.GetChild(c).transform.GetChild(l).gameObject.tag == "10" || LxC.transform.GetChild(c).transform.GetChild(l).gameObject.tag == "11")
            {
                imageSelect.transform.GetChild(c).transform.GetChild(l).gameObject.SetActive(true);
                Desmark();
                typeIncert = -3;
                reiSelectLinha = l;
                reiSelectColuna = c;
                if (LxC.transform.GetChild(c).transform.GetChild(l).gameObject.tag == "10")
                {
                    typeReiSelect = 0;
                }
                else
                {
                    typeReiSelect = 1;
                }
            }
        }
    }

    private void CountingPecas(string tag, int lin, int col)
    {
        int b = 0;
        int.TryParse(tag, out b);
        switch (b)
        {
            case 0:
                peaoBrancoPosi.Add(lin);
                peaoBrancoPosi.Add(col);
                break;
            case 1:
                peaoPretoPosi.Add(lin);
                peaoPretoPosi.Add(col);
                break;
            case 2:
                cavaloBrancoPosi.Add(lin);
                cavaloBrancoPosi.Add(col);
                break;
            case 3:
                cavaloPretoPosi.Add(lin);
                cavaloPretoPosi.Add(col);
                break;
            case 4:
                bispoBrancoPosi.Add(lin);
                bispoBrancoPosi.Add(col);
                break;
            case 5:
                bispoPretoPosi.Add(lin);
                bispoPretoPosi.Add(col);
                break;
            case 6:
                torreBrancoPosi.Add(lin);
                torreBrancoPosi.Add(col);
                break;
            case 7:
                torrePretoPosi.Add(lin);
                torrePretoPosi.Add(col);
                break;
            case 8:
                damaBrancoPosi.Add(lin);
                damaBrancoPosi.Add(col);
                break;
            case 9:
                damaPretoPosi.Add(lin);
                damaPretoPosi.Add(col);
                break;
            case 10:
                reiBrancoPosi.Add(lin);
                reiBrancoPosi.Add(col);
                break;
            case 11:
                reiPretoPosi.Add(lin);
                reiPretoPosi.Add(col);
                break;
            default:
                break;
        }
    }

    private void ClearPosi()
    {
        peaoBrancoPosi.Clear();
        peaoPretoPosi.Clear();
        cavaloBrancoPosi.Clear();
        cavaloPretoPosi.Clear();
        bispoBrancoPosi.Clear();
        bispoPretoPosi.Clear();
        torreBrancoPosi.Clear();
        torrePretoPosi.Clear();
        damaBrancoPosi.Clear();
        damaPretoPosi.Clear();
        reiBrancoPosi.Clear();
        reiPretoPosi.Clear();
    }

    private List<int> GetListPosicoes(int a)
    {
        switch (a)
        {
            case 0:
                return peaoBrancoPosi;
            case 1:
                return peaoPretoPosi;
            case 2:
                return cavaloBrancoPosi;
            case 3:
                return cavaloPretoPosi;
            case 4:
                return bispoBrancoPosi;
            case 5:
                return bispoPretoPosi;
            case 6:
                return torreBrancoPosi;
            case 7:
                return torrePretoPosi;
            case 8:
                return damaBrancoPosi;
            case 9:
                return damaPretoPosi;
            case 10:
                return reiBrancoPosi;
            case 11:
                return reiPretoPosi;
            default:
                return null;
        }
    }

    public void ClickStart()
    {
        ClearPosi();
        for (int i = 0; i < LxC.transform.childCount; i++)
        {
            for (int c = 0; c < LxC.transform.GetChild(i).transform.childCount; c++)
            {
                int x = 0;
                int.TryParse(LxC.transform.GetChild(i).transform.GetChild(c).gameObject.tag, out x);
                if (x >= 0)
                {
                    CountingPecas(LxC.transform.GetChild(i).transform.GetChild(c).gameObject.tag, c, i);
                }
            }
        }
        SavePositions.SavePos(this);
        SceneManager.LoadScene(1);
    }
}
