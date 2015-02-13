Public Class Form1
    Public arg1 As Double
    Public arg2 As Double
    Public ThreadMode As Boolean
    Public WarpColor As Color = Color.Blue
    Public WeftColor As Color = Color.Green
    Private Const diameter As Double = 1 / 16 'assume the thread will be 1/16 inch in diameter
    Private saved As Boolean = False
    Private patternCreated As Boolean = False
    Private pattern As PatternClass

    Public Sub createPattern()
        If (arg1 > 0 And arg2 > 0) Then
            lblStatus.Text = "Creating new pattern..."
            Threading.Thread.Sleep(10)
            If ThreadMode Then
                pattern = New PatternClass(arg2, arg1, pbxPattern.Width, pbxPattern.Height, WeftColor, WarpColor)
            Else
                pattern = New PatternClass(arg2, arg1, diameter, pbxPattern.Width, pbxPattern.Height, WeftColor, WarpColor)
            End If
            pbxPattern.Image = pattern.drawPattern()

            grbColor.Enabled = True
            gbxPrinting.Enabled = True
            PrintToolStripMenuItem.Enabled = True
            btnSave.Enabled = True
            SaveToolStripMenuItem.Enabled = True

            patternCreated = True

            cmbThread.Items.Clear()

            If arg1 <> vbNull And cmbThreadType.SelectedIndex = threadTypes.warp Then
                For x As Integer = 1 To arg1
                    cmbThread.Items.Add(x)
                Next
            ElseIf arg2 <> vbNull And cmbThreadType.SelectedIndex = threadTypes.weft Then
                For x As Integer = 1 To arg2
                    cmbThread.Items.Add(x)
                Next
            End If

            If cmbThread.Items.Count > 0 Then
                cmbThread.SelectedIndex = 0
            End If
            lblStatus.Text = "Created!"
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbThreadType.SelectedIndex = threadTypes.warp
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click

    End Sub

    Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            btnColor.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub pbxPattern_MouseMove(sender As Object, e As MouseEventArgs) Handles pbxPattern.MouseMove
        lblStatus.Text = "X: " & e.X & "Y: " & e.Y
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        TabControl1.SelectedIndex = 0
        NewPatternDialogeBox.Show()
    End Sub

    Private Sub cmbThreadType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbThreadType.SelectedIndexChanged
        cmbThread.Items.Clear()

        If arg1 <> vbNull And cmbThreadType.SelectedIndex = threadTypes.warp Then
            For x As Integer = 1 To arg1
                cmbThread.Items.Add(x)
            Next
        ElseIf arg2 <> vbNull And cmbThreadType.SelectedIndex = threadTypes.weft Then
            For x As Integer = 1 To arg2
                cmbThread.Items.Add(x)
            Next
        End If

        If cmbThread.Items.Count > 0 Then
            cmbThread.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmbThread_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbThread.SelectedIndexChanged
        btnColor.BackColor = pattern.getThreadColor(cmbThreadType.SelectedIndex, cmbThread.SelectedIndex)
    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        pbxPattern.Image = pattern.changeThreadColor(cmbThreadType.SelectedIndex, cmbThread.SelectedIndex, btnColor.BackColor)
    End Sub

    Private Sub pbxPattern_MouseClick(sender As Object, e As MouseEventArgs) Handles pbxPattern.MouseClick
        pbxPattern.Image = pattern.update(e.X, e.Y)
    End Sub

    Private Sub btnWeave_Click(sender As Object, e As EventArgs) Handles btnWeave.Click
        TabControl1.SelectedIndex = 1
        pbxFabric.Image = pattern.weave(pbxFabric.Width, pbxFabric.Height, 3, 6, diameter)
        btnFabricPreview.Enabled = True
        btnPrintFabric.Enabled = True
        FabricToolStripMenuItem.Enabled = True
        FabricToolStripMenuItem1.Enabled = True
        FabricImageToolStripMenuItem.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnPatternPreview.Click
        ppdPattern.Document = PrintPatternDoc
        ppdPattern.Show()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintPatternDoc.PrintPage
        e.Graphics.DrawImage(pbxPattern.Image, 0, 0)
    End Sub

    Private Sub btnPrintPattern_Click(sender As Object, e As EventArgs) Handles btnPrintPattern.Click
        ptdPattern.Document = PrintPatternDoc
        ptdPattern.ShowDialog()
    End Sub

    Private Sub PrintFabricDoc_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintFabricDoc.PrintPage
        e.Graphics.DrawImage(pbxFabric.Image, 0, 0)
    End Sub

    Private Sub btnPrintFabric_Click(sender As Object, e As EventArgs) Handles btnPrintFabric.Click
        ptdFabric.Document = PrintFabricDoc
        ptdFabric.ShowDialog()
    End Sub

    Private Sub btnFabricPreview_Click(sender As Object, e As EventArgs) Handles btnFabricPreview.Click
        ppdFabric.Document = PrintFabricDoc
        ppdFabric.Show()
    End Sub

    Private Sub PatternToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles PatternToolStripMenuItem4.Click
        btnPatternPreview.PerformClick()
    End Sub

    Private Sub FabricToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FabricToolStripMenuItem1.Click
        btnFabricPreview.PerformClick()
    End Sub

    Private Sub PatternToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles PatternToolStripMenuItem3.Click
        btnPrintPattern.PerformClick()
    End Sub

    Private Sub FabricToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FabricToolStripMenuItem.Click
        btnPrintFabric.PerformClick()
    End Sub

    Private Sub PatternToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PatternToolStripMenuItem.Click
        btnNew.PerformClick()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SavePattern.Filter = "Virtual Loom Pattern (*.vlp)|*.vlp|All files(*.*)|*.*"

        If SavePattern.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim SaveStream As IO.Stream = SavePattern.OpenFile
            If SaveStream IsNot Nothing Then
                lblStatus.Text = "Saving File..."
                Dim success As Boolean = pattern.save(SaveStream)

                If success Then
                    saved = success
                    lblStatus.Text = "Saved!"
                Else
                    lblStatus.Text = "Save Error!"
                End If
            End If
            SaveStream.Close()
        End If
    End Sub

    Private Sub FabricImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FabricImageToolStripMenuItem.Click
        If pbxFabric.Image IsNot Nothing Then
            SaveImg.Filter = "*.jpg|*.jpg"

            If SaveImg.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim imgStream As IO.Stream = SaveImg.OpenFile()

                If imgStream IsNot Nothing Then
                    lblStatus.Text = "Saving Fabric Image..."
                    pbxFabric.Image.Save(imgStream, System.Drawing.Imaging.ImageFormat.Jpeg)
                    lblStatus.Text = "Saved!"
                End If

                imgStream.Close()
            End If
        End If
    End Sub

    Private Sub PatternToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PatternToolStripMenuItem1.Click
        btnOpen.PerformClick()
    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        OpenPattern.Filter = "Virtual Loom Pattern (*.vlp)|*.vlp|All files(*.*)|*.*"

        If OpenPattern.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim tempStream As IO.Stream = OpenPattern.OpenFile
            If tempStream IsNot Nothing Then
                lblStatus.Text = "Opening Pattern..."
                pattern = New PatternClass(tempStream, pbxPattern.Height, pbxPattern.Width)

                If pattern.ErrorCheck Then
                    lblStatus.Text = "Error!"
                Else
                    lblStatus.Text = "Opened!"
                    pbxPattern.Image = pattern.drawPattern()
                    saved = False
                End If
            End If
            tempStream.Close()
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not saved And patternCreated Then
            If Windows.Forms.MessageBox.Show("You have not saved your pattern. Do you want to save your pattern?", "Pattern Not Saved", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                btnSave.PerformClick()
            End If
        End If
    End Sub

    Private Sub AsImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsImageToolStripMenuItem.Click
        If pbxPattern.Image IsNot Nothing Then
            SaveImg.Filter = "*.jpg|*.jpg"

            If SaveImg.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim imgStream As IO.Stream = SaveImg.OpenFile()

                If imgStream IsNot Nothing Then
                    lblStatus.Text = "Saving Pattern Image..."
                    pbxPattern.Image.Save(imgStream, System.Drawing.Imaging.ImageFormat.Jpeg)
                    lblStatus.Text = "Saved!"
                End If

                imgStream.Close()
            End If
        End If
    End Sub
End Class
