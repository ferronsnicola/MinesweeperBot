using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper {
	public partial class MainForm : Form {
		public MainForm() {
			InitializeComponent();
		}

		public TableLayoutPanel Grid {
			get {
				return _gridPanel;
			}
			set {
				_gridPanel = value;
			}
		}

		public Button EasyBtn {
			get {
				return _easyBtn;
			}
		}
		public Button MediumBtn {
			get {
				return _mediumBtn;
			}
		}
		public Button HardBtn {
			get {
				return _hardBtn;
			}
		}

		public Button AutoPlay {
			get {
				return _autoPlay;
			}
		}

		public Label RemainingMines {
			get {
				return _remainingMines;
			}
		}

		public Button MostraFrontiera {
			get {
				return _mostraFrontiera;
			}
		}
	}
}
