﻿
namespace QLKhachSan
{
    partial class FormSuppliesSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dvgSearch = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dvgSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgSearch
            // 
            this.dvgSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgSearch.Location = new System.Drawing.Point(26, 22);
            this.dvgSearch.Margin = new System.Windows.Forms.Padding(2);
            this.dvgSearch.Name = "dvgSearch";
            this.dvgSearch.RowHeadersWidth = 51;
            this.dvgSearch.RowTemplate.Height = 24;
            this.dvgSearch.Size = new System.Drawing.Size(685, 289);
            this.dvgSearch.TabIndex = 4;
            // 
            // FormSuppliesSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 329);
            this.Controls.Add(this.dvgSearch);
            this.Name = "FormSuppliesSearch";
            this.Text = "FormSuppliesSearch";
            this.Load += new System.EventHandler(this.FormSuppliesSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgSearch;
    }
}