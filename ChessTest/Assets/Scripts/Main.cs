using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    private int linOr;
    private int colOr;
    private int linDes;
    private int colDes;

    private bool isSelect;

    private List<GameObject> Pecas = new List<GameObject>();
    private List<GameObject> Posicoes = new List<GameObject>();
    
    


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

    Dictionary<int,List<int>> d = new System.Collections.Generic.Dictionary<int,List<int>>();

    PosicaoPeca p;

    private int index = 0;
    private int cor = 0;
    private int linhaPeao = 0;
    private int colunaPeao = 0;
    [SerializeField]
    private GameObject imageTelaPromotion;

    // Start is called before the first frame update
    void Start()
    {
        ClearTabuleiro();
        IniateDictionary();
        StartPositionTab();
        jogadas = "";
        isRoque = false;
        count = 0;
        vez = 0;
        isSelect = false;
        
        tab = new Tabuleiro(p);
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

    private void StartPositionTab()
    {
        AnalizePosPeca();
    }

    private void AnalizePosPeca()
    {
        for(int i=0;i<12;i++)
        {
            List<int> x;
            d.TryGetValue(i,out x);
            if (x.Count % 2 == 0)
            {
                for (int c = 0; c < x.Count; c+=2)
                {
                    int lin = x[c];
                    int col = x[c + 1];
                    PutPecainPosi(i,lin,col);
                }
            }
            else
            {
                Debug.Log("TEM ALGO ERRADO MAIN L:146");
            }
        }
    }

    private void PutPecainPosi(int t,int lin,int col)
    {
        switch(t)
        {
            case 0:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = peaoBranco;
                break;
            case 1:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = peaoPreto;
                break;
            case 2:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = cavaloBranco;
                break;
            case 3:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = cavaloPreto;
                break;
            case 4:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = bispoBranco;
                break;
            case 5:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = bispoPreto;
                break;
            case 6:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = torreBranco;
                break;
            case 7:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = torrePreto;
                break;
            case 8:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = damaBranco;
                break;
            case 9:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = damaPreto;
                break;
            case 10:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = reiBranco;
                break;
            case 11:
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LxC.transform.GetChild(col).transform.GetChild(lin).gameObject.GetComponent<Image>().sprite = reiPreto;
                break;
            default:
                break;
        }
    }
   

    private void ClearTabuleiro()
    {
        for(int i=0;i<LxC.transform.childCount;i++)
        {
            for(int c=0;c<LxC.transform.GetChild(i).transform.childCount;c++)
            {
                LxC.transform.GetChild(i).transform.GetChild(c).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                LxC.transform.GetChild(i).transform.GetChild(c).gameObject.GetComponent<Image>().sprite = null;
            }
        }
    }

    

    

    


    private void ChangeImagePeao(int type)
    {
        if(cor==0)
        {
            switch(type)
            {
                case 0:
                    LxC.transform.GetChild(colunaPeao).transform.GetChild(linhaPeao).GetComponent<Image>().sprite = damaBranco;
                    break;
                case 1:
                    LxC.transform.GetChild(colunaPeao).transform.GetChild(linhaPeao).GetComponent<Image>().sprite = torreBranco;
                    break;
                case 2:
                    LxC.transform.GetChild(colunaPeao).transform.GetChild(linhaPeao).GetComponent<Image>().sprite = bispoBranco;
                    break;
                case 3:
                    LxC.transform.GetChild(colunaPeao).transform.GetChild(linhaPeao).GetComponent<Image>().sprite = cavaloBranco;
                    break;
            }
        }
        else
        {
            switch (type)
            {
                case 0:
                    LxC.transform.GetChild(colunaPeao).transform.GetChild(linhaPeao).GetComponent<Image>().sprite = damaPreto;
                    break;
                case 1:
                    LxC.transform.GetChild(colunaPeao).transform.GetChild(linhaPeao).GetComponent<Image>().sprite = torrePreto;
                    break;
                case 2:
                    LxC.transform.GetChild(colunaPeao).transform.GetChild(linhaPeao).GetComponent<Image>().sprite = bispoPreto;
                    break;
                case 3:
                    LxC.transform.GetChild(colunaPeao).transform.GetChild(linhaPeao).GetComponent<Image>().sprite = cavaloPreto;
                    break;
            }
        }
    }
    public void ClickPromotion(int type)
    {
        tab.Promotion(index, cor, linhaPeao, colunaPeao, type);
        ChangeImagePeao(type);
        if (cor==0)
        {
            if (tab.getReiPreto().isCheck(tab))
            {
                if (tab.isCheckMateReiEndGame(cor))
                {
                    Debug.Log("CHECK MATE. BRANCO VENCEU");
                    tab.IsEnd = true;
                }
            }
        }
        else
        {
            if (tab.getReiBranco().isCheck(tab))
            {
                if (tab.isCheckMateReiEndGame(cor))
                {
                    Debug.Log("CHECK MATE. PRETO VENCEU");
                    tab.IsEnd = true;
                }
            }
        }
        if(tab.isAfogamento(cor))
        {
            Debug.Log("EMPATE POR AFOGAMENTO");
            tab.IsEnd = true;
        }
    }
    private void PromotionPeao(int c)
    {
        if(c==0)
        {
            for(int i=0;i<tab.getPb().Count;i++)
            {
                if(tab.getPb()[i].Linha()==7)
                {
                    cor = 0;
                    index = i;
                    imageTelaPromotion.SetActive(true);
                    linhaPeao = 7;
                    colunaPeao = tab.getPb()[i].Coluna();
                    ChangeImagePromotion(damaBranco,torreBranco,bispoBranco,cavaloBranco);
                }
            }
        }
        else
        {
            for (int i = 0; i < tab.getPb().Count; i++)
            {
                if (tab.getPb()[i].Linha() == 7)
                {
                    cor = 1;
                    index = i;
                    imageTelaPromotion.SetActive(true);
                    linhaPeao = 0;
                    colunaPeao = tab.getPp()[i].Coluna();
                    ChangeImagePromotion(damaPreto, torrePreto, bispoPreto, cavaloPreto);
                }
            }
        }
    }
    private void ChangeImagePromotion(Sprite d,Sprite t,Sprite b,Sprite c)
    {
        imageTelaPromotion.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = d;
        imageTelaPromotion.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = t;
        imageTelaPromotion.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = b;
        imageTelaPromotion.transform.GetChild(4).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = c;
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
                PromotionPeao(c);
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
