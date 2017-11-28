Imports System.Net
Imports System.Text
Imports System.Xml
Imports System.IO


Public Class GUIListar
    Public Class Escuelaa

        Public nombre As String
        Public profesor As String
        Public estudiante As String
        Public fechaCreacion As Date
        Public idE As String
    End Class

    Private Sub GUIListar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getDatos()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        ListView1.Items.Clear()
        getDatos()
    End Sub

    Public Sub getDatos()
        Dim uri As String
        uri = "http://localhost:7101/EscuelaREST-EscuelaREST-context-root/jersey/SWEscuelaREST"
        Dim document As XDocument = XDocument.Load(uri)

        For Each listEsc As XElement In document...<escuela>
            Dim nId As String = listEsc.Element("idE")
            Dim nNombre As String = listEsc.Element("nombre")
            Dim nProfesor As String = listEsc.Element("profesor")
            Dim nFecha As Date = listEsc.Element("fechaCreacion")
            Dim nEstudiante As String = listEsc.Element("estudiante")
            Dim Item As New ListViewItem(nId)
            Item.SubItems.Add(nNombre)
            Item.SubItems.Add(nProfesor)
            Item.SubItems.Add(nFecha)
            Item.SubItems.Add(nEstudiante)

            ListView1.Items.Add(Item)
        Next
    End Sub
End Class