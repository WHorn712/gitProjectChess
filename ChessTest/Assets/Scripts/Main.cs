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

    private int count;
    private int vez;

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

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        vez = 0;
        isSelect = false;
        tab = new Tabuleiro();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        Debug.Log("ok");
    }
    void OnMouseUpAsButton()
    {
        Debug.Log("ok2");
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
                ToMakeLance(linOr, colOr, linDes, colDes);
                if(c==0)
                {
                    if(tab.getReiPreto().isCheck(tab))
                    {
                        
                    }
                }
                else if(c==1)
                {
                    if(tab.getReiBranco().isCheck(tab))
                    {

                    }
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
                    ChangeImagePos(a, LxC.transform.GetChild(i).transform.GetChild(c).gameObject);
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
