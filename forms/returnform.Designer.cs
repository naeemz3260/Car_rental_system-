namespace CarRentalApp
{
    partial class ReturnForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCar;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCar = new System.Windows.Forms.TextBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(242, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(377, 216);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(259, 29);
            this.txtCustomer.TabIndex = 1;
            this.txtCustomer.TextChanged += new System.EventHandler(this.txtCustomer_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(242, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Car Name:";
            // 
            // txtCar
            // 
            this.txtCar.Location = new System.Drawing.Point(377, 163);
            this.txtCar.Name = "txtCar";
            this.txtCar.Size = new System.Drawing.Size(259, 29);
            this.txtCar.TabIndex = 3;
            this.txtCar.TextChanged += new System.EventHandler(this.txtCar_TextChanged);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(550, 280);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(103, 39);
            this.btnReturn.TabIndex = 4;
            this.btnReturn.Text = "Return Car";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(550, 325);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 33);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(120, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(661, 77);
            this.panel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.14286F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(66, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(501, 55);
            this.label3.TabIndex = 0;
            this.label3.Text = "CAR RETURN PAGE";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ReturnForm
            // 
            this.ClientSize = new System.Drawing.Size(949, 465);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCar);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnCancel);
            this.Name = "ReturnForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Return Car";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
    }
}
