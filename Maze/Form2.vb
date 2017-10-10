Public Class Form2
    'THIS IS THE ADVANCED OPTIONS WINDOW
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        'Basically forces the values to be an odd number because thats how the program best functions
        If nudWidth.Value Mod 2 <> 1 Then
            Form1.arrayWidth = (nudWidth.Value + 1)
            Form1.arrayHeight = (nudWidth.Value + 1)
        Else
            Form1.arrayWidth = nudWidth.Value
            Form1.arrayHeight = nudWidth.Value
        End If
        If nudSizeX.Value Mod 2 <> 1 Then
            Form1.gridSize.X = (nudSizeX.Value + 1)
            Form1.gridSize.Y = (nudSizeX.Value + 1)
        Else
            Form1.gridSize = New Point(nudSizeX.Value, nudSizeX.Value)
        End If
        'Starts a new round after stuff has been changed
        Form1.NewRound()
        'closes itself like a messagebox
        Me.Close()
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Shows what the values currently are 
        nudWidth.Value = Form1.arrayWidth
        nudWidth.Value = Form1.arrayHeight
        nudSizeX.Value = Form1.gridSize.X
        nudSizeX.Value = Form1.gridSize.Y
    End Sub
End Class