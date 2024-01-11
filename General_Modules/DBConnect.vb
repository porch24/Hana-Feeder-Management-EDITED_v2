Imports System
Imports System.Collections
Imports System.Reflection
Imports System.Data
Imports System.Configuration
'Imports System.Data.OracleClient
Imports System.Data.Odbc
Imports System.Data.Odbc.OdbcConnection

Public Class DBConnect
#Region "Private Instance Fields"
    '/// The IDbConnection that will be used to insert data into a database.
    '/// Database connection string.
    Private m_strConnectionString As String

    '/// String type name of the  type name, such as ODBC,OLEDB,MSSQL,ORACLE etc.
    Private m_strConnectionType As String

    '/// String type name of the  connection object
    Private m_strConnectionObject As String

    '/// String type name of the DataAdaper name.
    Private m_strDataAdapterObject As String

#End Region   '// Private Instance Fields


#Region "Public Instance Properties"

    '/// Gets or sets the type name of the connection that should be created.
    '/// The type name of the connection. such as ODBC,OLEDB,MSSQL,Oracle etc.
    '/// The type name of the ADO.NET provider to use.The default is to use the MS SQL DB provider.

    Public Property ConnectionType() As String
        Get
            Return m_strConnectionType
        End Get
        Set(ByVal Value As String)
            m_strConnectionType = Value
            Call GetObjectType(Value)
        End Set
    End Property

    Public Property ConnectionString() As String
        Get
            Return m_strConnectionString
        End Get
        Set(ByVal Value As String)
            m_strConnectionString = Value
        End Set
    End Property
#End Region   ' Public Instance Properties


