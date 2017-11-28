Public Class Principal
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim gui
        gui = GUIInsertar
        gui.Show()
    End Sub

    Private Sub txtListar_Click(sender As Object, e As EventArgs) Handles txtListar.Click
        Dim gui
        gui = GUIListar
        gui.Show()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim gui
        gui = GUIEliminar
        gui.Show()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim gui
        gui = GUIBuscar
        gui.Show()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim gui
        gui = GUIActualizar
        gui.Show()
    End Sub
End Class