Imports System.Diagnostics.Eventing
Imports System.Runtime.ConstrainedExecution
Imports Conexion
Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Relational

Public Class TablaBD
    Public Function InsertarUSU(ced As String, nom As String, dir As String, cel As String, usu As String, contra As String)
        Dim cmd As MySqlCommand
        Dim con As conexiones
        Dim reader As MySqlDataReader
        con = New conexiones()
        cmd = New MySqlCommand("Select usuario from usuario where usuario=@usu or cedula=@ced", con.getConexion)
        cmd.Parameters.Add("@usu", MySqlDbType.VarChar).Value = usu
        cmd.Parameters.Add("@ced", MySqlDbType.VarChar).Value = ced
        reader = cmd.ExecuteReader()
        reader.Read()
        If Not reader.HasRows Then
            If (ced.Length <> 0 And nom.Length <> 0 And dir.Length <> 0 And Val(cel) > 0 And usu.Length <> 0 And contra.Length <> 0) Then

                If (Val(cel) >= 60000000 And Val(cel) < 70000000) Then

                    con = New conexiones
                    cmd = New MySqlCommand("Insert Into usuario (cedula, nombre, direccion, cel, usuario, contrasena,rol) values (@ced,@nom,@dir,@tel,@user,@pass,@rol)", con.getConexion())
                    cmd.Parameters.Add("@ced", MySqlDbType.VarChar).Value = ced
                    cmd.Parameters.Add("@nom", MySqlDbType.VarChar).Value = nom
                    cmd.Parameters.Add("@dir", MySqlDbType.VarChar).Value = dir
                    cmd.Parameters.Add("@tel", MySqlDbType.Int64).Value = Val(cel)
                    cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = usu
                    cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = contra
                    cmd.Parameters.Add("@rol", MySqlDbType.VarChar).Value = "Cliente"
                    cmd.ExecuteNonQuery()
                    MsgBox("SE HA CREADO SU CUENTA SATISFACTORIAMENTE", MsgBoxStyle.Information, "Error")
                    Return True

                Else
                    MsgBox("Formato de celular incorrecta", MsgBoxStyle.Information, "Error")
                    Return False
                End If
            Else
                MsgBox("Faltan campos por llenar", MsgBoxStyle.Information, "Error")
                Return False
            End If
        Else
            MsgBox("Ya tiene una cuenta registrada", MsgBoxStyle.Information, "Error")
            Return False
        End If
        reader.Close()
    End Function

    Public Function BuscarUSU(usu As String, pass As String)

        If usu.Length > 0 And pass.Length > 0 Then
            Dim cmd As MySqlCommand
            Dim con As conexiones
            Dim reader As MySqlDataReader
            con = New conexiones()
            cmd = New MySqlCommand("Select rol from usuario where usuario=@usu and contrasena=@contra", con.getConexion)
            cmd.Parameters.Add("@usu", MySqlDbType.VarChar).Value = usu
            cmd.Parameters.Add("@contra", MySqlDbType.VarChar).Value = pass
            reader = cmd.ExecuteReader()
            reader.Read()
            If reader.HasRows Then
                Select Case reader.Item(0)
                    Case "Cliente"
                        Return 1
                    Case "Admin"
                        Return 2
                End Select
            Else
                MsgBox("Usuario o contraseña inválidos", MsgBoxStyle.Information, "Error")
                Return 0
            End If
            reader.Close()
        Else
            MsgBox("Faltan campos por llenar", MsgBoxStyle.Information, "Error")
            Return 0
        End If

    End Function
    Public Function InsertarAUTO(aByte As Byte(), marca As String, model As String, cant As Integer, prec As Double)
        If marca.Length > 0 And model.Length > 0 And cant > 0 And prec > 0 And Not IsNothing(aByte) Then
            Dim cmd As MySqlCommand
            Dim con As conexiones
            con = New conexiones()
            cmd = New MySqlCommand("INSERT INTO automovil (marca, modelo, cantidad, precio, imagen) VALUES (@marca,@model,@cant,@prec,@imagen)", con.getConexion)
            cmd.Parameters.Add("@marca", MySqlDbType.VarChar).Value = marca
            cmd.Parameters.Add("@model", MySqlDbType.VarChar).Value = model
            cmd.Parameters.Add("@cant", MySqlDbType.Int64).Value = cant
            cmd.Parameters.Add("@prec", MySqlDbType.Decimal).Value = prec
            cmd.Parameters.AddWithValue("@imagen", aByte)
            cmd.ExecuteNonQuery()
        Else
            MsgBox("Faltan campos por llenar", MsgBoxStyle.Information, "Error")
        End If





    End Function
    Public Function BuscarAUTO_ADMIN()
        Dim reader As MySqlDataReader
        Dim cmd As MySqlCommand
        Dim con = New conexiones()
        cmd = New MySqlCommand("Select marca as 'Marca', modelo as 'Modelo', cantidad as 'Cantidad disponible', precio as 'Precio' from automovil ", con.getConexion())
        reader = cmd.ExecuteReader()
        Dim tabla = New DataTable()
        tabla.Load(reader)
        reader.Close()
        Return tabla

    End Function
    Public Function Actualizar_AUTO(marca As String, model As String, marcaDB As String, modelDB As String, cant As Integer, precio As Decimal, img As Byte())
        If marca.Length > 0 And model.Length > 0 And cant > 0 And precio > 0 And Not IsNothing(img) Then

            Dim cmd As MySqlCommand
            Dim con = New conexiones()
            cmd = New MySqlCommand("Update automovil set marca = @marca, modelo= @model,cantidad = @cant, precio = @prec, imagen = @img where marca = @marcaDB and modelo = @modeloDB", con.getConexion())
            cmd.Parameters.Add("@marca", MySqlDbType.VarChar).Value = marca
            cmd.Parameters.Add("@marcaDB", MySqlDbType.VarChar).Value = marcaDB
            cmd.Parameters.Add("@modeloDB", MySqlDbType.VarChar).Value = modelDB
            cmd.Parameters.Add("@model", MySqlDbType.VarChar).Value = model
            cmd.Parameters.Add("@cant", MySqlDbType.Int64).Value = cant
            cmd.Parameters.Add("@prec", MySqlDbType.Decimal).Value = precio
            cmd.Parameters.AddWithValue("@img", img)
            cmd.ExecuteNonQuery()
        Else
            MsgBox("Faltan campos por llenar", MsgBoxStyle.Information, "Error")
        End If
    End Function
    Public Function EliminarAuto(marc As String, model As String)
        Dim con = New conexiones()
        Dim cmd As MySqlCommand
        cmd = New MySqlCommand("Delete from automovil where marca = @marc and modelo = @model", con.getConexion())
        cmd.Parameters.Add("@marc", MySqlDbType.VarChar).Value = marc
        cmd.Parameters.Add("@model", MySqlDbType.VarChar).Value = model
        cmd.ExecuteNonQuery()
    End Function
End Class
