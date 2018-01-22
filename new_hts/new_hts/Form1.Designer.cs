namespace new_hts
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.옵션ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.로그인ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.로그아웃ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.계좌조회ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt아이디 = new System.Windows.Forms.TextBox();
            this.cbo계좌번호 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn종목추가 = new System.Windows.Forms.Button();
            this.txt종목코드 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt금액 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.stockInfoView = new System.Windows.Forms.DataGridView();
            this.종목명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.현재가 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.등락률 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.거래량 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lst일반 = new System.Windows.Forms.ListBox();
            this.lst조회 = new System.Windows.Forms.ListBox();
            this.lst에러 = new System.Windows.Forms.ListBox();
            this.lst실시간 = new System.Windows.Forms.ListBox();
            this.axKHOpenAPI1 = new AxKHOpenAPILib.AxKHOpenAPI();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockInfoView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.옵션ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1544, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 옵션ToolStripMenuItem
            // 
            this.옵션ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.로그인ToolStripMenuItem,
            this.로그아웃ToolStripMenuItem,
            this.계좌조회ToolStripMenuItem});
            this.옵션ToolStripMenuItem.Name = "옵션ToolStripMenuItem";
            this.옵션ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.옵션ToolStripMenuItem.Text = "옵션";
            // 
            // 로그인ToolStripMenuItem
            // 
            this.로그인ToolStripMenuItem.Name = "로그인ToolStripMenuItem";
            this.로그인ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.로그인ToolStripMenuItem.Text = "로그인";
            this.로그인ToolStripMenuItem.Click += new System.EventHandler(this.로그인ToolStripMenuItem_Click);
            // 
            // 로그아웃ToolStripMenuItem
            // 
            this.로그아웃ToolStripMenuItem.Name = "로그아웃ToolStripMenuItem";
            this.로그아웃ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.로그아웃ToolStripMenuItem.Text = "로그아웃";
            this.로그아웃ToolStripMenuItem.Click += new System.EventHandler(this.로그아웃ToolStripMenuItem_Click);
            // 
            // 계좌조회ToolStripMenuItem
            // 
            this.계좌조회ToolStripMenuItem.Name = "계좌조회ToolStripMenuItem";
            this.계좌조회ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.계좌조회ToolStripMenuItem.Text = "계좌조회";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt아이디);
            this.groupBox1.Controls.Add(this.cbo계좌번호);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(475, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 95);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "접속정보";
            // 
            // txt아이디
            // 
            this.txt아이디.Location = new System.Drawing.Point(68, 52);
            this.txt아이디.Name = "txt아이디";
            this.txt아이디.Size = new System.Drawing.Size(100, 21);
            this.txt아이디.TabIndex = 3;
            // 
            // cbo계좌번호
            // 
            this.cbo계좌번호.FormattingEnabled = true;
            this.cbo계좌번호.Location = new System.Drawing.Point(68, 18);
            this.cbo계좌번호.Name = "cbo계좌번호";
            this.cbo계좌번호.Size = new System.Drawing.Size(121, 20);
            this.cbo계좌번호.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "아이디 :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "계좌번호 :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn종목추가);
            this.groupBox2.Controls.Add(this.txt종목코드);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt금액);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(475, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 110);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "주문정보";
            // 
            // btn종목추가
            // 
            this.btn종목추가.Location = new System.Drawing.Point(68, 73);
            this.btn종목추가.Name = "btn종목추가";
            this.btn종목추가.Size = new System.Drawing.Size(75, 23);
            this.btn종목추가.TabIndex = 4;
            this.btn종목추가.Text = "종목추가";
            this.btn종목추가.UseVisualStyleBackColor = true;
            this.btn종목추가.Click += new System.EventHandler(this.btn종목추가_Click);
            // 
            // txt종목코드
            // 
            this.txt종목코드.Location = new System.Drawing.Point(68, 46);
            this.txt종목코드.Name = "txt종목코드";
            this.txt종목코드.Size = new System.Drawing.Size(100, 21);
            this.txt종목코드.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "종목코드 :";
            // 
            // txt금액
            // 
            this.txt금액.Location = new System.Drawing.Point(68, 21);
            this.txt금액.Name = "txt금액";
            this.txt금액.Size = new System.Drawing.Size(100, 21);
            this.txt금액.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "금액 :";
            // 
            // stockInfoView
            // 
            this.stockInfoView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockInfoView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.종목명,
            this.현재가,
            this.등락률,
            this.거래량});
            this.stockInfoView.Location = new System.Drawing.Point(13, 28);
            this.stockInfoView.Name = "stockInfoView";
            this.stockInfoView.RowTemplate.Height = 23;
            this.stockInfoView.Size = new System.Drawing.Size(456, 334);
            this.stockInfoView.TabIndex = 4;
            // 
            // 종목명
            // 
            this.종목명.HeaderText = "종목명";
            this.종목명.Name = "종목명";
            // 
            // 현재가
            // 
            this.현재가.HeaderText = "현재가";
            this.현재가.Name = "현재가";
            // 
            // 등락률
            // 
            this.등락률.HeaderText = "등락률";
            this.등락률.Name = "등락률";
            // 
            // 거래량
            // 
            this.거래량.HeaderText = "거래량";
            this.거래량.Name = "거래량";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 720);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1544, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(164, 17);
            this.toolStripStatusLabel1.Text = "HTS에 오신 것을 환영합니다.";
            // 
            // lst일반
            // 
            this.lst일반.FormattingEnabled = true;
            this.lst일반.ItemHeight = 12;
            this.lst일반.Location = new System.Drawing.Point(690, 48);
            this.lst일반.Name = "lst일반";
            this.lst일반.Size = new System.Drawing.Size(691, 124);
            this.lst일반.TabIndex = 6;
            // 
            // lst조회
            // 
            this.lst조회.FormattingEnabled = true;
            this.lst조회.ItemHeight = 12;
            this.lst조회.Location = new System.Drawing.Point(690, 317);
            this.lst조회.Name = "lst조회";
            this.lst조회.Size = new System.Drawing.Size(691, 124);
            this.lst조회.TabIndex = 7;
            // 
            // lst에러
            // 
            this.lst에러.FormattingEnabled = true;
            this.lst에러.ItemHeight = 12;
            this.lst에러.Location = new System.Drawing.Point(690, 175);
            this.lst에러.Name = "lst에러";
            this.lst에러.Size = new System.Drawing.Size(691, 136);
            this.lst에러.TabIndex = 8;
            // 
            // lst실시간
            // 
            this.lst실시간.FormattingEnabled = true;
            this.lst실시간.ItemHeight = 12;
            this.lst실시간.Location = new System.Drawing.Point(690, 447);
            this.lst실시간.Name = "lst실시간";
            this.lst실시간.Size = new System.Drawing.Size(691, 136);
            this.lst실시간.TabIndex = 9;
            // 
            // axKHOpenAPI1
            // 
            this.axKHOpenAPI1.Enabled = true;
            this.axKHOpenAPI1.Location = new System.Drawing.Point(414, 663);
            this.axKHOpenAPI1.Name = "axKHOpenAPI1";
            this.axKHOpenAPI1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axKHOpenAPI1.OcxState")));
            this.axKHOpenAPI1.Size = new System.Drawing.Size(55, 29);
            this.axKHOpenAPI1.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1544, 742);
            this.Controls.Add(this.axKHOpenAPI1);
            this.Controls.Add(this.lst실시간);
            this.Controls.Add(this.lst에러);
            this.Controls.Add(this.lst조회);
            this.Controls.Add(this.lst일반);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.stockInfoView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockInfoView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem 옵션ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 로그인ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 로그아웃ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 계좌조회ToolStripMenuItem;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txt아이디;
        public System.Windows.Forms.ComboBox cbo계좌번호;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button btn종목추가;
        public System.Windows.Forms.TextBox txt종목코드;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txt금액;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView stockInfoView;
        public System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ListBox lst일반;
        public System.Windows.Forms.ListBox lst조회;
        public System.Windows.Forms.ListBox lst에러;
        public System.Windows.Forms.ListBox lst실시간;
        public System.Windows.Forms.DataGridViewTextBoxColumn 종목명;
        public System.Windows.Forms.DataGridViewTextBoxColumn 현재가;
        public System.Windows.Forms.DataGridViewTextBoxColumn 등락률;
        public System.Windows.Forms.DataGridViewTextBoxColumn 거래량;
        private AxKHOpenAPILib.AxKHOpenAPI axKHOpenAPI1;
    }
}

