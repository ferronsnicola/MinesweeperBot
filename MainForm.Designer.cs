namespace MineSweeper {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this._mainPanel = new System.Windows.Forms.Panel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this._hardBtn = new System.Windows.Forms.Button();
			this._mediumBtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this._easyBtn = new System.Windows.Forms.Button();
			this._remainingMines = new System.Windows.Forms.Label();
			this._autoPlay = new System.Windows.Forms.Button();
			this._gridPanel = new System.Windows.Forms.TableLayoutPanel();
			this._mostraFrontiera = new System.Windows.Forms.Button();
			this._mainPanel.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// _mainPanel
			// 
			this._mainPanel.AutoSize = true;
			this._mainPanel.Controls.Add(this.tableLayoutPanel3);
			this._mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this._mainPanel.Location = new System.Drawing.Point(0, 0);
			this._mainPanel.Name = "_mainPanel";
			this._mainPanel.Size = new System.Drawing.Size(878, 573);
			this._mainPanel.TabIndex = 0;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this._gridPanel, 0, 1);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 2;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(878, 573);
			this.tableLayoutPanel3.TabIndex = 2;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this._remainingMines, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this._autoPlay, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this._mostraFrontiera, 3, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(872, 34);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 4;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.Controls.Add(this._hardBtn, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this._mediumBtn, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this._easyBtn, 1, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(221, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(212, 28);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// _hardBtn
			// 
			this._hardBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
			this._hardBtn.Location = new System.Drawing.Point(162, 3);
			this._hardBtn.Name = "_hardBtn";
			this._hardBtn.Size = new System.Drawing.Size(47, 21);
			this._hardBtn.TabIndex = 3;
			this._hardBtn.Text = "Hard";
			this._hardBtn.UseVisualStyleBackColor = true;
			// 
			// _mediumBtn
			// 
			this._mediumBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
			this._mediumBtn.Location = new System.Drawing.Point(109, 3);
			this._mediumBtn.Name = "_mediumBtn";
			this._mediumBtn.Size = new System.Drawing.Size(47, 21);
			this._mediumBtn.TabIndex = 2;
			this._mediumBtn.Text = "Medium";
			this._mediumBtn.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "New Game:";
			// 
			// _easyBtn
			// 
			this._easyBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
			this._easyBtn.Location = new System.Drawing.Point(56, 3);
			this._easyBtn.Name = "_easyBtn";
			this._easyBtn.Size = new System.Drawing.Size(47, 21);
			this._easyBtn.TabIndex = 1;
			this._easyBtn.Text = "Easy";
			this._easyBtn.UseVisualStyleBackColor = true;
			// 
			// _remainingMines
			// 
			this._remainingMines.Anchor = System.Windows.Forms.AnchorStyles.None;
			this._remainingMines.AutoSize = true;
			this._remainingMines.Location = new System.Drawing.Point(498, 10);
			this._remainingMines.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this._remainingMines.Name = "_remainingMines";
			this._remainingMines.Size = new System.Drawing.Size(94, 13);
			this._remainingMines.TabIndex = 2;
			this._remainingMines.Text = "Remaining Mines: ";
			// 
			// _autoPlay
			// 
			this._autoPlay.Dock = System.Windows.Forms.DockStyle.Fill;
			this._autoPlay.Location = new System.Drawing.Point(2, 2);
			this._autoPlay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this._autoPlay.Name = "_autoPlay";
			this._autoPlay.Size = new System.Drawing.Size(214, 30);
			this._autoPlay.TabIndex = 3;
			this._autoPlay.Text = "AutoPlay";
			this._autoPlay.UseVisualStyleBackColor = true;
			// 
			// _gridPanel
			// 
			this._gridPanel.ColumnCount = 1;
			this._gridPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this._gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this._gridPanel.Location = new System.Drawing.Point(3, 43);
			this._gridPanel.Name = "_gridPanel";
			this._gridPanel.RowCount = 1;
			this._gridPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this._gridPanel.Size = new System.Drawing.Size(872, 527);
			this._gridPanel.TabIndex = 0;
			// 
			// _mostraFrontiera
			// 
			this._mostraFrontiera.Dock = System.Windows.Forms.DockStyle.Fill;
			this._mostraFrontiera.Location = new System.Drawing.Point(657, 3);
			this._mostraFrontiera.Name = "_mostraFrontiera";
			this._mostraFrontiera.Size = new System.Drawing.Size(212, 28);
			this._mostraFrontiera.TabIndex = 4;
			this._mostraFrontiera.Text = "Mostra Frontiera";
			this._mostraFrontiera.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(878, 573);
			this.Controls.Add(this._mainPanel);
			this.Name = "MainForm";
			this.Text = "Form1";
			this._mainPanel.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel _mainPanel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.TableLayoutPanel _gridPanel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button _hardBtn;
		private System.Windows.Forms.Button _mediumBtn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button _easyBtn;
		private System.Windows.Forms.Label _remainingMines;
		private System.Windows.Forms.Button _autoPlay;
		private System.Windows.Forms.Button _mostraFrontiera;
	}
}

