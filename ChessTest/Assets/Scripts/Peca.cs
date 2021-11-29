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
            if (cor==0)
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
            }
        }
        lisLin.Clear();
        lisCol.Clear();
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
            }
        }
        lisLin.Clear();
        lisCol.Clear();
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
            }
        }
        lisLin.Clear();
        lisCol.Clear();
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
            }
        }
        lisLin.Clear();
        lisCol.Clear();
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
            }
        }
        lisLin.Clear();
        lisCol.Clear();
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
            }
        }
        lisLin.Clear();
        lisCol.Clear();
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
            }
        }
        lisLin.Clear();
        lisCol.Clear();
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
            }
        }
        lisLin.Clear();
        lisCol.Clear();
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
            }
        }
        lisLin.Clear();
        lisCol.Clear();
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
            }
        }
        lisLin.Clear();
        lisCol.Clear();
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
            }
        }
        lisLin.Clear();
        lisCol.Clear();
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
            }
        }
        lisLin.Clear();
        lisCol.Clear();
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
            }
        }
        lisLin.Clear();
        lisCol.Clear();
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
            }
        }
        lisLin.Clear();
        lisCol.Clear();
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
            }
        }
        lisLin.Clear();
        lisCol.Clear();
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
            }
        }
        lisLin.Clear();
        lisCol.Clear();
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
            if (PulosCavalo(c,i,tab))
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

    private bool PulosCavalo(List<Cavalo> c,int i,Tabuleiro t)
    {
        if(c[i].getLinha()==linha-2&&c[i].getColuna()==coluna+ 1 && isPermitidMoviment(0, c[i], null, null, null, linha-2, coluna+1, t))
        {
            return true;
        }
        else if (c[i].getLinha() == linha - 1 && c[i].getColuna() == coluna + 2 && isPermitidMoviment(0, c[i], null, null, null, linha - 1, coluna + 2, t))
        {
            return true;
        }
        else if (c[i].getLinha() == linha + 1 && c[i].getColuna() == coluna + 2 && isPermitidMoviment(0, c[i], null, null, null, linha + 1, coluna + 2, t))
        {
            return true;
        }
        else if (c[i].getLinha() == linha + 2 && c[i].getColuna() == coluna + 1 && isPermitidMoviment(0, c[i], null, null, null, linha + 2, coluna + 1, t))
        {
            return true;
        }
        else if (c[i].getLinha() == linha + 2 && c[i].getColuna() == coluna - 1 && isPermitidMoviment(0, c[i], null, null, null, linha + 2, coluna - 1, t))
        {
            return true;
        }
        else if (c[i].getLinha() == linha + 1 && c[i].getColuna() == coluna - 2 && isPermitidMoviment(0, c[i], null, null, null, linha + 1, coluna - 2, t))
        {
            return true;
        }
        else if (c[i].getLinha() == linha - 1 && c[i].getColuna() == coluna - 2 && isPermitidMoviment(0, c[i], null, null, null, linha - 1, coluna - 2, t))
        {
            return true;
        }
        else if (c[i].getLinha() == linha - 2 && c[i].getColuna() == coluna - 1 && isPermitidMoviment(0, c[i], null, null, null, linha - 2, coluna - 1, t))
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
                if (lin == linha && col == coluna && isPermitidMoviment(1, null, b[i], null, null, lin, col, t))
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
                if (lin == linha && col == coluna && isPermitidMoviment(1, null, b[i], null, null, lin, col, t))
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
                if (lin == linha && col == coluna && isPermitidMoviment(1, null, b[i], null, null, lin, col, t))
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
                if (lin == linha && col == coluna && isPermitidMoviment(1, null, b[i], null, null, lin, col, t))
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
                if (lin == linha && col == coluna && isPermitidMoviment(2, null, null, t[i], null, lin, col, tab))
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
                if (lin == linha && col == coluna && isPermitidMoviment(2, null, null, t[i], null, lin, col, tab))
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
                if (lin == linha && col == coluna && isPermitidMoviment(2, null, null, t[i], null, lin, col, tab))
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
                if (lin == linha && col == coluna && isPermitidMoviment(2, null, null, t[i], null, lin, col, tab))
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
                if (lin == linha && col == coluna && isPermitidMoviment(3,null,null,null,d[i],lin,col,tab))
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
                if (lin == linha && col == coluna && isPermitidMoviment(3, null, null, null, d[i], lin, col, tab))
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
                if (lin == linha && col == coluna && isPermitidMoviment(3, null, null, null, d[i], lin, col, tab))
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
                if (lin == linha && col == coluna && isPermitidMoviment(3, null, null, null, d[i], lin, col, tab))
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
                if (lin == linha && col == coluna && isPermitidMoviment(3, null, null, null, d[i], lin, col, tab))
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
                if (lin == linha && col == coluna && isPermitidMoviment(3, null, null, null, d[i], lin, col, tab))
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
                if (lin == linha && col == coluna && isPermitidMoviment(3, null, null, null, d[i], lin, col, tab))
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
                if (lin == linha && col == coluna && isPermitidMoviment(3, null, null, null, d[i], lin, col, tab))
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

    private bool isPermitidMoviment(int type,Cavalo c, Bispo b,Torre t,Dama d,int lin,int col,Tabuleiro tab)
    {
        bool ok = true;
        if (type == 0)
        {
            int li = c.getLinha();
            int co = c.getColuna();
            c.setLinha(lin);
            c.setColuna(col);
            if (cor == 0)
            {
                if (tab.getReiBranco().isCheck(tab))
                {
                    ok = false;
                }
            }
            else
            {
                if (tab.getReiPreto().isCheck(tab))
                {
                    ok = false;
                }
            }
            c.setLinha(li);
            c.setColuna(co);
        }
        else if (type == 1)
        {
            int li = b.getLinha();
            int co = b.getColuna();
            b.setLinha(lin);
            b.setColuna(col);
            if (cor == 0)
            {
                if (tab.getReiBranco().isCheck(tab))
                {
                    ok = false;
                }
            }
            else
            {
                if (tab.getReiPreto().isCheck(tab))
                {
                    ok = false;
                }
            }
            b.setLinha(li);
            b.setColuna(co);
        }
        else if (type == 2)
        {
            int li = t.getLinha();
            int co = t.getColuna();
            t.setLinha(lin);
            t.setColuna(col);
            if (cor == 0)
            {
                if (tab.getReiBranco().isCheck(tab))
                {
                    ok = false;
                }
            }
            else
            {
                if (tab.getReiPreto().isCheck(tab))
                {
                    ok = false;
                }
            }
            t.setLinha(li);
            t.setColuna(co);
        }
        else if (type == 3)
        {
            int li = d.getLinha();
            int co = d.getColuna();
            d.setLinha(lin);
            d.setColuna(col);
            if (cor == 0)
            {
                if (tab.getReiBranco().isCheck(tab))
                {
                    ok = false;
                }
            }
            else
            {
                if (tab.getReiPreto().isCheck(tab))
                {
                    ok = false;
                }
            }
            d.setLinha(li);
            d.setColuna(co);
        }
        return ok;
    }
}
