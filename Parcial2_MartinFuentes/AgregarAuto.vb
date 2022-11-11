Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports Conexion
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports TablaDB
Public Class AgregarAuto
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Dim tabla As New TablaBD
        tablaDatos.DataSource = tabla.BuscarAUTO_ADMIN()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


    End Sub
    Private Sub AgregarAuto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click

        Dim ofdSeleccionar = New OpenFileDialog()
        ofdSeleccionar.Filter = "Imagenes|*.jpg; *.png"
        ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        ofdSeleccionar.Title = "Seleccionar imagen"

        If (ofdSeleccionar.ShowDialog() = DialogResult.OK) Then

            imgAuto.Image = Image.FromFile(ofdSeleccionar.FileName)
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Not imgAuto.Image Is Nothing Then
            Dim ms As New MemoryStream()
            imgAuto.Image.Save(ms, ImageFormat.Jpeg)
            Dim aByte As Byte() = ms.ToArray()
            Dim tabla As New TablaBD
            tabla.InsertarAUTO(aByte, txtMarca.Text, txtModelo.Text, Val(txtCant.Text), Val(txtPrecio.Text))
            tablaDatos.DataSource = tabla.BuscarAUTO_ADMIN()
        Else
            MsgBox("Por favor inserte una imagen", MsgBoxStyle.Information, "Error")
        End If
    End Sub

    Private Sub tablaDatos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tablaDatos.CellClick
        Dim marca = tablaDatos.CurrentRow.Cells("Marca").Value
        Dim model = tablaDatos.CurrentRow.Cells("Modelo").Value
        Dim reader As MySqlDataReader
        Dim cmd As MySqlCommand
        Dim con = New conexiones()
        cmd = New MySqlCommand("Select marca, modelo, cantidad, precio, imagen from automovil where marca = @marc and modelo = @model ", con.getConexion())
        cmd.Parameters.Add("@marc", MySqlDbType.VarChar).Value = marca
        cmd.Parameters.Add("@model", MySqlDbType.VarChar).Value = model
        reader = cmd.ExecuteReader()
        reader.Read()
        txtMarca.Text = reader.Item(0)
        txtModelo.Text = reader.Item(1)
        txtCant.Text = reader.Item(2)
        txtPrecio.Text = reader.Item(3)
        Dim ms = New MemoryStream(CType(reader(4), Byte()))
        Dim bm = New Bitmap(ms)
        imgAuto.Image = bm
        reader.Close()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim tabla As New TablaBD
        Dim marca = tablaDatos.CurrentRow.Cells("Marca").Value
        Dim model = tablaDatos.CurrentRow.Cells("Modelo").Value
        Dim ms As New MemoryStream()
        imgAuto.Image.Save(ms, ImageFormat.Jpeg)
        Dim aByte As Byte() = ms.ToArray()
        tabla.Actualizar_AUTO(txtMarca.Text, txtModelo.Text, marca, model, Val(txtCant.Text), Val(txtPrecio.Text), aByte)
        tablaDatos.DataSource = tabla.BuscarAUTO_ADMIN()

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim tabla As New TablaBD
        Dim marca = tablaDatos.CurrentRow.Cells("Marca").Value
        Dim model = tablaDatos.CurrentRow.Cells("Modelo").Value
        If MessageBox.Show("¿Desea Eliminar el automóvil " & marca & " " & model & " de los artículos a comprar?", "Eliminar", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            tabla.EliminarAuto(marca, model)
            tablaDatos.DataSource = tabla.BuscarAUTO_ADMIN()
        Else
            MessageBox.Show("No se eliminó el automóvil", "Eliminar", MessageBoxButtons.OK)
        End If
    End Sub
End Class