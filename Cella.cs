using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper {
	class Cella : Button {
		private int _row;
		private int _col;
		private int _value;

		public Cella (int value, int row, int col) : base() {
			base.Text = "";
			_row = row;
			_col = col;
			if (value < 0 || value > 1) {
				throw new ArgumentException("value of cell != 0/1");
			}
			_value = value;
			base.Width = base.Height;
		}


		public int Value {
			get {
				return _value;
			}
			set {
				_value = value;
			}
		}

		public int GetNeighbour() {
			throw new NotImplementedException();
		}

		public int Row {
			get {
				return _row;
			}
		}
		public int Col {
			get {
				return _col;
			}
		}

		public bool IsNextTo (Cella other) {
			int x = Math.Abs(_col - other.Col);
			int y = Math.Abs(_row - other.Row);

			return x <= 1 && y <= 1;
		}

	}
}
