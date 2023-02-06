using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			MainForm mf = new MainForm();
			mf.StartPosition = FormStartPosition.CenterScreen;
			Controller controller = new Controller(mf);
			Application.Run(mf);
		}
	}
}
