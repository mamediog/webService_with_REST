Imports System.Net
Imports System.Text
Public Class GUIActualizar
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
                txtNombre.Text = nNombre
                txtProfesor.Text = nProfesor
                txtFecha.Text = nFecha
                txtEstudiante.Text = nEstudiante
            Else
                MessageBox.Show("No existe!", "")
            End If

        Next
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim uri As String
        Dim refCliente As WebClient
        Dim content As String
        Dim postArray As Byte()
        Dim n As String
        Dim p As String
        Dim es As String
        Dim f As Date
        Dim id As String
        n = txtNombre.Text
        p = txtProfesor.Text
        es = txtEstudiante.Text
        f = Convert.ToDateTime(txtFecha.Text)
        id = txtID.Text
        uri = "http://localhost:7101/EscuelaREST-EscuelaREST-context-root/jersey/SWEscuelaREST/editarSW?n=" + n + "&p=" + p + "&es=" + es + "&id=" + id + "&f=" + f + ""


        refCliente = New WebClient()
        txtFecha.Text = Convert.ToDateTime(txtFecha.Text)
        postArray = Encoding.ASCII.GetBytes("n=" + n + "&p=" + p +
            "&es=" + es + "&f=" + f + "&id=" + id)
        refCliente.UploadData(uri, "PUT", postArray)

        MessageBox.Show("Listo!", "")
    End Sub
End Class