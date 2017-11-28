Imports System.Net
Imports System.Text

Public Class GUIInsertar



    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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
        uri = "http://localhost:7101/EscuelaREST-EscuelaREST-context-root/jersey/SWEscuelaREST/addEscuela?n=" + n + "&p=" + p + "&es=" + es + "&f=" + f + "&id=" + id + ""


        refCliente = New WebClient()
        txtFecha.Text = Convert.ToDateTime(txtFecha.Text)
        postArray = Encoding.ASCII.GetBytes("n=" + n + "&p=" + p +
            "&es=" + es + "&f=" + f + "&id=" + id)
        refCliente.UploadData(uri, "PUT", postArray)

        txtEstudiante.Text = ""
        txtNombre.Text = ""
        txtID.Text = ""
        txtFecha.Text = ""
        txtProfesor.Text = ""

        MessageBox.Show("Listo!", "")

    End Sub
End Class
