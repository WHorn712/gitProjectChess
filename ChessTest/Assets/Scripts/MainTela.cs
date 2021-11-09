using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainTela : MonoBehaviour
{
    Tabuleiro tab = new Tabuleiro();

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

    Dictionary<int, List<int>> d = new System.Collections.Generic.Dictionary<int, List<int>>();
    PosicaoPeca p;
    // Start is called before the first frame update
    void Start()
    {
        typeIncert = -2;
        if(SavePositions.isExist())
        {
            ClearTabuleiro();
            IniateDictionary();
            StartPositionTab();
        }
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


    private void ClearTabuleiro()
    {
        for (int i = 0; i < LxC.transform.childCount; i++)
        {
            for (int c = 0; c < LxC.transform.GetChild(i).transform.childCount; c++)
            {
                LxC.transform.GetChild(i).transform.GetChild(c).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                LxC.transform.GetChild(i).transform.GetChild(c).gameObject.GetComponent<Image>().sprite = null;
                LxC.transform.GetChild(i).transform.GetChild(c).gameObject.tag = "-1";
            }
        }
    }

    private void IniateDictionary()
    {
        p = SavePositions.LoadPos();
        peaoBrancoPosi = p.PeaoBrancoPosi;
        peaoPretoPosi = p.PeaoPretoPosi;
        cavaloBrancoPosi = p.CavaloBrancoPosi;
        cavaloPretoPosi = p.CavaloPretoPosi;
        bispoBrancoPosi = p.BispoBrancoPosi;
        bispoPretoPosi = p.BispoPretoPosi;
        torreBrancoPosi = p.TorreBrancoPosi;
        torrePretoPosi = p.TorrePretoPosi;
        damaBrancoPosi = p.DamaBrancoPosi;
        damaPretoPosi = p.DamaPretoPosi;
        reiBrancoPosi = p.ReiBrancoPosi;
        reiPretoPosi = p.ReiPretoPosi;
        d.Add(0, peaoBrancoPosi);
        d.Add(1, peaoPretoPosi);
        d.Add(2, cavaloBrancoPosi);
        d.Add(3, cavaloPretoPosi);
        d.Add(4, bispoBrancoPosi);
        d.Add(5, bispoPretoPosi);
        d.Add(6, torreBrancoPosi);
        d.Add(7, torrePretoPosi);
        d.Add(8, damaBrancoPosi);
        d.Add(9, damaPretoPosi);
        d.Add(10, reiBrancoPosi);
        d.Add(11, reiPretoPosi);
    }

    private void PutPecainPosi(int t, int lin, int col)
    {
        switch (t)
        {
            case 0:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = peaoBranco;
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.tag = "0";
                break;
            case 1:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = peaoPreto;
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.tag = "1";
                break;
            case 2:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = cavaloBranco;
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.tag = "2";
                break;
            case 3:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = cavaloPreto;
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.tag = "3";
                break;
            case 4:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = bispoBranco;
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.tag = "4";
                break;
            case 5:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = bispoPreto;
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.tag = "5";
                break;
            case 6:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = torreBranco;
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.tag = "6";
                break;
            case 7:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = torrePreto;
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.tag = "7";
                break;
            case 8:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = damaBranco;
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.tag = "8";
                break;
            case 9:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = damaPreto;
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.tag = "9";
                break;
            case 10:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = reiBranco;
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.tag = "10";
                break;
            case 11:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = reiPreto;
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.tag = "11";
                break;
            default:
                break;
        }
    }

    private void AnalizePosPeca()
    {
        for (int i = 0; i < 12; i++)
        {
            List<int> x;
            d.TryGetValue(i, out x);
            if (x.Count % 2 == 0)
            {
                for (int c = 0; c < x.Count; c += 2)
                {
                    int lin = x[c];
                    int col = x[c + 1];
                    PutPecainPosi(i, lin, col);
                }
            }
            else
            {
                Debug.Log("TEM ALGO ERRADO MAIN L:146");
            }
        }
    }

    private void StartPositionTab()
    {
        AnalizePosPeca();
    }



    public void ClickPadrao()
    {
        ClearTabuleiro();
        PutPecainPosi(6,0,0);
        PutPecainPosi(2, 0, 1);
        PutPecainPosi(4, 0, 2);
        PutPecainPosi(8, 0, 3);
        PutPecainPosi(10, 0, 4);
        PutPecainPosi(4, 0, 5);
        PutPecainPosi(2, 0, 6);
        PutPecainPosi(6, 0, 7);
        PutPecainPosi(7, 7, 0);
        PutPecainPosi(3, 7, 1);
        PutPecainPosi(5, 7, 2);
        PutPecainPosi(9, 7, 3);
        PutPecainPosi(11, 7, 4);
        PutPecainPosi(5, 7, 5);
        PutPecainPosi(3, 7, 6);
        PutPecainPosi(7, 7, 7);
        for(int i=0;i<8;i++)
        {
            PutPecainPosi(0,1,i);
        }
        for (int i = 0; i < 8; i++)
        {
            PutPecainPosi(1, 6, i);
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
                bool ok = true;
                if (typeIncert != -1)
                {
                    ok = true;
                }
                //else
                //{
                //    ok = tab.MovePecaMainTela(typeIncert,l,c,tab);
                //}
                if (ok)
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
                else
                {
                    Debug.Log("ERROR ADAPTE TABULEIRO: REIS ENCOSTANDO OU CHECK MATE INDEVIDO");
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
