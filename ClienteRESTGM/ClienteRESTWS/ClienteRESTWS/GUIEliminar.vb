Imports System.Net
Imports System.Text
Public Class GUIEliminar
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim refCliente As WebClient
        Dim content As String
        Dim postArray As Byte()
        Dim uri As String
        Dim id As String
        id = txtID.Text

        uri = "http://127.0.0.1:7101/EscuelaREST-EscuelaREST-context-root/jersey/SWEscuelaREST/eliminarEscuela?idEsc=" + id + ""

        refCliente = New WebClient()
        postArray = Encoding.ASCII.GetBytes("idEsc=" + id)
        refCliente.UploadData(uri, "DELETE", postArray)

        lblEstudiante.Text = ""
        lblFecha.Text = ""
        lblNombre.Text = ""
        lblProfesor.Text = ""

        MessageBox.Show("Eliminado!", "")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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