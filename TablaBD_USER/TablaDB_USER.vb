Imports System.Diagnostics.Eventing
Imports System.Reflection
Imports System.Runtime.ConstrainedExecution
Imports System.Text.RegularExpressions
Imports Conexion
Imports MySql.Data.MySqlClient

Public Class TablaBD_USUARIO
    Public Function BuscarAUTO_USER()
        Dim reader As MySqlDataReader


        Dim cmd As MySqlCommand

        Dim con = New conexiones()
        cmd = New MySqlCommand("Select marca as 'Marca', modelo as 'Modelo', cantidad as 'Cantidad disponible', precio as 'Precio',imagen from automovil ", con.getConexion())
        reader = cmd.ExecuteReader()


        Dim arr(100, 100) As Object
        Dim i As Integer = 0
        While (reader.Read())
            arr(i, 0) = reader.Item(0)
            arr(i, 1) = reader.Item(1)
            arr(i, 2) = reader.Item(2)
            arr(i, 3) = reader.Item(3)
            arr(i, 4) = reader.Item(4)
            i += 1
        End While

        Return arr
    End Function
    Public Function BuscarUsu(usu As String)
        Dim reader As MySqlDataReader
        Dim cmd As MySqlCommand

        Dim con = New conexiones()
        cmd = New MySqlCommand("Select cedula from usuario where usuario=@usu ", con.getConexion())
        cmd.Parameters.Add("@usu", MySqlDbType.VarChar).Value = usu
        reader = cmd.ExecuteReader()
        reader.Read()
        Return reader.Item(0)
        reader.Close()
    End Function
    Public Sub InsertarCompra(ced As String)
        Dim cmd As MySqlCommand
        Dim con As conexiones
        con = New conexiones()
        cmd = New MySqlCommand("INSERT INTO compra (cedula, fecha, itbms, total) VALUES (@ced,@fech,@itbms,@total)", con.getConexion)
        cmd.Parameters.Add("@ced", MySqlDbType.VarChar).Value = ced
        cmd.Parameters.Add("@fech", MySqlDbType.VarChar).Value = Date.Now
        cmd.Parameters.Add("@itbms", MySqlDbType.Int64).Value = 0
        cmd.Parameters.Add("@total", MySqlDbType.Decimal).Value = 0
        cmd.ExecuteNonQuery()
    End Sub
    Public Function InsertarCompraAuto(marca As String, model As String)
        Dim reader As MySqlDataReader
        Dim cmd As MySqlCommand

        Dim con = New conexiones()
        cmd = New MySqlCommand("Select Max(id_compra) from compra", con.getConexion())
        reader = cmd.ExecuteReader()
        reader.Read()
        Dim idCompra = reader.Item(0)
        reader.Close()

        con = New conexiones()
        cmd = New MySqlCommand("Select id_auto,cantidad from automovil where marca=@marc and modelo=@model", con.getConexion())
        cmd.Parameters.Add("@marc", MySqlDbType.VarChar).Value = marca
        cmd.Parameters.Add("@model", MySqlDbType.VarChar).Value = model
        reader = cmd.ExecuteReader()
        reader.Read()
        Dim idAuto = reader.Item(0)
        Dim cantidad = reader.Item(1) - 1
        reader.Close()

        con = New conexiones()
        cmd = New MySqlCommand("UPDATE automovil set cantidad = @cant WHERE id_auto = @idau;", con.getConexion())
        cmd.Parameters.Add("@cant", MySqlDbType.Int64).Value = cantidad
        cmd.Parameters.Add("@idau", MySqlDbType.Int64).Value = idAuto
        Dim ks = cmd.ExecuteNonQuery()

        con = New conexiones()
        cmd = New MySqlCommand("INSERT INTO compra_auto (id_auto, id_compra) VALUES (@idAu,@idCom)", con.getConexion)
        cmd.Parameters.Add("@idAu", MySqlDbType.VarChar).Value = idAuto
        cmd.Parameters.Add("@idCom", MySqlDbType.VarChar).Value = idCompra
        cmd.ExecuteNonQuery()


        con = New conexiones()
        cmd = New MySqlCommand("Select SUM(precio*0.07) ,SUM(precio*0.07+precio) from automovil as auto,compra_auto as com where auto.id_auto=com.id_auto and id_compra=@idcom;", con.getConexion())
        cmd.Parameters.Add("@idcom", MySqlDbType.VarChar).Value = idCompra
        reader = cmd.ExecuteReader()
        reader.Read()
        Dim itmbs = reader.Item(0)
        Dim tot = reader.Item(1)
        reader.Close()

        con = New conexiones()
        cmd = New MySqlCommand("UPDATE compra set itbms = @itbm,total=@tot WHERE id_compra = @idCom;", con.getConexion())
        cmd.Parameters.Add("@itbm", MySqlDbType.Int64).Value = itmbs
        cmd.Parameters.Add("@tot", MySqlDbType.VarChar).Value = tot
        cmd.Parameters.Add("@idCom", MySqlDbType.Int64).Value = idCompra
        cmd.ExecuteNonQuery()
        'Recordar sacar algunas cosas de aquí a través de un array para que lo imprima en la pantalla y ver si puedes imprimir la cantidad de autos comprados
        'Por cada uno
        Dim arr(5) As String
        arr(0) = tot
        arr(1) = itmbs
        arr(2) = cantidad
        Return arr

    End Function
    Public Function VerAutos(marca As String, model As String)
        Dim reader As MySqlDataReader
        Dim cmd As MySqlCommand

        Dim con = New conexiones()
        cmd = New MySqlCommand("SELECT id_auto from  automovil where marca=@marc and modelo=@model;", con.getConexion())
        cmd.Parameters.Add("@marc", MySqlDbType.VarChar).Value = marca
        cmd.Parameters.Add("@model", MySqlDbType.VarChar).Value = model
        reader = cmd.ExecuteReader()
        reader.Read()
        Dim idauto = reader.Item(0)
        reader.Close()

        con = New conexiones()
        cmd = New MySqlCommand("SELECT MAX(id_compra) from  compra;", con.getConexion())
        reader = cmd.ExecuteReader()
        reader.Read()
        Dim id_com = reader.Item(0)
        reader.Close()

        con = New conexiones()
        cmd = New MySqlCommand("SELECT count(id_auto) from  compra_auto where id_auto=@id_au and id_compra=@id_com;", con.getConexion())
        cmd.Parameters.Add("@id_au", MySqlDbType.VarChar).Value = idauto
        cmd.Parameters.Add("@id_com", MySqlDbType.VarChar).Value = id_com
        reader = cmd.ExecuteReader()
        reader.Read()

        Dim cant = reader.Item(0)
        reader.Close()
        Return cant
    End Function
    Public Function verDetalles()

    End Function

End Class
