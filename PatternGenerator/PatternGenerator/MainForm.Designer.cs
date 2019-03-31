namespace PatternGenerator
{
    partial class MainForm
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
            this.Generate = new System.Windows.Forms.Button();
            this.SetPattern = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Generate
            // 
            this.Generate.Location = new System.Drawing.Point(79, 26);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(123, 34);
            this.Generate.TabIndex = 0;
            this.Generate.Text = "Сгенерировать шаблон";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Page_Button_Click);
            // 
            // SetPattern
            // 
            this.SetPattern.FormattingEnabled = true;
            this.SetPattern.Items.AddRange(new object[] {
            "Pattern 1",
            "Pattern 2"});
            this.SetPattern.SelectedIndex = 0;
            this.SetPattern.Location = new System.Drawing.Point(81, 66);
            this.SetPattern.Name = "SetPattern";
            this.SetPattern.Size = new System.Drawing.Size(121, 21);
            this.SetPattern.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 129);
            this.Controls.Add(this.SetPattern);
            this.Controls.Add(this.Generate);
            this.Name = "MainForm";
            this.Text = "Генератор Шаблонов";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.ComboBox SetPattern;
    }
}

