Imports System.Diagnostics.Eventing
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
End Class
