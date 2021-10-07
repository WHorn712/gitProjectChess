using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dama
{
	private int cor;
	private int linha;
	private int coluna;

	public Dama(int c, int lin, int col)
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
	public int getCor()
	{
		return cor;
	}
	public int getLinha()
	{
		return linha;
	}

	//TODOS OS MOVIMENTOS EM HORIZONTAIS E VERTICAIS
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

	private bool AnalizeMoviment(int l, int c, Tabuleiro t)
	{
		int c2 = linha;
		int d = coluna;
		Rei r;
		if (cor == 0)
		{
			r = t.getReiBranco();
		}
		else
		{
			r = t.getReiPreto();
		}
		int y = 0;
		bool ok = true;
		bool x = true;
		while (x)
		{
			y++;
			int a = linha + l;
			int b = coluna + c;
			if (t.PositionisEmpty(a, b))
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
			else if (ok == false && y == 7)
			{
				x = false;
			}
		}
		linha = c2;
		coluna = d;
		return ok;
	}

	private bool AnalizeCheckRei(int a, int b, Rei r, Tabuleiro t)
	{
		bool ok = false;
		linha = a;
		coluna = b;
		if (r.isCheck(t))
		{
			ok = true;
		}
		return ok;
	}

	//TODOS OS MOVIMENTOS NA DIAGONAL
	public bool AllMovimentPossibleBis(Tabuleiro tab)
	{
		if (AnaliseMovimentBis(+1, -1, tab) == false)
		{
			return true;
		}
		if (AnaliseMovimentBis(+1, +1, tab) == false)
		{
			return true;
		}
		if (AnaliseMovimentBis(-1, +1, tab) == false)
		{
			return true;
		}
		if (AnaliseMovimentBis(-1, -1, tab) == false)
		{
			return true;
		}
		return false;
	}

	private bool AnaliseMovimentBis(int l, int c, Tabuleiro t)
	{
		int c2 = linha;
		int d = coluna;
		Rei r;
		if (cor == 0)
		{
			r = t.getReiBranco();
		}
		else
		{
			r = t.getReiPreto();
		}
		int y = 0;
		bool ok = true;
		bool x = true;
		while (x)
		{
			y++;
			int a = linha + l;
			int b = coluna + c;
			if (t.PositionisEmpty(a, b))
			{
				ok = AnalizeCheckReiBis(a, b, r, t);
			}
			else
			{
				if (cor == 0)
				{
					if (t.PositionisEmptyPreto(a, b, 1) == false)
					{
						ok = AnalizeCheckReiBis(a, b, r, t);
						t.ReecolockPeca(a, b);
					}
				}
				else
				{
					if (t.PositionisEmptyBranco(a, b, 1) == false)
					{
						ok = AnalizeCheckReiBis(a, b, r, t);
						t.ReecolockPeca(a, b);
					}
				}
				y = 7;
			}
			if (ok)
			{
				x = false;
			}
			else if (ok == false && y == 7)
			{
				x = false;
			}
		}
		linha = c2;
		coluna = d;
		return ok;
	}

	private bool AnalizeCheckReiBis(int a, int b, Rei r, Tabuleiro t)
	{
		bool ok = false;
		linha = a;
		coluna = b;
		if (r.isCheck(t))
		{
			ok = true;
		}
		return ok;
	}

	public bool AnalizeMovimentisAfog(Tabuleiro tab)
	{
		Bispo b = new Bispo(cor, linha, coluna);
		Torre t = new Torre(cor, linha, coluna);
		if (b.AnalizeMoviment(tab))
		{
			return true;
		}
		if (t.AnalizeMoviment(tab))
		{
			return true;
		}
		return false;
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

	public bool isMovimentPadron(int lin, int col, Tabuleiro tab)
	{
		Torre t = new Torre(cor, linha, coluna);
		Bispo b = new Bispo(cor, linha, coluna);
		if (t.IsMovimentPadron(lin, col, tab, 0))
		{
			return true;
		}
		else if (b.isMovimentPadron(lin, col, tab, 0))
		{
			return true;
		}
		return false;
	}

	public bool IsMove(int lin, int col, Tabuleiro tab)
	{
		Torre t = new Torre(cor, linha, coluna);
		Bispo b = new Bispo(cor, linha, coluna);
		if (t.IsMove(lin, col, tab))
		{
			linha = lin;
			coluna = col;
			return true;
		}
		else if (b.IsMove(lin, col, tab))
		{
			linha = lin;
			coluna = col;
			return true;
		}
		else
		{
			return false;
		}
	}
}
