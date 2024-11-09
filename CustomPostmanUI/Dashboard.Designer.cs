namespace CustomPostmanUI
{
    partial class Dashboard
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
            formHeader = new Label();
            apiLabel = new Label();
            apiText = new TextBox();
            callAPI = new Button();
            resultsText = new TextBox();
            statusStrip = new StatusStrip();
            systemStatus = new ToolStripStatusLabel();
            resultsLabel = new Label();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // formHeader
            // 
            formHeader.AutoSize = true;
            formHeader.Font = new Font("Segoe UI", 26F, FontStyle.Regular, GraphicsUnit.Point, 0);
            formHeader.Location = new Point(59, 38);
            formHeader.Name = "formHeader";
            formHeader.Size = new Size(417, 70);
            formHeader.TabIndex = 0;
            formHeader.Text = "Custom Postman";
            // 
            // apiLabel
            // 
            apiLabel.AutoSize = true;
            apiLabel.Location = new Point(78, 155);
            apiLabel.Name = "apiLabel";
            apiLabel.Size = new Size(81, 48);
            apiLabel.TabIndex = 1;
            apiLabel.Text = "API:";
            // 
            // apiText
            // 
            apiText.Location = new Point(165, 152);
            apiText.Name = "apiText";
            apiText.Size = new Size(1167, 55);
            apiText.TabIndex = 2;
            // 
            // callAPI
            // 
            callAPI.Location = new Point(1338, 152);
            callAPI.Name = "callAPI";
            callAPI.Size = new Size(167, 55);
            callAPI.TabIndex = 3;
            callAPI.Text = "Go";
            callAPI.UseVisualStyleBackColor = true;
            callAPI.Click += callAPI_Click;
            // 
            // resultsText
            // 
            resultsText.Location = new Point(78, 309);
            resultsText.Multiline = true;
            resultsText.Name = "resultsText";
            resultsText.ReadOnly = true;
            resultsText.ScrollBars = ScrollBars.Both;
            resultsText.Size = new Size(1427, 647);
            resultsText.TabIndex = 4;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.FromArgb(255, 192, 128);
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Items.AddRange(new ToolStripItem[] { systemStatus });
            statusStrip.Location = new Point(0, 986);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1600, 45);
            statusStrip.TabIndex = 5;
            statusStrip.Text = "statusStrip1";
            // 
            // systemStatus
            // 
            systemStatus.BackColor = Color.FromArgb(255, 224, 192);
            systemStatus.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            systemStatus.Name = "systemStatus";
            systemStatus.Size = new Size(92, 38);
            systemStatus.Text = "Ready";
            systemStatus.Click += toolStripStatusLabel1_Click;
            // 
            // resultsLabel
            // 
            resultsLabel.AutoSize = true;
            resultsLabel.Location = new Point(78, 245);
            resultsLabel.Name = "resultsLabel";
            resultsLabel.Size = new Size(131, 48);
            resultsLabel.TabIndex = 6;
            resultsLabel.Text = "Results";
            resultsLabel.Click += resultsLabel_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(20F, 48F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(1600, 1031);
            Controls.Add(resultsLabel);
            Controls.Add(statusStrip);
            Controls.Add(resultsText);
            Controls.Add(callAPI);
            Controls.Add(apiText);
            Controls.Add(apiLabel);
            Controls.Add(formHeader);
            Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(6);
            Name = "Dashboard";
            Text = "CustomPostman";
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label formHeader;
        private Label apiLabel;
        private TextBox apiText;
        private Button callAPI;
        private TextBox resultsText;
        private StatusStrip statusStrip;
        private Label resultsLabel;
        private ToolStripStatusLabel systemStatus;
    }
}
