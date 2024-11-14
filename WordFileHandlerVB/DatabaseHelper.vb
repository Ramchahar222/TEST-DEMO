Imports System.Data.SqlClient

Public Class DatabaseHelper

    Public Const connectionString As String = "Server=DESKTOP-VOPC0TR\SQL2019;Database=WordFileDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;user id=sa;password=oasislims"


    Public Shared Sub InsertWordFile(fileName As String, fileData As Byte())
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim query As String = "INSERT INTO WordFiles (FileName, FileData) VALUES (@FileName, @FileData)"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@FileName", fileName)
                cmd.Parameters.AddWithValue("@FileData", fileData)
                cmd.ExecuteNonQuery()
                'cbcbzcbzkcbzkcb
            End Using
        End Using
    End Sub

    Public Shared Function GetWordFile(id As Integer) As WordFile
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT Id, FileName, FileData FROM WordFiles WHERE Id = @Id"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Id", id)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            If reader.Read() Then
                                ' Display debug information for each field
                                Dim retrievedId As Integer = reader.GetInt32(0)
                                Dim retrievedFileName As String = If(reader.IsDBNull(1), String.Empty, reader.GetString(1))
                                Dim retrievedFileData As Byte() = If(reader.IsDBNull(2), New Byte() {}, CType(reader.GetValue(2), Byte()))
                                MessageBox.Show("Retrieved Record: Id = " & retrievedId & ", FileName = " & retrievedFileName & ", FileData Length = " & retrievedFileData.Length)
                                Dim wordFile As New WordFile() With {
                                    .Id = retrievedId,
                                    .FileName = retrievedFileName,
                                    .FileData = retrievedFileData
                                }
                                Return wordFile
                            End If
                        Else
                            MessageBox.Show("No records found with the specified Id.")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred: " + ex.Message)
        End Try
        Return Nothing
    End Function

    'Public Shared Function GetWordFile(id As Integer) As WordFile
    '    Using conn As New SqlConnection(connectionString)
    '        conn.Open()
    '        Dim query As String = "SELECT * FROM WordFiles WHERE Id = @Id"
    '        Using cmd As New SqlCommand(query, conn)
    '            cmd.Parameters.AddWithValue("@Id", id)
    '            Using reader As SqlDataReader = cmd.ExecuteReader()
    '                If reader.HasRows Then
    '                    If reader.Read() Then
    '                        ' Debugging messages
    '                        MessageBox.Show($"Retrieved Record: Id = {reader.GetInt32(0)}, FileName = {reader.GetString(1)}")
    '                        Dim wordFile As New WordFile() With {
    '                        .Id = reader.GetInt32(0),
    '                        .FileName = If(reader.IsDBNull(1), String.Empty, reader.GetString(1)),
    '                        .FileData = If(reader.IsDBNull(2), New Byte() {}, CType(reader.GetValue(2), Byte()))
    '                    }
    '                        Return wordFile
    '                    End If
    '                Else
    '                    MessageBox.Show("No records found.")
    '                End If
    '            End Using
    '        End Using
    '    End Using
    '    Return Nothing
    'End Function
End Class