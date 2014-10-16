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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.addBTN = new System.Windows.Forms.Button();
			this.courseInputBox = new System.Windows.Forms.TextBox();
			this.refreshBox = new System.Windows.Forms.ComboBox();
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
			this.trackBox.Size = new System.Drawing.Size(262, 134);
			this.trackBox.TabIndex = 3;
			// 
			// removeBTN
			// 
			this.removeBTN.Location = new System.Drawing.Point(12, 209);
			this.removeBTN.Name = "removeBTN";
			this.removeBTN.Size = new System.Drawing.Size(262, 23);
			this.removeBTN.TabIndex = 4;
			this.removeBTN.Text = "Remove Selected Class";
			this.removeBTN.UseVisualStyleBackColor = true;
			// 
			// closeBTN
			// 
			this.closeBTN.Location = new System.Drawing.Point(199, 238);
			this.closeBTN.Name = "closeBTN";
			this.closeBTN.Size = new System.Drawing.Size(75, 23);
			this.closeBTN.TabIndex = 6;
			this.closeBTN.Text = "Close";
			this.closeBTN.UseVisualStyleBackColor = true;
			this.closeBTN.Click += new System.EventHandler(this.closeBTN_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 242);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(116, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Refresh Rate (Minutes)";
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
			// addBTN
			// 
			this.addBTN.Location = new System.Drawing.Point(199, 20);
			this.addBTN.Name = "addBTN";
			this.addBTN.Size = new System.Drawing.Size(75, 23);
			this.addBTN.TabIndex = 2;
			this.addBTN.Text = "Add";
			this.addBTN.UseVisualStyleBackColor = true;
			this.addBTN.Click += new System.EventHandler(this.addBTN_Click);
			// 
			// courseInputBox
			// 
			this.courseInputBox.Location = new System.Drawing.Point(12, 22);
			this.courseInputBox.Name = "courseInputBox";
			this.courseInputBox.Size = new System.Drawing.Size(183, 20);
			this.courseInputBox.TabIndex = 0;
			// 
			// refreshBox
			// 
			this.refreshBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.refreshBox.FormattingEnabled = true;
			this.refreshBox.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "30",
            "60"});
			this.refreshBox.Location = new System.Drawing.Point(133, 239);
			this.refreshBox.Name = "refreshBox";
			this.refreshBox.Size = new System.Drawing.Size(60, 21);
			this.refreshBox.TabIndex = 8;
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(282, 267);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.refreshBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.closeBTN);
			this.Controls.Add(this.removeBTN);
			this.Controls.Add(this.trackBox);
			this.Controls.Add(this.addBTN);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.courseInputBox);
			this.Name = "SettingsForm";
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.SettingsForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox trackBox;
		private System.Windows.Forms.Button removeBTN;
		private System.Windows.Forms.Button closeBTN;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button addBTN;
		private System.Windows.Forms.TextBox courseInputBox;
		private System.Windows.Forms.ComboBox refreshBox;
	}
}