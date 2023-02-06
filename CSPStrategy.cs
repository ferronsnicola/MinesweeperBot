using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper {
	class CSPStrategy : IStrategy {

		MainForm _mainForm;
		Controller _controller;
		List<Cella> _frontiera;
		List<BitArray> _solutions;
		List<Preview> _previews;

		public CSPStrategy (MainForm mf, Controller c, List<Cella> frontiera) {
			_mainForm = mf;
			_controller = c;
			_frontiera = frontiera;
			_solutions = new List<BitArray>();
			_previews = new List<Preview>();
		}

		public int Play() {
			return PlayForwardChecking();
			//return PlayGenerateAndTest();
		}

		public int PlayForwardChecking() {
			Console.WriteLine();
			Console.WriteLine("_----------------------------_");
			Console.WriteLine();

			int result = 0;
			_previews = new List<Preview>();

			ForwardChecking(0);

			// ho una soluzione, la devo salvare e fare backtracking per trovarne altre eventuali
			bool[] sol = new bool[_previews.Count];
			for (int i=0; i<_previews.Count; i++) {
				sol[i] = _previews[i].Mossa == "*" ? true : false;
				Console.Write(_previews[i].Mossa == "*" ? "1" : "0");
			}
			Console.WriteLine();
			_solutions.Add(new BitArray(sol));

			while (ChangablePreview(_previews)) { // continuo a farlo finchè non ho più mosse ambigue
				int i = BackTracking(_frontiera.Count - 1)+1;
				ForwardChecking(i);

				if (_previews.Count == _frontiera.Count) {
					bool[] sol1 = new bool[_previews.Count];
					for (int j = 0; j < _previews.Count; j++) {
						sol1[j] = _previews[j].Mossa == "*" ? true : false;
						Console.Write(_previews[j].Mossa == "*" ? "1" : "0");
					}
					Console.WriteLine();
					_solutions.Add(new BitArray(sol1));
				}
			}

			// resetto i valori
			foreach (Cella c in _frontiera) {
				c.Text = "";
			}

			// dopo che ho tutte le possibili soluzioni, le confronto e ne trovo i punti in comune
			result += ConfrontaSoluzioni(_frontiera.Count);



			return result;
		}

		private bool ChangablePreview(List<Preview> previews) {
			bool result = false;

			foreach (Preview p in previews) {
				if (!p.Obbligo)
					result = true;
			}

			return result;
		}

		private void ForwardChecking(int index) {
			for (int i = index; i < _frontiera.Count; i++) { // per ognuno testo i valori del dominio e scelgo cosa provare
				bool bomba = _controller.TryPreview(_frontiera[i], "*"); // testo i due valori del dominio
				bool vuoto = _controller.TryPreview(_frontiera[i], "N");
				bool entrambi = bomba && vuoto;

				if (entrambi) { // vanno bene entrambi, metto la preview senza obbligo, con valore di default *
					_previews.Add(new Preview(_frontiera[i], false, "*"));
				} else if (bomba || vuoto) { // se almeno una delle due mosse andava bene, la metto
					string mossa = bomba ? "*" : "N";
					_previews.Add(new Preview(_frontiera[i], true, mossa));
				} else { // se nessuna delle due andava bene, devo fare backtracking fino all'ultima preview senza l'obbligo
					i = BackTracking(i);
				}
			}
		}

		private int BackTracking(int i) {
			for (int j = _previews.Count - 1; j >= 0; j--) {
				if (_previews[j].Obbligo) { // se era una mossa obbligata
					if (j == 0)
						return _frontiera.Count;
					_previews[j].Cella.Text = "";
					_previews.RemoveAt(j); // la cancello
				} else { // se era una scelta
					_previews[j].Obbligo = true; // la diventa un obbligo
					_previews[j].Mossa = _previews[j].Mossa == "*" ? "N" : "*"; // cambio il valore della mossa

					// reimposto il valore i per ripartire correttamente
					i = j;

					// esco dal ciclo
					break;
				}
			}
			return i;
		}

		public int PlayGenerateAndTest() {
			int result = 0;

			int l = _frontiera.Count > 15 ? 15 : _frontiera.Count;

			int length = (int)Math.Pow(2, l);

			for (int i = 0; i < length; i++) {
				string s = Convert.ToString(i, 2);
				BitArray b = new BitArray(new int[] { i }); // creo l'array di bit corrispondente alla soluzione
				b.Length = l;

				for (int j = 0; j < l; j++) { // lo inserisco nella tabella
					if (b.Get(j)) {
						_frontiera[j].Text = "*";
					} else {
						_frontiera[j].Text = "";
					}
				}

				// lo testo
				bool test = true;
				foreach (Cella c1 in _frontiera.GetRange(0, l-2)) {
					foreach (Cella c2 in _controller.GetTouchingNumberCell(c1)) {
						if (_controller.GetTouchingBomb(c2.Row, c2.Col) != Int32.Parse(c2.Text)) {
							test = false;
							break;
						}
					}
					if (!test)
						break;
				}

				// se è ok, lo salvo
				if (test)
					_solutions.Add(b);
			}

			//resetto la frontiera
			foreach (Cella cella in _frontiera) {
				cella.Text = "";
			}

			// a questo punto ho tutte le soluzioni ammissibili, le confronto per trovare i punti comuni
			result += ConfrontaSoluzioni(l);

			Console.WriteLine("fine");
			return result;
			
		}


		private int ConfrontaSoluzioni(int length) {
			int result = 0;
			for (int i = 0; i < length; i++) {
				bool test = true;
				bool value = _solutions[0].Get(i); // prendo l'i-esimo valore del primo bitarray
				foreach (BitArray b in _solutions) {
					if (b.Get(i) != value) {
						test = false;
						break;
					}
				}
				if (test) { // se tutti gli i-esimi bit delle possibili soluzioni sono risultati uguali, metto il valore nella cella
					if (value)
						_frontiera[i].Text = "*";
					else
						_controller.CellClick(_frontiera[i], null);
					result++;
				}
			}
			return result;
		}
	}
}
