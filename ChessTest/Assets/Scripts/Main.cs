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
    


    public void ClickPositionStart(GameObject go)
    {

        ////c=0 peaobranco c=1 peaopreto c=2 cavalobranco ...
        int x = go.transform.GetSiblingIndex();
        if (go.layer==8)
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
            if (typeIncert > -2)
            {
                int l = go.transform.GetSiblingIndex();
                int c = go.transform.parent.GetSiblingIndex();
                switch (typeIncert)
                {
                    case -1:
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = null;
                        break;
                    case 0:
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = peaoBranco;
                        break;
                    case 1:
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = peaoPreto;
                        break;
                    case 2:
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = cavaloBranco;
                        break;
                    case 3:
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = cavaloPreto;
                        break;
                    case 4:
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = bispoBranco;
                        break;
                    case 5:
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = bispoPreto;
                        break;
                    case 6:
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = torreBranco;
                        break;
                    case 7:
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = torrePreto;
                        break;
                    case 8:
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = damaBranco;
                        break;
                    case 9:
                        LxC.transform.GetChild(c).transform.GetChild(l).gameObject.GetComponent<Image>().sprite = damaPreto;
                        break;
                    default:
                        break;
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
