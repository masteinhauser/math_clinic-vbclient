' Desc: Centralized Database functions and wrappers
' Auth: Myles A. K. Steinhauser
' Date: 05/04/2012

Option Strict On
Option Explicit On

Imports ADOX

' Wrapper class for all non-trivial database functions
Public Module Database
    ' Base Connection String used to access our AccessDB
    Dim strBaseCN As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="

    'DEMO
    '      If CreateAccessDatabase("F:\test.mdb") = True Then
    '           MsgBox("Database Created")
    '      Else
    '           MsgBox("Database Creation Failed")
    '      End If
    Public Function CreateAccessDatabase(ByVal strDatabaseFullPath As String) As Boolean
        Dim blnResult As Boolean
        Dim cat As Catalog = New Catalog()

        Try
            Dim strCreateString As String
            ' Build the connection string
            strCreateString = strBaseCN & strDatabaseFullPath

            ' Create the actual database
            cat.Create(strCreateString)

            ' Creation was succesful
            blnResult = True
        Catch Excep As System.Runtime.InteropServices.COMException
            Console.WriteLine("Error creating database: " + strDatabaseFullPath)
            Console.WriteLine(Excep.Message)
            Console.WriteLine(Excep.InnerException)
            blnResult = False
        Finally
            ' Clear up our object reference for garbage collection
            cat = Nothing
        End Try

        Return blnResult
    End Function

    ' Dynamically adds a specified table with the specified primary key and fields to the specified database.
    Public Function CreateTable(ByVal strDatabaseFullPath As String, ByRef strTable As String, ByRef strPrimaryKey As String, ByRef dicFields As Dictionary(Of String, ADOX.DataTypeEnum)) As Boolean
        Dim blnResult As Boolean

        Dim Cn As ADODB.Connection = New ADODB.Connection
        Dim Cat As Catalog = New Catalog
        Dim objTable As Table = New Table

        Try
            ' Connect to the database
            Cn.Open(strBaseCN + strDatabaseFullPath)

            ' Open the Catalog
            Cat.ActiveConnection = Cn

            ' Create the Table
            objTable.Name = strTable

            ' Create and append new field and primary key to strTable
            objTable.Columns.Append(strPrimaryKey, ADOX.DataTypeEnum.adInteger)
            objTable.Keys.Append(strPrimaryKey, ADOX.KeyTypeEnum.adKeyPrimary, strPrimaryKey)

            ' Create and append new fields to strTable
            For Each field As KeyValuePair(Of String, ADOX.DataTypeEnum) In dicFields
                objTable.Columns.Append(field.Key, field.Value)
            Next

            ' Append new created table to Tables Collection
            Cat.Tables.Append(objTable)

            blnResult = True
        Catch Excep As System.Runtime.InteropServices.COMException
            Console.WriteLine("Error adding table: " + strTable + " to database: " + strDatabaseFullPath)
            Console.WriteLine(Excep.Message)
            Console.WriteLine(Excep.InnerException)

            blnResult = False
        Finally
            ' Clean up objects for easier garbage collection
            objTable = Nothing
            Cat = Nothing
            Cn = Nothing
        End Try

        Return blnResult
    End Function

    Public Sub SelectData(strDatabase As String, strTable As String)
        'Instantiate Connection Class
        Dim objConnection As New OleDbConnection(mstrCN)
    End Sub

End Module
