using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper {
	class NaiveStrategy : IStrategy {

		private MainForm _mainForm;
		private Controller _controller;

		public NaiveStrategy(MainForm mf, Controller c) {
			_mainForm = mf;
			_controller = c;
		}

		public int Play() {
			int result = 0;
			int rows = _controller.Rows;
			int cols = _controller.Cols;

			for (int r = 0; r < rows; r++) {
				bool end = false;
				for (int c = 0; c < cols; c++) {
					Cella cella = (Cella)_mainForm.Grid.GetControlFromPosition(c, r);
					if (!cella.Enabled) {
						int touchingMines=-1;
						try {
							touchingMines = Int32.Parse(cella.Text);
						} catch (Exception) {
							continue;
						}

						if (_controller.GetTouchingFlags(r, c) == touchingMines) {
							// clicco le altre
							for (int i = r - 1; i <= r + 1 && i < rows; i++) {
								for (int j = c - 1; j <= c + 1 && j < cols; j++) {
									if (i >= 0 && j >= 0/* && i != r && j != c*/) {
										Cella cell = (Cella)_mainForm.Grid.GetControlFromPosition(j, i);
										if (cell.Enabled && cell.Text != "*") {
											_controller.CellClick(cell, null);
											end = true;
											result++;
										}
									}
								}
							}
						} else if (_controller.GetTouchingFree(r, c) == touchingMines - _controller.GetTouchingFlags(r,c)) {
							// bandiero tutte
							for (int i = r - 1; i <= r + 1 && i < rows; i++) {
								for (int j = c - 1; j <= c + 1 && j < cols; j++) {
									if (i >= 0 && j >= 0/* && i!=r && j!=c*/) {
										Cella cell = (Cella)_mainForm.Grid.GetControlFromPosition(j, i);
										if (cell.Enabled) {
											cell.Text = "*";
											end = true;
											result++;
										}
									}
								}
							}
						}
					}
					if (end)
						break;
				}
				if (end)
					break;
			}
			return result;
		}
	}
}

