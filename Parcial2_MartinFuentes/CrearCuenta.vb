Imports MySql.Data.MySqlClient
Imports Conexion
Imports TablaDB
Imports System.Diagnostics.Eventing


Public Class CrearCuenta

    Private Sub btnCrearCuenta_Click(sender As Object, e As EventArgs) Handles btnCrearCuenta.Click
        Dim tabla As New TablaBD
        Dim seagrego As Boolean = tabla.InsertarUSU(txtCed.Text, txtNom.Text, txtDir.Text, txtTel.Text, txtUsu.Text, txtContra.Text)
        If (seagrego) Then
            Me.Close()
            Dim frm As New Iniciosesion()
            frm.Show()
        End If
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles enlInicio.Click
        Me.Close()
        Dim frm As New Iniciosesion()
        frm.Show()
    End Sub
End Class