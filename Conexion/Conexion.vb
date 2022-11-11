Imports MySql.Data.MySqlClient
Public Class conexiones
    Private cnx As MySqlConnection
    Public Function getConexion()
        If cnx Is Nothing Then
            cnx = New MySqlConnection("Server=localhost; UserID=root; Password=; Database=bd_automoviles;")
            cnx.Open()
        End If
        Return cnx
    End Function
End Class
