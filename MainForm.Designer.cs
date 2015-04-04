namespace Spotangles {
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
			this.settingsBTN = new System.Windows.Forms.Button();
			this.startBTN = new System.Windows.Forms.Button();
			this.stopBTN = new System.Windows.Forms.Button();
			this.statusTXT = new System.Windows.Forms.Label();
			this.updatedTXT = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// settingsBTN
			// 
			this.settingsBTN.Location = new System.Drawing.Point(230, 56);
			this.settingsBTN.Name = "settingsBTN";
			this.settingsBTN.Size = new System.Drawing.Size(75, 23);
			this.settingsBTN.TabIndex = 0;
			this.settingsBTN.Text = "Settings";
			this.settingsBTN.UseVisualStyleBackColor = true;
			this.settingsBTN.Click += new System.EventHandler(this.settingsBTN_Click);
			// 
			// startBTN
			// 
			this.startBTN.Location = new System.Drawing.Point(13, 56);
			this.startBTN.Name = "startBTN";
			this.startBTN.Size = new System.Drawing.Size(75, 23);
			this.startBTN.TabIndex = 1;
			this.startBTN.Text = "Start";
			this.startBTN.UseVisualStyleBackColor = true;
			this.startBTN.Click += new System.EventHandler(this.startBTN_Click);
			// 
			// stopBTN
			// 
			this.stopBTN.Location = new System.Drawing.Point(94, 56);
			this.stopBTN.Name = "stopBTN";
			this.stopBTN.Size = new System.Drawing.Size(75, 23);
			this.stopBTN.TabIndex = 2;
			this.stopBTN.Text = "Stop";
			this.stopBTN.UseVisualStyleBackColor = true;
			this.stopBTN.Click += new System.EventHandler(this.stopBTN_Click);
			// 
			// statusTXT
			// 
			this.statusTXT.AutoSize = true;
			this.statusTXT.Location = new System.Drawing.Point(13, 12);
			this.statusTXT.Name = "statusTXT";
			this.statusTXT.Size = new System.Drawing.Size(40, 13);
			this.statusTXT.TabIndex = 3;
			this.statusTXT.Text = "Status:";
			// 
			// updatedTXT
			// 
			this.updatedTXT.AutoSize = true;
			this.updatedTXT.Location = new System.Drawing.Point(13, 32);
			this.updatedTXT.Name = "updatedTXT";
			this.updatedTXT.Size = new System.Drawing.Size(108, 13);
			this.updatedTXT.TabIndex = 4;
			this.updatedTXT.Text = "Data is correct as at: ";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(317, 91);
			this.Controls.Add(this.updatedTXT);
			this.Controls.Add(this.statusTXT);
			this.Controls.Add(this.stopBTN);
			this.Controls.Add(this.startBTN);
			this.Controls.Add(this.settingsBTN);
			this.Name = "MainForm";
			this.Text = "Spotangles";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button settingsBTN;
		private System.Windows.Forms.Button startBTN;
		private System.Windows.Forms.Button stopBTN;
		private System.Windows.Forms.Label statusTXT;
		private System.Windows.Forms.Label updatedTXT;
	}
}

