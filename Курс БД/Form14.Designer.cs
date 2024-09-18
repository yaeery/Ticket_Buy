
namespace Курс_БД
{
    partial class Form14
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            "",
            "",
            "",
            ""}, -1);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.NumOfTicket = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NumOfTrain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NumOfVagon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NumOfPlace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WhereFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WhereFor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeInMovement = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TypeOfSit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(604, 555);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 79);
            this.button1.TabIndex = 0;
            this.button1.Text = "Выйти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(604, 462);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(177, 79);
            this.button2.TabIndex = 1;
            this.button2.Text = "Сдать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 27);
            this.label1.TabIndex = 3;
            // 
            // listView2
            // 
            this.listView2.AutoArrange = false;
            this.listView2.CheckBoxes = true;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NumOfTicket,
            this.NumOfTrain,
            this.columnHeader10,
            this.Date,
            this.Time,
            this.NumOfVagon,
            this.NumOfPlace,
            this.WhereFrom,
            this.WhereFor,
            this.TimeInMovement,
            this.TypeOfSit});
            this.listView2.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            this.listView2.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView2.Location = new System.Drawing.Point(21, 43);
            this.listView2.Margin = new System.Windows.Forms.Padding(4);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(1385, 410);
            this.listView2.TabIndex = 17;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // NumOfTicket
            // 
            this.NumOfTicket.Tag = "Номер билета";
            this.NumOfTicket.Text = "Номер билета";
            this.NumOfTicket.Width = 92;
            // 
            // NumOfTrain
            // 
            this.NumOfTrain.DisplayIndex = 2;
            this.NumOfTrain.Text = "Номер поезда";
            this.NumOfTrain.Width = 94;
            // 
            // columnHeader10
            // 
            this.columnHeader10.DisplayIndex = 1;
            this.columnHeader10.Text = "Дата покупки";
            this.columnHeader10.Width = 94;
            // 
            // Date
            // 
            this.Date.Text = "Дата отпрв.";
            this.Date.Width = 98;
            // 
            // Time
            // 
            this.Time.Text = "Время";
            this.Time.Width = 70;
            // 
            // NumOfVagon
            // 
            this.NumOfVagon.Text = "Номер вагона";
            this.NumOfVagon.Width = 99;
            // 
            // NumOfPlace
            // 
            this.NumOfPlace.Text = "Номер места";
            this.NumOfPlace.Width = 94;
            // 
            // WhereFrom
            // 
            this.WhereFrom.Text = "Откуда";
            this.WhereFrom.Width = 82;
            // 
            // WhereFor
            // 
            this.WhereFor.Text = "Куда";
            this.WhereFor.Width = 82;
            // 
            // TimeInMovement
            // 
            this.TimeInMovement.Text = "Время в пути";
            this.TimeInMovement.Width = 108;
            // 
            // TypeOfSit
            // 
            this.TypeOfSit.Text = "Тип Места";
            this.TypeOfSit.Width = 124;
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "data source=HPLAPTOP\\SQLEXPRESS; Initial Catalog=Жд курс;Integrated Security = Tr" +
    "ue";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // Form14
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1483, 731);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form14";
            this.Text = "Просмотр покупк";
            this.Load += new System.EventHandler(this.Form14_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader NumOfTicket;
        private System.Windows.Forms.ColumnHeader NumOfTrain;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.ColumnHeader NumOfVagon;
        private System.Windows.Forms.ColumnHeader NumOfPlace;
        private System.Windows.Forms.ColumnHeader WhereFrom;
        private System.Windows.Forms.ColumnHeader WhereFor;
        private System.Windows.Forms.ColumnHeader TimeInMovement;
        private System.Windows.Forms.ColumnHeader TypeOfSit;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
    }
}