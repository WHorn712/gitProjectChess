using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peca
{
    private int linha;
    private int coluna;
    //0==peao 1==cavalo 2==bispo 3==torre 4==dama
    private int type;
    private int cor;

    private List<int> lisLin = new List<int>();
    private List<int> lisCol = new List<int>();

    private int peaoType;

    public Peca(int lin,int col,int ty,int c)
    {
        peaoType = 0;
        linha = lin;
        coluna = col;
        type = ty;
        cor = c;
    }
    public int Linha
    {
        get
        {
            return linha;
        }
        set
        {
            linha = value;
        }
    }
    public int Coluna
    {
        get
        {
            return coluna;
        }
        set
        {
            coluna = value;
        }
    }
    public int Type
    {
        get
        {
            return type;
        }
        set
        {
            type = value;
        }
    }
    public int Cor
    {
        get
        {
            return cor;
        }
        set
        {
            cor = value;
        }
    }

    public bool PutToFace(Rei rei,Tabuleiro tab)
    {
        if(DefinindoCaminho(rei,tab))
        {
            if(cor==0)
            {
                for (int i = 0; i < lisLin.Count; i++)
                {
                    linha = lisLin[i];
                    coluna = lisCol[i];
                    peaoType = 1;
                    if (AnalizeTypePeca(tab.getPp(), tab.getCp(), tab.getBp(), tab.getTp(), tab.getDp(), tab))
                    {
                        return true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < lisCol.Count; i++)
                {
                    linha = lisLin[i];
                    coluna = lisCol[i];
                    peaoType = 1;
                    if (AnalizeTypePeca(tab.getPb(), tab.getCb(), tab.getBb(), tab.getTb(), tab.getDb(), tab))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    private bool DefinindoCaminho(Rei rei,Tabuleiro tab)
    {
        if (cor == 0)
        {
            if (type == 2)
            {
                for (int i = 0; i < tab.getBb().Count;i++)
                {
                    if(AnalizeBispo(rei,tab.getBb(),i,tab))
                    {
                        return true;
                    }
                }
            }
            else if(type==3)
            {
                for(int i=0;i<tab.getTb().Count;i++)
                {
                    if(AnalizeTorre(rei,tab.getTb(),i,tab))
                    {
                        return true;
                    }
                }
            }
            else if(type==4)
            {
                for (int i = 0; i < tab.getDb().Count; i++)
                {
                    if (AnalizeDama(rei, tab.getDb(), i, tab))
                    {
                        return true;
                    }
                }
            }
        }
        else
        {
            if (type == 2)
            {
                for (int i = 0; i < tab.getBp().Count; i++)
                {
                    if (AnalizeBispo(rei, tab.getBp(), i, tab))
                    {
                        return true;
                    }
                }
            }
            else if (type == 3)
            {
                for (int i = 0; i < tab.getTp().Count; i++)
                {
                    if (AnalizeTorre(rei, tab.getTp(), i, tab))
                    {
                        return true;
                    }
                }
            }
            else if (type == 4)
            {
                for (int i = 0; i < tab.getDp().Count; i++)
                {
                    if (AnalizeDama(rei, tab.getDp(), i, tab))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    private bool AnalizeDama(Rei r,List<Dama> d,int i,Tabuleiro tab)
    {
        for (int x = 1; x < 9; x++)
        {
            int lin = d[i].getLinha() + x;
            int col = d[i].getColuna() + 0;
            if (d[i].CheckPossible(lin, col))
            {
                if (lin == r.getLinha() && col == r.getColuna())
                {
                    return true;
                }
                else if (tab.PositionisEmpty(lin, col))
                {
                    lisLin.Add(lin);
                    lisCol.Add(col);
                }
                else if (tab.PositionisEmpty(lin, col) == false)
                {
                    lisLin.Clear();
                    lisCol.Clear();
                    x = 10;
                }
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = d[i].getLinha() + 0;
            int col = d[i].getColuna() + x;
            if (d[i].CheckPossible(lin, col))
            {
                if (lin == r.getLinha() && col == r.getColuna())
                {
                    return true;
                }
                else if (tab.PositionisEmpty(lin, col))
                {
                    lisLin.Add(lin);
                    lisCol.Add(col);
                }
                else if (tab.PositionisEmpty(lin, col) == false)
                {
                    lisLin.Clear();
                    lisCol.Clear();
                    x = 10;
                }
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = d[i].getLinha() - x;
            int col = d[i].getColuna() - 0;
            if (d[i].CheckPossible(lin, col))
            {
                if (lin == r.getLinha() && col == r.getColuna())
                {
                    return true;
                }
                else if (tab.PositionisEmpty(lin, col))
                {
                    lisLin.Add(lin);
                    lisCol.Add(col);
                }
                else if (tab.PositionisEmpty(lin, col) == false)
                {
                    lisLin.Clear();
                    lisCol.Clear();
                    x = 10;
                }
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = d[i].getLinha() - 0;
            int col = d[i].getColuna() - x;
            if (d[i].CheckPossible(lin, col))
            {
                if (lin == r.getLinha() && col == r.getColuna())
                {
                    return true;
                }
                else if (tab.PositionisEmpty(lin, col))
                {
                    lisLin.Add(lin);
                    lisCol.Add(col);
                }
                else if (tab.PositionisEmpty(lin, col) == false)
                {
                    lisLin.Clear();
                    lisCol.Clear();
                    x = 10;
                }
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = d[i].getLinha() + x;
            int col = d[i].getColuna() + x;
            if (d[i].CheckPossible(lin, col))
            {
                if (lin == r.getLinha() && col == r.getColuna())
                {
                    return true;
                }
                else if (tab.PositionisEmpty(lin, col))
                {
                    lisLin.Add(lin);
                    lisCol.Add(col);
                }
                else if (tab.PositionisEmpty(lin, col) == false)
                {
                    lisLin.Clear();
                    lisCol.Clear();
                    x = 10;
                }
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = d[i].getLinha() + x;
            int col = d[i].getColuna() - x;
            if (d[i].CheckPossible(lin, col))
            {
                if (lin == r.getLinha() && col == r.getColuna())
                {
                    return true;
                }
                else if (tab.PositionisEmpty(lin, col))
                {
                    lisLin.Add(lin);
                    lisCol.Add(col);
                }
                else if (tab.PositionisEmpty(lin, col) == false)
                {
                    lisLin.Clear();
                    lisCol.Clear();
                    x = 10;
                }
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = d[i].getLinha() - x;
            int col = d[i].getColuna() - x;
            if (d[i].CheckPossible(lin, col))
            {
                if (lin == r.getLinha() && col == r.getColuna())
                {
                    return true;
                }
                else if (tab.PositionisEmpty(lin, col))
                {
                    lisLin.Add(lin);
                    lisCol.Add(col);
                }
                else if (tab.PositionisEmpty(lin, col) == false)
                {
                    lisLin.Clear();
                    lisCol.Clear();
                    x = 10;
                }
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = d[i].getLinha() - x;
            int col = d[i].getColuna() + x;
            if (d[i].CheckPossible(lin, col))
            {
                if (lin == r.getLinha() && col == r.getColuna())
                {
                    return true;
                }
                else if (tab.PositionisEmpty(lin, col))
                {
                    lisLin.Add(lin);
                    lisCol.Add(col);
                }
                else if (tab.PositionisEmpty(lin, col) == false)
                {
                    lisLin.Clear();
                    lisCol.Clear();
                    x = 10;
                }
            }
        }
        return false;
    }

    private bool AnalizeTorre(Rei r,List<Torre> t,int i,Tabuleiro tab)
    {
        for (int x = 1; x < 9; x++)
        {
            int lin = t[i].getLinha() + x;
            int col = t[i].getColuna() + 0;
            if (t[i].CheckPossible(lin, col))
            {
                if (lin == r.getLinha() && col == r.getColuna())
                {
                    return true;
                }
                else if (tab.PositionisEmpty(lin, col))
                {
                    lisLin.Add(lin);
                    lisCol.Add(col);
                }
                else if (tab.PositionisEmpty(lin, col) == false)
                {
                    lisLin.Clear();
                    lisCol.Clear();
                    x = 10;
                }
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = t[i].getLinha() + 0;
            int col = t[i].getColuna() + x;
            if (t[i].CheckPossible(lin, col))
            {
                if (lin == r.getLinha() && col == r.getColuna())
                {
                    return true;
                }
                else if (tab.PositionisEmpty(lin, col))
                {
                    lisLin.Add(lin);
                    lisCol.Add(col);
                }
                else if (tab.PositionisEmpty(lin, col) == false)
                {
                    lisLin.Clear();
                    lisCol.Clear();
                    x = 10;
                }
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = t[i].getLinha() - x;
            int col = t[i].getColuna() - 0;
            if (t[i].CheckPossible(lin, col))
            {
                if (lin == r.getLinha() && col == r.getColuna())
                {
                    return true;
                }
                else if (tab.PositionisEmpty(lin, col))
                {
                    lisLin.Add(lin);
                    lisCol.Add(col);
                }
                else if (tab.PositionisEmpty(lin, col) == false)
                {
                    lisLin.Clear();
                    lisCol.Clear();
                    x = 10;
                }
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = t[i].getLinha() - 0;
            int col = t[i].getColuna() - x;
            if (t[i].CheckPossible(lin, col))
            {
                if (lin == r.getLinha() && col == r.getColuna())
                {
                    return true;
                }
                else if (tab.PositionisEmpty(lin, col))
                {
                    lisLin.Add(lin);
                    lisCol.Add(col);
                }
                else if (tab.PositionisEmpty(lin, col) == false)
                {
                    lisLin.Clear();
                    lisCol.Clear();
                    x = 10;
                }
            }
        }
        return false;
    }

    private bool AnalizeBispo(Rei r,List<Bispo> b,int i,Tabuleiro t)
    {
        for(int x=1;x<9;x++)
        {
            int lin = b[i].getLinha() + x;
            int col = b[i].getColuna() + x;
            if (b[i].CheckPossible(lin, col))
            {
                if(lin==r.getLinha() && col==r.getColuna())
                {
                    return true;
                }
                else if (t.PositionisEmpty(lin, col))
                {
                    lisLin.Add(lin);
                    lisCol.Add(col);
                }
                else if(t.PositionisEmpty(lin, col)==false)
                {
                    lisLin.Clear();
                    lisCol.Clear();
                    x = 10;
                }
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = b[i].getLinha() + x;
            int col = b[i].getColuna() - x;
            if (b[i].CheckPossible(lin, col))
            {
                if (lin == r.getLinha() && col == r.getColuna())
                {
                    return true;
                }
                else if (t.PositionisEmpty(lin, col))
                {
                    lisLin.Add(lin);
                    lisCol.Add(col);
                }
                else if (t.PositionisEmpty(lin, col) == false)
                {
                    lisLin.Clear();
                    lisCol.Clear();
                    x = 10;
                }
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = b[i].getLinha() - x;
            int col = b[i].getColuna() - x;
            if (b[i].CheckPossible(lin, col))
            {
                if (lin == r.getLinha() && col == r.getColuna())
                {
                    return true;
                }
                else if (t.PositionisEmpty(lin, col))
                {
                    lisLin.Add(lin);
                    lisCol.Add(col);
                }
                else if (t.PositionisEmpty(lin, col) == false)
                {
                    lisLin.Clear();
                    lisCol.Clear();
                    x = 10;
                }
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = b[i].getLinha() - x;
            int col = b[i].getColuna() + x;
            if (b[i].CheckPossible(lin, col))
            {
                if (lin == r.getLinha() && col == r.getColuna())
                {
                    return true;
                }
                else if (t.PositionisEmpty(lin, col))
                {
                    lisLin.Add(lin);
                    lisCol.Add(col);
                }
                else if (t.PositionisEmpty(lin, col) == false)
                {
                    lisLin.Clear();
                    lisCol.Clear();
                    x = 10;
                }
            }
        }
        return false;
    }



    public bool HimEliminator(Tabuleiro tab)
    {
        peaoType = 0;
        if(isReiProximo(tab))
        {
            if(HaveCobert(tab)==false)
            {
                return true;
            }
        }
        if(cor==0)
        {
            if(AnalizeTypePeca(tab.getPp(),tab.getCp(),tab.getBp(),tab.getTp(),tab.getDp(),tab))
            {
                return true;
            }
        }
        else
        {
            if (AnalizeTypePeca(tab.getPb(), tab.getCb(), tab.getBb(), tab.getTb(), tab.getDb(), tab))
            {
                return true;
            }
        }
        return false;
    }
    private bool isReiProximo(Tabuleiro t)
    {
        Rei r;
        if(cor==0)
        {
            r = t.getReiPreto();
        }
        else
        {
            r = t.getReiBranco();
        }
        if(linha+1==r.getLinha()&&coluna-1==r.getColuna())
        {
            return true;
        }
        else if (linha == r.getLinha() && coluna - 1 == r.getColuna())
        {
            return true;
        }
        else if (linha -1 == r.getLinha() && coluna - 1 == r.getColuna())
        {
            return true;
        }
        else if (linha -1 == r.getLinha() && coluna  == r.getColuna())
        {
            return true;
        }
        else if (linha -1 == r.getLinha() && coluna + 1 == r.getColuna())
        {
            return true;
        }
        else if (linha == r.getLinha() && coluna + 1 == r.getColuna())
        {
            return true;
        }
        else if (linha +1 == r.getLinha() && coluna + 1 == r.getColuna())
        {
            return true;
        }
        else if (linha +1 == r.getLinha() && coluna == r.getColuna())
        {
            return true;
        }
        return false;
    }
    private bool HaveCobert(Tabuleiro t)
    {
        if(cor==0)
        {
            if(AnalizeTypePeca(t.getPb(),t.getCb(),t.getBb(),t.getTb(),t.getDb(),t))
            {
                return true;
            }
        }
        else
        {
            if (AnalizeTypePeca(t.getPp(), t.getCp(), t.getBp(), t.getTp(), t.getDp(), t))
            {
                return true;
            }
        }
        return false;
    }

    private bool AnalizeTypePeca(List<Peao> p,List<Cavalo> c,List<Bispo> b,List<Torre> t,List<Dama> d,Tabuleiro tab)
    {
        if (peaoType == 0)
        {
            for (int i = 0; i < p.Count; i++)
            {
                if (p[i].Cor() == 0)
                {
                    if (p[i].Linha() == linha - 1 && (p[i].Coluna() == coluna - 1 || p[i].Coluna() == coluna + 1))
                    {
                        return true;
                    }
                }
                else
                {
                    if (p[i].Linha() == linha + 1 && (p[i].Coluna() == coluna - 1 || p[i].Coluna() == coluna + 1))
                    {
                        return true;
                    }
                }
            }
        }
        for (int i = 0; i < c.Count; i++)
        {
            if (PulosCavalo(c,i))
            {
                return true;
            }
        }
        for (int i = 0; i < b.Count; i++)
        {
            if(MoveBispo(b,i,tab))
            {
                return true;
            }
        }
        for(int i=0;i<t.Count;i++)
        {
            if(MoveTorre(t,i,tab))
            {
                return true;
            }
        }
        for (int i = 0; i < d.Count; i++)
        {
            if (MoveDama(d, i, tab))
            {
                return true;
            }
        }
        return false;
    }

    private bool PulosCavalo(List<Cavalo> c,int i)
    {
        if(c[i].getLinha()==linha-2&&c[i].getColuna()==coluna+1)
        {
            return true;
        }
        else if (c[i].getLinha() == linha - 1 && c[i].getColuna() == coluna + 2)
        {
            return true;
        }
        else if (c[i].getLinha() == linha + 1 && c[i].getColuna() == coluna + 2)
        {
            return true;
        }
        else if (c[i].getLinha() == linha + 2 && c[i].getColuna() == coluna + 1)
        {
            return true;
        }
        else if (c[i].getLinha() == linha + 2 && c[i].getColuna() == coluna - 1)
        {
            return true;
        }
        else if (c[i].getLinha() == linha + 1 && c[i].getColuna() == coluna - 2)
        {
            return true;
        }
        else if (c[i].getLinha() == linha - 1 && c[i].getColuna() == coluna - 2)
        {
            return true;
        }
        else if (c[i].getLinha() == linha - 2 && c[i].getColuna() == coluna - 1)
        {
            return true;
        }
        return false;
    }

    private bool MoveBispo(List<Bispo> b, int i,Tabuleiro t)
    {
        for (int x = 1; x < 9; x++)
        {
            int lin = b[i].getLinha() + x;
            int col = b[i].getColuna() + x;
            if (b[i].CheckPossible(lin, col))
            {
                if (lin == linha && col == coluna)
                {
                    return true;
                }
                else
                {
                    if (t.PositionisEmpty(lin, col) == false)
                    {
                        x = 10;
                    }
                }
            }
            else
            {
                x = 10;
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = b[i].getLinha() + x;
            int col = b[i].getColuna() - x;
            if (b[i].CheckPossible(lin, col))
            {
                if (lin == linha && col == coluna)
                {
                    return true;
                }
                else
                {
                    if (t.PositionisEmpty(lin, col) == false)
                    {
                        x = 10;
                    }
                }
            }
            else
            {
                x = 10;
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = b[i].getLinha() - x;
            int col = b[i].getColuna() - x;
            if (b[i].CheckPossible(lin, col))
            {
                if (lin == linha && col == coluna)
                {
                    return true;
                }
                else
                {
                    if (t.PositionisEmpty(lin, col) == false)
                    {
                        x = 10;
                    }
                }
            }
            else
            {
                x = 10;
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = b[i].getLinha() - x;
            int col = b[i].getColuna() + x;
            if (b[i].CheckPossible(lin, col))
            {
                if (lin == linha && col == coluna)
                {
                    return true;
                }
                else
                {
                    if (t.PositionisEmpty(lin, col) == false)
                    {
                        x = 10;
                    }
                }
            }
            else
            {
                x = 10;
            }
        }
        return false;
    }

    private bool MoveTorre(List<Torre> t,int i,Tabuleiro tab)
    {
        for (int x = 1; x < 9; x++)
        {
            int lin = t[i].getLinha() + x;
            int col = t[i].getColuna() + 0;
            if (t[i].CheckPossible(lin, col))
            {
                if (lin == linha && col == coluna)
                {
                    return true;
                }
                else
                {
                    if (tab.PositionisEmpty(lin, col) == false)
                    {
                        x = 10;
                    }
                }
            }
            else
            {
                x = 10;
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = t[i].getLinha() + 0;
            int col = t[i].getColuna() + x;
            if (t[i].CheckPossible(lin, col))
            {
                if (lin == linha && col == coluna)
                {
                    return true;
                }
                else
                {
                    if (tab.PositionisEmpty(lin, col) == false)
                    {
                        x = 10;
                    }
                }
            }
            else
            {
                x = 10;
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = t[i].getLinha() - x;
            int col = t[i].getColuna() + 0;
            if (t[i].CheckPossible(lin, col))
            {
                if (lin == linha && col == coluna)
                {
                    return true;
                }
                else
                {
                    if (tab.PositionisEmpty(lin, col) == false)
                    {
                        x = 10;
                    }
                }
            }
            else
            {
                x = 10;
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = t[i].getLinha() + 0;
            int col = t[i].getColuna() - x;
            if (t[i].CheckPossible(lin, col))
            {
                if (lin == linha && col == coluna)
                {
                    return true;
                }
                else
                {
                    if (tab.PositionisEmpty(lin, col) == false)
                    {
                        x = 10;
                    }
                }
            }
            else
            {
                x = 10;
            }
        }
        return false;
    }
    
    private bool MoveDama(List<Dama> d,int i,Tabuleiro tab)
    {
        for (int x = 1; x < 9; x++)
        {
            int lin = d[i].getLinha() + x;
            int col = d[i].getColuna() + x;
            if (d[i].CheckPossible(lin, col))
            {
                if (lin == linha && col == coluna)
                {
                    return true;
                }
                else
                {
                    if (tab.PositionisEmpty(lin, col) == false)
                    {
                        x = 10;
                    }
                }
            }
            else
            {
                x = 10;
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = d[i].getLinha() + x;
            int col = d[i].getColuna() - x;
            if (d[i].CheckPossible(lin, col))
            {
                if (lin == linha && col == coluna)
                {
                    return true;
                }
                else
                {
                    if (tab.PositionisEmpty(lin, col) == false)
                    {
                        x = 10;
                    }
                }
            }
            else
            {
                x = 10;
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = d[i].getLinha() - x;
            int col = d[i].getColuna() - x;
            if (d[i].CheckPossible(lin, col))
            {
                if (lin == linha && col == coluna)
                {
                    return true;
                }
                else
                {
                    if (tab.PositionisEmpty(lin, col) == false)
                    {
                        x = 10;
                    }
                }
            }
            else
            {
                x = 10;
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = d[i].getLinha() - x;
            int col = d[i].getColuna() + x;
            if (d[i].CheckPossible(lin, col))
            {
                if (lin == linha && col == coluna)
                {
                    return true;
                }
                else
                {
                    if (tab.PositionisEmpty(lin, col) == false)
                    {
                        x = 10;
                    }
                }
            }
            else
            {
                x = 10;
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = d[i].getLinha() + x;
            int col = d[i].getColuna() + 0;
            if (d[i].CheckPossible(lin, col))
            {
                if (lin == linha && col == coluna)
                {
                    return true;
                }
                else
                {
                    if (tab.PositionisEmpty(lin, col) == false)
                    {
                        x = 10;
                    }
                }
            }
            else
            {
                x = 10;
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = d[i].getLinha() + 0;
            int col = d[i].getColuna() + x;
            if (d[i].CheckPossible(lin, col))
            {
                if (lin == linha && col == coluna)
                {
                    return true;
                }
                else
                {
                    if (tab.PositionisEmpty(lin, col) == false)
                    {
                        x = 10;
                    }
                }
            }
            else
            {
                x = 10;
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = d[i].getLinha() - x;
            int col = d[i].getColuna() + 0;
            if (d[i].CheckPossible(lin, col))
            {
                if (lin == linha && col == coluna)
                {
                    return true;
                }
                else
                {
                    if (tab.PositionisEmpty(lin, col) == false)
                    {
                        x = 10;
                    }
                }
            }
            else
            {
                x = 10;
            }
        }
        for (int x = 1; x < 9; x++)
        {
            int lin = d[i].getLinha() + 0;
            int col = d[i].getColuna() - x;
            if (d[i].CheckPossible(lin, col))
            {
                if (lin == linha && col == coluna)
                {
                    return true;
                }
                else
                {
                    if (tab.PositionisEmpty(lin, col) == false)
                    {
                        x = 10;
                    }
                }
            }
            else
            {
                x = 10;
            }
        }
        return false;
    }
}
