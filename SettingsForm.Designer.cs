namespace Spotangles {
	partial class SettingsForm {
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
			this.label1 = new System.Windows.Forms.Label();
			this.trackBox = new System.Windows.Forms.ListBox();
			this.removeBTN = new System.Windows.Forms.Button();
			this.closeBTN = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.searchBTN = new System.Windows.Forms.Button();
			this.courseInputBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(215, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Enter course code to track (eg. COMP1917)";
			// 
			// trackBox
			// 
			this.trackBox.FormattingEnabled = true;
			this.trackBox.Location = new System.Drawing.Point(12, 69);
			this.trackBox.Name = "trackBox";
			this.trackBox.Size = new System.Drawing.Size(385, 134);
			this.trackBox.TabIndex = 3;
			this.trackBox.SelectedIndexChanged += new System.EventHandler(this.trackBox_SelectedIndexChanged);
			// 
			// removeBTN
			// 
			this.removeBTN.Location = new System.Drawing.Point(12, 209);
			this.removeBTN.Name = "removeBTN";
			this.removeBTN.Size = new System.Drawing.Size(385, 23);
			this.removeBTN.TabIndex = 4;
			this.removeBTN.Text = "Remove Selected Class";
			this.removeBTN.UseVisualStyleBackColor = true;
			this.removeBTN.Click += new System.EventHandler(this.removeBTN_Click);
			// 
			// closeBTN
			// 
			this.closeBTN.Location = new System.Drawing.Point(322, 238);
			this.closeBTN.Name = "closeBTN";
			this.closeBTN.Size = new System.Drawing.Size(75, 23);
			this.closeBTN.TabIndex = 6;
			this.closeBTN.Text = "Close";
			this.closeBTN.UseVisualStyleBackColor = true;
			this.closeBTN.Click += new System.EventHandler(this.closeBTN_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 51);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(86, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Tracked Classes";
			// 
			// searchBTN
			// 
			this.searchBTN.Location = new System.Drawing.Point(322, 21);
			this.searchBTN.Name = "searchBTN";
			this.searchBTN.Size = new System.Drawing.Size(75, 23);
			this.searchBTN.TabIndex = 2;
			this.searchBTN.Text = "Search";
			this.searchBTN.UseVisualStyleBackColor = true;
			this.searchBTN.Click += new System.EventHandler(this.searchBTN_Click);
			// 
			// courseInputBox
			// 
			this.courseInputBox.Location = new System.Drawing.Point(12, 22);
			this.courseInputBox.Name = "courseInputBox";
			this.courseInputBox.Size = new System.Drawing.Size(304, 20);
			this.courseInputBox.TabIndex = 0;
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(409, 267);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.closeBTN);
			this.Controls.Add(this.removeBTN);
			this.Controls.Add(this.trackBox);
			this.Controls.Add(this.searchBTN);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.courseInputBox);
			this.Name = "SettingsForm";
			this.Text = "Settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox trackBox;
		private System.Windows.Forms.Button removeBTN;
		private System.Windows.Forms.Button closeBTN;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button searchBTN;
		private System.Windows.Forms.TextBox courseInputBox;
	}
}