using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper {
	class Preview {
		private Cella _cella;
		private bool _obbligo;
		private string _mossa;

		public Preview (Cella cella) {
			_cella = cella;
		}

		public Preview (Cella cella, bool obbligo, string mossa) {
			_cella = cella;
			_obbligo = obbligo;
			_mossa = mossa;
			_cella.Text = mossa;
		}

		public Cella Cella {
			get { return _cella; }
		}

		public bool Obbligo {
			get { return _obbligo; }
			set { _obbligo = value; }
		}

		public string Mossa {
			get { return _mossa; }
			set {
				_mossa = value;
				_cella.Text = value;
			}
		}
	}
}
