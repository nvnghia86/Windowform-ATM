﻿namespace ATM.UC.UC3
{
    partial class Fail1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fail1));
            this.lbErrorMoney = new System.Windows.Forms.Label();
            this.lbErrorCard = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbErrorMoney
            // 
            this.lbErrorMoney.AutoSize = true;
            this.lbErrorMoney.BackColor = System.Drawing.Color.Transparent;
            this.lbErrorMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbErrorMoney.ForeColor = System.Drawing.Color.Red;
            this.lbErrorMoney.Location = new System.Drawing.Point(12, 160);
            this.lbErrorMoney.Name = "lbErrorMoney";
            this.lbErrorMoney.Size = new System.Drawing.Size(548, 24);
            this.lbErrorMoney.TabIndex = 7;
            this.lbErrorMoney.Text = "Số tiền trong tài khoản của bạn không đủ để thực hiện giao dịch";
            this.lbErrorMoney.Visible = false;
            // 
            // lbErrorCard
            // 
            this.lbErrorCard.AutoSize = true;
            this.lbErrorCard.BackColor = System.Drawing.Color.Transparent;
            this.lbErrorCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbErrorCard.ForeColor = System.Drawing.Color.Red;
            this.lbErrorCard.Location = new System.Drawing.Point(184, 189);
            this.lbErrorCard.Name = "lbErrorCard";
            this.lbErrorCard.Size = new System.Drawing.Size(183, 24);
            this.lbErrorCard.TabIndex = 8;
            this.lbErrorCard.Text = "Mã thẻ không hợp lệ";
            this.lbErrorCard.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(199, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "Giao dịch thất bại";
            // 
            // Fail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.lbErrorMoney);
            this.Controls.Add(this.lbErrorCard);
            this.Controls.Add(this.label4);
            this.Name = "Fail";
            this.Size = new System.Drawing.Size(570, 360);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbErrorMoney;
        private System.Windows.Forms.Label lbErrorCard;
        private System.Windows.Forms.Label label4;
    }
}
