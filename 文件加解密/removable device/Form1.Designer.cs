namespace removable_device
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.RemovableList = new System.Windows.Forms.ListBox();
            this.bt_ScanDrive = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_OpenDisk = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_help = new System.Windows.Forms.Button();
            this.bt_delete = new System.Windows.Forms.Button();
            this.bt_back = new System.Windows.Forms.Button();
            this.bt_Open = new System.Windows.Forms.Button();
            this.bt_encry = new System.Windows.Forms.Button();
            this.bt_decip = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_ResetKey = new System.Windows.Forms.Button();
            this.tB_KeyConfirm = new System.Windows.Forms.TextBox();
            this.bt_change = new System.Windows.Forms.Button();
            this.tB_Key = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tB_Suffix = new System.Windows.Forms.TextBox();
            this.tB_AfterEncry = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RemovableList
            // 
            this.RemovableList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RemovableList.FormattingEnabled = true;
            this.RemovableList.ItemHeight = 16;
            this.RemovableList.Location = new System.Drawing.Point(0, 19);
            this.RemovableList.Name = "RemovableList";
            this.RemovableList.Size = new System.Drawing.Size(279, 148);
            this.RemovableList.TabIndex = 0;
            // 
            // bt_ScanDrive
            // 
            this.bt_ScanDrive.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_ScanDrive.Location = new System.Drawing.Point(5, 185);
            this.bt_ScanDrive.Name = "bt_ScanDrive";
            this.bt_ScanDrive.Size = new System.Drawing.Size(77, 23);
            this.bt_ScanDrive.TabIndex = 1;
            this.bt_ScanDrive.Text = "扫描驱动";
            this.bt_ScanDrive.UseVisualStyleBackColor = true;
            this.bt_ScanDrive.Click += new System.EventHandler(this.ScanDrive_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.bt_OpenDisk);
            this.groupBox1.Controls.Add(this.RemovableList);
            this.groupBox1.Controls.Add(this.bt_ScanDrive);
            this.groupBox1.Location = new System.Drawing.Point(9, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 224);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "驱动列表";
            // 
            // bt_OpenDisk
            // 
            this.bt_OpenDisk.Location = new System.Drawing.Point(204, 185);
            this.bt_OpenDisk.Name = "bt_OpenDisk";
            this.bt_OpenDisk.Size = new System.Drawing.Size(75, 23);
            this.bt_OpenDisk.TabIndex = 2;
            this.bt_OpenDisk.Text = "打开驱动";
            this.bt_OpenDisk.UseVisualStyleBackColor = true;
            this.bt_OpenDisk.Click += new System.EventHandler(this.bt_OpenDisk_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(6, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(365, 352);
            this.listBox1.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Location = new System.Drawing.Point(318, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(482, 403);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.btn_help);
            this.groupBox5.Controls.Add(this.bt_delete);
            this.groupBox5.Controls.Add(this.listBox1);
            this.groupBox5.Controls.Add(this.bt_back);
            this.groupBox5.Controls.Add(this.bt_Open);
            this.groupBox5.Controls.Add(this.bt_encry);
            this.groupBox5.Controls.Add(this.bt_decip);
            this.groupBox5.Location = new System.Drawing.Point(12, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(464, 381);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "未加密";
            // 
            // btn_help
            // 
            this.btn_help.Location = new System.Drawing.Point(383, 201);
            this.btn_help.Name = "btn_help";
            this.btn_help.Size = new System.Drawing.Size(75, 23);
            this.btn_help.TabIndex = 17;
            this.btn_help.Text = "帮  助";
            this.btn_help.UseVisualStyleBackColor = true;
            this.btn_help.Click += new System.EventHandler(this.btn_help_Click);
            // 
            // bt_delete
            // 
            this.bt_delete.Location = new System.Drawing.Point(383, 130);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(75, 23);
            this.bt_delete.TabIndex = 16;
            this.bt_delete.Text = "删 除";
            this.bt_delete.UseVisualStyleBackColor = true;
            this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // bt_back
            // 
            this.bt_back.Location = new System.Drawing.Point(383, 168);
            this.bt_back.Name = "bt_back";
            this.bt_back.Size = new System.Drawing.Size(75, 23);
            this.bt_back.TabIndex = 5;
            this.bt_back.Text = "返回上一级";
            this.bt_back.UseVisualStyleBackColor = true;
            this.bt_back.Click += new System.EventHandler(this.bt_back_Click);
            // 
            // bt_Open
            // 
            this.bt_Open.Location = new System.Drawing.Point(383, 16);
            this.bt_Open.Name = "bt_Open";
            this.bt_Open.Size = new System.Drawing.Size(75, 23);
            this.bt_Open.TabIndex = 12;
            this.bt_Open.Text = "打  开";
            this.bt_Open.UseVisualStyleBackColor = true;
            this.bt_Open.Click += new System.EventHandler(this.bt_Open_Click);
            // 
            // bt_encry
            // 
            this.bt_encry.Location = new System.Drawing.Point(383, 54);
            this.bt_encry.Name = "bt_encry";
            this.bt_encry.Size = new System.Drawing.Size(75, 23);
            this.bt_encry.TabIndex = 11;
            this.bt_encry.Text = "加  密";
            this.bt_encry.UseVisualStyleBackColor = true;
            this.bt_encry.Click += new System.EventHandler(this.bt_encry_Click);
            // 
            // bt_decip
            // 
            this.bt_decip.Location = new System.Drawing.Point(383, 92);
            this.bt_decip.Name = "bt_decip";
            this.bt_decip.Size = new System.Drawing.Size(75, 23);
            this.bt_decip.TabIndex = 11;
            this.bt_decip.Text = "解  密";
            this.bt_decip.UseVisualStyleBackColor = true;
            this.bt_decip.Click += new System.EventHandler(this.bt_decip_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.panel1);
            this.groupBox9.Controls.Add(this.groupBox1);
            this.groupBox9.Location = new System.Drawing.Point(12, 0);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(300, 403);
            this.groupBox9.TabIndex = 8;
            this.groupBox9.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bt_ResetKey);
            this.panel1.Controls.Add(this.tB_KeyConfirm);
            this.panel1.Controls.Add(this.bt_change);
            this.panel1.Controls.Add(this.tB_Key);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tB_Suffix);
            this.panel1.Controls.Add(this.tB_AfterEncry);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(9, 251);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 139);
            this.panel1.TabIndex = 6;
            // 
            // bt_ResetKey
            // 
            this.bt_ResetKey.Location = new System.Drawing.Point(214, 111);
            this.bt_ResetKey.Name = "bt_ResetKey";
            this.bt_ResetKey.Size = new System.Drawing.Size(68, 23);
            this.bt_ResetKey.TabIndex = 14;
            this.bt_ResetKey.Text = "重设密钥";
            this.bt_ResetKey.UseVisualStyleBackColor = true;
            this.bt_ResetKey.Click += new System.EventHandler(this.bt_ResetKey_Click);
            // 
            // tB_KeyConfirm
            // 
            this.tB_KeyConfirm.Location = new System.Drawing.Point(66, 111);
            this.tB_KeyConfirm.Name = "tB_KeyConfirm";
            this.tB_KeyConfirm.PasswordChar = '*';
            this.tB_KeyConfirm.Size = new System.Drawing.Size(142, 21);
            this.tB_KeyConfirm.TabIndex = 14;
            // 
            // bt_change
            // 
            this.bt_change.Location = new System.Drawing.Point(214, 77);
            this.bt_change.Name = "bt_change";
            this.bt_change.Size = new System.Drawing.Size(68, 23);
            this.bt_change.TabIndex = 14;
            this.bt_change.Text = "显示";
            this.bt_change.UseVisualStyleBackColor = true;
            this.bt_change.Click += new System.EventHandler(this.bt_change_Click);
            // 
            // tB_Key
            // 
            this.tB_Key.Location = new System.Drawing.Point(66, 77);
            this.tB_Key.Name = "tB_Key";
            this.tB_Key.PasswordChar = '*';
            this.tB_Key.Size = new System.Drawing.Size(142, 21);
            this.tB_Key.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "确认秘钥:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "秘    钥:";
            // 
            // tB_Suffix
            // 
            this.tB_Suffix.Location = new System.Drawing.Point(214, 42);
            this.tB_Suffix.Name = "tB_Suffix";
            this.tB_Suffix.ReadOnly = true;
            this.tB_Suffix.Size = new System.Drawing.Size(68, 21);
            this.tB_Suffix.TabIndex = 2;
            // 
            // tB_AfterEncry
            // 
            this.tB_AfterEncry.Location = new System.Drawing.Point(5, 42);
            this.tB_AfterEncry.Name = "tB_AfterEncry";
            this.tB_AfterEncry.Size = new System.Drawing.Size(203, 21);
            this.tB_AfterEncry.TabIndex = 1;
            this.tB_AfterEncry.TextChanged += new System.EventHandler(this.tB_AfterEncry_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "加（解）密后的文件路径:（后缀自动生成）";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(278, 415);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "label4";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 449);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件加解密";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox RemovableList;
        private System.Windows.Forms.Button bt_ScanDrive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button bt_back;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button bt_decip;
        private System.Windows.Forms.Button bt_encry;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tB_Suffix;
        private System.Windows.Forms.TextBox tB_AfterEncry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tB_Key;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_Open;
        private System.Windows.Forms.Button bt_change;
        private System.Windows.Forms.TextBox tB_KeyConfirm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bt_ResetKey;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Button bt_OpenDisk;
        private System.Windows.Forms.Button btn_help;
    }
}

