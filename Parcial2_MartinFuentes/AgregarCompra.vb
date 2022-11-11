Imports System.Diagnostics.Eventing
Imports System.Drawing
Imports System.IO
Imports Conexion
Imports MySql.Data.MySqlClient
Imports TablaBD_USER

Public Class AgregarCompra
    Public arr
    Public cont = 0
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Dim tabla As New TablaBD_USUARIO
        arr = tabla.BuscarAUTO_USER
        btnAnte.Enabled() = False
        If (Not arr(cont, 0) Is Nothing) Then
            txtMarca.Text = arr(cont, 0).ToString
            txtModelo.Text = arr(cont, 1).ToString
            txtCant.Text = arr(cont, 2).ToString
            txtPrecio.Text = arr(cont, 3).ToString
            Dim ms = New MemoryStream(CType(arr(cont, 4), Byte()))
            Dim bm = New Bitmap(ms)
            imgAuto.Image = bm


        End If

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub btnAnte_Click(sender As Object, e As EventArgs) Handles btnAnte.Click
        cont -= 1
        btnSigui.Enabled = True
        If (cont = 0) Then
            btnAnte.Enabled = False
        End If
        If (Not arr(cont, 0) Is Nothing) Then
            txtMarca.Text = arr(cont, 0).ToString
            txtModelo.Text = arr(cont, 1).ToString
            txtCant.Text = arr(cont, 2).ToString
            txtPrecio.Text = arr(cont, 3).ToString
            Dim ms = New MemoryStream(CType(arr(cont, 4), Byte()))
            Dim bm = New Bitmap(ms)
            imgAuto.Image = bm

        End If


    End Sub


    Private Sub btnSigui_Click(sender As Object, e As EventArgs) Handles btnSigui.Click
        cont += 1
        If (Not arr(cont, 0) Is Nothing) Then
            txtMarca.Text = arr(cont, 0).ToString
            txtModelo.Text = arr(cont, 1).ToString
            txtCant.Text = arr(cont, 2).ToString
            txtPrecio.Text = arr(cont, 3).ToString
            Dim ms = New MemoryStream(CType(arr(cont, 4), Byte()))
            Dim bm = New Bitmap(ms)
            imgAuto.Image = bm

        End If
        If (arr(cont + 1, 0) Is Nothing) Then
            btnSigui.Enabled = False
        End If
        If (Not cont = 0) Then
            btnAnte.Enabled = True
        End If

    End Sub


End Class