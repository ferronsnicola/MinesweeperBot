using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper {
	class Controller {
		private MainForm _mainForm;
		private int _rows;
		private int _cols;
		private int _remainingMines;
		private List<List<Cella>> _frontiere;

		public Controller (MainForm mainForm) {
			_mainForm = mainForm;
			_mainForm.AutoPlay.Click += AutoPlay;
			_mainForm.EasyBtn.Click += EasyBtnClick;
			_mainForm.MediumBtn.Click += MediumBtnClick;
			_mainForm.HardBtn.Click += HardBtnClick;
			_mainForm.MostraFrontiera.Click += ResetFrontiere;
			_mainForm.MostraFrontiera.Click += MostraFrontiereEsterne;
		}

		private void ResetFrontiere(object sender, EventArgs e) {
			foreach (Control c in _mainForm.Grid.Controls) {
				Cella cella = (Cella)c;
				cella.BackColor = _mainForm.EasyBtn.BackColor;
			}
		}

		private void MostraFrontiereEsterne(object sender, EventArgs e) {
			_frontiere = GetFrontiereEsterne2();
			Console.WriteLine("TROVATE " + _frontiere.Count + " FRONTIERE INDIPENDENTI");
			List<Color> colors = new List<Color>();
			Random r = new Random();

			for (int i=0; i<50; i++) {
				colors.Add(Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256)));
			}

			int index = 0;
			foreach (List<Cella> f in _frontiere) {
				Console.WriteLine("frontiera " + index);
				index++;
				foreach (Cella c in f) {
					Console.WriteLine(c.Row + ", " + c.Col);
					c.BackColor = colors[index];
				}
			}
		}

		public bool TryPreview(Cella cliccabile, string mossa) {
			bool result = true;

			cliccabile.Text = mossa;
			foreach (Cella c in GetTouchingNumberCell(cliccabile)) {
				result = result && TestPreview(c);
			}
			cliccabile.Text = "";

			return result;
		}

		private bool TestPreview(Cella c) {
			bool result = true;

			result = result && (GetTouchingBomb(c.Row, c.Col) <= Int32.Parse(c.Text)); // il numero di bombe che tocca sia <= del numero di bombe che dovrebbe toccare
			result = result && (GetTouchingFree(c.Row, c.Col) + GetTouchingBomb(c.Row, c.Col) >= Int32.Parse(c.Text)); // con le celle libere sia possibile arrivare al numero di bombe da toccare

			return result;
		}

		private void MostraFrontiereInterne(object sender, EventArgs e) {
			_frontiere = GetFrontiereInterne();
			Console.WriteLine("TROVATE " + _frontiere.Count + " FRONTIERE INDIPENDENTI");
			List<Color> colors = new List<Color>();
			Random r = new Random();

			for (int i = 0; i < 50; i++) {
				colors.Add(Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256)));
			}

			int index = 0;
			foreach (List<Cella> f in _frontiere) {
				Console.WriteLine("frontiera " + index);
				index++;
				foreach (Cella c in f) {
					Console.WriteLine(c.Row + ", " + c.Col);
					c.BackColor = colors[index];
				}
			}
		}

		private List<List<Cella>> GetFrontiereInterne() {
			List<List<Cella>> result = new List<List<Cella>>();

			// cerco le frontiere aperte, dove è importante avere il punto di partenza
			int c = 0, r = 0 ;
			for (c=0; c<Cols; c++)
				FillFrontiereAperteInterne(result, c, r);
			for (r = 0; r < Rows; r++)
				FillFrontiereAperteInterne(result, c-1, r);
			for (c=c-1; c >= 0; c--)
				FillFrontiereAperteInterne(result, c, r-1);
			for (r=r-1; r >= 0; r--)
				FillFrontiereAperteInterne(result, c+1, r);

			// dopo aver trovato quelle aperte, trovo quelle che si chiudono su loro stesse, non importa quindi il punto di partenza
			for(c=0; c<Cols; c++) {
				for(r=0;r<Rows;r++) {
					FillFrontiereAperteInterne(result, c, r);
				}
			}

			return result;
		}

		private List<List<Cella>> GetFrontiereEsterne2() {
			List<List<Cella>> result = new List<List<Cella>>();

			// cerco le frontiere aperte, dove è importante avere il punto di partenza
			int c = 0, r = 0;
			for (c = 0; c < Cols; c++)
				FillFrontiereAperteEsterne(result, c, r);
			for (r = 0; r < Rows; r++)
				FillFrontiereAperteEsterne(result, c - 1, r);
			for (c = c - 1; c >= 0; c--)
				FillFrontiereAperteEsterne(result, c, r - 1);
			for (r = r - 1; r >= 0; r--)
				FillFrontiereAperteEsterne(result, c + 1, r);

			// dopo aver trovato quelle aperte, trovo quelle che si chiudono su loro stesse, non importa quindi il punto di partenza
			for (c = 0; c < Cols; c++) {
				for (r = 0; r < Rows; r++) {
					FillFrontiereAperteEsterne(result, c, r);
				}
			}

			return result;
		}

		private void FillFrontiereAperteEsterne(List<List<Cella>> result, int c, int r) {
			Cella cella = (Cella)_mainForm.Grid.GetControlFromPosition(c, r);
			if (cella.Enabled && GetTouchingNumbers(cella.Row, cella.Col) > 0 && cella.Text == "") {
				bool test = false;
				foreach (List<Cella> f in result)
					if (f.Contains(cella))
						test = true;

				if (!test) { // se la cella non è già contenuta in un'altra frontiera
					result.Add(new List<Cella>());
					result[result.Count - 1].Add(cella);
					FrontieraEsterna(cella, result[result.Count - 1]);
				}
			}
		}

		private void FrontieraEsterna(Cella cella, List<Cella> result) {
			Cella next = null;

			foreach (Cella c in GetAdiacentiInFrontieraEsterna(cella, result)) {
				if (GetAdiacentiInFrontieraEsterna(c, result).Count > 0 && NumeriInComune(cella, c))
					next = c;
				else if (GetAdiacentiInFrontieraEsterna(c, result).Count == 0) // lo aggiungo solo se non da vita a un altro ramo
					result.Add(c);
			}

			if (next != null) {
				result.Add(next);
				FrontieraEsterna(next, result);
			}
		}

		private bool NumeriInComune(Cella cella, Cella c) {
			bool result = false;

			foreach (Cella cell in GetTouchingNumberCell(cella)) {
				if (GetTouchingNumberCell(c).Contains(cell))
					result = true;
			}

			return result;
		}

		private List<Cella> GetAdiacentiInFrontieraEsterna(Cella cella, List<Cella> frontiera) {
			List<Cella> result = new List<Cella>();

			foreach (Cella c in GetAdiacenti(cella)) {
				if (c.Enabled && c.Text == "" && !frontiera.Contains(c) && GetTouchingNumbers(c.Row, c.Col) > 0)
					result.Add(c);
			}

			return result;
		}

		private void FillFrontiereAperteInterne(List<List<Cella>> result, int c, int r) {
			Cella cella = (Cella)_mainForm.Grid.GetControlFromPosition(c, r);
			if (!cella.Enabled && GetTouchingFree(cella.Row, cella.Col) > 0) {
				bool test = false;
				foreach (List<Cella> f in result)
					if (f.Contains(cella))
						test = true;

				if (!test) { // se la cella non è già contenuta in un'altra frontiera
					result.Add(new List<Cella>());
					result[result.Count - 1].Add(cella);
					FrontieraInterna(cella, result[result.Count - 1]);
				}
			}
		}


		private void MostraFrontiera(object sender, EventArgs e) {
			List<Cella> frontiera = new List<Cella>();
			for (int r=0; r<Rows; r++) {
				for (int c=0; c<Cols; c++) {
					Cella cella = (Cella)_mainForm.Grid.GetControlFromPosition(c, r);
					if (!cella.Enabled && GetTouchingFree(cella.Row, cella.Col) > 0 && !frontiera.Contains(cella)) {
						FrontieraInterna(cella, frontiera);
						Console.WriteLine(frontiera.Count);
						foreach(Cella cell in frontiera) {
							Console.WriteLine(cell.Row + ", " + cell.Col);
							cell.BackColor = Color.Azure;
						}
					}
				}
			}
		}

		private List<List<Cella>> GetFrontiereEsterne() {
			List<List<Cella>> result = new List<List<Cella>>();

			for (int r = 0; r < Rows; r++) {
				for (int c = 0; c < Cols; c++) {
					Cella cella = (Cella)_mainForm.Grid.GetControlFromPosition(c, r);
					if (cella.Enabled && GetTouchingNumbers(r, c) > 0 && cella.Text != "*") {
						// controllo che la cella non sia già contenuta in altre frontiere
						bool trovato = false;
						foreach (List<Cella> f in result) {
							if (f.Contains(cella)) {
								trovato = true;
							}
						}
						// se non lo trovo allora devo creare la nuova frontiera
						if (!trovato) {
							result.Add(new List<Cella>());
							GetFrontiera(cella, result[result.Count - 1]);
						}
					}
				}
			}

			return result;
		}

		private void GetFrontiera(Cella cella, List<Cella> frontiera) {
			if (frontiera.Contains(cella))
				return;
			frontiera.Add(cella);
			foreach (Cella c in GetViciniFrontiera(cella)) {
				GetFrontiera(c, frontiera);
			}
		}

		private List<Cella> GetViciniFrontiera(Cella cella) {
			List<Cella> result = new List<Cella>();

			foreach (Cella c in GetVicini(cella)) {
				if (c.Enabled && c.Text == "" && GetTouchingNumbers(c.Row, c.Col) > 0)
					result.Add(c);
			}

			return result;
		}

		public List<Cella> GetVicini(Cella cella) {
			List<Cella> result = new List<Cella>();

			for (int r = cella.Row - 1; r <= cella.Row + 1 && r < _rows; r++) {
				for (int c = cella.Col - 1; c <= cella.Col + 1 && c < _cols; c++) {
					if (r >= 0 && c >= 0)
						result.Add((Cella)_mainForm.Grid.GetControlFromPosition(c, r));
				}
			}

			return result;
		}

