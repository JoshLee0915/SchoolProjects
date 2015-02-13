Public Class NewPatternDialogeBox
    'NOTE: 29 x 29 is the maxium number of threads that can be rendered other wise they are to small to see
    Private WarpColor As Color = Color.Blue
    Private WeftColor As Color = Color.Green

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Double.TryParse(txtPram1.Text, Form1.arg1)
        Double.TryParse(txtPram2.Text, Form1.arg2)
        Form1.WarpColor = WarpColor
        Form1.WeftColor = WeftColor

        Form1.ThreadMode = True
        Me.Hide()

        Form1.Focus()
        Form1.createPattern()

        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Form1.Focus()
        Me.Close()
    End Sub

    Private Sub NewPatternDialogeBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pbxWarpColor.BackColor = WarpColor
        pbxWeftColor.BackColor = WeftColor
    End Sub

    Private Sub btnWarpColor_Click(sender As Object, e As EventArgs) Handles btnWarpColor.Click
        Dim result As DialogResult = ColorDialog1.ShowDialog()

        If result = DialogResult.OK Then
            WarpColor = ColorDialog1.Color
            pbxWarpColor.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub btnWeftColor_Click(sender As Object, e As EventArgs) Handles btnWeftColor.Click
        Dim result As DialogResult = ColorDialog1.ShowDialog()

        If result = DialogResult.OK Then
            WeftColor = ColorDialog1.Color
            pbxWeftColor.BackColor = ColorDialog1.Color
        End If
    End Sub
End Class