#Region "Implementation "

    '/// Initialise the appender based on the options set
    Public Function ActivateConnection(ByVal pstrConnectionType As String) As IDbConnection

        Try
            Call GetObjectType(pstrConnectionType)
            ActivateConnection = ActivateConnection()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Public Function ActivateConnection() As IDbConnection
        Try
            '// Create the connection object
            ActivateConnection = CType(Activator.CreateInstance(ResolveConnectionType(m_strConnectionObject)), IDbConnection)
            '// Set the connection string
            ActivateConnection.ConnectionString = m_strConnectionString
            '// Open the database connection
            ActivateConnection.Open()
        Catch ex As Exception
            '// Sadly, your connection string is bad.
            'ErrorHandler.Error("Could not open database connection [" + m_connectionString + "]", e)
            Throw New Exception("Could not open database connection [" + m_strConnectionString + "]" + ex.Message)
        End Try
    End Function
    'Return a dataset according a query
    Public Function DataSet(ByVal strSql As String) As DataSet
        Dim iAdapter As IDbDataAdapter
        Dim idbConnnection As IDbConnection
        Dim idbCmd As IDbCommand

        Try
            idbConnnection = ActivateConnection()
            iAdapter = CType(Activator.CreateInstance(ResolveConnectionType(m_strDataAdapterObject)), IDbDataAdapter)
            idbCmd = idbConnnection.CreateCommand()
            idbCmd.CommandText = strSql
            iAdapter.SelectCommand = idbCmd

            DataSet = New DataSet
            iAdapter.Fill(DataSet)

        Catch ex As Exception
            Throw New Exception("Failed to fill dataset." + ex.Message)
        Finally
            CloseConnection(idbConnnection)
        End Try

    End Function

    Public Function DataSet(ByVal strSql As String, ByVal strConnectionType As String) As DataSet
        Dim iAdapter As IDbDataAdapter
        Dim idbConnnection As IDbConnection
        Dim idbCmd As IDbCommand

        Try
            idbConnnection = ActivateConnection(strConnectionType)
            iAdapter = CType(Activator.CreateInstance(ResolveConnectionType(m_strDataAdapterObject)), IDbDataAdapter)
            idbCmd = idbConnnection.CreateCommand()
            idbCmd.CommandText = strSql
            iAdapter.SelectCommand = idbCmd

            DataSet = New DataSet
            iAdapter.Fill(DataSet)

        Catch ex As Exception
            Throw New Exception("Failed to fill dataset." + ex.Message)
        Finally
            CloseConnection(idbConnnection)
        End Try
    End Function
    'Execute insert/update/delete command
    Public Function ExecuteSql(ByVal strSql As String, Optional ByVal strConnectType As String = "", Optional ByVal cmdType As CommandType = 1) As Boolean
        Dim sqlCmd As IDbCommand
        Dim idbConn As IDbConnection

        Try
            If Trim(strConnectType).Length > 0 Then
                idbConn = ActivateConnection(strConnectType)
            Else
                idbConn = ActivateConnection()
            End If

            sqlCmd = idbConn.CreateCommand()
            sqlCmd.CommandText = strSql
            sqlCmd.CommandType = cmdType    'CommandType.Text
            sqlCmd.ExecuteNonQuery()
            ExecuteSql = True

        Catch ex As Exception
            Throw New Exception("Failed to update data in database." + strSql + ex.Message)
        Finally
            If Not sqlCmd Is Nothing Then
                Try
                    sqlCmd.Dispose()
                Catch
                    sqlCmd = Nothing
                End Try
            End If
            CloseConnection(idbConn)
        End Try

    End Function

    Public Function ExecuteSql(ByVal strSqlArray As ArrayList, Optional ByVal strConnectType As String = "") As Boolean
        Dim sqlCmd As IDbCommand
        Dim idbConn As IDbConnection
        Dim connTrans As IDbTransaction

        Try
            If Trim(strConnectType).Length > 0 Then
                idbConn = ActivateConnection(strConnectType)
            Else
                idbConn = ActivateConnection()
            End If

            connTrans = idbConn.BeginTransaction()

            sqlCmd = idbConn.CreateCommand()
            sqlCmd.CommandType = CommandType.Text
            sqlCmd.Transaction = connTrans

            For Each strSql As String In strSqlArray
                If Trim(strSql).Length > 0 Then
                    sqlCmd.CommandText = strSql

                    sqlCmd.ExecuteNonQuery()
                End If
            Next
            connTrans.Commit()

            ExecuteSql = True

        Catch ex As Exception
            connTrans.Rollback()
            Throw New Exception("Failed to update data in database." + ex.Message)

        Finally
            If Not sqlCmd Is Nothing Then
                Try
                    sqlCmd.Dispose()
                Catch
                    sqlCmd = Nothing
                End Try
            End If
            CloseConnection(idbConn)
        End Try

    End Function
    Public Function GetValueOfField(ByVal strSql As String) As String
        Try

            Dim myTable As DataTable

            myTable = Me.DataSet(strSql).Tables(0)

            If myTable.Rows.Count > 0 Then
                Return CType(myTable.Rows(0).Item(0), String)
            Else
                Return ""
            End If
        Catch ex As Exception
            Throw New Exception("Failed to get value of this field." & ex.Message)
        End Try
    End Function

    Public Function GetDBServerTime(Optional ByVal strDBType As String = "MSSQL") As String
        Dim strSql As String
        Select Case UCase(Trim(strDBType))

            Case "DB2"
                strSql = ""
            Case "MSSQL"
                strSql = "SELECT CONVERT(CHAR(19),GETDATE(),20) AS currenttime"
            Case "ORACLE"
                strSql = "select sysdate from dual"
            Case "MYSQL"
                strSql = "SELECT NOW()"
            Case "SYBASE"
                strSql = ""
        End Select
        Try
            Return GetValueOfField(strSql)
        Catch ex As Exception
            Throw New Exception("Failed to get DB server time." & ex.Message)
        End Try
    End Function
    '/// Retrieves the class type of the ADO.NET provider.
    Protected Function ResolveConnectionType(ByVal pstrObjectName As String) As Type

        Try

            ResolveConnectionType = Type.GetType(pstrObjectName, True)

        Catch ex As Exception

            'ErrorHandler.Error("Failed to load connection type ["+m_connectionType+"]", ex)
            Throw New Exception("Failed to load object type [" + m_strConnectionType + "]" + ex.Message)
        End Try

    End Function

    Private Function GetObjectType(ByVal strConnectType As String) As Boolean
        Select Case UCase(Trim(strConnectType))
            Case "ODBC"
                m_strConnectionObject = "System.Data.Odbc.OdbcConnection,System.Data,version=1.0.3300.0,publicKeyToken=b77a5c561934e089,culture=neutral"
                m_strDataAdapterObject = "System.Data.Odbc.OdbcDataAdapter, System.Data, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            Case "OLEDB"
                m_strConnectionObject = "System.Data.OleDb.OleDbConnection, System.Data, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                m_strDataAdapterObject = "System.Data.OleDb.OleDbDataAdapter, System.Data, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            Case "MSSQL"
                m_strConnectionObject = "System.Data.SqlClient.SqlConnection, System.Data, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                m_strDataAdapterObject = "System.Data.SqlClient.SqlDataAdapter, System.Data, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            Case "ORACLE"
                m_strConnectionObject = "System.Data.OracleClient.OracleConnection, System.Data.OracleClient, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                m_strDataAdapterObject = "System.Data.OracleClient.OracleDataAdapter, System.Data.OracleClient, Version=1.0.5000.0,Culture=neutral, PublicKeyToken=b77a5c561934e089"
            Case Else
                m_strConnectionObject = "System.Data.SqlClient.SqlConnection, System.Data, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                m_strDataAdapterObject = "System.Data.SqlClient.SqlDataAdapter,System.Data, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        End Select
    End Function
#End Region

#Region "Class self"
    Public Sub New()
        Try
            '/// Initializes a new instance of the class.
            ConnectionType = ConfigurationSettings.AppSettings("ConnectionType")
            ConnectionString = ConfigurationSettings.AppSettings("ConnectionString")
        Catch Ex As Exception
            Throw New Exception("Failed to load parameters from config file." + Ex.Message)
        End Try

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Function CloseConnection(ByRef idbConn As IDbConnection) As Boolean

        If idbConn.State = ConnectionState.Open Then
            idbConn.Close()
            idbConn.Dispose()
        End If

        idbConn = Nothing

    End Function
#End Region

    

End Class
