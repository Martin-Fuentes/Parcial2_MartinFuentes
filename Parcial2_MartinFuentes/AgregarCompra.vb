Imports System.Diagnostics.Eventing
Imports System.Drawing
Imports System.IO
Imports Conexion
Imports MySql.Data.MySqlClient
Imports TablaBD_USER

Public Class AgregarCompra
    Public arr
    Public cont = 0
    Public Usuario As String
    Public cedUsu
    Public Sub New(usu As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Dim tabla As New TablaBD_USUARIO
        Me.Usuario = usu
        arr = tabla.BuscarAUTO_USER
        cedUsu = tabla.BuscarUsu(Usuario)
        tabla.InsertarCompra(cedUsu)
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
        Dim tabla As New TablaBD_USUARIO
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
            Dim cant = tabla.VerAutos(txtMarca.Text, txtModelo.Text)

            lblCant.Text = "Comprado: " & cant

        End If


    End Sub


    Private Sub btnSigui_Click(sender As Object, e As EventArgs) Handles btnSigui.Click
        Dim tabla As New TablaBD_USUARIO
        cont += 1
        If (Not arr(cont, 0) Is Nothing) Then
            txtMarca.Text = arr(cont, 0).ToString
            txtModelo.Text = arr(cont, 1).ToString
            txtCant.Text = arr(cont, 2).ToString
            txtPrecio.Text = arr(cont, 3).ToString
            Dim ms = New MemoryStream(CType(arr(cont, 4), Byte()))
            Dim bm = New Bitmap(ms)
            imgAuto.Image = bm
            Dim cant = tabla.VerAutos(txtMarca.Text, txtModelo.Text)
            lblCant.Text = "Comprado: " & cant

        End If
        If (arr(cont + 1, 0) Is Nothing) Then
            btnSigui.Enabled = False
        End If
        If (Not cont = 0) Then
            btnAnte.Enabled = True
        End If

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim tabla As New TablaBD_USUARIO
        Dim arr = tabla.InsertarCompraAuto(txtMarca.Text, txtModelo.Text)
        Dim cant = tabla.VerAutos(txtMarca.Text, txtModelo.Text)
        lblTot.Text = "Total a pagar: " & Format(CType(arr(0), Double), "n")
        lblCant.Text = "Comprado: " & cant
        txtCant.Text = arr(2)







    End Sub

End Class