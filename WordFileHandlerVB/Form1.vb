Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.Office.Interop.Word

Public Class Form1
    Private Sub btnUpload_Click_1(sender As Object, e As EventArgs) Handles btnUpload.Click
        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = OpenFileDialog.FileName
            txtFileName.Text = Path.GetFileName(filePath)
            Dim fileData As Byte() = File.ReadAllBytes(filePath)
            DatabaseHelper.InsertWordFile(txtFileName.Text, fileData)
            MessageBox.Show("File uploaded and stored in the database.")
        End If
    End Sub


    Private Function IsFileInUse(filePath As String) As Boolean
        Try
            Using fs As New FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None)
            End Using
            Return False
        Catch ex As IOException
            Return True
        End Try
    End Function

    Private WordFile As WordFile

    Private Sub btnEdit_Click_1(sender As Object, e As EventArgs) Handles btnEdit.Click
        'test data
        WordFile = DatabaseHelper.GetWordFile(1)
        If WordFile IsNot Nothing Then
            Dim customPath As String = "C:\Users\Oasis\source\repos\Wordfile\"
            If Not Directory.Exists(customPath) Then
                Directory.CreateDirectory(customPath)
            End If
            Dim tempFilePath As String = Path.Combine(customPath, "TempWordFile.docx")
            File.WriteAllBytes(tempFilePath, WordFile.FileData)

            If IsFileInUse(tempFilePath) Then
                MessageBox.Show("The file is currently open in another application.")
                Return
            End If

            Dim wordApp As New Application()
            Dim wordDoc As Document = wordApp.Documents.Open(tempFilePath)
            'rtbDocument.Text = wordDoc.Content.Text
            wordApp.Visible = True

            MessageBox.Show("File edited and updated in the database.")
        Else
            MessageBox.Show("File not found.")
        End If
    End Sub


    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            Dim tempFilePath As String = "C:\Users\Oasis\source\repos\Wordfile\TempWordFile.docx"
            If Not File.Exists(tempFilePath) Then
                MessageBox.Show("The temporary file does not exist.")
                Return
            End If
            If IsFileInUse(tempFilePath) Then
                MessageBox.Show("The file is currently open and cannot be saved.")
                Return
            End If

            Dim editedData As Byte() = File.ReadAllBytes(tempFilePath)
            If WordFile IsNot Nothing AndAlso WordFile.Id > 0 Then
                Using conn As New SqlConnection(DatabaseHelper.connectionString)
                    conn.Open()
                    Dim query As String = "UPDATE WordFiles SET FileData = @FileData WHERE Id = @Id"
                    Using cmd As New SqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@FileData", editedData)
                        cmd.Parameters.AddWithValue("@Id", WordFile.Id)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show("File data updated successfully in the database.")
            Else
                MessageBox.Show("Invalid file or ID for updating.")
            End If
        Catch ex As IOException
            MessageBox.Show("Error reading the file: " & ex.Message)
        Catch ex As SqlException
            MessageBox.Show("Database error: " & ex.Message)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message)
        End Try
    End Sub


End Class