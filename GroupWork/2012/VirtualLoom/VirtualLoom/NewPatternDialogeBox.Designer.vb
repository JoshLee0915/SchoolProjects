<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewPatternDialogeBox
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
        Me.txtPram1 = New System.Windows.Forms.TextBox()
        Me.txtPram2 = New System.Windows.Forms.TextBox()
        Me.lblPram1 = New System.Windows.Forms.Label()
        Me.lblPram2 = New System.Windows.Forms.Label()
        Me.lblDim1 = New System.Windows.Forms.Label()
        Me.lblDim2 = New System.Windows.Forms.Label()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnWarpColor = New System.Windows.Forms.Button()
        Me.btnWeftColor = New System.Windows.Forms.Button()
        Me.pbxWarpColor = New System.Windows.Forms.PictureBox()
        Me.pbxWeftColor = New System.Windows.Forms.PictureBox()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        CType(Me.pbxWarpColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxWeftColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPram1
        '
        Me.txtPram1.Location = New System.Drawing.Point(58, 12)
        Me.txtPram1.Name = "txtPram1"
        Me.txtPram1.Size = New System.Drawing.Size(59, 20)
        Me.txtPram1.TabIndex = 2
        '
        'txtPram2
        '
        Me.txtPram2.Location = New System.Drawing.Point(58, 38)
        Me.txtPram2.Name = "txtPram2"
        Me.txtPram2.Size = New System.Drawing.Size(59, 20)
        Me.txtPram2.TabIndex = 3
        '
        'lblPram1
        '
        Me.lblPram1.AutoSize = True
        Me.lblPram1.Location = New System.Drawing.Point(8, 15)
        Me.lblPram1.Name = "lblPram1"
        Me.lblPram1.Size = New System.Drawing.Size(36, 13)
        Me.lblPram1.TabIndex = 4
        Me.lblPram1.Text = "Warp:"
        '
        'lblPram2
        '
        Me.lblPram2.AutoSize = True
        Me.lblPram2.Location = New System.Drawing.Point(8, 41)
        Me.lblPram2.Name = "lblPram2"
        Me.lblPram2.Size = New System.Drawing.Size(33, 13)
        Me.lblPram2.TabIndex = 5
        Me.lblPram2.Text = "Weft:"
        '
        'lblDim1
        '
        Me.lblDim1.AutoSize = True
        Me.lblDim1.Location = New System.Drawing.Point(123, 15)
        Me.lblDim1.Name = "lblDim1"
        Me.lblDim1.Size = New System.Drawing.Size(46, 13)
        Me.lblDim1.TabIndex = 6
        Me.lblDim1.Text = "Threads"
        '
        'lblDim2
        '
        Me.lblDim2.AutoSize = True
        Me.lblDim2.Location = New System.Drawing.Point(123, 41)
        Me.lblDim2.Name = "lblDim2"
        Me.lblDim2.Size = New System.Drawing.Size(46, 13)
        Me.lblDim2.TabIndex = 7
        Me.lblDim2.Text = "Threads"
        '
        'btnCreate
        '
        Me.btnCreate.Location = New System.Drawing.Point(10, 122)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(100, 23)
        Me.btnCreate.TabIndex = 10
        Me.btnCreate.Text = "Create"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(115, 122)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(70, 23)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnWarpColor
        '
        Me.btnWarpColor.Location = New System.Drawing.Point(11, 64)
        Me.btnWarpColor.Name = "btnWarpColor"
        Me.btnWarpColor.Size = New System.Drawing.Size(75, 23)
        Me.btnWarpColor.TabIndex = 12
        Me.btnWarpColor.Text = "Warp Color"
        Me.btnWarpColor.UseVisualStyleBackColor = True
        '
        'btnWeftColor
        '
        Me.btnWeftColor.Location = New System.Drawing.Point(11, 93)
        Me.btnWeftColor.Name = "btnWeftColor"
        Me.btnWeftColor.Size = New System.Drawing.Size(75, 23)
        Me.btnWeftColor.TabIndex = 13
        Me.btnWeftColor.Text = "Weft Color"
        Me.btnWeftColor.UseVisualStyleBackColor = True
        '
        'pbxWarpColor
        '
        Me.pbxWarpColor.BackColor = System.Drawing.Color.Blue
        Me.pbxWarpColor.Location = New System.Drawing.Point(92, 64)
        Me.pbxWarpColor.Name = "pbxWarpColor"
        Me.pbxWarpColor.Size = New System.Drawing.Size(93, 23)
        Me.pbxWarpColor.TabIndex = 14
        Me.pbxWarpColor.TabStop = False
        '
        'pbxWeftColor
        '
        Me.pbxWeftColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pbxWeftColor.Location = New System.Drawing.Point(92, 93)
        Me.pbxWeftColor.Name = "pbxWeftColor"
        Me.pbxWeftColor.Size = New System.Drawing.Size(93, 23)
        Me.pbxWeftColor.TabIndex = 15
        Me.pbxWeftColor.TabStop = False
        '
        'NewPatternDialogeBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(199, 150)
        Me.Controls.Add(Me.pbxWeftColor)
        Me.Controls.Add(Me.pbxWarpColor)
        Me.Controls.Add(Me.btnWeftColor)
        Me.Controls.Add(Me.btnWarpColor)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.lblDim2)
        Me.Controls.Add(Me.lblDim1)
        Me.Controls.Add(Me.lblPram2)
        Me.Controls.Add(Me.lblPram1)
        Me.Controls.Add(Me.txtPram2)
        Me.Controls.Add(Me.txtPram1)
        Me.Name = "NewPatternDialogeBox"
        Me.Text = "New Pattern"
        CType(Me.pbxWarpColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxWeftColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPram1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPram2 As System.Windows.Forms.TextBox
    Friend WithEvents lblPram1 As System.Windows.Forms.Label
    Friend WithEvents lblPram2 As System.Windows.Forms.Label
    Friend WithEvents lblDim1 As System.Windows.Forms.Label
    Friend WithEvents lblDim2 As System.Windows.Forms.Label
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnWarpColor As System.Windows.Forms.Button
    Friend WithEvents btnWeftColor As System.Windows.Forms.Button
    Friend WithEvents pbxWarpColor As System.Windows.Forms.PictureBox
    Friend WithEvents pbxWeftColor As System.Windows.Forms.PictureBox
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
End Class
