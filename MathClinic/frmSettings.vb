' Myles A. K. Steinhauser

Option Strict On
Option Explicit On

Public Class frmSettings
    
    Private Sub btnSaveSettings_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveSettings.Click
        Dim strDatabasePath As String = txtDatabasePath.Text

        ' They moved the database
        If strDatabasePath <> AppShared.DBPath Then
            ' Create a new one at this location
            Database.CreateAccessDatabase(strDatabasePath)

            ' Users table, to keep track of logins
            ' Add our needed fields to the fields dictionary
            Dim dicUserFields As Dictionary(Of String, ADOX.DataTypeEnum) = New Dictionary(Of String, ADOX.DataTypeEnum)

            ' Used to reference back to the MongoDB on the backend
            dicUserFields.Add("_id", ADOX.DataTypeEnum.adVarWChar)
            dicUserFields.Add("username", ADOX.DataTypeEnum.adVarWChar)
            dicUserFields.Add("birth", ADOX.DataTypeEnum.adVarWChar)
            dicUserFields.Add("fname", ADOX.DataTypeEnum.adVarWChar)
            dicUserFields.Add("lname", ADOX.DataTypeEnum.adVarWChar)
            dicUserFields.Add("role", ADOX.DataTypeEnum.adVarWChar)

            ' Now, let's create the required tables in the new database
            Database.CreateTable(strDatabasePath, "Users", "id", dicUserFields)

            ' Questions table which is used for the "non-compiled" questions
            ' Add our needed fields to the fields dictionary
            Dim dicQuestionFields As Dictionary(Of String, ADOX.DataTypeEnum) = New Dictionary(Of String, ADOX.DataTypeEnum)

            ' Used to reference back to the MongoDB on the backend
            dicQuestionFields.Add("_id", ADOX.DataTypeEnum.adVarWChar)
            dicQuestionFields.Add("equation", ADOX.DataTypeEnum.adVarWChar)
            dicQuestionFields.Add("type", ADOX.DataTypeEnum.adVarWChar)
            dicQuestionFields.Add("level", ADOX.DataTypeEnum.adVarWChar)

            ' Now, let's create the required tables in the new database
            Database.CreateTable(strDatabasePath, "Questions", "id", dicQuestionFields)

            ' Answers table which is used for the 
            ' Add our needed fields to the fields dictionary
            Dim dicAnswerFields As Dictionary(Of String, ADOX.DataTypeEnum) = New Dictionary(Of String, ADOX.DataTypeEnum)

            ' Used to reference back to the MongoDB on the backend
            dicAnswerFields.Add("question", ADOX.DataTypeEnum.adVarWChar)
            dicAnswerFields.Add("answer", ADOX.DataTypeEnum.adVarWChar)
            dicAnswerFields.Add("latency", ADOX.DataTypeEnum.adInteger)
            dicAnswerFields.Add("correct", ADOX.DataTypeEnum.adBoolean)
            dicAnswerFields.Add("submitted", ADOX.DataTypeEnum.adBoolean)

            ' Now, let's create the required tables in the new database
            Database.CreateTable(strDatabasePath, "Answers", "id", dicAnswerFields)

            MsgBox("New Offline Database created!")
        End If

        AppShared.DBPath = strDatabasePath
        AppShared.OfflineStore = chkOfflineMode.CheckState.ToString
    End Sub

    Private Sub frmSettings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtDatabasePath.Text = AppShared.DBPath

        If AppShared.OfflineStore = "Checked" Then
            chkOfflineMode.CheckState = CheckState.Checked
        Else
            chkOfflineMode.CheckState = CheckState.Unchecked
        End If
    End Sub
End Class