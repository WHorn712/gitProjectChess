using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PosicaoPeca
{
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

    public PosicaoPeca(MainTela m)
    {
        peaoBrancoPosi = m.PeaoBrancoPosi;
        peaoPretoPosi = m.PeaoPretoPosi;
        cavaloBrancoPosi = m.CavaloBrancoPosi;
        cavaloPretoPosi = m.CavaloPretoPosi;
        bispoBrancoPosi = m.BispoBrancoPosi;
        bispoPretoPosi = m.BispoPretoPosi;
        torreBrancoPosi = m.TorreBrancoPosi;
        torrePretoPosi = m.TorrePretoPosi;
        damaBrancoPosi = m.DamaBrancoPosi;
        damaPretoPosi = m.DamaPretoPosi;
        reiBrancoPosi = m.ReiBrancoPosi;
        reiPretoPosi = m.ReiPretoPosi;
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
}
