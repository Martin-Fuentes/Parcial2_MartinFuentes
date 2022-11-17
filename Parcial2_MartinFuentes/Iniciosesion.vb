Imports System.Diagnostics.Eventing
Imports TablaDB
Public Class Iniciosesion
    Private Sub enlCrear_Click(sender As Object, e As EventArgs) Handles enlCrear.Click
        Me.Hide()
        Dim frm As New CrearCuenta()
        frm.Show()
    End Sub

    Private Sub btnInicio_Click(sender As Object, e As EventArgs) Handles btnInicio.Click
        Dim tabla As New TablaBD
        Dim rolUsuario As Integer = tabla.BuscarUSU(txtUsu.Text, txtPass.Text)
        Select Case rolUsuario
            Case 1
                Me.Hide()
                Dim frm As New AgregarCompra(txtUsu.Text)
                frm.Show()
            Case 2
                Me.Hide()
                Dim frm As New AgregarAuto(txtUsu.Text)
                frm.Show()
        End Select
    End Sub
End Class