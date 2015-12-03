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
            this.TrackBox = new System.Windows.Forms.ListBox();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.CourseInputBox = new System.Windows.Forms.TextBox();
            this.SemesterComboBox = new System.Windows.Forms.ComboBox();
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
            // TrackBox
            // 
            this.TrackBox.FormattingEnabled = true;
            this.TrackBox.Location = new System.Drawing.Point(12, 69);
            this.TrackBox.Name = "TrackBox";
            this.TrackBox.Size = new System.Drawing.Size(385, 134);
            this.TrackBox.TabIndex = 3;
            this.TrackBox.SelectedIndexChanged += new System.EventHandler(this.TrackBox_SelectedIndexChanged);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(12, 209);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(385, 23);
            this.RemoveButton.TabIndex = 4;
            this.RemoveButton.Text = "Remove Selected Class";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(322, 238);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 6;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
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
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(322, 21);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // CourseInputBox
            // 
            this.CourseInputBox.Location = new System.Drawing.Point(12, 22);
            this.CourseInputBox.Name = "CourseInputBox";
            this.CourseInputBox.Size = new System.Drawing.Size(212, 20);
            this.CourseInputBox.TabIndex = 0;
            // 
            // SemesterComboBox
            // 
            this.SemesterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SemesterComboBox.FormattingEnabled = true;
            this.SemesterComboBox.Items.AddRange(new object[] {
            "Semester 1",
            "Semester 2",
            "Summer"});
            this.SemesterComboBox.Location = new System.Drawing.Point(230, 22);
            this.SemesterComboBox.Name = "SemesterComboBox";
            this.SemesterComboBox.Size = new System.Drawing.Size(86, 21);
            this.SemesterComboBox.TabIndex = 10;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(409, 267);
            this.Controls.Add(this.SemesterComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.TrackBox);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CourseInputBox);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox TrackBox;
		private System.Windows.Forms.Button RemoveButton;
		private System.Windows.Forms.Button CloseButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button SearchButton;
		private System.Windows.Forms.TextBox CourseInputBox;
        private System.Windows.Forms.ComboBox SemesterComboBox;
    }
}