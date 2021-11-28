using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tabuleiro
{
    //0==Peao // 1==Cavalo // 2==Bispo // 3==Torre // 4==Dama // 5==Rei
    private int typePecaMove;
    private int pecaMoveCheck;
    private int indexDesmove;
    private string sit;
    private bool enPassant;
    private bool isEnd;

    //PEÇAS BRANCAS
    private List<Peao> pb;
    private List<Cavalo> cb;
    private List<Bispo> bb;
    private List<Torre> tb;
    private List<Dama> db;
    private Rei reiBranco;

    //PEÇAS PRETAS
    private List<Peao> pp;
    private List<Cavalo> cp;
    private List<Bispo> bp;
    private List<Torre> tp;
    private List<Dama> dp;
    private Rei reiPreto;

    public Tabuleiro()
    {
        isEnd = false;
        enPassant = false;
        sit = "";
        indexDesmove = -1;
        pecaMoveCheck = -1;
        typePecaMove = -1;
        pb = new List<Peao>();
        pp = new List<Peao>();
        for (int i = 0; i < 8; i++)
        {
            pb.Add(new Peao(0, 1, i));
            pp.Add(new Peao(1, 6, i));
        }
        InitiateCavalo();
        InitiateBispo();
        InitiateTorre();
        db = new List<Dama>();
        dp = new List<Dama>();
        db.Add(new Dama(0, 0, 3));
        dp.Add(new Dama(1, 7, 3));
        reiBranco = new Rei(0, 0, 4);
        reiPreto = new Rei(1, 7, 4);
        //Start();
    }

    public Tabuleiro(Tabuleiro tab)
    {
        typePecaMove = -1;
        pb = tab.getPb();
        pp = tab.getPp();
        cb = tab.getCb();
        cp = tab.getCp();
        bb = tab.getBb();
        bp = tab.getBp();
        tb = tab.getTb();
        tp = tab.getTp();
        db = tab.getDb();
        dp = tab.getDp();
        reiBranco = tab.getReiBranco();
        reiPreto = tab.getReiPreto();
    }

    public Tabuleiro(PosicaoPeca p)
    {
        pb = new List<Peao>();
        pp = new List<Peao>();
        cb = new List<Cavalo>();
        cp = new List<Cavalo>();
        bb = new List<Bispo>();
        bp = new List<Bispo>();
        tb = new List<Torre>();
        tp = new List<Torre>();
        db = new List<Dama>();
        dp = new List<Dama>();
        for(int i=0;i<p.PeaoBrancoPosi.Count;i+=2)
        {
            pb.Add(new Peao(0,p.PeaoBrancoPosi[i],p.PeaoBrancoPosi[i+1]));
        }
        for (int i = 0; i < p.PeaoPretoPosi.Count; i+=2)
        {
            pp.Add(new Peao(1, p.PeaoPretoPosi[i], p.PeaoPretoPosi[i + 1]));
        }
        for (int i = 0; i < p.CavaloBrancoPosi.Count; i+=2)
        {
            cb.Add(new Cavalo(0, p.CavaloBrancoPosi[i], p.CavaloBrancoPosi[i + 1]));
        }
        for (int i = 0; i < p.CavaloPretoPosi.Count; i+=2)
        {
            cp.Add(new Cavalo(1, p.CavaloPretoPosi[i], p.CavaloPretoPosi[i + 1]));
        }
        for (int i = 0; i < p.BispoBrancoPosi.Count; i+=2)
        {
            bb.Add(new Bispo(0, p.BispoBrancoPosi[i], p.BispoBrancoPosi[i + 1]));
        }
        for (int i = 0; i < p.BispoPretoPosi.Count; i+=2)
        {
            bp.Add(new Bispo(1, p.BispoPretoPosi[i], p.BispoPretoPosi[i + 1]));
        }
        for (int i = 0; i < p.TorreBrancoPosi.Count; i+=2)
        {
            tb.Add(new Torre(0, p.TorreBrancoPosi[i], p.TorreBrancoPosi[i + 1]));
        }
        for (int i = 0; i < p.TorrePretoPosi.Count; i+=2)
        {
            tp.Add(new Torre(1, p.TorrePretoPosi[i], p.TorrePretoPosi[i + 1]));
        }
        for (int i = 0; i < p.DamaBrancoPosi.Count; i+=2)
        {
            db.Add(new Dama(0, p.DamaBrancoPosi[i], p.DamaBrancoPosi[i + 1]));
        }
        for (int i = 0; i < p.DamaPretoPosi.Count; i+=2)
        {
            dp.Add(new Dama(1, p.DamaPretoPosi[i], p.DamaPretoPosi[i + 1]));
        }
        reiBranco = new Rei(0,p.ReiBrancoPosi[0],p.ReiBrancoPosi[1]);
        reiPreto = new Rei(1, p.ReiPretoPosi[0], p.ReiPretoPosi[1]);
    }

    //move a peca no menu
    public bool MovePecaMainTela(int type,int lin,int col,Tabuleiro tab)
    {
        if (type == 10)
        {
            //reiBranco
            if (reiBranco.isReiDominate(lin, col, tab))
            {
                return false;
            }
        }
        else if (type == 11)
        {
            //reiPreto
            if (reiPreto.isReiDominate(lin, col, tab))
            {
                return false;
            }
        }
        else
        {
            if (reiBranco.isPosition(lin, col))
            {
                return false;
            }
            else if (reiPreto.isPosition(lin, col))
            {
                return false;
            }
            PositionisEmptyBranco(lin, col, 1);
            PositionisEmptyPreto(lin, col, 1);
            ToMakeMovimentMainTela(0,lin,col,type);
            if(reiBranco.isCheckMate(this)==false)
            {
                ToMakeMovimentMainTela(1,lin,col,type);
                ReecolockPeca(lin,col);
                return false;
            }
            else if (reiPreto.isCheckMate(this) == false)
            {
                ToMakeMovimentMainTela(1,lin, col, type);
                ReecolockPeca(lin, col);
                return false;
            }
        }
        return true;
    }

    private void ToMakeMovimentMainTela(int t,int lin,int col,int type)
    {
        switch (type)
        {
            case 0:
                if (t == 0)
                {
                    pb.Add(new Peao(0, lin, col));
                }
                else
                {
                    pb.Remove(pb[pb.Count-1]);
                }
                break;
            case 1:
                if (t == 0)
                {
                    pp.Add(new Peao(1, lin, col));
                }
                else
                {
                    pp.Remove(pp[pp.Count - 1]);
                }
                break;
            case 2:
                if (t == 0)
                {
                    cb.Add(new Cavalo(0, lin, col));
                }
                else
                {
                    cb.Remove(cb[cb.Count - 1]);
                }
                break;
            case 3:
                if (t == 0)
                {
                    cp.Add(new Cavalo(1, lin, col));
                }
                else
                {
                    cp.Remove(cp[cp.Count - 1]);
                }
                break;
            case 4:
                if (t == 0)
                {
                    bb.Add(new Bispo(0, lin, col));
                }
                else
                {
                    bb.Remove(bb[bb.Count - 1]);
                }
                break;
            case 5:
                if (t == 0)
                {
                    bp.Add(new Bispo(1, lin, col));
                }
                else
                {
                    bp.Remove(bp[bp.Count - 1]);
                }
                break;
            case 6:
                if (t == 0)
                {
                    tb.Add(new Torre(0, lin, col));
                }
                else
                {
                    tb.Remove(tb[tb.Count - 1]);
                }
                break;
            case 7:
                if (t == 0)
                {
                    tp.Add(new Torre(1, lin, col));
                }
                else
                {
                    tp.Remove(tp[tp.Count - 1]);
                }
                break;
            case 8:
                if (t == 0)
                {
                    db.Add(new Dama(0, lin, col));
                }
                else
                {
                    db.Remove(db[db.Count - 1]);
                }
                break;
            case 9:
                if (t == 0)
                {
                    dp.Add(new Dama(1, lin, col));
                }
                else
                {
                    dp.Remove(dp[dp.Count - 1]);
                }
                break;
            default:
                break;
        }
    }


    public bool IsEnd
    {
        get
        {
            return isEnd;
        }
        set
        {
            isEnd = value;
        }
    }
    public bool EnPassant
    {
        get
        {
            return enPassant;
        }
        set
        {
            enPassant = value;
        }
    }
    public bool getEnPassant()
    {
        return enPassant;
    }
    public List<Peao> getPb()
    {
        return pb;
    }
    public List<Peao> getPp()
    {
        return pp;
    }
    public List<Cavalo> getCb()
    {
        return cb;
    }
    public List<Cavalo> getCp()
    {
        return cp;
    }
    public List<Bispo> getBb()
    {
        return bb;
    }
    public List<Bispo> getBp()
    {
        return bp;
    }
    public List<Torre> getTb()
    {
        return tb;
    }
    public List<Torre> getTp()
    {
        return tp;
    }
    public List<Dama> getDb()
    {
        return db;
    }
    public List<Dama> getDp()
    {
        return dp;
    }
    public Rei getReiBranco()
    {
        return reiBranco;
    }
    public Rei getReiPreto()
    {
        return reiPreto;
    }

    public void setPb(List<Peao> pb)
    {
        this.pb = pb;
    }
    public void setPp(List<Peao> pp)
    {
        this.pp = pp;
    }
    public void setCb(List<Cavalo> cb)
    {
        this.cb = cb;
    }
    public void setCp(List<Cavalo> cp)
    {
        this.cp = cp;
    }
    public void setReiBranco(Rei reiBranco)
    {
        this.reiBranco = reiBranco;
    }
    public void setReiPreto(Rei reiPreto)
    {
        this.reiPreto = reiPreto;
    }
    public void setBb(List<Bispo> bb)
    {
        this.bb = bb;
    }
    public void setBp(List<Bispo> bp)
    {
        this.bp = bp;
    }
    public void setTb(List<Torre> tb)
    {
        this.tb = tb;
    }
    public void setTp(List<Torre> tp)
    {
        this.tp = tp;
    }
    public void setDb(List<Dama> db)
    {
        this.db = db;
    }
    public void setDp(List<Dama> dp)
    {
        this.dp = dp;
    }

    public void isEnPassant()
    {
        enPassant = true;
    }

    private void InitiateCavalo()
    {
        cb = new List<Cavalo>();
        cp = new List<Cavalo>();
        cb.Add(new Cavalo(0, 0, 1));
        cb.Add(new Cavalo(0, 0, 6));
        cp.Add(new Cavalo(1, 7, 1));
        cp.Add(new Cavalo(1, 7, 6));
    }

    private void InitiateBispo()
    {
        bb = new List<Bispo>();
        bp = new List<Bispo>();
        bb.Add(new Bispo(0, 0, 2));
        bb.Add(new Bispo(0, 0, 5));
        bp.Add(new Bispo(1, 7, 2));
        bp.Add(new Bispo(1, 7, 5));
    }

    private void InitiateTorre()
    {
        tb = new List<Torre>();
        tp = new List<Torre>();
        tb.Add(new Torre(0, 0, 0));
        tb.Add(new Torre(0, 0, 7));
        tp.Add(new Torre(1, 7, 0));
        tp.Add(new Torre(1, 7, 7));

    }

    public int AnalizePeaoLinha(int vez)
    {
        if (vez == 0)
        {
            for (int i = 0; i < pb.Count; i++)
            {
                if (pb[i].Linha() == 7)
                {
                    return i;
                }
            }
        }
        else
        {
            for (int i = 0; i < pp.Count; i++)
            {
                if (pp[i].Linha() == 0)
                {
                    return i;
                }
            }
        }
        return -1;
    }

    public void makeTransformPromotion(int a, int index, int cor)
    {
        if (cor == 0)
        {
            if (a == 1)
            {
                db.Add(new Dama(0, pb[index].Linha(), pb[index].Coluna()));
            }
            else if (a == 2)
            {
                tb.Add(new Torre(0, pb[index].Linha(), pb[index].Coluna()));
            }
            else if (a == 3)
            {
                bb.Add(new Bispo(0, pb[index].Linha(), pb[index].Coluna()));
            }
            else if (a == 4)
            {
                cb.Add(new Cavalo(0, pb[index].Linha(), pb[index].Coluna()));
            }
            pb.Remove(pb[index]);
        }
        else
        {
            if (a == 1)
            {
                dp.Add(new Dama(1, pp[index].Linha(), pp[index].Coluna()));
            }
            else if (a == 2)
            {
                tp.Add(new Torre(1, pp[index].Linha(), pp[index].Coluna()));
            }
            else if (a == 3)
            {
                bp.Add(new Bispo(1, pp[index].Linha(), pp[index].Coluna()));
            }
            else if (a == 4)
            {
                cp.Add(new Cavalo(1, pp[index].Linha(), pp[index].Coluna()));
            }
            pp.Remove(pp[index]);
        }
    }

    public bool PositionisEmpty(int lin, int col)
    {
        for (int i = 0; i < pb.Count; i++)
        {
            if (pb[i].isPosition(lin, col))
            {
                return false;
            }
        }
        for (int i = 0; i < pp.Count; i++)
        {
            if (pp[i].isPosition(lin, col))
            {
                return false;
            }
        }

        for (int i = 0; i < cb.Count; i++)
        {
            if (cb[i].isPosition(lin, col))
            {
                return false;
            }
        }
        for (int i = 0; i < cp.Count; i++)
        {
            if (cp[i].isPosition(lin, col))
            {
                return false;
            }
        }
        for (int i = 0; i < bb.Count; i++)
        {
            if (bb[i].isPosition(lin, col))
            {
                return false;
            }
        }
        for (int i = 0; i < bp.Count; i++)
        {
            if (bp[i].isPosition(lin, col))
            {
                return false;
            }
        }
        for (int i = 0; i < tb.Count; i++)
        {
            if (tb[i].isPosition(lin, col))
            {
                return false;
            }
        }
        for (int i = 0; i < tp.Count; i++)
        {
            if (tp[i].isPosition(lin, col))
            {
                return false;
            }
        }
        for (int i = 0; i < db.Count; i++)
        {
            if (db[i].isPosition(lin, col))
            {
                return false;
            }
        }
        for (int i = 0; i < dp.Count; i++)
        {
            if (dp[i].isPosition(lin, col))
            {
                return false;
            }
        }
        if (reiBranco.isPosition(lin, col))
        {
            return false;
        }
        if (reiPreto.isPosition(lin, col))
        {
            return false;
        }
        return true;
    }

    public bool PositionisEmptyBranco(int lin, int col, int type)
    {
        //type==1 -> remove
        for (int i = 0; i < pb.Count; i++)
        {
            if (pb[i].isPosition(lin, col))
            {
                if (type == 1)
                {
                    pecaMoveCheck = 0;
                    pb.Remove(pb[i]);
                }
                return false;
            }
        }
        for (int i = 0; i < cb.Count; i++)
        {
            if (cb[i].isPosition(lin, col))
            {
                if (type == 1)
                {
                    pecaMoveCheck = 1;
                    cb.Remove(cb[i]);
                }
                return false;
            }
        }
        for (int i = 0; i < bb.Count; i++)
        {
            if (bb[i].isPosition(lin, col))
            {
                if (type == 1)
                {
                    pecaMoveCheck = 2;
                    bb.Remove(bb[i]);
                }
                return false;
            }
        }
        for (int i = 0; i < tb.Count; i++)
        {
            if (tb[i].isPosition(lin, col))
            {
                if (type == 1)
                {
                    pecaMoveCheck = 3;
                    tb.Remove(tb[i]);
                }
                return false;
            }
        }
        for (int i = 0; i < db.Count; i++)
        {
            if (db[i].isPosition(lin, col))
            {
                if (type == 1)
                {
                    pecaMoveCheck = 4;
                    db.Remove(db[i]);
                }
                return false;
            }
        }
        if (reiBranco.isPosition(lin, col))
        {
            return false;
        }
        return true;
    }

    public bool PositionisEmptyPreto(int lin, int col, int type)
    {
        for (int i = 0; i < pp.Count; i++)
        {
            if (pp[i].isPosition(lin, col))
            {
                if (type == 1)
                {
                    pecaMoveCheck = 5;
                    pp.Remove(pp[i]);
                }
                return false;
            }
        }
        for (int i = 0; i < cp.Count; i++)
        {
            if (cp[i].isPosition(lin, col))
            {
                if (type == 1)
                {
                    pecaMoveCheck = 6;
                    cp.Remove(cp[i]);
                }
                return false;
            }
        }
        for (int i = 0; i < bp.Count; i++)
        {
            if (bp[i].isPosition(lin, col))
            {
                if (type == 1)
                {
                    pecaMoveCheck = 7;
                    bp.Remove(bp[i]);
                }
                return false;
            }
        }
        for (int i = 0; i < tp.Count; i++)
        {
            if (tp[i].isPosition(lin, col))
            {
                if (type == 1)
                {
                    pecaMoveCheck = 8;
                    tp.Remove(tp[i]);
                }
                return false;
            }
        }
        for (int i = 0; i < dp.Count; i++)
        {
            if (dp[i].isPosition(lin, col))
            {
                if (type == 1)
                {
                    pecaMoveCheck = 9;
                    dp.Remove(dp[i]);
                }
                return false;
            }
        }
        if (reiPreto.isPosition(lin, col))
        {
            return false;
        }
        return true;
    }

    public void ReecolockPeca(int lin, int col)
    {
        switch (pecaMoveCheck)
        {
            case 0:
                pb.Add(new Peao(0, lin, col));
                break;
            case 1:
                cb.Add(new Cavalo(0, lin, col));
                break;
            case 2:
                bb.Add(new Bispo(0, lin, col));
                break;
            case 3:
                tb.Add(new Torre(0, lin, col));
                break;
            case 4:
                db.Add(new Dama(0, lin, col));
                break;
            case 5:
                pp.Add(new Peao(1, lin, col));
                break;
            case 6:
                cp.Add(new Cavalo(1, lin, col));
                break;
            case 7:
                bp.Add(new Bispo(1, lin, col));
                break;
            case 8:
                tp.Add(new Torre(1, lin, col));
                break;
            case 9:
                dp.Add(new Dama(1, lin, col));
                break;
        }
        pecaMoveCheck = -1;
    }

    public bool isAfogamento(int vez)
    {
        int c = 0;
        if (vez == 0)
        {
            c = 1;
        }
        if (c == 0)
        {
            if (reiBranco.isCheck(this))
            {
                return false;
            }
            for (int i = 0; i < pb.Count; i++)
            {
                if (pb[i].AnalizeMoviment(this))
                {
                    return false;
                }
            }
            for (int i = 0; i < cb.Count; i++)
            {
                if (cb[i].AnalizeMoviment(this))
                {
                    return false;
                }
            }
            for (int i = 0; i < bb.Count; i++)
            {
                if (bb[i].AnalizeMoviment(this))
                {
                    return false;
                }
            }
            for (int i = 0; i < tb.Count; i++)
            {
                if (tb[i].AnalizeMoviment(this))
                {
                    return false;
                }
            }
            for (int i = 0; i < db.Count; i++)
            {
                if (db[i].AnalizeMovimentisAfog(this))
                {
                    return false;
                }
            }
            return !reiBranco.AnalizeMoviment(this);
        }
        else
        {
            if (reiPreto.isCheck(this))
            {
                return false;
            }
            for (int i = 0; i < pp.Count; i++)
            {
                if (pp[i].AnalizeMoviment(this))
                {
                    return false;
                }
            }
            for (int i = 0; i < cp.Count; i++)
            {
                if (cp[i].AnalizeMoviment(this))
                {
                    return false;
                }
            }
            for (int i = 0; i < bp.Count; i++)
            {
                if (bp[i].AnalizeMoviment(this))
                {
                    return false;
                }
            }
            for (int i = 0; i < tp.Count; i++)
            {
                if (tp[i].AnalizeMoviment(this))
                {
                    return false;
                }
            }
            for (int i = 0; i < dp.Count; i++)
            {
                if (dp[i].AnalizeMovimentisAfog(this))
                {
                    return false;
                }
            }
            return !reiPreto.AnalizeMoviment(this);
        }
    }

    private bool isCkeckMate(int cor)
    {
        if (cor == 0)
        {
            return reiBranco.isCheckMate(this);
        }
        else
        {
            return reiPreto.isCheckMate(this);
        }
    }

    public bool isMoveCheck(int lin, int col, int cor, int l, int c)
    {
        if (isPosition(lin, col))
        {
            return ToMove(lin, col, cor, l, c);
        }
        return false;
    }

    public int getPositionPecaId(int lin, int col)
    {
        for (int i = 0; i < pb.Count; i++)
        {
            if (pb[i].isPosition(lin, col))
            {
                return 0;
            }
        }
        for (int i = 0; i < pp.Count; i++)
        {
            if (pp[i].isPosition(lin, col))
            {
                return 1;
            }
        }
        for (int i = 0; i < cb.Count; i++)
        {
            if (cb[i].isPosition(lin, col))
            {
                return 2;
            }
        }
        for (int i = 0; i < cp.Count; i++)
        {
            if (cp[i].isPosition(lin, col))
            {
                return 3;
            }
        }
        for (int i = 0; i < bb.Count; i++)
        {
            if (bb[i].isPosition(lin, col))
            {
                return 4;
            }
        }
        for (int i = 0; i < bp.Count; i++)
        {
            if (bp[i].isPosition(lin, col))
            {
                return 5;
            }
        }
        for (int i = 0; i < tb.Count; i++)
        {
            if (tb[i].isPosition(lin, col))
            {
                return 6;
            }
        }
        for (int i = 0; i < tp.Count; i++)
        {
            if (tp[i].isPosition(lin, col))
            {
                return 7;
            }
        }
        for(int i=0;i<db.Count;i++)
        {
            if(db[i].isPosition(lin,col))
            {
                return 8;
            }
        }
        for (int i = 0; i < dp.Count; i++)
        {
            if (dp[i].isPosition(lin, col))
            {
                return 9;
            }
        }
        if(reiBranco.isPosition(lin,col))
        {
            return 10;
        }
        if(reiPreto.isPosition(lin,col))
        {
            return 11;
        }
        return -1;
    }

    public string getPositionPeca(int lin, int col)
    {
        for (int i = 0; i < pb.Count; i++)
        {
            if (pb[i].isPosition(lin, col))
            {
                return "PB";
            }
        }
        for (int i = 0; i < pp.Count; i++)
        {
            if (pp[i].isPosition(lin, col))
            {
                return "PP";
            }
        }
        for (int i = 0; i < cb.Count; i++)
        {
            if (cb[i].isPosition(lin, col))
            {
                return "CB";
            }
        }
        for (int i = 0; i < cp.Count; i++)
        {
            if (cp[i].isPosition(lin, col))
            {
                return "CP";
            }
        }
        for (int i = 0; i < bb.Count; i++)
        {
            if (bb[i].isPosition(lin, col))
            {
                return "BB";
            }
        }
        for (int i = 0; i < bp.Count; i++)
        {
            if (bp[i].isPosition(lin, col))
            {
                return "BP";
            }
        }
        for (int i = 0; i < tb.Count; i++)
        {
            if (tb[i].isPosition(lin, col))
            {
                return "TB";
            }
        }
        for (int i = 0; i < tp.Count; i++)
        {
            if (tp[i].isPosition(lin, col))
            {
                return "TP";
            }
        }
        return "";
    }

    private bool OtherPossibiltyAnalyze()
    {
        return false;
    }

    public bool isCheckMateReiEndGame(int cor)
    {
        if (cor == 0)
        {
            if (reiPreto.isCheckMate(this) == false)
            {
                sit = "CHECK MATE. BRANCO VENCEU";
                return true;
            }
        }
        else
        {
            if (reiBranco.isCheckMate(this) == false)
            {
                sit = "CHECK MATE. PRETO VENCEU";
                return true;
            }
        }
        return false;
    }

    //lin E col == POSIÇÃO DE ORIGEM // l E c == POSIÇÃO DE DESTINO
    public bool isMove(int lin, int col, int cor, int l, int c)
    {
        if(isEnd)
        {
            return false;
        }
        if (isPosition(lin, col))
        {
            if (reiBranco.isCheck(this) || reiPreto.isCheck(this))
            {
                Debug.Log("REI EM CHECK");
                if (PositionisEmpty(l, c))
                {
                    bool ok = ToMove(lin, col, cor, l, c);
                    if (reiBranco.isCheck(this) || reiPreto.isCheck(this))
                    {
                        if (ok)
                        {
                            DesMove(lin, col, cor);
                        }
                        return false;
                    }
                    else
                    {

                        return true;
                    }
                }
                else
                {
                    
                    bool ok = ToMove(lin, col, cor, l, c);
                    if (reiBranco.isCheck(this) || reiPreto.isCheck(this))
                    {
                        if (ok)
                        {
                            DesMove(lin, col, cor);
                        }
                        ReecolockPeca(l, c);
                        return false;
                    }
                    return true;
                }
            }
            else
            {
                return ToMove(lin, col, cor, l, c);
            }
        }
        else
        {
            return false;
        }
    }

    private bool DesMove(int lin, int col, int cor)
    {
        if (typePecaMove == 0 && cor == 0)
        {
            pb[indexDesmove].setColuna(col);
            pb[indexDesmove].setLinha(lin);
        }
        else if (typePecaMove == 1 && cor == 0)
        {
            cb[indexDesmove].setColuna(col);
            cb[indexDesmove].setLinha(lin);
        }
        else if (typePecaMove == 2 && cor == 0)
        {
            bb[indexDesmove].setColuna(col);
            bb[indexDesmove].setLinha(lin);
        }
        else if (typePecaMove == 3 && cor == 0)
        {
            tb[indexDesmove].setColuna(col);
            tb[indexDesmove].setLinha(lin);
        }
        else if (typePecaMove == 4 && cor == 0)
        {
            db[indexDesmove].setColuna(col);
            db[indexDesmove].setLinha(lin);
        }
        else if (typePecaMove == 5 && cor == 0)
        {

        }
        else if (typePecaMove == 0 && cor == 1)
        {
            pp[indexDesmove].setColuna(col);
            pp[indexDesmove].setLinha(lin);
        }
        else if (typePecaMove == 1 && cor == 1)
        {
            cp[indexDesmove].setColuna(col);
            cp[indexDesmove].setLinha(lin);
        }
        else if (typePecaMove == 2 && cor == 1)
        {
            bp[indexDesmove].setColuna(col);
            bp[indexDesmove].setLinha(lin);
        }
        else if (typePecaMove == 3 && cor == 1)
        {
            tp[indexDesmove].setColuna(col);
            tp[indexDesmove].setLinha(lin);
        }
        else if (typePecaMove == 4 && cor == 1)
        {
            dp[indexDesmove].setColuna(col);
            dp[indexDesmove].setLinha(lin);
        }
        else if (typePecaMove == 5 && cor == 1)
        {

        }
        return true;
    }

    public bool isPossibleToMovePromotion(int v,int linOr,int colOr,int linDes,int colDes,int i)
    {
        bool ok = true;
        //v==cor
        if(v==0)
        {
            pb[i].setLinha(linDes);
            pb[i].setColuna(colDes);
            if(reiBranco.isCheck(this))
            {
                ok = false;
            }
            pb[i].setLinha(linOr);
            pb[i].setColuna(colOr);
        }
        else
        {
            pp[i].setLinha(linDes);
            pp[i].setColuna(colDes);
            if (reiPreto.isCheck(this))
            {
                ok = false;
            }
            pp[i].setLinha(linOr);
            pp[i].setColuna(colOr);
        }
        return ok;
    }
    public void MovePromotion(int type,int cor, int index,int linOr, int colOr, int linDes,int colDes)
    {
        //type==0-> promoção de peao sem eliminar nenhum peça inimiga
        //type==1-> promoção de peao eliminando peça inimiga
        if(cor==0)
        {
            pb[index].setLinha(linDes);
            if(type==1)
            {
                PositionisEmptyPreto(7, colDes, 1);
                pb[index].setColuna(colDes);
                if(reiBranco.isCheck(this))
                {
                    ReecolockPeca(7,colDes);
                    pb[index].setColuna(colOr);
                    pb[index].setLinha(linOr);
                }
            }
            else if(type==0 && reiBranco.isCheck(this))
            {
                pb[index].setLinha(linOr);
            }
        }
        else
        {
            pp[index].setLinha(linDes);
            if(type==1)
            {
                PositionisEmptyBranco(0,colDes,1);
                pp[index].setColuna(colDes);
                if(reiPreto.isCheck(this))
                {
                    ReecolockPeca(0,colDes);
                    pp[index].setColuna(colOr);
                    pp[index].setLinha(linOr);
                }
            }
            else if(type==0 && reiPreto.isCheck(this))
            {
                pp[index].setLinha(linOr);
            }
        }
    }
    public void Promotion(int index,int cor,int lin,int col,int type)
    {
        if(cor==0)
        {
            pb.Remove(pb[index]);
            switch (type)
            {
                case 0:
                    db.Add(new Dama(cor,lin,col));
                    break;
                case 1:
                    tb.Add(new Torre(cor, lin, col));
                    break;
                case 2:
                    bb.Add(new Bispo(cor, lin, col));
                    break;
                case 3:
                    cb.Add(new Cavalo(cor, lin, col));
                    break;
            }
        }
        else
        {
            pp.Remove(pp[index]);
            switch (type)
            {
                case 0:
                    dp.Add(new Dama(cor, lin, col));
                    break;
                case 1:
                    tp.Add(new Torre(cor, lin, col));
                    break;
                case 2:
                    bp.Add(new Bispo(cor, lin, col));
                    break;
                case 3:
                    cp.Add(new Cavalo(cor, lin, col));
                    break;
            }
        }
    }

    private bool ToMove(int lin, int col, int cor, int l, int c)
    {
        bool ok = false;
        if (cor == 0)
        {
            if (typePecaMove == 0)
            {
                for (int i = 0; i < pb.Count; i++)
                {
                    if (pb[i].isPosition(lin, col))
                    {
                        indexDesmove = i;
                        bool x = pb[i].IsMove(l, c, this);
                        return x;
                    }
                }
            }
            else if (typePecaMove == 1)
            {
                for (int i = 0; i < cb.Count; i++)
                {
                    if (cb[i].isPosition(lin, col))
                    {
                        indexDesmove = i;
                        return cb[i].IsMove(l, c, this);
                    }
                }
            }
            else if (typePecaMove == 2)
            {
                for (int i = 0; i < bb.Count; i++)
                {
                    if (bb[i].isPosition(lin, col))
                    {
                        indexDesmove = i;
                        return bb[i].IsMove(l, c, this);
                    }
                }
            }
            else if (typePecaMove == 3)
            {
                for (int i = 0; i < tb.Count; i++)
                {
                    if (tb[i].isPosition(lin, col))
                    {
                        indexDesmove = i;
                        return tb[i].IsMove(l, c, this);
                    }
                }
            }
            else if (typePecaMove == 4)
            {
                for (int i = 0; i < db.Count; i++)
                {
                    if (db[i].isPosition(lin, col))
                    {
                        indexDesmove = i;
                        return db[i].IsMove(l, c, this);
                    }
                }
            }
            else if (typePecaMove == 5)
            {
                return reiBranco.isMove(l, c, this);
            }
        }
        else if (cor == 1)
        {
            if (typePecaMove == 0)
            {
                for (int i = 0; i < pp.Count; i++)
                {
                    if (pp[i].isPosition(lin, col))
                    {
                        indexDesmove = i;
                        bool x = pp[i].IsMove(l, c, this);
                        if (x && pp[i].Linha() == 0)
                        {
                            pp.Remove(pp[i]);
                            dp.Add(new Dama(1, l, c));
                            return true;
                        }
                        return x;
                    }
                }
            }
            else if (typePecaMove == 1)
            {
                for (int i = 0; i < cp.Count; i++)
                {
                    if (cp[i].isPosition(lin, col))
                    {
                        indexDesmove = i;
                        return cp[i].IsMove(l, c, this);
                    }
                }
            }
            else if (typePecaMove == 2)
            {
                for (int i = 0; i < bp.Count; i++)
                {
                    if (bp[i].isPosition(lin, col))
                    {
                        indexDesmove = i;
                        return bp[i].IsMove(l, c, this);
                    }
                }
            }
            else if (typePecaMove == 3)
            {
                for (int i = 0; i < tp.Count; i++)
                {
                    if (tp[i].isPosition(lin, col))
                    {
                        indexDesmove = i;
                        return tp[i].IsMove(l, c, this);
                    }
                }
            }
            else if (typePecaMove == 4)
            {
                for (int i = 0; i < dp.Count; i++)
                {
                    if (dp[i].isPosition(lin, col))
                    {
                        indexDesmove = i;
                        return dp[i].IsMove(l, c, this);
                    }
                }
            }
            else if (typePecaMove == 5)
            {
                return reiPreto.isMove(l, c, this);
            }
        }
        return ok;
    }

    //analiza se a posição está ocupada e defini qual a peça que a ocupa
    private bool isPosition(int lin, int col)
    {
        for (int i = 0; i < pb.Count; i++)
        {
            if (pb[i].isPosition(lin, col))
            {
                typePecaMove = 0;
                return true;
            }
        }
        for (int i = 0; i < pp.Count; i++)
        {
            if (pp[i].isPosition(lin, col))
            {
                typePecaMove = 0;
                return true;
            }
        }
        for (int i = 0; i < cb.Count; i++)
        {
            if (cb[i].isPosition(lin, col))
            {
                typePecaMove = 1;
                return true;
            }
        }
        for (int i = 0; i < cp.Count; i++)
        {
            if (cp[i].isPosition(lin, col))
            {
                typePecaMove = 1;
                return true;
            }
        }
        for (int i = 0; i < bb.Count; i++)
        {
            if (bb[i].isPosition(lin, col))
            {
                typePecaMove = 2;
                return true;
            }
        }
        for (int i = 0; i < bp.Count; i++)
        {
            if (bp[i].isPosition(lin, col))
            {
                typePecaMove = 2;
                return true;
            }
        }
        for (int i = 0; i < tb.Count; i++)
        {
            if (tb[i].isPosition(lin, col))
            {
                typePecaMove = 3;
                return true;
            }
        }
        for (int i = 0; i < tp.Count; i++)
        {
            if (tp[i].isPosition(lin, col))
            {
                typePecaMove = 3;
                return true;
            }
        }
        for (int i = 0; i < db.Count; i++)
        {
            if (db[i].isPosition(lin, col))
            {
                typePecaMove = 4;
                return true;
            }
        }
        for (int i = 0; i < dp.Count; i++)
        {
            if (dp[i].isPosition(lin, col))
            {
                typePecaMove = 4;
                return true;
            }
        }
        if (reiBranco.isPosition(lin, col))
        {
            typePecaMove = 5;
            return true;
        }
        if (reiPreto.isPosition(lin, col))
        {
            typePecaMove = 5;
            return true;
        }
        return false;
    }

    public void Imprex()
    {
        Debug.Log("BRANCO");
        Debug.Log("PEAO");
        for (int i = 0; i < pb.Count; i++)
        {
            Debug.Log(pb[i].Linha() + "" + pb[i].Coluna());
            Debug.Log(" ");
        }
        Debug.Log("");
        Debug.Log("CAVALO");
        for (int i = 0; i < cb.Count; i++)
        {
            Debug.Log(cb[i].getLinha() + "" + cb[i].getColuna());
            Debug.Log(" ");
        }
        Debug.Log("");
        Debug.Log("BISPO");
        for (int i = 0; i < bb.Count; i++)
        {
            Debug.Log(bb[i].getLinha() + "" + bb[i].getColuna());
            Debug.Log(" ");
        }
        Debug.Log("");
        Debug.Log("TORRE");
        for (int i = 0; i < tb.Count; i++)
        {
            Debug.Log(tb[i].getLinha() + "" + tb[i].getColuna());
            Debug.Log(" ");
        }
        Debug.Log("");
        Debug.Log("DAMA");
        for (int i = 0; i < db.Count; i++)
        {
            Debug.Log(db[i].getLinha() + "" + db[i].getColuna());
            Debug.Log(" ");
        }
        Debug.Log("REI BRANCO " + reiBranco.getLinha() + "" + reiBranco.getColuna());
        Debug.Log("");

        Debug.Log("");

        Debug.Log("PRETO");
        Debug.Log("PEAO");
        for (int i = 0; i < pp.Count; i++)
        {
            Debug.Log(pp[i].Linha() + "" + pp[i].Coluna());
            Debug.Log(" ");
        }
        Debug.Log("");
        Debug.Log("CAVALO");
        for (int i = 0; i < cp.Count; i++)
        {
            Debug.Log(cp[i].getLinha() + "" + cp[i].getColuna());
            Debug.Log(" ");
        }
        Debug.Log("");
        Debug.Log("BISPO");
        for (int i = 0; i < bp.Count; i++)
        {
            Debug.Log(bp[i].getLinha() + "" + bp[i].getColuna());
            Debug.Log(" ");
        }
        Debug.Log("");
        Debug.Log("TORRE");
        for (int i = 0; i < tp.Count; i++)
        {
            Debug.Log(tp[i].getLinha() + "" + tp[i].getColuna());
            Debug.Log(" ");
        }
        Debug.Log("");
        Debug.Log("DAMA");
        for (int i = 0; i < dp.Count; i++)
        {
            Debug.Log(dp[i].getLinha() + "" + dp[i].getColuna());
            Debug.Log(" ");
        }
        Debug.Log("REI Preto " + reiPreto.getLinha() + "" + reiPreto.getColuna());
        Debug.Log("");
        Debug.Log(sit);
    }
}
