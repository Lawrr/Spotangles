namespace Spotangles {
	partial class ClassSearchForm {
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
			this.classBox = new System.Windows.Forms.ListBox();
			this.classTXT = new System.Windows.Forms.Label();
			this.addBTN = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// classBox
			// 
			this.classBox.FormattingEnabled = true;
			this.classBox.Items.AddRange(new object[] {
            "Loading classes..."});
			this.classBox.Location = new System.Drawing.Point(12, 29);
			this.classBox.Name = "classBox";
			this.classBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
			this.classBox.Size = new System.Drawing.Size(530, 199);
			this.classBox.TabIndex = 0;
			this.classBox.SelectedIndexChanged += new System.EventHandler(this.classBox_SelectedIndexChanged);
			// 
			// classTXT
			// 
			this.classTXT.AutoSize = true;
			this.classTXT.Location = new System.Drawing.Point(12, 9);
			this.classTXT.Name = "classTXT";
			this.classTXT.Size = new System.Drawing.Size(43, 13);
			this.classTXT.TabIndex = 1;
			this.classTXT.Text = "Classes";
			// 
			// addBTN
			// 
			this.addBTN.Enabled = false;
			this.addBTN.Location = new System.Drawing.Point(467, 234);
			this.addBTN.Name = "addBTN";
			this.addBTN.Size = new System.Drawing.Size(75, 23);
			this.addBTN.TabIndex = 2;
			this.addBTN.Text = "Add Class";
			this.addBTN.UseVisualStyleBackColor = true;
			this.addBTN.Click += new System.EventHandler(this.addBTN_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 239);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(300, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Tent = Stop Further Enrolment, Tentative, Closed or Cancelled";
			// 
			// ClassSearchForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(554, 265);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.addBTN);
			this.Controls.Add(this.classTXT);
			this.Controls.Add(this.classBox);
			this.Name = "ClassSearchForm";
			this.Text = "Class Search";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox classBox;
		private System.Windows.Forms.Label classTXT;
		private System.Windows.Forms.Button addBTN;
		private System.Windows.Forms.Label label2;
	}
}