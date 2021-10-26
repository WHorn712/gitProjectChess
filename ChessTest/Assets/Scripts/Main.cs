using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    private int linOr;
    private int colOr;
    private int linDes;
    private int colDes;

    private bool isSelect;

    private List<GameObject> Pecas = new List<GameObject>();
    private List<GameObject> Posicoes = new List<GameObject>();
    [SerializeField]
    private GameObject lixeira;
    [SerializeField]
    private GameObject images;
    private int typeIncert;
    private int reiSelectLinha=0;
    private int reiSelectColuna = 0;
    private int typeReiSelect = -1;
    Dictionary<int, int> pecasTab = new Dictionary<int, int>();
    Dictionary<string, int> posicaoPecasTab = new Dictionary<string, int>();
    

    private int count;
    private int vez;

    private bool isRoque;

    private Tabuleiro tab;

    
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

    [SerializeField]
    private GameObject LxC;
    [SerializeField]
    private GameObject imageSelect;

    private string jogadas;

    // Start is called before the first frame update
    void Start()
    {
        jogadas = "";
        isRoque = false;
        count = 0;
        vez = 0;
        isSelect = false;
        typeIncert = -2;
        
        tab = new Tabuleiro();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            tab.Imprex();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log(jogadas);
        }
    }
    void OnMouseDown()
    {
        Debug.Log("ok");
    }
    void OnMouseUpAsButton()
    {
        Debug.Log("ok2");
    }

    public void ClickStart()
    {
        for(int i=0;i<LxC.transform.childCount;i++)
        {
            for(int c=0;c<LxC.transform.GetChild(i).transform.childCount;c++)
            {
                int x = 0;
                int.TryParse(LxC.transform.GetChild(i).transform.GetChild(c).gameObject.tag,out x);
                if (x>=0)
                {
                    CountingPecas(LxC.transform.GetChild(i).transform.GetChild(c).gameObject.tag, pecasTab, c, i);
                }
            }
        }
        
    }

    private void CountingPecas(string tag,Dictionary<int,int> d,int lin,int col)
    {
        int c = 0;
        int b = 0;
        int.TryParse(tag,out b);
        int a = 0;
        int i = 0;
        switch(b)
        {
            case 0:
                d.TryGetValue(0,out a);
                a++;
                c = a;
                d.Remove(0);
                d.Add(0,c);
                i = a - 1;
                posicaoPecasTab.Add("0"+i+"1",lin);
                posicaoPecasTab.Add("0" + i + "2", col);
                break;
            case 1:
                d.TryGetValue(1, out a);
                a++;
                c = a;
                d.Remove(1);
                d.Add(1, c);
                i = a - 1;
                posicaoPecasTab.Add("1" + i + "1", lin);
                posicaoPecasTab.Add("1" + i + "2", col);
                break;
            case 2:
                d.TryGetValue(2, out a);
                a++;
                c = a;
                d.Remove(2);
                d.Add(2, c);
                i = a - 1;
                posicaoPecasTab.Add("2" + i + "1", lin);
                posicaoPecasTab.Add("2" + i + "2", col);
                break;
            case 3:
                d.TryGetValue(3, out a);
                a++;
                c = a;
                d.Remove(3);
                d.Add(3, c);
                i = a - 1;
                posicaoPecasTab.Add("3" + i + "1", lin);
                posicaoPecasTab.Add("3" + i + "2", col);
                break;
            case 4:
                d.TryGetValue(4, out a);
                a++;
                c = a;
                d.Remove(4);
                d.Add(4, c);
                i = a - 1;
                posicaoPecasTab.Add("4" + i + "1", lin);
                posicaoPecasTab.Add("4" + i + "2", col);
                break;
            case 5:
                d.TryGetValue(5, out a);
                a++;
                c = a;
                d.Remove(5);
                d.Add(5, c);
                i = a - 1;
                posicaoPecasTab.Add("5" + i + "1", lin);
                posicaoPecasTab.Add("5" + i + "2", col);
                break;
            case 6:
                d.TryGetValue(6, out a);
                a++;
                c = a;
                d.Remove(6);
                d.Add(6, c);
                i = a - 1;
                posicaoPecasTab.Add("6" + i + "1", lin);
                posicaoPecasTab.Add("6" + i + "2", col);
                break;
            case 7:
                d.TryGetValue(7, out a);
                a++;
                c = a;
                d.Remove(7);
                d.Add(7, c);
                i = a - 1;
                posicaoPecasTab.Add("7" + i + "1", lin);
                posicaoPecasTab.Add("7" + i + "2", col);
                break;
            case 8:
                d.TryGetValue(8, out a);
                a++;
                c = a;
                d.Remove(8);
                d.Add(8, c);
                i = a - 1;
                posicaoPecasTab.Add("8" + i + "1", lin);
                posicaoPecasTab.Add("8" + i + "2", col);
                break;
            case 9:
                d.TryGetValue(9, out a);
                a++;
                c = a;
                d.Remove(9);
                d.Add(9, c);
                i = a - 1;
                posicaoPecasTab.Add("9" + i + "1", lin);
                posicaoPecasTab.Add("9" + i + "2", col);
                break;
            case 10:
                posicaoPecasTab.Add("10" + "0" + "1", lin);
                posicaoPecasTab.Add("10" + "0" + "2", col);
                break;
            case 11:
                posicaoPecasTab.Add("11" + "0" + "1", lin);
                posicaoPecasTab.Add("11" + "0" + "2", col);
                break;
            default:
                break;
        }
    }


    public void ClickPositionStart(GameObject go)
    {

        ////c=0 peaobranco c=1 peaopreto c=2 cavalobranco ...
        int x = go.transform.GetSiblingIndex();
        if(typeIncert==-3)
        {
            if(go.layer==10)
            { 
            int l = go.transform.GetSiblingIndex();
            int c = go.transform.parent.GetSiblingIndex();
            LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().color = new Color(1,1,1,1);
            imageSelect.transform.GetChild(reiSelectColuna).transform.GetChild(reiSelectLinha).gameObject.SetActive(false);

            LxC.transform.GetChild(reiSelectColuna).transform.GetChild(reiSelectLinha).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            LxC.transform.GetChild(reiSelectColuna).transform.GetChild(reiSelectLinha).gameObject.GetComponent<Image>().sprite = null;
            LxC.transform.GetChild(reiSelectColuna).transform.GetChild(reiSelectLinha).gameObject.tag = "-1";
            if (typeReiSelect==0)
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
        else if (go.layer==8)
        {
            Desmark();
            lixeira.GetComponent<Image>().color = new Color(0.92f, 0.87f, 0.63f, 1);
            typeIncert = -1;
        }
        else if(go.layer==9)
        {
            Desmark();
            images.transform.GetChild(x).gameObject.GetComponent<Image>().color = new Color(0.92f,0.87f,0.63f,1);
            typeIncert = x;
        }
        else if(go.layer==10)
        {
            int l = go.transform.GetSiblingIndex();
            int c = go.transform.parent.GetSiblingIndex();
            if (typeIncert > -2 && (LxC.transform.GetChild(c).transform.GetChild(l).gameObject.tag != "10" && LxC.transform.GetChild(c).transform.GetChild(l).gameObject.tag != "11"))
            {
                switch (typeIncert)
                {
                    case -1:
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().color = new Color(1,1,1,0);
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
            else if(LxC.transform.GetChild(c).transform.GetChild(l).gameObject.tag == "10" || LxC.transform.GetChild(c).transform.GetChild(l).gameObject.tag == "11")
            {
                imageSelect.transform.GetChild(c).transform.GetChild(l).gameObject.SetActive(true);
                Desmark();
                typeIncert = -3;
                reiSelectLinha = l;
                reiSelectColuna = c;
                if(LxC.transform.GetChild(c).transform.GetChild(l).gameObject.tag == "10")
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

    private void Desmark()
    {
        lixeira.GetComponent<Image>().color = new Color(0.16f,0.01f,0.01f,1);
        for(int i=0;i<images.transform.childCount;i++)
        {
            images.transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color(1,1,1,1);
        }
    }


    public void ClickPosition(GameObject go)
    {
        int a = go.transform.GetSiblingIndex();
        int b = go.transform.parent.GetSiblingIndex();
        int c = vez; 
        
        if (isSelect)
        {
            isSelect = false;
            linDes = a;
            colDes = b;
            imageSelect.transform.GetChild(colOr).transform.GetChild(linOr).gameObject.SetActive(false);
            bool ab = tab.isMove(linOr, colOr, vez, linDes, colDes);
            
            if (ab)
            {
                Debug.Log(linOr+"."+colOr+"  /  "+linDes+"."+colDes);
                jogadas += linOr + "." + colOr + "." + linDes + "." + colDes + " / ";
                ToMakeLance(linOr, colOr, linDes, colDes);
                if(c==0)
                {
                    if(tab.getReiPreto().isCheck(tab))
                    {
                        if(tab.isCheckMateReiEndGame(c))
                        {
                            Debug.Log("CHECK MATE. BRANCO VENCEU");
                            tab.IsEnd = true;
                        }
                    }
                }
                else if(c==1)
                {
                    if(tab.getReiBranco().isCheck(tab))
                    {
                        if (tab.isCheckMateReiEndGame(c))
                        {
                            Debug.Log("CHECK MATE. PRETO VENCEU");
                            tab.IsEnd = true;
                        }
                    }
                }
                if(tab.isAfogamento(c))
                {
                    Debug.Log("EMPATE POR AFOGAMENTO");
                    tab.IsEnd = true;
                }
            }
        }
        else
        {
            if(go.GetComponent<Image>().color.a==1)
            {
                isSelect = true;
                linOr = a;
                colOr = b;
                imageSelect.transform.GetChild(b).transform.GetChild(a).gameObject.SetActive(true);
            }
        }
    }

    private void ToMakeLance(int lo,int co,int ld, int cd)
    {
        int b = vez;
        int a = tab.getPositionPecaId(ld,cd);
        if((lo==0&&ld==0&&co==4&&(cd==6||cd==2))||(lo==7&&ld==7&&co==4&&(cd==6||cd==2)))
        {
            isRoque = true;
        }
        bool ok = false;
        if (tab.EnPassant)
        {
            ok = true;
            tab.EnPassant = false;
        }
        for (int i=0;i<LxC.transform.childCount;i++)
        {
            for(int c=0;c<LxC.transform.GetChild(i).transform.childCount;c++)
            {
                if(i==cd && c==ld)
                {
                    if (isRoque)
                    {
                        isRoque = false;
                        ChangeImagePosRoque(cd,co);
                    }
                    else
                    {
                        ChangeImagePos(a, LxC.transform.GetChild(i).transform.GetChild(c).gameObject);
                    }
                }
                if(i==co && c==lo)
                {
                    LxC.transform.GetChild(i).transform.GetChild(c).GetComponent<Image>().color = new Color(1,1,1,0);
                }
                if(ok && ((b==0 && c==ld-1 && i==cd)||(b==1 && c==ld+1 &&i==cd)))
                {
                    LxC.transform.GetChild(i).transform.GetChild(c).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
            }
        }
    }

    private void ChangeImagePosRoque(int cd,int co)
    {
        if(vez==0)
        {
            if(cd>co)
            {
                LxC.transform.GetChild(4).transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                LxC.transform.GetChild(7).transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                LxC.transform.GetChild(6).transform.GetChild(0).GetComponent<Image>().sprite = reiBranco;
                LxC.transform.GetChild(6).transform.GetChild(0).GetComponent<Image>().color = new Color(1,1,1,1);
                LxC.transform.GetChild(5).transform.GetChild(0).GetComponent<Image>().sprite = torreBranco;
                LxC.transform.GetChild(5).transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
            else
            {
                LxC.transform.GetChild(4).transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                LxC.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                LxC.transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = reiBranco;
                LxC.transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().sprite = torreBranco;
                LxC.transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
        else
        {
            if (cd > co)
            {
                LxC.transform.GetChild(4).transform.GetChild(7).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                LxC.transform.GetChild(7).transform.GetChild(7).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                LxC.transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().sprite = reiPreto;
                LxC.transform.GetChild(6).transform.GetChild(7).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(5).transform.GetChild(7).GetComponent<Image>().sprite = torrePreto;
                LxC.transform.GetChild(5).transform.GetChild(7).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
            else
            {
                LxC.transform.GetChild(4).transform.GetChild(7).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                LxC.transform.GetChild(0).transform.GetChild(7).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                LxC.transform.GetChild(2).transform.GetChild(7).GetComponent<Image>().sprite = reiPreto;
                LxC.transform.GetChild(2).transform.GetChild(7).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(3).transform.GetChild(7).GetComponent<Image>().sprite = torrePreto;
                LxC.transform.GetChild(3).transform.GetChild(7).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
        count++;
        if (count % 2 == 0)
        {
            vez = 0;
        }
        else
        {
            vez = 1;
        }
    }

    private void ChangeImagePos(int a,GameObject go)
    {
        switch(a)
        {
            case 0:
                go.GetComponent<Image>().sprite = peaoBranco;
                go.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                break;
            case 1:
                go.GetComponent<Image>().sprite = peaoPreto;
                go.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                break;
            case 2:
                go.GetComponent<Image>().sprite = cavaloBranco;
                go.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                break;
            case 3:
                go.GetComponent<Image>().sprite = cavaloPreto;
                go.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                break;
            case 4:
                go.GetComponent<Image>().sprite = bispoBranco;
                go.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                break;
            case 5:
                go.GetComponent<Image>().sprite = bispoPreto;
                go.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                break;
            case 6:
                go.GetComponent<Image>().sprite = torreBranco;
                go.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                break;
            case 7:
                go.GetComponent<Image>().sprite = torrePreto;
                go.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                break;
            case 8:
                go.GetComponent<Image>().sprite = damaBranco;
                go.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                break;
            case 9:
                go.GetComponent<Image>().sprite = damaPreto;
                go.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                break;
            case 10:
                go.GetComponent<Image>().sprite = reiBranco;
                go.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                if(isRoque)
                {

                }
                break;
            case 11:
                go.GetComponent<Image>().sprite = reiPreto;
                go.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                break;
            default:
                break;
        }
        count++;
        if(count % 2 == 0)
        {
            vez = 0;
        }
        else
        {
            vez = 1;
        }
    }

    


}
