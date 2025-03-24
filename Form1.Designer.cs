namespace FindFiles
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.listBoxResultsDirectories = new System.Windows.Forms.ListBox();
            this.listBoxResultsFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxResultsFilesInDirectory = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(69, 129);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(407, 31);
            this.textBoxPath.TabIndex = 0;
            this.textBoxPath.Text = "путь к папке с файлом";
            // 
            // textBoxFile
            // 
            this.textBoxFile.Location = new System.Drawing.Point(69, 205);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.Size = new System.Drawing.Size(407, 31);
            this.textBoxFile.TabIndex = 0;
            this.textBoxFile.Text = "название файла";
            // 
            // listBoxResultsDirectories
            // 
            this.listBoxResultsDirectories.FormattingEnabled = true;
            this.listBoxResultsDirectories.ItemHeight = 25;
            this.listBoxResultsDirectories.Location = new System.Drawing.Point(60, 363);
            this.listBoxResultsDirectories.Name = "listBoxResultsDirectories";
            this.listBoxResultsDirectories.Size = new System.Drawing.Size(950, 304);
            this.listBoxResultsDirectories.TabIndex = 1;
            // 
            // listBoxResultsFiles
            // 
            this.listBoxResultsFiles.FormattingEnabled = true;
            this.listBoxResultsFiles.ItemHeight = 25;
            this.listBoxResultsFiles.Location = new System.Drawing.Point(605, 828);
            this.listBoxResultsFiles.Name = "listBoxResultsFiles";
            this.listBoxResultsFiles.Size = new System.Drawing.Size(1058, 304);
            this.listBoxResultsFiles.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(390, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Список вложеных папок";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(972, 783);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Список искомых файлов";
            // 
            // listBoxResultsFilesInDirectory
            // 
            this.listBoxResultsFilesInDirectory.FormattingEnabled = true;
            this.listBoxResultsFilesInDirectory.ItemHeight = 25;
            this.listBoxResultsFilesInDirectory.Location = new System.Drawing.Point(1053, 363);
            this.listBoxResultsFilesInDirectory.Name = "listBoxResultsFilesInDirectory";
            this.listBoxResultsFilesInDirectory.Size = new System.Drawing.Size(1018, 304);
            this.listBoxResultsFilesInDirectory.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1429, 325);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(249, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Список файлов в папке";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2144, 1207);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxResultsFilesInDirectory);
            this.Controls.Add(this.listBoxResultsFiles);
            this.Controls.Add(this.listBoxResultsDirectories);
            this.Controls.Add(this.textBoxFile);
            this.Controls.Add(this.textBoxPath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.ListBox listBoxResultsDirectories;
        private System.Windows.Forms.ListBox listBoxResultsFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxResultsFilesInDirectory;
        private System.Windows.Forms.Label label3;
    }
}

