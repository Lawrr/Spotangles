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
			this.SuspendLayout();
			// 
			// settingsBTN
			// 
			this.settingsBTN.Location = new System.Drawing.Point(230, 12);
			this.settingsBTN.Name = "settingsBTN";
			this.settingsBTN.Size = new System.Drawing.Size(75, 23);
			this.settingsBTN.TabIndex = 0;
			this.settingsBTN.Text = "Settings";
			this.settingsBTN.UseVisualStyleBackColor = true;
			this.settingsBTN.Click += new System.EventHandler(this.settingsBTN_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(317, 270);
			this.Controls.Add(this.settingsBTN);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button settingsBTN;
	}
}