/*
		private List<Cella> GetFrontiera() {
			List<Cella> result = new List<Cella>();
			
			for (int r=0; r<Rows; r++) {
				for (int c=0; c<Cols; c++) {
					Cella cella = (Cella)_mainForm.Grid.GetControlFromPosition(c, r);
					if (cella.Enabled && GetTouchingNumbers(r, c)>0 && cella.Text != "*") {
						result.Add(cella);
					}
				}
			}

			List<Cella> frontiera = new List<Cella>();
			frontiera.AddRange(result);

			_frontiere = new List<List<Cella>>();
			_frontiere.Add(new List<Cella>());
			int i = 0;
			foreach (Cella c in result) {
				if (_frontiere[i].Count == 0 ) {
					_frontiere[i].Add(c); frontiera.Remove(c);
				} else {
					bool adiacente = false;
					foreach (Cella c1 in _frontiere[i]) {
						if (c.IsNextTo(c1)) {
							_frontiere[i].Add(c);
							adiacente = true;
							break;
						}
					}
					if (!adiacente) {
						bool trovato = false;
						foreach (List<Cella> f in _frontiere) {
							foreach (Cella c1 in f) {
								if (c.IsNextTo(c1)) {
									i = _frontiere.IndexOf(f);
									_frontiere[i].Add(c);
									trovato = true;
									break;
								}
							}
							if (trovato)
								break;
						}
						if (!trovato) {
							_frontiere.Add(new List<Cella>());
							i = _frontiere.Count - 1;
							_frontiere[i].Add(c);
						}
					}
				}
			}

			return result;
		}
		*/

		private List<Cella> GetAdiacenti(Cella cella) {
			List<Cella> result = new List<Cella>();

			for (int r = cella.Row - 1; r <= cella.Row + 1 && r < _rows; r++) {
				for (int c = cella.Col - 1; c <= cella.Col + 1 && c < _cols; c++) {
					if (r >= 0 && c >= 0 && (c == cella.Col || r == cella.Row)) {
						Cella cell = (Cella)_mainForm.Grid.GetControlFromPosition(c, r);
						if (cell != cella)
							result.Add(cell);
					}
				}
			}
			return result;
		}

		private List<Cella> GetAdiacentiInFrontieraInterna(Cella cella, List<Cella> frontiera) {
			List<Cella> result = new List<Cella>();

			foreach (Cella c in GetAdiacenti(cella)) {
				if (((!c.Enabled && c.Text != "0")||(c.Enabled && c.Text == "*")) && !frontiera.Contains(c) && GetTouchingFree(c.Row, c.Col) > 0)
					result.Add(c);
			}

			return result;
		}

		private void FrontieraInterna(Cella cella, List<Cella> result) {
			Cella next = null;

			foreach (Cella c in GetAdiacentiInFrontieraInterna(cella, result)) {
//				if (!result.Contains(c)) {
					if (GetAdiacentiInFrontieraInterna(c, result).Count > 0)
						next = c;
					else
						result.Add(c);
//				}
			}

			if (next != null) {
				result.Add(next);
				FrontieraInterna(next, result);
			}
		}

		/*
			result.Add(cella);

			for (int r = cella.Row - 1; r <= cella.Row + 1 && r < _rows; r++) {
				for (int c = cella.Col - 1; c <= cella.Col + 1 && c < _cols; c++) {
					if (r >= 0 && c >= 0) {
						Cella cell = (Cella)_mainForm.Grid.GetControlFromPosition(c, r); // passo tutti i vicini...
						if (!cell.Enabled && GetTouchingFree(cell.Row, cell.Col) > 0 && !result.Contains(cell)) {
							Frontiera(cell, result);
						}
					}
				}
			}
		}*/
		

		private void AutoPlay(object sender, EventArgs e) {
			IStrategy strategy = new NaiveStrategy(_mainForm, this);
			if (strategy.Play() == 0) {
				strategy = new CSPStrategy(_mainForm, this, GetFrontiereEsterne2()[0]);
				int i = 1;
				while (strategy.Play() == 0 && i<GetFrontiereEsterne2().Count) {
					strategy = new CSPStrategy(_mainForm, this, GetFrontiereEsterne2()[i]);
					i++;
				}
			}
		}

		public int RemainingMines {
			get { return _remainingMines; }
			set { _remainingMines = value; }
		}

		public int Rows {
			get { return _rows; }
			set { _rows = value; }
		}

		public int Cols {
			get { return _cols; }
			set { _cols = value; }
		}

		private void EasyBtnClick(object sender, EventArgs e) {
			UpdateGrid(9, 9, 10);
		}

		private void MediumBtnClick(object sender, EventArgs e) {
			UpdateGrid(16, 16, 40);
		}

		private void HardBtnClick(object sender, EventArgs e) {
			UpdateGrid(16, 30, 99);
		}

		private void UpdateGrid (int rows, int cols, int mines) {
			_rows = rows;
			_cols = cols;
			_mainForm.Grid.Controls.Clear();

			_mainForm.Grid.RowCount = rows;
			_mainForm.Grid.ColumnCount = cols;

			for (int i=0; i<rows; i++) {
				for (int j=0; j<cols; j++) {
					Cella cella = new Cella(0, i, j);
					_mainForm.Grid.Controls.Add(cella, j, i);
					cella.MouseClick += CellClick;
					cella.KeyPress += ShowValue;
				}
			}

			_mainForm.RemainingMines.Text = "Remaining Mines: " + mines;

			while (mines > 0) {
				Random rand = new Random();
				int r = rand.Next(rows);
				int c = rand.Next(cols);

				Cella cella = (Cella) _mainForm.Grid.GetControlFromPosition(c, r);
				if (cella.Value == 0) {
					cella.Value = 1;
					mines--;
				}
			}
		}

		private void ShowValue(object sender, KeyPressEventArgs e) {
			Cella cella = (Cella)sender;
			Console.WriteLine(cella.Value);
		}


		/*		public void CellClicks(object sender, EventArgs e) {
					Cella cella = (Cella)sender;
					int r = cella.Row;
					int c = cella.Col;
					for (int i=r-1; i<=r+1 && i<_rows; i++) {
						for (int j=c-1; j<=c+1 && j<_cols; j++) {
							if (i >= 0 && j >= 0 && i != r && j != c) {
								Cella cell = (Cella)_mainForm.Grid.GetControlFromPosition(j, i);
								if (cell.Enabled && cell.Text != "*") {
									CellClick(cell, null);
								}
							}
						}
					}
				}
		*/

		public void CellClick(object sender, MouseEventArgs e) {
			Cella cella = (Cella)sender;
			if (e != null && e.Button == MouseButtons.Right) {
				cella.Text = cella.Text == "*" ? "" : "*";
				cella.Text = "*";
				_remainingMines--;
				Console.WriteLine("destro");
			} else {
				cella.Enabled = false;
				if (cella.Value == 1) {
					foreach (Cella c in _mainForm.Grid.Controls) {
						c.Enabled = false;
						if (c.Value == 1) {
							c.Text = "#";
							c.BackColor = Color.Red;
						} else {
							c.Text = GetNeighbour(c.Row, c.Col).ToString(); ;
						}
					}
					cella.BackColor = Color.Black;
				} else {
					int n = GetNeighbour(cella.Row, cella.Col);
					cella.Text = n.ToString();
					if (n == 0) {
						ExpandZero(cella.Row, cella.Col);
					}
				}
			}
		}

		private void ExpandZero(int row, int col) {
			for (int r = row - 1; r <= row + 1 && r < _rows; r++) {
				for (int c = col - 1; c <= col + 1 && c < _cols; c++) {
					if (r >= 0 && c >= 0) {
						Cella cella = (Cella)_mainForm.Grid.GetControlFromPosition(c, r);
						if (cella.Enabled)
							CellClick(cella, null);
					}
				}
			}
		}

		private int GetNeighbour(int row, int col) {
			int result = 0;

			for (int r=row-1; r<=row+1 && r<_rows; r++) {
				for (int c=col-1; c<=col+1 && c<_cols; c++) {
					if (r >= 0 && c >= 0)
						result += ((Cella)_mainForm.Grid.GetControlFromPosition(c,r)).Value;
				}
			}

			return result;
		}

		public int GetTouchingFlags (int row, int col) {
			int result = 0;
			for (int r = row - 1; r <= row + 1 && r < _rows; r++) {
				for (int c = col - 1; c <= col + 1 && c < _cols; c++) {
					if (r >= 0 && c >= 0 /* && r!=row && c!=col */)
						if (((Cella)_mainForm.Grid.GetControlFromPosition(c, r)).Text == "*")
							result++;
				}
			}
			return result;
		}

		public int GetTouchingFree(int row, int col) {
			int result = 0;
			for (int r = row - 1; r <= row + 1 && r < _rows; r++) {
				for (int c = col - 1; c <= col + 1 && c < _cols; c++) {
					if (r >= 0 && c >= 0 /* && r != row && c != col */ ) {
						Cella cella = (Cella)_mainForm.Grid.GetControlFromPosition(c, r);
						if (cella.Text == "")
							result++;
					}
				}
			}
			return result;
		}

		public List<Cella> GetTouchingFreeCell(int row, int col) {
			List<Cella> result = new List<Cella>();
			for (int r = row - 1; r <= row + 1 && r < _rows; r++) {
				for (int c = col - 1; c <= col + 1 && c < _cols; c++) {
					if (r >= 0 && c >= 0 /* && r != row && c != col */ ) {
						Cella cella = (Cella)_mainForm.Grid.GetControlFromPosition(c, r);
						if (cella.Text == "")
							result.Add(cella);
					}
				}
			}
			return result;
		}

		public int GetTouchingNumbers(int row, int col) {
			int result = 0;
			for (int r = row - 1; r <= row + 1 && r < _rows; r++) {
				for (int c = col - 1; c <= col + 1 && c < _cols; c++) {
					if (r >= 0 && c >= 0) {
						Cella cella = (Cella)_mainForm.Grid.GetControlFromPosition(c, r);
						if (!cella.Enabled)
							result++;
					}
				}
			}
			return result;
		}

		public List<Cella> GetTouchingNumberCell(Cella cella) {
			List<Cella> result = new List<Cella>();
			int row = cella.Row;
			int col = cella.Col;

			for (int r = row - 1; r <= row + 1 && r < _rows; r++) {
				for (int c = col - 1; c <= col + 1 && c < _cols; c++) {
					if (r >= 0 && c >= 0) {
						Cella cell = (Cella)_mainForm.Grid.GetControlFromPosition(c, r);
						if (!cell.Enabled)
							result.Add(cell);
					}
				}
			}

			return result;
		}

		public int GetTouchingBomb(int row, int col) {
			int result = 0;
			for (int r = row - 1; r <= row + 1 && r < _rows; r++) {
				for (int c = col - 1; c <= col + 1 && c < _cols; c++) {
					if (r >= 0 && c >= 0 /* && r != row && c != col */ ) {
						Cella cella = (Cella)_mainForm.Grid.GetControlFromPosition(c, r);
						if (cella.Text == "*")
							result++;
					}
				}
			}
			return result;
		}

	}
}
