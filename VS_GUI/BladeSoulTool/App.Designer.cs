﻿namespace BladeSoulTool
{
    partial class App
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCostume = new System.Windows.Forms.TabPage();
            this.tabAttach = new System.Windows.Forms.TabPage();
            this.tabWeapon = new System.Windows.Forms.TabPage();
            this.tabUtil = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabCostume);
            this.tabControl.Controls.Add(this.tabAttach);
            this.tabControl.Controls.Add(this.tabWeapon);
            this.tabControl.Controls.Add(this.tabUtil);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1192, 830);
            this.tabControl.TabIndex = 0;
            // 
            // tabCostume
            // 
            this.tabCostume.Location = new System.Drawing.Point(4, 22);
            this.tabCostume.Name = "tabCostume";
            this.tabCostume.Padding = new System.Windows.Forms.Padding(3);
            this.tabCostume.Size = new System.Drawing.Size(1184, 804);
            this.tabCostume.TabIndex = 0;
            this.tabCostume.UseVisualStyleBackColor = true;
            // 
            // tabAttach
            // 
            this.tabAttach.Location = new System.Drawing.Point(4, 22);
            this.tabAttach.Name = "tabAttach";
            this.tabAttach.Padding = new System.Windows.Forms.Padding(3);
            this.tabAttach.Size = new System.Drawing.Size(1177, 797);
            this.tabAttach.TabIndex = 1;
            this.tabAttach.UseVisualStyleBackColor = true;
            // 
            // tabWeapon
            // 
            this.tabWeapon.Location = new System.Drawing.Point(4, 22);
            this.tabWeapon.Name = "tabWeapon";
            this.tabWeapon.Padding = new System.Windows.Forms.Padding(3);
            this.tabWeapon.Size = new System.Drawing.Size(1177, 797);
            this.tabWeapon.TabIndex = 2;
            this.tabWeapon.UseVisualStyleBackColor = true;
            // 
            // tabUtil
            // 
            this.tabUtil.Location = new System.Drawing.Point(4, 22);
            this.tabUtil.Name = "tabUtil";
            this.tabUtil.Padding = new System.Windows.Forms.Padding(3);
            this.tabUtil.Size = new System.Drawing.Size(1177, 797);
            this.tabUtil.TabIndex = 3;
            this.tabUtil.UseVisualStyleBackColor = true;
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 830);
            this.Controls.Add(this.tabControl);
            this.Name = "App";
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCostume;
        private System.Windows.Forms.TabPage tabAttach;
        private System.Windows.Forms.TabPage tabWeapon;
        private System.Windows.Forms.TabPage tabUtil;

    }
}

