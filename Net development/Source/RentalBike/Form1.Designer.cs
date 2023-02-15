namespace RentalBike
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxSerialNumber = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonRentABike = new System.Windows.Forms.Button();
            this.buttonReturnRentedBike = new System.Windows.Forms.Button();
            this.textBoxDescriptionBike = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxSerialNumber
            // 
            this.textBoxSerialNumber.Location = new System.Drawing.Point(55, 63);
            this.textBoxSerialNumber.Name = "textBoxSerialNumber";
            this.textBoxSerialNumber.Size = new System.Drawing.Size(150, 27);
            this.textBoxSerialNumber.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(55, 132);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(469, 204);
            this.listBox1.TabIndex = 2;
            // 
            // buttonRentABike
            // 
            this.buttonRentABike.Location = new System.Drawing.Point(569, 35);
            this.buttonRentABike.Name = "buttonRentABike";
            this.buttonRentABike.Size = new System.Drawing.Size(125, 68);
            this.buttonRentABike.TabIndex = 3;
            this.buttonRentABike.Text = "Rent a bike";
            this.buttonRentABike.UseVisualStyleBackColor = true;
            this.buttonRentABike.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonReturnRentedBike
            // 
            this.buttonReturnRentedBike.Location = new System.Drawing.Point(569, 165);
            this.buttonReturnRentedBike.Name = "buttonReturnRentedBike";
            this.buttonReturnRentedBike.Size = new System.Drawing.Size(123, 70);
            this.buttonReturnRentedBike.TabIndex = 4;
            this.buttonReturnRentedBike.Text = "Return rented bike";
            this.buttonReturnRentedBike.UseVisualStyleBackColor = true;
            // 
            // textBoxDescriptionBike
            // 
            this.textBoxDescriptionBike.Location = new System.Drawing.Point(264, 63);
            this.textBoxDescriptionBike.Name = "textBoxDescriptionBike";
            this.textBoxDescriptionBike.Size = new System.Drawing.Size(260, 27);
            this.textBoxDescriptionBike.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Serial number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Description bike";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDescriptionBike);
            this.Controls.Add(this.buttonReturnRentedBike);
            this.Controls.Add(this.buttonRentABike);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBoxSerialNumber);
            this.Name = "Form1";
            this.Text = "Rentalbike";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxSerialNumber;
        private ListBox listBox1;
        private Button buttonRentABike;
        private Button buttonReturnRentedBike;
        private TextBox textBoxDescriptionBike;
        private Label label1;
        private Label label2;
    }
}