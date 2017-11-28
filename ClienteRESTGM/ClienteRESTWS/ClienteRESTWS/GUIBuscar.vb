Public Class GUIBuscar
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        buscar()
    End Sub

    Public Sub buscar()
        Dim uri As String
        Dim id As String
        id = txtID.Text

        uri = "http://localhost:7101/EscuelaREST-EscuelaREST-context-root/jersey/SWEscuelaREST/buscarSW?idEsc=" + id + ""

        Dim document As XDocument = XDocument.Load(uri)

        For Each listEsc As XElement In document...<escuela>
            Dim nId As String = listEsc.Element("idE")
            If id.Equals(nId) Then
                Dim nNombre As String = listEsc.Element("nombre")
                Dim nProfesor As String = listEsc.Element("profesor")
                Dim nFecha As Date = listEsc.Element("fechaCreacion")
                Dim nEstudiante As String = listEsc.Element("estudiante")
                lblNombre.Text = nNombre
                lblProfesor.Text = nProfesor
                lblFecha.Text = nFecha
                lblEstudiante.Text = nEstudiante
            Else
                MessageBox.Show("No existe!", "")
            End If

        Next
    End Sub
End Class