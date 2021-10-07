using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peao
{
    private int cor;
    private int linha;
    private int coluna;
    private bool enPassant;

    public Peao(int c,int m,int n)
    {
        cor = c;
        linha = m;
        coluna = n;
        enPassant = false;
    }

    public void setEnpass(bool ok)
    {
        enPassant = ok;
    }
    public void setLinha(int l)
    {
        linha = l;
    }
    public void setColuna(int c)
    {
        coluna = c;
    }
    public int Cor()
    {
        return cor;
    }
    public int Linha()
    {
        return linha;
    }
    public int Coluna()
    {
        return coluna;
    }
    public bool EnPassant()
    {
        return enPassant;
    }

    public bool isCheckRei(int lin, int col)
    {
        if (cor == 0)
        {
            if (linha + 1 == lin && (coluna + 1 == col || coluna - 1 == col))
            {
                return true;
            }
        }
        else if (cor == 1)
        {
            if (linha - 1 == lin && (coluna + 1 == col || coluna - 1 == col))
            {
                return true;
            }
        }
        return false;
    }

    //lin E col == CHECK DE POSIÇÕES DE ORIGEM
    public bool isPosition(int lin, int col)
    {
        if (lin == linha && col == coluna)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckPossible(int l, int c)
    {
        if (l >= 0 && l <= 7 && c >= 0 && c <= 7)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //lin E col == POSIÇÕES DE DESTINO
    public bool IsMove(int lin, int col, Tabuleiro tab)
    {
        if (CheckPossible(lin, col))
        {
            if (isMovimentSimple(lin, col, tab))
            {
                return true;
            }
            else if (isFirsDoubleMoviment(lin, col, tab))
            {
                return true;
            }
            else if (isCapture(lin, col, tab))
            {
                return true;
            }
            else if (MoveEnPassan(lin, col, tab))
            {
                tab.isEnPassant();
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }


    private bool MoveEnPassan(int l, int c, Tabuleiro t)
    {
        int a = linha;
        int b = coluna;
        if(cor==0)
        {
            for(int i=0;i<t.getPp().Count;i++)
            {
                if(t.getPp()[i].Linha()==linha&&t.getPp()[i].Coluna()==coluna+1&&t.getPp()[i].EnPassant())
                {
                    if(linha+1==l&&coluna+1==c&&t.PositionisEmpty(l,c))
                    {
                        linha = l;
                        coluna = c;
                        t.getPp().Remove(t.getPp()[i]);
                        return true;
                    }
                }
                else if (t.getPp()[i].Linha() == linha && t.getPp()[i].Coluna() == coluna - 1 && t.getPp()[i].EnPassant())
                {
                    if (linha + 1 == l && coluna - 1 == c && t.PositionisEmpty(l, c))
                    {
                        linha = l;
                        coluna = c;
                        t.getPp().Remove(t.getPp()[i]);
                        return true;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < t.getPb().Count; i++)
            {
                if (t.getPb()[i].Linha() == linha && t.getPb()[i].Coluna() == coluna + 1 && t.getPb()[i].EnPassant())
                {
                    if (linha - 1 == l && coluna + 1 == c && t.PositionisEmpty(l, c))
                    {
                        linha = l;
                        coluna = c;
                        t.getPb().Remove(t.getPb()[i]);
                        return true;
                    }
                }
                else if (t.getPb()[i].Linha() == linha && t.getPb()[i].Coluna() == coluna - 1 && t.getPb()[i].EnPassant())
                {
                    if (linha - 1 == l && coluna - 1 == c && t.PositionisEmpty(l, c))
                    {
                        linha = l;
                        coluna = c;
                        t.getPb().Remove(t.getPb()[i]);
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private bool isCapture(int l, int c, Tabuleiro tab)
    {
        int a = linha;
        int b = coluna;
        if (cor == 0)
        {
            if (linha + 1 == l)
            {
                if (coluna - 1 == c || coluna + 1 == c)
                {
                    if (!tab.PositionisEmptyPreto(l, c, 1))
                    {
                        ToMakeMoviment(l, c);
                        if (AnalizeReiCheck(a, b, tab) == false)
                        {
                            tab.ReecolockPeca(l, c);
                            return false;
                        }
                        enPassant = false;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else if (cor == 1)
        {
            if (linha - 1 == l)
            {
                if (coluna - 1 == c || coluna + 1 == c)
                {
                    if (!tab.PositionisEmptyBranco(l, c, 1))
                    {
                        ToMakeMoviment(l, c);
                        if (AnalizeReiCheck(a, b, tab) == false)
                        {
                            tab.ReecolockPeca(l, c);
                            return false;
                        }
                        enPassant = false;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    private bool isFirsDoubleMoviment(int lin, int col, Tabuleiro tab)
    {
        int a = linha;
        int b = coluna;
        if (tab.PositionisEmpty(lin, col))
        {
            if (isFirstDouble() == false)
            {
                return false;
            }
            else
            {
                if (isEmptyPos(tab))
                {
                    if (linha + 2 == lin && cor == 0)
                    {
                        ToMakeMoviment(lin, coluna);
                        if (AnalizeReiCheck(a, b, tab) == false)
                        {
                            return false;
                        }
                        enPassant = true;
                        return true;
                    }
                    else if (linha - 2 == lin && cor == 1)
                    {
                        ToMakeMoviment(lin, coluna);
                        if (AnalizeReiCheck(a, b, tab) == false)
                        {
                            return false;
                        }
                        enPassant = true;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
    }

    private bool isEmptyPos(Tabuleiro tab)
    {
        if (tab.PositionisEmpty(linha + 1, coluna) && cor == 0)
        {
            return true;
        }
        else if (tab.PositionisEmpty(linha - 1, coluna) && cor == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool isFirstDouble()
    {
        if (cor == 0)
        {
            if (linha == 1)
            {
                return true;
            }
        }
        else
        {
            if (linha == 6)
            {
                return true;
            }
        }
        return false;
    }

    private bool isMovimentSimple(int lin, int col, Tabuleiro tab)
    {
        int a = linha;
        int b = coluna;
        if (tab.PositionisEmpty(lin, col))
        {
            if (linha + 1 == lin && cor == 0 && coluna==col)
            {
                ToMakeMoviment(lin, coluna);
                if (AnalizeReiCheck(a, b, tab) == false)
                {
                    return false;
                }
                enPassant = false;
                return true;
            }
            else if (linha - 1 == lin && cor == 1 && coluna == col)
            {
                ToMakeMoviment(lin, coluna);
                if (AnalizeReiCheck(a, b, tab) == false)
                {
                    return false;
                }
                enPassant = false;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    //Só vai chamar esse movimento se e somente se algum rei estiver em check -> true = tem volta   //  false = checkmate
    public bool AnalizeAllMoviments(Tabuleiro t)
    {
        if (cor == 0)
        {
            if (isFirstDouble())
            {
                if (AnalizeThisMoviment(linha + 2, coluna, t, 0))
                {
                    return true;
                }
            }
            if (AnalizeThisMoviment(linha + 1, coluna, t, 0))
            {
                return true;
            }
            if (AnalizeThisMoviment(linha + 1, coluna + 1, t, 1))
            {
                return true;
            }
            if (AnalizeThisMoviment(linha + 1, coluna - 1, t, 1))
            {
                return true;
            }
        }
        else
        {
            if (isFirstDouble())
            {
                if (AnalizeThisMoviment(linha - 2, coluna, t, 0))
                {
                    return true;
                }
            }
            if (AnalizeThisMoviment(linha - 1, coluna, t, 0))
            {
                return true;
            }
            if (AnalizeThisMoviment(linha - 1, coluna + 1, t, 1))
            {
                return true;
            }
            if (AnalizeThisMoviment(linha - 1, coluna - 1, t, 1))
            {
                return true;
            }
        }
        return false;
    }

    private bool AnalizeThisMoviment(int l, int c, Tabuleiro t, int type)
    {
        int a = linha;
        int b = coluna;
        if (!t.PositionisEmpty(l, c) && type == 1)
        {
            if (cor == 0)
            {
                if (!t.PositionisEmptyPreto(l, c, 1))
                {
                    linha = l;
                    coluna = c;
                    if (t.getReiBranco().isCheck(t))
                    {
                        linha = a;
                        coluna = b;
                        t.ReecolockPeca(l, c);
                        return false;
                    }
                    else
                    {
                        linha = a;
                        coluna = b;
                        t.ReecolockPeca(l, c);
                        return true;
                    }
                }
            }
            else
            {
                if (!t.PositionisEmptyBranco(l, c, 1))
                {
                    linha = l;
                    coluna = c;
                    if (t.getReiPreto().isCheck(t))
                    {
                        linha = a;
                        coluna = b;
                        t.ReecolockPeca(l, c);
                        return false;
                    }
                    else
                    {
                        linha = a;
                        coluna = b;
                        t.ReecolockPeca(l, c);
                        return true;
                    }
                }
            }
        }
        if (type == 0)
        {
            linha = l;
            coluna = c;
            if (cor == 0)
            {
                if (t.getReiBranco().isCheck(t))
                {
                    linha = a;
                    coluna = b;
                    return false;
                }
                else
                {
                    linha = a;
                    coluna = b;
                    return true;
                }
            }
            else
            {
                if (t.getReiPreto().isCheck(t))
                {
                    linha = a;
                    coluna = b;
                    return false;
                }
                else
                {
                    linha = a;
                    coluna = b;
                    return true;
                }
            }
        }
        return false;
    }

    public bool AnalizeMoviment(Tabuleiro t)
    {
        if (cor == 0)
        {
            if (t.PositionisEmpty(linha + 1, coluna))
            {
                return true;
            }
        }
        else
        {
            if (t.PositionisEmpty(linha - 1, coluna))
            {
                return true;
            }
        }
        if (cor == 0)
        {
            if (t.PositionisEmptyPreto(linha + 1, coluna + 1, 0) == false)
            {
                return true;
            }
            if (t.PositionisEmptyPreto(linha + 1, coluna - 1, 0) == false)
            {
                return true;
            }
        }
        else
        {
            if (t.PositionisEmptyBranco(linha - 1, coluna + 1, 0) == false)
            {
                return true;
            }
            if (t.PositionisEmptyBranco(linha - 1, coluna - 1, 0) == false)
            {
                return true;
            }
        }
        return false;
    }

    public bool AllMovimentsPossible(Tabuleiro tab)
    {
        bool ok = true;
        if (cor == 0)
        {
            if (isFirstDouble())
            {
                linha += 2;
                if (tab.getReiBranco().isCheck(tab))
                {
                    ok = false;
                }
                linha -= 2;
                if (ok == false)
                {
                    ok = true;
                    linha++;
                    if (tab.getReiBranco().isCheck(tab))
                    {
                        ok = false;
                    }
                    linha--;
                }
            }
            else
            {
                linha++;
                if (tab.getReiBranco().isCheck(tab))
                {
                    ok = false;
                }
                linha--;
            }
            if (ok == true)
            {
                return true;
            }
            else
            {
                return AnalizeMoviment(0, tab);
            }
        }
        else
        {
            if (isFirstDouble())
            {
                linha -= 2;
                if (tab.getReiPreto().isCheck(tab))
                {
                    ok = false;
                }
                linha += 2;
                if (ok == false)
                {
                    linha--;
                    if (tab.getReiPreto().isCheck(tab))
                    {
                        ok = false;
                    }
                    linha++;
                }
            }
            else
            {
                linha--;
                if (tab.getReiPreto().isCheck(tab))
                {
                    ok = false;
                }
                linha++;
            }
            if (ok == true)
            {
                return true;
            }
            else
            {
                return AnalizeMoviment(1, tab);
            }
        }
    }

    private bool AnalizeMoviment(int cor, Tabuleiro tab)
    {
        bool ok = false;
        if (cor == 0)
        {
            ok = tab.PositionisEmptyPreto(linha + 1, coluna + 1, 1);
            if (ok)
            {
                ok = tab.PositionisEmptyPreto(linha + 1, coluna - 1, 1);
                int l = linha;
                int c = coluna;
                linha++;
                coluna--;
                if (tab.getReiBranco().isCheck(tab))
                {
                    ok = false;
                }
                else
                {
                    ok = true;
                }
                linha = l;
                coluna = c;
                tab.ReecolockPeca(linha++, coluna--);
            }
            else
            {
                int l = linha;
                int c = coluna;
                linha++;
                coluna++;
                if (tab.getReiBranco().isCheck(tab))
                {
                    ok = false;
                }
                else
                {
                    ok = true;
                }
                linha = l;
                coluna = c;
                tab.ReecolockPeca(linha++, coluna++);
            }
        }
        else
        {
            ok = tab.PositionisEmptyBranco(linha - 1, coluna + 1, 1);
            if (ok)
            {
                ok = tab.PositionisEmptyBranco(linha - 1, coluna - 1, 1);
                int l = linha;
                int c = coluna;
                linha++;
                coluna--;
                if (tab.getReiPreto().isCheck(tab))
                {
                    ok = false;
                }
                else
                {
                    ok = true;
                }
                linha = l;
                coluna = c;
                tab.ReecolockPeca(linha++, coluna--);
            }
            else
            {
                int l = linha;
                int c = coluna;
                linha++;
                coluna++;
                if (tab.getReiPreto().isCheck(tab))
                {
                    ok = false;
                }
                else
                {
                    ok = true;
                }
                linha = l;
                coluna = c;
                tab.ReecolockPeca(linha++, coluna++);
            }
        }
        return ok;
    }



    private bool AnalizeReiCheck(int a, int b, Tabuleiro t)
    {
        if (cor == 0)
        {
            if (t.getReiBranco().isCheck(t))
            {
                linha = a;
                coluna = b;
                return false;
            }
        }
        else
        {
            if (t.getReiPreto().isCheck(t))
            {
                linha = a;
                coluna = b;
                return false;
            }
        }
        return true;
    }

    //TODO O PROCESSO DE TROCA DE POSIÇÃO
    private void ToMakeMoviment(int lin, int col)
    {
        linha = lin;
        coluna = col;
    }
}
