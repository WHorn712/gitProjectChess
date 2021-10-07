using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cavalo
{
	private int cor;
	private int linha;
	private int coluna;

	public Cavalo(int c, int lin, int col)
	{
		cor = c;
		linha = lin;
		coluna = col;
	}

	public void setLinha(int l)
	{
		linha = l;
	}
	public void setColuna(int c)
	{
		coluna = c;
	}
	public int getColuna()
	{
		return coluna;
	}
	public int getLinha()
	{
		return linha;
	}
	public int getCor()
	{
		return cor;
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

	public bool AllMovimentPossible(Tabuleiro tab)
	{
		if (AnalizeMoviment(linha + 2, coluna - 1, tab))
		{
			return true;
		}
		else if (AnalizeMoviment(linha + 1, coluna - 2, tab))
		{
			return true;
		}
		else if (AnalizeMoviment(linha - 1, coluna - 2, tab))
		{
			return true;
		}
		else if (AnalizeMoviment(linha - 2, coluna - 1, tab))
		{
			return true;
		}
		else if (AnalizeMoviment(linha - 2, coluna + 1, tab))
		{
			return true;
		}
		else if (AnalizeMoviment(linha - 1, coluna + 2, tab))
		{
			return true;
		}
		else if (AnalizeMoviment(linha + 1, coluna + 2, tab))
		{
			return true;
		}
		else if (AnalizeMoviment(linha + 2, coluna + 1, tab))
		{
			return true;
		}
		return false;
	}

	private bool AnalizeMoviment(int l, int c, Tabuleiro tab)
	{
		bool ok = false;
		Rei r;
		if (cor == 0)
		{
			r = tab.getReiBranco();
		}
		else
		{
			r = tab.getReiPreto();
		}
		if (tab.PositionisEmpty(l, c))
		{
			ok = AnalizeCheckRei(l, c, r, tab);
		}
		else
		{
			if (cor == 0)
			{
				if (tab.PositionisEmptyPreto(l, c, 1) == false)
				{
					ok = AnalizeCheckRei(l, c, r, tab);
					tab.ReecolockPeca(l, c);
				}
			}
			else
			{
				if (tab.PositionisEmptyBranco(l, c, 1) == false)
				{
					ok = AnalizeCheckRei(l, c, r, tab);
					tab.ReecolockPeca(l, c);
				}
			}
		}
		return ok;
	}

	private bool AnalizeCheckRei(int l, int c, Rei r, Tabuleiro tab)
	{
		bool ok = true;
		int lin = linha;
		int col = coluna;
		linha = l;
		coluna = c;
		ok = true;
		if (r.isCheck(tab))
		{
			ok = false;
		}
		linha = lin;
		coluna = col;
		return ok;
	}

	public bool AnalizeMoviment(Tabuleiro t)
	{
		if (AnalizePosition(linha + 2, coluna - 1, t))
		{
			return true;
		}
		if (AnalizePosition(linha + 1, coluna - 2, t))
		{
			return true;
		}
		if (AnalizePosition(linha - 1, coluna - 2, t))
		{
			return true;
		}
		if (AnalizePosition(linha - 2, coluna - 1, t))
		{
			return true;
		}
		if (AnalizePosition(linha - 2, coluna + 1, t))
		{
			return true;
		}
		if (AnalizePosition(linha - 1, coluna + 2, t))
		{
			return true;
		}
		if (AnalizePosition(linha + 1, coluna + 2, t))
		{
			return true;
		}
		if (AnalizePosition(linha + 2, coluna + 1, t))
		{
			return true;
		}
		return false;
	}

	private bool AnalizePosition(int lin, int col, Tabuleiro t)
	{
		if (t.PositionisEmpty(lin, col))
		{
			return true;
		}
		if (cor == 0)
		{
			if (t.PositionisEmptyPreto(lin, col, 0) == false)
			{
				return true;
			}
		}
		else
		{
			if (t.PositionisEmptyBranco(lin, col, 0) == false)
			{
				return true;
			}
		}
		return false;
	}

	private bool MovimentoPadron(int lin, int col)
	{
		if (linha - 2 == lin && coluna - 1 == col)
		{
			return true;
		}
		else if (linha - 1 == lin && coluna - 2 == col)
		{
			return true;
		}
		else if (linha + 1 == lin && coluna - 2 == col)
		{
			return true;
		}
		else if (linha + 2 == lin && coluna - 1 == col)
		{
			return true;
		}
		else if (linha + 2 == lin && coluna + 1 == col)
		{
			return true;
		}
		else if (linha + 1 == lin && coluna + 2 == col)
		{
			return true;
		}
		else if (linha - 1 == lin && coluna + 2 == col)
		{
			return true;
		}
		else if (linha - 2 == lin && coluna + 1 == col)
		{
			return true;
		}
		else
		{
			return false;
		}
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

	public bool isCheckRei(int lin, int col)
	{
		return MovimentoPadron(lin, col);
	}

	public bool IsMove(int lin, int col, Tabuleiro tab)
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
		if (MovimentoPadron(lin, col))
		{
			return isCapture(lin, col, tab);
		}
		else
		{
			return false;
		}
	}

	private bool isCapture(int lin, int col, Tabuleiro tab)
	{
		int a = linha;
		int b = coluna;
		if (cor == 0)
		{
			if (!tab.PositionisEmptyPreto(lin, col, 1))
			{
				ToMakeMoviment(lin, col);
				if (AnalizeReiCheck(a, b, tab) == false)
				{
					tab.ReecolockPeca(lin, col);
					return false;
				}
				return true;
			}
			else if (tab.PositionisEmpty(lin, col))
			{
				ToMakeMoviment(lin, col);
				if (AnalizeReiCheck(a, b, tab) == false)
				{
					return false;
				}
				return true;
			}
			else
			{
				return false;
			}
		}
		else
		{
			if (!tab.PositionisEmptyBranco(lin, col, 1))
			{
				ToMakeMoviment(lin, col);
				if (AnalizeReiCheck(a, b, tab) == false)
				{
					tab.ReecolockPeca(lin, col);
					return false;
				}
				return true;
			}
			else if (tab.PositionisEmpty(lin, col))
			{
				ToMakeMoviment(lin, col);
				if (AnalizeReiCheck(a, b, tab) == false)
				{
					return false;
				}
				return true;
			}
			else
			{
				return false;
			}
		}
	}

	private void ToMakeMoviment(int l, int c)
	{
		linha = l;
		coluna = c;
	}
}
