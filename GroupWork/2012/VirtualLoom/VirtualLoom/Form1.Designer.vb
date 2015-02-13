<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PatternToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PatternToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PatternToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FabricImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PatternToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FabricToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PatternToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FabricToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbpPattern = New System.Windows.Forms.TabPage()
        Me.pbxPattern = New System.Windows.Forms.PictureBox()
        Me.tbpFabric = New System.Windows.Forms.TabPage()
        Me.pbxFabric = New System.Windows.Forms.PictureBox()
        Me.grbPattern = New System.Windows.Forms.GroupBox()
        Me.gbxPrinting = New System.Windows.Forms.GroupBox()
        Me.btnPrintFabric = New System.Windows.Forms.Button()
        Me.btnFabricPreview = New System.Windows.Forms.Button()
        Me.btnPrintPattern = New System.Windows.Forms.Button()
        Me.btnPatternPreview = New System.Windows.Forms.Button()
        Me.btnWeave = New System.Windows.Forms.Button()
        Me.grbColor = New System.Windows.Forms.GroupBox()
        Me.btnChange = New System.Windows.Forms.Button()
        Me.cmbThread = New System.Windows.Forms.ComboBox()
        Me.btnColor = New System.Windows.Forms.Button()
        Me.cmbThreadType = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ppdPattern = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintPatternDoc = New System.Drawing.Printing.PrintDocument()
        Me.ptdPattern = New System.Windows.Forms.PrintDialog()
        Me.PrintFabricDoc = New System.Drawing.Printing.PrintDocument()
        Me.ptdFabric = New System.Windows.Forms.PrintDialog()
        Me.ppdFabric = New System.Windows.Forms.PrintPreviewDialog()
        Me.OpenPattern = New System.Windows.Forms.OpenFileDialog()
        Me.SavePattern = New System.Windows.Forms.SaveFileDialog()
        Me.SaveImg = New System.Windows.Forms.SaveFileDialog()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tbpPattern.SuspendLayout()
        CType(Me.pbxPattern, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpFabric.SuspendLayout()
        CType(Me.pbxFabric, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbPattern.SuspendLayout()
        Me.gbxPrinting.SuspendLayout()
        Me.grbColor.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(817, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.PrintToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PatternToolStripMenuItem})
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'PatternToolStripMenuItem
        '
        Me.PatternToolStripMenuItem.Name = "PatternToolStripMenuItem"
        Me.PatternToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.PatternToolStripMenuItem.Text = "Pattern"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PatternToolStripMenuItem1})
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'PatternToolStripMenuItem1
        '
        Me.PatternToolStripMenuItem1.Name = "PatternToolStripMenuItem1"
        Me.PatternToolStripMenuItem1.Size = New System.Drawing.Size(213, 22)
        Me.PatternToolStripMenuItem1.Text = "Virtual Loom Pattern (.vlp)"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PatternToolStripMenuItem2, Me.FabricImageToolStripMenuItem})
        Me.SaveToolStripMenuItem.Enabled = False
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'PatternToolStripMenuItem2
        '
        Me.PatternToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AsFileToolStripMenuItem, Me.AsImageToolStripMenuItem})
        Me.PatternToolStripMenuItem2.Name = "PatternToolStripMenuItem2"
        Me.PatternToolStripMenuItem2.Size = New System.Drawing.Size(152, 22)
        Me.PatternToolStripMenuItem2.Text = "Pattern"
        '
        'AsFileToolStripMenuItem
        '
        Me.AsFileToolStripMenuItem.Name = "AsFileToolStripMenuItem"
        Me.AsFileToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.AsFileToolStripMenuItem.Text = "as .vlp"
        '
        'AsImageToolStripMenuItem
        '
        Me.AsImageToolStripMenuItem.Name = "AsImageToolStripMenuItem"
        Me.AsImageToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AsImageToolStripMenuItem.Text = "as image"
        '
        'FabricImageToolStripMenuItem
        '
        Me.FabricImageToolStripMenuItem.Enabled = False
        Me.FabricImageToolStripMenuItem.Name = "FabricImageToolStripMenuItem"
        Me.FabricImageToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.FabricImageToolStripMenuItem.Text = "Fabric Image"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripMenuItem1, Me.PreviewToolStripMenuItem})
        Me.PrintToolStripMenuItem.Enabled = False
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'PrintToolStripMenuItem1
        '
        Me.PrintToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PatternToolStripMenuItem3, Me.FabricToolStripMenuItem})
        Me.PrintToolStripMenuItem1.Name = "PrintToolStripMenuItem1"
        Me.PrintToolStripMenuItem1.Size = New System.Drawing.Size(115, 22)
        Me.PrintToolStripMenuItem1.Text = "Print"
        '
        'PatternToolStripMenuItem3
        '
        Me.PatternToolStripMenuItem3.Name = "PatternToolStripMenuItem3"
        Me.PatternToolStripMenuItem3.Size = New System.Drawing.Size(112, 22)
        Me.PatternToolStripMenuItem3.Text = "Pattern"
        '
        'FabricToolStripMenuItem
        '
        Me.FabricToolStripMenuItem.Enabled = False
        Me.FabricToolStripMenuItem.Name = "FabricToolStripMenuItem"
        Me.FabricToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.FabricToolStripMenuItem.Text = "Fabric"
        '
        'PreviewToolStripMenuItem
        '
        Me.PreviewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PatternToolStripMenuItem4, Me.FabricToolStripMenuItem1})
        Me.PreviewToolStripMenuItem.Name = "PreviewToolStripMenuItem"
        Me.PreviewToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.PreviewToolStripMenuItem.Text = "Preview"
        '
        'PatternToolStripMenuItem4
        '
        Me.PatternToolStripMenuItem4.Name = "PatternToolStripMenuItem4"
        Me.PatternToolStripMenuItem4.Size = New System.Drawing.Size(112, 22)
        Me.PatternToolStripMenuItem4.Text = "Pattern"
        '
        'FabricToolStripMenuItem1
        '
        Me.FabricToolStripMenuItem1.Enabled = False
        Me.FabricToolStripMenuItem1.Name = "FabricToolStripMenuItem1"
        Me.FabricToolStripMenuItem1.Size = New System.Drawing.Size(112, 22)
        Me.FabricToolStripMenuItem1.Text = "Fabric"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbpPattern)
        Me.TabControl1.Controls.Add(Me.tbpFabric)
        Me.TabControl1.Location = New System.Drawing.Point(248, 27)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(557, 476)
        Me.TabControl1.TabIndex = 1
        '
        'tbpPattern
        '
        Me.tbpPattern.Controls.Add(Me.pbxPattern)
        Me.tbpPattern.Location = New System.Drawing.Point(4, 22)
        Me.tbpPattern.Name = "tbpPattern"
        Me.tbpPattern.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpPattern.Size = New System.Drawing.Size(549, 450)
        Me.tbpPattern.TabIndex = 0
        Me.tbpPattern.Text = "Pattern"
        Me.tbpPattern.UseVisualStyleBackColor = True
        '
        'pbxPattern
        '
        Me.pbxPattern.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbxPattern.Location = New System.Drawing.Point(6, 6)
        Me.pbxPattern.Name = "pbxPattern"
        Me.pbxPattern.Size = New System.Drawing.Size(537, 438)
        Me.pbxPattern.TabIndex = 0
        Me.pbxPattern.TabStop = False
        '
        'tbpFabric
        '
        Me.tbpFabric.Controls.Add(Me.pbxFabric)
        Me.tbpFabric.Location = New System.Drawing.Point(4, 22)
        Me.tbpFabric.Name = "tbpFabric"
        Me.tbpFabric.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpFabric.Size = New System.Drawing.Size(549, 450)
        Me.tbpFabric.TabIndex = 1
        Me.tbpFabric.Text = "Fabric"
        Me.tbpFabric.UseVisualStyleBackColor = True
        '
        'pbxFabric
        '
        Me.pbxFabric.Location = New System.Drawing.Point(6, 6)
        Me.pbxFabric.Name = "pbxFabric"
        Me.pbxFabric.Size = New System.Drawing.Size(537, 438)
        Me.pbxFabric.TabIndex = 0
        Me.pbxFabric.TabStop = False
        '
        'grbPattern
        '
        Me.grbPattern.Controls.Add(Me.gbxPrinting)
        Me.grbPattern.Controls.Add(Me.btnWeave)
        Me.grbPattern.Controls.Add(Me.grbColor)
        Me.grbPattern.Controls.Add(Me.btnSave)
        Me.grbPattern.Controls.Add(Me.btnOpen)
        Me.grbPattern.Controls.Add(Me.btnNew)
        Me.grbPattern.Location = New System.Drawing.Point(12, 27)
        Me.grbPattern.Name = "grbPattern"
        Me.grbPattern.Size = New System.Drawing.Size(230, 335)
        Me.grbPattern.TabIndex = 2
        Me.grbPattern.TabStop = False
        Me.grbPattern.Text = "Pattern"
        '
        'gbxPrinting
        '
        Me.gbxPrinting.Controls.Add(Me.btnPrintFabric)
        Me.gbxPrinting.Controls.Add(Me.btnFabricPreview)
        Me.gbxPrinting.Controls.Add(Me.btnPrintPattern)
        Me.gbxPrinting.Controls.Add(Me.btnPatternPreview)
        Me.gbxPrinting.Enabled = False
        Me.gbxPrinting.Location = New System.Drawing.Point(9, 217)
        Me.gbxPrinting.Name = "gbxPrinting"
        Me.gbxPrinting.Size = New System.Drawing.Size(215, 110)
        Me.gbxPrinting.TabIndex = 6
        Me.gbxPrinting.TabStop = False
        Me.gbxPrinting.Text = "Printing"
        '
        'btnPrintFabric
        '
        Me.btnPrintFabric.Enabled = False
        Me.btnPrintFabric.Location = New System.Drawing.Point(113, 19)
        Me.btnPrintFabric.Name = "btnPrintFabric"
        Me.btnPrintFabric.Size = New System.Drawing.Size(96, 38)
        Me.btnPrintFabric.TabIndex = 8
        Me.btnPrintFabric.Text = "Print Fabric"
        Me.btnPrintFabric.UseVisualStyleBackColor = True
        '
        'btnFabricPreview
        '
        Me.btnFabricPreview.Enabled = False
        Me.btnFabricPreview.Location = New System.Drawing.Point(113, 63)
        Me.btnFabricPreview.Name = "btnFabricPreview"
        Me.btnFabricPreview.Size = New System.Drawing.Size(96, 38)
        Me.btnFabricPreview.TabIndex = 7
        Me.btnFabricPreview.Text = "Fabric Print Preview"
        Me.btnFabricPreview.UseVisualStyleBackColor = True
        '
        'btnPrintPattern
        '
        Me.btnPrintPattern.Location = New System.Drawing.Point(6, 19)
        Me.btnPrintPattern.Name = "btnPrintPattern"
        Me.btnPrintPattern.Size = New System.Drawing.Size(96, 38)
        Me.btnPrintPattern.TabIndex = 6
        Me.btnPrintPattern.Text = "Print Pattern"
        Me.btnPrintPattern.UseVisualStyleBackColor = True
        '
        'btnPatternPreview
        '
        Me.btnPatternPreview.Location = New System.Drawing.Point(6, 63)
        Me.btnPatternPreview.Name = "btnPatternPreview"
        Me.btnPatternPreview.Size = New System.Drawing.Size(96, 38)
        Me.btnPatternPreview.TabIndex = 5
        Me.btnPatternPreview.Text = "Pattern Print Preview"
        Me.btnPatternPreview.UseVisualStyleBackColor = True
        '
        'btnWeave
        '
        Me.btnWeave.Location = New System.Drawing.Point(6, 188)
        Me.btnWeave.Name = "btnWeave"
        Me.btnWeave.Size = New System.Drawing.Size(218, 23)
        Me.btnWeave.TabIndex = 4
        Me.btnWeave.Text = "Weave Pattern"
        Me.btnWeave.UseVisualStyleBackColor = True
        '
        'grbColor
        '
        Me.grbColor.Controls.Add(Me.btnChange)
        Me.grbColor.Controls.Add(Me.cmbThread)
        Me.grbColor.Controls.Add(Me.btnColor)
        Me.grbColor.Controls.Add(Me.cmbThreadType)
        Me.grbColor.Enabled = False
        Me.grbColor.Location = New System.Drawing.Point(9, 77)
        Me.grbColor.Name = "grbColor"
        Me.grbColor.Size = New System.Drawing.Size(215, 105)
        Me.grbColor.TabIndex = 3
        Me.grbColor.TabStop = False
        Me.grbColor.Text = "Color"
        '
        'btnChange
        '
        Me.btnChange.Location = New System.Drawing.Point(6, 75)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(203, 23)
        Me.btnChange.TabIndex = 7
        Me.btnChange.Text = "Change Color"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'cmbThread
        '
        Me.cmbThread.FormattingEnabled = True
        Me.cmbThread.Location = New System.Drawing.Point(108, 19)
        Me.cmbThread.Name = "cmbThread"
        Me.cmbThread.Size = New System.Drawing.Size(101, 21)
        Me.cmbThread.TabIndex = 6
        '
        'btnColor
        '
        Me.btnColor.Location = New System.Drawing.Point(6, 46)
        Me.btnColor.Name = "btnColor"
        Me.btnColor.Size = New System.Drawing.Size(203, 23)
        Me.btnColor.TabIndex = 5
        Me.btnColor.UseVisualStyleBackColor = True
        '
        'cmbThreadType
        '
        Me.cmbThreadType.FormattingEnabled = True
        Me.cmbThreadType.Items.AddRange(New Object() {"Warp", "Weft"})
        Me.cmbThreadType.Location = New System.Drawing.Point(6, 19)
        Me.cmbThreadType.Name = "cmbThreadType"
        Me.cmbThreadType.Size = New System.Drawing.Size(101, 21)
        Me.cmbThreadType.TabIndex = 4
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(9, 48)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(215, 23)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save Pattern"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(117, 19)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(107, 23)
        Me.btnOpen.TabIndex = 1
        Me.btnOpen.Text = "Open Pattern"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(9, 19)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(107, 23)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "New Pattern"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 493)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(817, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'ppdPattern
        '
        Me.ppdPattern.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppdPattern.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppdPattern.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppdPattern.Enabled = True
        Me.ppdPattern.Icon = CType(resources.GetObject("ppdPattern.Icon"), System.Drawing.Icon)
        Me.ppdPattern.Name = "ppdPattern"
        Me.ppdPattern.Visible = False
        '
        'PrintPatternDoc
        '
        '
        'ptdPattern
        '
        Me.ptdPattern.UseEXDialog = True
        '
        'PrintFabricDoc
        '
        '
        'ptdFabric
        '
        Me.ptdFabric.UseEXDialog = True
        '
        'ppdFabric
        '
        Me.ppdFabric.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppdFabric.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppdFabric.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppdFabric.Enabled = True
        Me.ppdFabric.Icon = CType(resources.GetObject("ppdFabric.Icon"), System.Drawing.Icon)
        Me.ppdFabric.Name = "ppdFabric"
        Me.ppdFabric.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(817, 515)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.grbPattern)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Virtual Loom"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tbpPattern.ResumeLayout(False)
        CType(Me.pbxPattern, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpFabric.ResumeLayout(False)
        CType(Me.pbxFabric, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbPattern.ResumeLayout(False)
        Me.gbxPrinting.ResumeLayout(False)
        Me.grbColor.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PatternToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PatternToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PatternToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FabricImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tbpPattern As System.Windows.Forms.TabPage
    Friend WithEvents pbxPattern As System.Windows.Forms.PictureBox
    Friend WithEvents tbpFabric As System.Windows.Forms.TabPage
    Friend WithEvents pbxFabric As System.Windows.Forms.PictureBox
    Friend WithEvents grbPattern As System.Windows.Forms.GroupBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents grbColor As System.Windows.Forms.GroupBox
    Friend WithEvents btnColor As System.Windows.Forms.Button
    Friend WithEvents cmbThreadType As System.Windows.Forms.ComboBox
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents cmbThread As System.Windows.Forms.ComboBox
    Friend WithEvents btnChange As System.Windows.Forms.Button
    Friend WithEvents btnWeave As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ppdPattern As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents btnPatternPreview As System.Windows.Forms.Button
    Friend WithEvents PrintPatternDoc As System.Drawing.Printing.PrintDocument
    Friend WithEvents gbxPrinting As System.Windows.Forms.GroupBox
    Friend WithEvents btnPrintPattern As System.Windows.Forms.Button
    Friend WithEvents btnPrintFabric As System.Windows.Forms.Button
    Friend WithEvents btnFabricPreview As System.Windows.Forms.Button
    Friend WithEvents ptdPattern As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintFabricDoc As System.Drawing.Printing.PrintDocument
    Friend WithEvents ptdFabric As System.Windows.Forms.PrintDialog
    Friend WithEvents ppdFabric As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PatternToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FabricToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PatternToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FabricToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenPattern As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SavePattern As System.Windows.Forms.SaveFileDialog
    Friend WithEvents SaveImg As System.Windows.Forms.SaveFileDialog

End Class
