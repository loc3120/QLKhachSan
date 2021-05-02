
namespace QLKhachSan.RoomSubForm
{
    partial class SearchRoomForm
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
            this.roomSearchDgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.roomSearchDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // roomSearchDgv
            // 
            this.roomSearchDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.roomSearchDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.roomSearchDgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.roomSearchDgv.Location = new System.Drawing.Point(0, 109);
            this.roomSearchDgv.Name = "roomSearchDgv";
            this.roomSearchDgv.RowHeadersWidth = 51;
            this.roomSearchDgv.RowTemplate.Height = 24;
            this.roomSearchDgv.Size = new System.Drawing.Size(984, 402);
            this.roomSearchDgv.TabIndex = 1;
            // 
            // SearchRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 511);
            this.Controls.Add(this.roomSearchDgv);
            this.Name = "SearchRoomForm";
            this.Text = "SearchRoomForm";
            this.Load += new System.EventHandler(this.SearchRoomForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roomSearchDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView roomSearchDgv;
    }
}