using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre
{
	private int cor;
	private int linha;
	private int coluna;
	private int type;

	public Torre(int c, int lin, int col)
	{
		type = 0;
		cor = c;
		linha = lin;
		coluna = col;
	}
	public Torre()
	{

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

	public bool CheckPossible(int l, int c)
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
		return IsMovimentPadron(lin, col, tab, 0);
	}

	public bool IsMovimentPadron(int lin, int col, Tabuleiro tab, int t)
	{
		for (int i = 1; i < 8; i++)
		{
			if (linha + i == lin && coluna == col)
			{
				type = 0;
				return SeparationIsMP(lin, col, type, tab, 1, 0, t);
			}
		}
		for (int i = 1; i < 8; i++)
		{
			if (coluna + i == col && linha == lin)
			{
				type = 1;
				return SeparationIsMP(lin, col, type, tab, 0, 1, t);
			}
		}
		for (int i = 1; i < 8; i++)
		{
			if (linha - i == lin && coluna == col)
			{
				type = 2;
				return SeparationIsMP(lin, col, type, tab, -1, 0, t);
			}
		}
		for (int i = 1; i < 8; i++)
		{
			if (coluna - i == col && linha == lin)
			{
				type = 3;
				return SeparationIsMP(lin, col, type, tab, 0, -1, t);
			}
		}
		return false;
	}

	private bool SeparationIsMP(int lin, int col, int ty, Tabuleiro t, int a, int b, int tipo)
	{
		if (tipo == 0)
		{
			return FreePositionST(lin, col, ty, t);
		}
		else
		{
			return GetAnalizePositionCheckRei(lin, col, a, b, t);
		}
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

	public bool AnalizeMoviment(Tabuleiro t)
	{
		if (AnalizePosition(linha, coluna + 1, t))
		{
			return true;
		}
		if (AnalizePosition(linha, coluna - 1, t))
		{
			return true;
		}
		if (AnalizePosition(linha + 1, coluna, t))
		{
			return true;
		}
		if (AnalizePosition(linha - 1, coluna, t))
		{
			return true;
		}
		return false;
	}

	private bool AnalizeCheckRei(int a, int b, Rei r, Tabuleiro t)
	{
		bool ok = true;
		linha = a;
		coluna = b;
		if (r.isCheck(t))
		{
			ok = false;
		}
		return ok;
	}

	public bool AllMovimentPossible(Tabuleiro tab)
	{
		if (AnalizeMoviment(+1, 0, tab) == false)
		{
			return true;
		}
		if (AnalizeMoviment(0, +1, tab) == false)
		{
			return true;
		}
		if (AnalizeMoviment(-1, 0, tab) == false)
		{
			return true;
		}
		if (AnalizeMoviment(0, -1, tab) == false)
		{
			return true;
		}
		return false;
	}

	private bool AnalizeMoviment(int l,int c,Tabuleiro t)
	{
		int c2=linha;
		int d=coluna;
		Rei r;
		if(cor==0)
		{
			r=t.getReiBranco();
		}
		else
		{
			r=t.getReiPreto();
		}
		bool ok=true;
		int y = 0;
		bool x = true;
		while (x)
		{
			y++;
			int a = linha + l;
			int b = coluna + c;
			if (CheckPossible(a, b) == false)
			{
				ok = true;
				x = false;
			}
			else if (t.PositionisEmpty(a, b))
			{
				ok = AnalizeCheckRei(a, b, r, t);
			}
			else
			{
				if (cor == 0)
				{
					if (t.PositionisEmptyPreto(a, b, 1) == false)
					{
						ok = AnalizeCheckRei(a, b, r, t);
						t.ReecolockPeca(a, b);
					}
				}
				else
				{
					if (t.PositionisEmptyBranco(a, b, 1) == false)
					{
						ok = AnalizeCheckRei(a, b, r, t);
						t.ReecolockPeca(a, b);
					}
				}
				y = 7;
			}
			if (ok)
			{
				x = false;
			}
			else if (y == 7)
			{
				x = false;
			}
		}
		linha =c2;
		coluna=d;
		return !ok;
	}

	private bool GetAnalizePositionCheckRei(int lin, int col, int a, int b, Tabuleiro t)
	{
		int c = linha;
		int d = coluna;
		int x = linha + a;
		int y = coluna + b;
		int z = 0;
		while (z <= 7)
		{
			if (t.PositionisEmpty(x, y))
			{
				x = x + a;
				y = y + b;
			}
			else
			{
				if (x == lin && y == col)
				{
					return true;
				}
			}
			z++;
		}
		return false;
	}

	private void ToMakeMoviment(int lin, int col)
	{
		linha = lin;
		coluna = col;
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

	private bool FreePositionST(int lin, int col, int type, Tabuleiro tab)
	{
		int x = linha;
		int b = coluna;
		int a = 1;
		if (type == 0)
		{
			while (a != 0)
			{
				if (tab.PositionisEmpty(linha + a, coluna))
				{
					if (linha + a == lin && coluna == col)
					{
						linha = lin;
						coluna = col;
						if (AnalizeReiCheck(x, b, tab) == false)
						{
							return false;
						}
						return true;
					}
					else
					{
						a++;
					}
				}
				else
				{
					if (linha + a == lin && coluna == col)
					{
						if (cor == 0)
						{
							if (!tab.PositionisEmptyPreto(lin, col, 1))
							{
								linha = lin;
								coluna = col;
								if (AnalizeReiCheck(x, b, tab) == false)
								{
									tab.ReecolockPeca(lin, col);
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
								linha = lin;
								coluna = col;
								if (AnalizeReiCheck(x, b, tab) == false)
								{
									tab.ReecolockPeca(lin, col);
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
					else
					{
						return false;
					}
				}
			}
		}
		else if (type == 1)
		{
			while (a != 0)
			{
				if (tab.PositionisEmpty(linha, coluna + a))
				{
					if (linha == lin && coluna + a == col)
					{
						linha = lin;
						coluna = col;
						if (AnalizeReiCheck(x, b, tab) == false)
						{
							return false;
						}
						return true;
					}
					else
					{
						a++;
					}
				}
				else
				{
					if (linha == lin && coluna + a == col)
					{
						if (cor == 0)
						{
							if (!tab.PositionisEmptyPreto(lin, col, 1))
							{
								linha = lin;
								coluna = col;
								if (AnalizeReiCheck(x, b, tab) == false)
								{
									tab.ReecolockPeca(lin, col);
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
								linha = lin;
								coluna = col;
								if (AnalizeReiCheck(x, b, tab) == false)
								{
									tab.ReecolockPeca(lin, col);
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
					else
					{
						return false;
					}
				}
			}
		}
		else if (type == 2)
		{
			while (a != 0)
			{
				if (tab.PositionisEmpty(linha - a, coluna))
				{
					if (linha - a == lin && coluna == col)
					{
						linha = lin;
						coluna = col;
						if (AnalizeReiCheck(x, b, tab) == false)
						{
							return false;
						}
						return true;
					}
					else
					{
						a++;
					}
				}
				else
				{
					if (linha - a == lin && coluna == col)
					{
						if (cor == 0)
						{
							if (!tab.PositionisEmptyPreto(lin, col, 1))
							{
								linha = lin;
								coluna = col;
								if (AnalizeReiCheck(x, b, tab) == false)
								{
									tab.ReecolockPeca(lin, col);
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
								linha = lin;
								coluna = col;
								if (AnalizeReiCheck(x, b, tab) == false)
								{
									tab.ReecolockPeca(lin, col);
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
					else
					{
						return false;
					}
				}
			}
		}
		else if (type == 3)
		{
			while (a != 0)
			{
				if (tab.PositionisEmpty(linha, coluna - a))
				{
					if (linha == lin && coluna - a == col)
					{
						linha = lin;
						coluna = col;
						if (AnalizeReiCheck(x, b, tab) == false)
						{
							return false;
						}
						return true;
					}
					else
					{
						a++;
					}
				}
				else
				{
					if (linha == lin && coluna - a == col)
					{
						if (cor == 0)
						{
							if (!tab.PositionisEmptyPreto(lin, col, 1))
							{
								linha = lin;
								coluna = col;
								if (AnalizeReiCheck(x, b, tab) == false)
								{
									tab.ReecolockPeca(lin, col);
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
								linha = lin;
								coluna = col;
								if (AnalizeReiCheck(x, b, tab) == false)
								{
									tab.ReecolockPeca(lin, col);
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
					else
					{
						return false;
					}
				}
			}
		}
		return false;
	}
}
