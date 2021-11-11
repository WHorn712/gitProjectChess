using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rei
{
	private int cor;
	private int linha;
	private int coluna;
	private bool isRoque;

	List<Peca> peca = new List<Peca>();

	//noCheck==-1 ; peao==0 ; cavalo==1 ; bispo==2 ; torre==3 ; dama==4
	private List<int> typeCheck=new List<int>();
	private List<int> indexPeca=new List<int>();

	public Rei(int c, int lin, int col)
	{
		cor = c;
		linha = lin;
		coluna = col;
		isRoque = true;
	}

	public void setLinha(int l)
	{
		linha = l;
	}
	public void setColuna(int c)
	{
		coluna = c;
	}

	public bool getIsRoque()
	{
		return isRoque;
	}
	public int getColuna()
	{
		return coluna;
	}
	public int getCor()
	{
		return cor;
	}
	public int getLinha()
	{
		return linha;
	}

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

	public bool isCheck(Tabuleiro tab)
	{
		bool ok = false;
		typeCheck.Clear();
		indexPeca.Clear();
		peca.Clear();
		if (cor == 0)
		{
			for (int i = 0; i < tab.getPp().Count; i++)
			{
				if (tab.getPp()[i].isCheckRei(linha, coluna))
				{
					peca.Add(new Peca(tab.getPp()[i].Linha(), tab.getPp()[i].Coluna(), 0, 1));
					indexPeca.Add(i);
					typeCheck.Add(0);
					ok = true;
				}
			}
            for (int i = 0; i < tab.getCp().Count; i++)
            {
                if (tab.getCp()[i].isCheckRei(linha, coluna))
                {
					peca.Add(new Peca(tab.getCp()[i].getLinha(), tab.getCp()[i].getColuna(), 1, 1));
					indexPeca.Add(i);
					typeCheck.Add(1);
					ok = true;
				}
            }
            for (int i = 0; i < tab.getBp().Count; i++)
            {
                if (tab.getBp()[i].isMovimentPadron(linha, coluna, tab, 1))
                {
					peca.Add(new Peca(tab.getBp()[i].getLinha(), tab.getBp()[i].getColuna(), 2, 1));
					indexPeca.Add(i);
					typeCheck.Add(2);
					ok = true;
				}
            }
            for (int i = 0; i < tab.getTp().Count; i++)
            {
                if (tab.getTp()[i].IsMovimentPadron(linha, coluna, tab, 1))
                {
					peca.Add(new Peca(tab.getTp()[i].getLinha(), tab.getTp()[i].getColuna(), 3, 1));
					indexPeca.Add(i);
					typeCheck.Add(3);
					ok = true;
				}
            }
            for (int i = 0; i < tab.getDp().Count; i++)
            {
                if (tab.getDp()[i].isMovimentPadron(linha, coluna, tab))
                {
					peca.Add(new Peca(tab.getDp()[i].getLinha(), tab.getDp()[i].getColuna(), 4, 1));
					indexPeca.Add(i);
					typeCheck.Add(4);
					ok = true;
				}
            }
        }
		else if (cor == 1)
		{
			for (int i = 0; i < tab.getPb().Count; i++)
			{
				if (tab.getPb()[i].isCheckRei(linha, coluna))
				{
					peca.Add(new Peca(tab.getPb()[i].Linha(), tab.getPb()[i].Coluna(), 0, 0));
					indexPeca.Add(i);
					typeCheck.Add(0);
					ok = true;
				}
			}
            for (int i = 0; i < tab.getCb().Count; i++)
            {
                if (tab.getCb()[i].isCheckRei(linha, coluna))
                {
					peca.Add(new Peca(tab.getCb()[i].getLinha(), tab.getCb()[i].getColuna(), 1, 0));
					indexPeca.Add(i);
					typeCheck.Add(1);
					ok = true;
				}
            }
            for (int i = 0; i < tab.getBb().Count; i++)
            {
                if (tab.getBb()[i].isMovimentPadron(linha, coluna, tab, 1))
                {
					peca.Add(new Peca(tab.getBb()[i].getLinha(), tab.getBb()[i].getColuna(), 2, 0));
					indexPeca.Add(i);
					typeCheck.Add(2);
					ok = true;
				}
            }
            for (int i = 0; i < tab.getTb().Count; i++)
            {
                if (tab.getTb()[i].IsMovimentPadron(linha, coluna, tab, 1))
                {
					peca.Add(new Peca(tab.getTb()[i].getLinha(), tab.getTb()[i].getColuna(), 3, 0));
					indexPeca.Add(i);
					typeCheck.Add(3);
					ok = true;
				}
            }
            for (int i = 0; i < tab.getDb().Count; i++)
            {
                if (tab.getDb()[i].isMovimentPadron(linha, coluna, tab))
                {
					peca.Add(new Peca(tab.getDb()[i].getLinha(), tab.getDb()[i].getColuna(), 4, 0));
					indexPeca.Add(i);
					typeCheck.Add(4);
					ok = true;
				}
            }
        }
		return ok;
	}

	private bool isPossibleNoCheck(Tabuleiro tab, int l, int c)
	{
		if (isReiDominate(l, c, tab))
		{
			return false;
		}
		if (CheckPossible(l, c) == false)
		{
			return false;
		}
		bool ok = false;
		if (tab.PositionisEmpty(l, c))
		{
			ok = isCkeckReiMoviment(l, c, tab);
		}
		else
		{
			if (cor == 0)
			{
				if (tab.PositionisEmptyPreto(l, c, 1) == false)
				{
					ok = isCkeckReiMoviment(l, c, tab);
					tab.ReecolockPeca(l, c);
				}
			}
			else
			{
				if (tab.PositionisEmptyBranco(l, c, 1) == false)
				{
					ok = isCkeckReiMoviment(l, c, tab);
					tab.ReecolockPeca(l, c);
				}
			}
		}
		return ok;
	}

	public bool isReiDominate(int lin, int col, Tabuleiro tab)
	{
		if (cor == 0)
		{
			if (tab.getReiPreto().getLinha() == lin && tab.getReiPreto().getColuna() - 1 == col)
			{
				return true;
			}
			else if (tab.getReiPreto().getLinha() - 1 == lin && tab.getReiPreto().getColuna() - 1 == col)
			{
				return true;
			}
			else if (tab.getReiPreto().getLinha() - 1 == lin && tab.getReiPreto().getColuna() == col)
			{
				return true;
			}
			else if (tab.getReiPreto().getLinha() - 1 == lin && tab.getReiPreto().getColuna() + 1 == col)
			{
				return true;
			}
			else if (tab.getReiPreto().getLinha() == lin && tab.getReiPreto().getColuna() + 1 == col)
			{
				return true;
			}
			else if (tab.getReiPreto().getLinha() + 1 == lin && tab.getReiPreto().getColuna() + 1 == col)
			{
				return true;
			}
			else if (tab.getReiPreto().getLinha() + 1 == lin && tab.getReiPreto().getColuna() == col)
			{
				return true;
			}
			else if (tab.getReiPreto().getLinha() + 1 == lin && tab.getReiPreto().getColuna() - 1 == col)
			{
				return true;
			}
		}
		else
		{
			if (tab.getReiBranco().getLinha() == lin && tab.getReiBranco().getColuna() - 1 == col)
			{
				return true;
			}
			else if (tab.getReiBranco().getLinha() - 1 == lin && tab.getReiBranco().getColuna() - 1 == col)
			{
				return true;
			}
			else if (tab.getReiBranco().getLinha() - 1 == lin && tab.getReiBranco().getColuna() == col)
			{
				return true;
			}
			else if (tab.getReiBranco().getLinha() - 1 == lin && tab.getReiBranco().getColuna() + 1 == col)
			{
				return true;
			}
			else if (tab.getReiBranco().getLinha() == lin && tab.getReiBranco().getColuna() + 1 == col)
			{
				return true;
			}
			else if (tab.getReiBranco().getLinha() + 1 == lin && tab.getReiBranco().getColuna() + 1 == col)
			{
				return true;
			}
			else if (tab.getReiBranco().getLinha() + 1 == lin && tab.getReiBranco().getColuna() == col)
			{
				return true;
			}
			else if (tab.getReiBranco().getLinha() + 1 == lin && tab.getReiBranco().getColuna() - 1 == col)
			{
				return true;
			}
		}
		return false;
	}

	private bool isCkeckReiMoviment(int l, int c, Tabuleiro tab)
	{
		bool ok = true;
		int a = linha;
		int b = coluna;
		linha = l;
		coluna = c;
		if (isCheck(tab))
		{
			ok = false;
		}
		linha = a;
		coluna = b;
		return ok;
	}

	//retorna true se tem chance, false se não tem chance
	public bool isCheckMate(Tabuleiro t)
	{
		if (AllMovimentRei(t))
		{
			return true;
		}
		//else
		//{
		//	if (cor == 0)
		//	{
		//		for (int i = 0; i < t.getPb().Count; i++)
		//		{
		//			if (t.getPb()[i].AnalizeAllMoviments(t))
		//			{
		//				return true;
		//			}
		//		}
  //              for (int i = 0; i < t.getCb().Count; i++)
  //              {
  //                  if (t.getCb()[i].AllMovimentPossible(t))
  //                  {
  //                      return true;
  //                  }
  //              }
  //              for (int i = 0; i < t.getBb().Count; i++)
  //              {
  //                  if (t.getBb()[i].AllMovimentPossible(t))
  //                  {
  //                      return true;
  //                  }
  //              }
  //              for (int i = 0; i < t.getTb().Count; i++)
  //              {
  //                  if (t.getTb()[i].AllMovimentPossible(t))
  //                  {
  //                      return true;
  //                  }
  //              }
  //              for (int i = 0; i < t.getDb().Count; i++)
  //              {
  //                  if (t.getDb()[i].AllMovimentPossible(t))
  //                  {
  //                      return true;
  //                  }
  //              }
  //          }
		//	else
		//	{
		//		for (int i = 0; i < t.getPp().Count; i++)
		//		{
		//			if (t.getPp()[i].AnalizeAllMoviments(t))
		//			{
		//				return true;
		//			}
		//		}
		//		Debug.Log("pp");
  //              for (int i = 0; i < t.getCp().Count; i++)
  //              {
  //                  if (t.getCp()[i].AllMovimentPossible(t))
  //                  {
  //                      return true;
  //                  }
  //              }
		//		Debug.Log("cp");
		//		for (int i = 0; i < t.getBp().Count; i++)
  //              {
  //                  if (t.getBp()[i].AllMovimentPossible(t))
  //                  {
  //                      return true;
  //                  }
  //              }
		//		Debug.Log("bp");
		//		for (int i = 0; i < t.getTp().Count; i++)
  //              {
  //                  if (t.getTp()[i].AllMovimentPossible(t))
  //                  {
  //                      return true;
  //                  }
  //              }
		//		Debug.Log("tp");
		//		for (int i = 0; i < t.getDp().Count; i++)
  //              {
  //                  if (t.getDp()[i].AllMovimentPossible(t))
  //                  {
  //                      return true;
  //                  }
  //              }
		//		Debug.Log("dp");
		//	}
		//}

		isCheck(t);
		if(peca.Count==1)
        {
			if (peca[0].HimEliminator(t))
			{
				return true;
			}
			return peca[0].PutToFace(this, t);
		}
		return false;
	}

	//Método para fazer o rock
	//type==1->roque curto    type==2->roque grande
	public bool toMakeRoque(int type, Tabuleiro t)
	{
		if (isRoque)
		{
			return CompletingRoque(type, t);
		}
		return false;
	}

	private bool CompletingRoque(int type, Tabuleiro t)
	{
		if (AnalizeIsRoque(t, type) && isCheck(t) == false)
		{
			if (type == 1)
			{
				if (cor == 0)
				{
                    if (t.PositionisEmpty(linha, coluna + 1) && t.PositionisEmpty(linha, coluna + 2) && t.getTb()[1].isPosition(0, 7))
                    {
                        toMakeMovimentRoque(linha, coluna + 2, 0, t.getTb()[1].getColuna() - 2, 1, t);
                        return true;
                    }
                }
				else
				{
                    if (t.PositionisEmpty(linha, coluna + 1) && t.PositionisEmpty(linha, coluna + 2) && t.getTp()[1].isPosition(7, 7))
                    {
                        toMakeMovimentRoque(linha, coluna + 2, 7, t.getTp()[1].getColuna() - 2, 1, t);
                        return true;
                    }
                }
            }
            else
            {
                if (cor == 0)
                {
                    if (t.PositionisEmpty(linha, coluna - 1) && t.PositionisEmpty(linha, coluna - 2) && t.getTb()[0].isPosition(0, 0) && t.PositionisEmpty(linha, coluna - 3))
                    {
                        toMakeMovimentRoque(linha, coluna - 2, 0, t.getTb()[0].getColuna() + 3, 0, t);
                        return true;
                    }
                }
                else
                {
                    if (t.PositionisEmpty(linha, coluna - 1) && t.PositionisEmpty(linha, coluna - 2) && t.getTp()[0].isPosition(7, 0) && t.PositionisEmpty(linha, coluna - 3))
                    {
                        toMakeMovimentRoque(linha, coluna - 2, 7, t.getTp()[0].getColuna() + 3, 0, t);
                        return true;
                    }
                }
			}
		}
		return false;
	}

	private void toMakeMovimentRoque(int l, int c, int lt, int ct, int index, Tabuleiro t)
	{
		linha = l;
		coluna = c;
        if (cor == 0)
        {
            t.getTb()[index].setLinha(lt);
            t.getTb()[index].setColuna(ct);
        }
        else
        {
            t.getTp()[index].setLinha(lt);
            t.getTp()[index].setColuna(ct);
        }
    }

	private bool AnalizeIsRoque(Tabuleiro t, int roq)
	{
		if (cor == 0)
		{
			if (roq == 1)
			{
				if (AnalizeMovimentRoque(0, 5, t) == false)
				{
					Debug.Log("compelting roque = 0,5");
					return false;
				}
				if (AnalizeMovimentRoque(0, 6, t) == false)
				{
					Debug.Log("compelting roque = 0,6");
					return false;
				}
			}
			else
			{
				if (AnalizeMovimentRoque(0, 2, t) == false)
				{
					return false;
				}
				if (AnalizeMovimentRoque(0, 3, t) == false)
				{
					return false;
				}
			}
		}
		else
		{
			if (roq == 1)
			{
				if (AnalizeMovimentRoque(7, 5, t) == false)
				{
					return false;
				}
				if (AnalizeMovimentRoque(7, 6, t) == false)
				{
					return false;
				}
			}
			else
			{
				if (AnalizeMovimentRoque(7, 2, t) == false)
				{
					return false;
				}
				if (AnalizeMovimentRoque(7, 3, t) == false)
				{
					return false;
				}
			}
		}
		return true;
	}

	private bool AnalizeMovimentRoque(int l, int c, Tabuleiro t)
	{
		if (Moviment(t, l, c, 1, 1, 0) == false)
		{
			return false;
		}
		if (Moviment(t, l, c, 1, -1, 1) == false)
		{
			return false;
		}
		if (Moviment(t, l, c, 1, 0, 2) == false)
		{
			return false;
		}
		if (Moviment(t, l, c, -1, 1, 3) == false)
		{
			return false;
		}
		if (Moviment(t, l, c, -1, -1, 4) == false)
		{
			return false;
		}
		if (Moviment(t, l, c, -1, 0, 5) == false)
		{
			return false;
		}
		if (AnalizeMovimentCavalo(l, c, t))
		{
			return false;
		}
		return true;
	}

	public bool isMove(int lin, int col, Tabuleiro tab)
	{
		if (CheckPossible(lin, col))
		{
			return isMovimentSimple(lin, col, tab);
		}
		else
		{
			return false;
		}
	}

	private bool isMovimentSimple(int lin, int col, Tabuleiro tab)
	{
		if (isReiDominate(lin, col, tab))
		{
			return false;
		}
		else
		{
			if (linha + 1 == lin && coluna - 1 == col)
			{
				return isFreeCaminho(lin, col, tab);
			}
			else if (linha == lin && coluna - 1 == col)
			{
				return isFreeCaminho(lin, col, tab);
			}
			else if (linha - 1 == lin && coluna - 1 == col)
			{
				return isFreeCaminho(lin, col, tab);
			}
			else if (linha - 1 == lin && coluna == col)
			{
				return isFreeCaminho(lin, col, tab);
			}
			else if (linha - 1 == lin && coluna + 1 == col)
			{
				return isFreeCaminho(lin, col, tab);
			}
			else if (linha == lin && coluna + 1 == col)
			{
				return isFreeCaminho(lin, col, tab);
			}
			else if (linha + 1 == lin && coluna + 1 == col)
			{
				return isFreeCaminho(lin, col, tab);
			}
			else if (linha + 1 == lin && coluna == col)
			{
				return isFreeCaminho(lin, col, tab);
			}
			if (coluna == 4 && (linha == 0 || linha == 7))
			{
				if (coluna + 2 == col)
				{
					return toMakeRoque(1, tab);
				}
				else if (coluna - 2 == col)
				{
					return toMakeRoque(2, tab);
				}
			}
		}
		return false;
	}

	private bool isFreeCaminho(int lin, int col, Tabuleiro tab)
	{
		if (tab.PositionisEmpty(lin, col))
		{
			int a = linha;
			int b = coluna;
			toMakeMoviment(lin, col);
			if (isCheck(tab))
			{
				toMakeMoviment(a, b);
				isRoque = true;
				return false;
			}
			return true;
		}
		if (cor == 0)
		{
			if (!tab.PositionisEmptyPreto(lin, col, 1))
			{
				int a = linha;
				int b = coluna;
				toMakeMoviment(lin, col);
				if (isCheck(tab))
				{
					toMakeMoviment(a, b);
					isRoque = true;
					tab.ReecolockPeca(lin, col);
					return false;
				}
				return true;
			}
		}
		else
		{
			if (!tab.PositionisEmptyBranco(lin, col, 1))
			{
				int a = linha;
				int b = coluna;
				toMakeMoviment(lin, col);
				if (isCheck(tab))
				{
					toMakeMoviment(a, b);
					isRoque = true;
					tab.ReecolockPeca(lin, col);
					return false;
				}
				return true;
			}
		}
		return false;
	}

	private void toMakeMoviment(int lin, int col)
	{
		linha = lin;
		coluna = col;
		isRoque = false;
	}

	public bool AnalizeMoviment(Tabuleiro t)
	{
		if (AnalizePosition(linha + 1, coluna - 1, t))
		{
			return true;
		}
		if (AnalizePosition(linha, coluna - 1, t))
		{
			return true;
		}
		if (AnalizePosition(linha - 1, coluna - 1, t))
		{
			return true;
		}
		if (AnalizePosition(linha - 1, coluna, t))
		{
			return true;
		}
		if (AnalizePosition(linha - 1, coluna + 1, t))
		{
			return true;
		}
		if (AnalizePosition(linha, coluna + 1, t))
		{
			return true;
		}
		if (AnalizePosition(linha + 1, coluna + 1, t))
		{
			return true;
		}
		if (AnalizePosition(linha + 1, coluna, t))
		{
			return true;
		}
		return false;
	}

	private bool AnalizePosition(int lin, int col, Tabuleiro t)
	{
		if (CheckPossible(lin, col) == false)
		{
			return false;
		}
		if (t.PositionisEmpty(lin, col))
		{
			return AnalizePositionIsCheck(lin, col, t);
		}
		if (cor == 0)
		{
			if (t.PositionisEmptyPreto(lin, col, 1) == false)
			{
				bool ok = AnalizePositionIsCheck(lin, col, t);
				t.ReecolockPeca(lin, col);
				if (ok)
				{
					return true;
				}
			}
		}
		else
		{
			if (t.PositionisEmptyBranco(lin, col, 1) == false)
			{
				bool ok = AnalizePositionIsCheck(lin, col, t);
				t.ReecolockPeca(lin, col);
				if (ok)
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool AnalizePositionIsCheck(int lin, int col, Tabuleiro t)
	{
		int a = linha;
		int b = coluna;
		linha = lin;
		coluna = col;
		if (isCheck(t))
		{
			linha = a;
			coluna = b;
			return false;
		}
		linha = a;
		coluna = b;
		return true;
	}

	private bool AnalizeMovimentCavalo(int l, int c, Tabuleiro t)
	{
		if (MovimentCavalo(l + 2, c - 1, t))
		{
			return true;
		}
		if (MovimentCavalo(l + 1, c - 2, t))
		{
			return true;
		}
		if (MovimentCavalo(l - 1, c - 2, t))
		{
			return true;
		}
		if (MovimentCavalo(l - 2, c - 1, t))
		{
			return true;
		}
		if (MovimentCavalo(l - 2, c + 1, t))
		{
			return true;
		}
		if (MovimentCavalo(l - 1, c + 2, t))
		{
			return true;
		}
		if (MovimentCavalo(l + 1, c + 2, t))
		{
			return true;
		}
		if (MovimentCavalo(l + 2, c + 1, t))
		{
			return true;
		}
		return false;
	}

	private bool MovimentCavalo(int l, int c, Tabuleiro t)
	{
		if (cor == 0)
		{
            for (int i = 0; i < t.getCp().Count; i++)
            {
                if (t.getCp()[i].isPosition(l, c))
                {
                    return true;
                }
            }
        }
		else
		{
            for (int i = 0; i < t.getCb().Count; i++)
            {
                if (t.getCb()[i].isPosition(l, c))
                {
                    return true;
                }
            }
        }
		return false;
	}

	//Moviment -> analisa todas as jogadas de um movimento
	private bool Moviment(Tabuleiro t, int l, int c, int a, int b, int type)
	{
		int x = l + a;
		int y = c + b;
		int z = 0;
		bool ok = true;
		while (ok || z == 7)
		{
			if (CheckPossible(x, y))
			{
				bool d = AnalizePositionRoque(t, x, y, type, z);
				if (d)
				{
					return false;
				}
				else
				{
					if (cor == 0)
					{
						if (t.PositionisEmptyBranco(x, y, 0) == false)
						{
							return true;
						}
					}
					else
					{
						if (t.PositionisEmptyPreto(x, y, 0) == false)
						{
							return true;
						}
					}
				}
			}
			else
			{
				ok = false;
			}
			z++;
			x = x + a;
			y = y + b;
		}
		return true;
	}

	private bool AnalizePositionRoque(Tabuleiro t, int l, int c, int type, int z)
	{
		if (type == 0 || type == 1 || type == 3 || type == 4)
		{
			if (cor == 0)
			{
				if (z == 0)
				{
					for (int i = 0; i < t.getPp().Count; i++)
					{
						if (t.getPp()[i].isPosition(l, c))
						{
							return true;
						}
					}
				}
                for (int i = 0; i < t.getBp().Count; i++)
                {
                    if (t.getBp()[i].isPosition(l, c))
                    {
                        return true;
                    }
                }
            }
			else
			{
				if (z == 0)
				{
					for (int i = 0; i < t.getPb().Count; i++)
					{
						if (t.getPb()[i].isPosition(l, c))
						{
							return true;
						}
					}
				}
                for (int i = 0; i < t.getBb().Count; i++)
                {
                    if (t.getBb()[i].isPosition(l, c))
                    {
                        return true;
                    }
                }
            }
        }
        else if (type == 2 || type == 5)
        {
            if (cor == 0)
            {
                for (int i = 0; i < t.getTp().Count; i++)
                {
                    if (t.getTp()[i].isPosition(l, c))
                    {
                        return true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < t.getTb().Count; i++)
                {
                    if (t.getTb()[i].isPosition(l, c))
                    {
                        return true;
                    }
                }
            }
        }
        if (cor == 0)
        {
            for (int i = 0; i < t.getDp().Count; i++)
            {
                if (t.getDp()[i].isPosition(l, c))
                {
                    return true;
                }
            }
        }
        else
        {
            for (int i = 0; i < t.getDb().Count; i++)
            {
                if (t.getDb()[i].isPosition(l, c))
                {
                    return true;
                }
            }
        }
		return false;
	}

	private bool AllMovimentRei(Tabuleiro t)
	{
		if (isPossibleNoCheck(t, linha - 1, coluna - 1))
		{
			return true;
		}
		else if (isPossibleNoCheck(t, linha - 1, coluna))
		{
			return true;
		}
		else if (isPossibleNoCheck(t, linha - 1, coluna + 1))
		{
			return true;
		}
		else if (isPossibleNoCheck(t, linha, coluna + 1))
		{
			return true;
		}
		else if (isPossibleNoCheck(t, linha + 1, coluna + 1))
		{
			return true;
		}
		else if (isPossibleNoCheck(t, linha + 1, coluna))
		{
			return true;
		}
		else if (isPossibleNoCheck(t, linha + 1, coluna - 1))
		{
			return true;
		}
		else if (isPossibleNoCheck(t, linha, coluna - 1))
		{
			return true;
		}
		return false;
	}
}
