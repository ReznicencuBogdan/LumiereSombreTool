' ***********************************************************************
' Assembly         : LumiereServer
' Author           : rezni
' Created          : 06-12-2020
'
' Last Modified By : rezni
' Last Modified On : 06-11-2020
' ***********************************************************************
' <copyright file="ServerClientManagement2003DataSet.Designer.vb" company="LumiereSombre | HorizonDova">
'     Copyright ©  LumiereSombre Inc. 2020
' </copyright>
' <summary></summary>
' ***********************************************************************--

Option Strict Off
Option Explicit On



''' <summary>
''' Represents a strongly typed in-memory cache of data.
''' </summary>
<Global.System.Serializable(),
 Global.System.ComponentModel.DesignerCategoryAttribute("code"),
 Global.System.ComponentModel.ToolboxItem(True),
 Global.System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema"),
 Global.System.Xml.Serialization.XmlRootAttribute("ServerClientManagement2003DataSet"),
 Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")>
Partial Public Class ServerClientManagement2003DataSet
    Inherits Global.System.Data.DataSet

    ''' <summary>
    ''' The table blacklist
    ''' </summary>
    Private tableBlacklist As BlacklistDataTable

    ''' <summary>
    ''' The table registered clients
    ''' </summary>
    Private tableRegisteredClients As RegisteredClientsDataTable

    ''' <summary>
    ''' The schema serialization mode
    ''' </summary>
    Private _schemaSerializationMode As Global.System.Data.SchemaSerializationMode = Global.System.Data.SchemaSerializationMode.IncludeSchema

    ''' <summary>
    ''' Initializes a new instance of the <see cref="ServerClientManagement2003DataSet"/> class.
    ''' </summary>
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
    Public Sub New()
        MyBase.New
        Me.BeginInit()
        Me.InitClass()
        Dim schemaChangedHandler As Global.System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler MyBase.Tables.CollectionChanged, schemaChangedHandler
        AddHandler MyBase.Relations.CollectionChanged, schemaChangedHandler
        Me.EndInit()
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="ServerClientManagement2003DataSet"/> class.
    ''' </summary>
    ''' <param name="info">The data needed to serialize or deserialize an object.</param>
    ''' <param name="context">The source and destination of a given serialized stream.</param>
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
    Protected Sub New(ByVal info As Global.System.Runtime.Serialization.SerializationInfo, ByVal context As Global.System.Runtime.Serialization.StreamingContext)
        MyBase.New(info, context, False)
        If (Me.IsBinarySerialized(info, context) = True) Then
            Me.InitVars(False)
            Dim schemaChangedHandler1 As Global.System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
            AddHandler Me.Tables.CollectionChanged, schemaChangedHandler1
            AddHandler Me.Relations.CollectionChanged, schemaChangedHandler1
            Return
        End If
        Dim strSchema As String = CType(info.GetValue("XmlSchema", GetType(String)), String)
        If (Me.DetermineSchemaSerializationMode(info, context) = Global.System.Data.SchemaSerializationMode.IncludeSchema) Then
            Dim ds As Global.System.Data.DataSet = New Global.System.Data.DataSet()
            ds.ReadXmlSchema(New Global.System.Xml.XmlTextReader(New Global.System.IO.StringReader(strSchema)))
            If (Not (ds.Tables("Blacklist")) Is Nothing) Then
                MyBase.Tables.Add(New BlacklistDataTable(ds.Tables("Blacklist")))
            End If
            If (Not (ds.Tables("RegisteredClients")) Is Nothing) Then
                MyBase.Tables.Add(New RegisteredClientsDataTable(ds.Tables("RegisteredClients")))
            End If
            Me.DataSetName = ds.DataSetName
            Me.Prefix = ds.Prefix
            Me.Namespace = ds.Namespace
            Me.Locale = ds.Locale
            Me.CaseSensitive = ds.CaseSensitive
            Me.EnforceConstraints = ds.EnforceConstraints
            Me.Merge(ds, False, Global.System.Data.MissingSchemaAction.Add)
            Me.InitVars()
        Else
            Me.ReadXmlSchema(New Global.System.Xml.XmlTextReader(New Global.System.IO.StringReader(strSchema)))
        End If
        Me.GetSerializationData(info, context)
        Dim schemaChangedHandler As Global.System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler MyBase.Tables.CollectionChanged, schemaChangedHandler
        AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
    End Sub

    ''' <summary>
    ''' Gets the blacklist.
    ''' </summary>
    ''' <value>The blacklist.</value>
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
     Global.System.ComponentModel.Browsable(False),
     Global.System.ComponentModel.DesignerSerializationVisibility(Global.System.ComponentModel.DesignerSerializationVisibility.Content)>
    Public ReadOnly Property Blacklist() As BlacklistDataTable
        Get
            Return Me.tableBlacklist
        End Get
    End Property

    ''' <summary>
    ''' Gets the registered clients.
    ''' </summary>
    ''' <value>The registered clients.</value>
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
     Global.System.ComponentModel.Browsable(False),
     Global.System.ComponentModel.DesignerSerializationVisibility(Global.System.ComponentModel.DesignerSerializationVisibility.Content)>
    Public ReadOnly Property RegisteredClients() As RegisteredClientsDataTable
        Get
            Return Me.tableRegisteredClients
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets a <see cref="T:System.Data.SchemaSerializationMode" /> for a <see cref="T:System.Data.DataSet" />.
    ''' </summary>
    ''' <value>The schema serialization mode.</value>
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
     Global.System.ComponentModel.BrowsableAttribute(True),
     Global.System.ComponentModel.DesignerSerializationVisibilityAttribute(Global.System.ComponentModel.DesignerSerializationVisibility.Visible)>
    Public Overrides Property SchemaSerializationMode() As Global.System.Data.SchemaSerializationMode
        Get
            Return Me._schemaSerializationMode
        End Get
        Set
            Me._schemaSerializationMode = Value
        End Set
    End Property

    ''' <summary>
    ''' Gets the collection of tables contained in the <see cref="T:System.Data.DataSet" />.
    ''' </summary>
    ''' <value>The tables.</value>
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
     Global.System.ComponentModel.DesignerSerializationVisibilityAttribute(Global.System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Shadows ReadOnly Property Tables() As Global.System.Data.DataTableCollection
        Get
            Return MyBase.Tables
        End Get
    End Property

    ''' <summary>
    ''' Gets the collection of relations that link tables and allow navigation from parent tables to child tables.
    ''' </summary>
    ''' <value>The relations.</value>
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
     Global.System.ComponentModel.DesignerSerializationVisibilityAttribute(Global.System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Shadows ReadOnly Property Relations() As Global.System.Data.DataRelationCollection
        Get
            Return MyBase.Relations
        End Get
    End Property

    ''' <summary>
    ''' Deserialize all of the tables data of the DataSet from the binary or XML stream.
    ''' </summary>
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
    Protected Overrides Sub InitializeDerivedDataSet()
        Me.BeginInit()
        Me.InitClass()
        Me.EndInit()
    End Sub

    ''' <summary>
    ''' Copies the structure of the <see cref="T:System.Data.DataSet" />, including all <see cref="T:System.Data.DataTable" /> schemas, relations, and constraints. Does not copy any data.
    ''' </summary>
    ''' <returns>A new <see cref="T:System.Data.DataSet" /> with the same schema as the current <see cref="T:System.Data.DataSet" />, but none of the data.</returns>
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
    Public Overrides Function Clone() As Global.System.Data.DataSet
        Dim cln As ServerClientManagement2003DataSet = CType(MyBase.Clone, ServerClientManagement2003DataSet)
        cln.InitVars()
        cln.SchemaSerializationMode = Me.SchemaSerializationMode
        Return cln
    End Function

    ''' <summary>
    ''' Gets a value indicating whether <see cref="P:System.Data.DataSet.Tables" /> property should be persisted.
    ''' </summary>
    ''' <returns><see langword="true" /> if the property value has been changed from its default; otherwise, <see langword="false" />.</returns>
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
    Protected Overrides Function ShouldSerializeTables() As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Gets a value indicating whether <see cref="P:System.Data.DataSet.Relations" /> property should be persisted.
    ''' </summary>
    ''' <returns><see langword="true" /> if the property value has been changed from its default; otherwise, <see langword="false" />.</returns>
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
    Protected Overrides Function ShouldSerializeRelations() As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Ignores attributes and returns an empty DataSet.
    ''' </summary>
    ''' <param name="reader">The specified XML reader.</param>
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
    Protected Overrides Sub ReadXmlSerializable(ByVal reader As Global.System.Xml.XmlReader)
        If (Me.DetermineSchemaSerializationMode(reader) = Global.System.Data.SchemaSerializationMode.IncludeSchema) Then
            Me.Reset()
            Dim ds As Global.System.Data.DataSet = New Global.System.Data.DataSet()
            ds.ReadXml(reader)
            If (Not (ds.Tables("Blacklist")) Is Nothing) Then
                MyBase.Tables.Add(New BlacklistDataTable(ds.Tables("Blacklist")))
            End If
            If (Not (ds.Tables("RegisteredClients")) Is Nothing) Then
                MyBase.Tables.Add(New RegisteredClientsDataTable(ds.Tables("RegisteredClients")))
            End If
            Me.DataSetName = ds.DataSetName
            Me.Prefix = ds.Prefix
            Me.Namespace = ds.Namespace
            Me.Locale = ds.Locale
            Me.CaseSensitive = ds.CaseSensitive
            Me.EnforceConstraints = ds.EnforceConstraints
            Me.Merge(ds, False, Global.System.Data.MissingSchemaAction.Add)
            Me.InitVars()
        Else
            Me.ReadXml(reader)
            Me.InitVars()
        End If
    End Sub

    ''' <summary>
    ''' Returns a serializable <see cref="T:System.Xml.Schema.XmlSchema" /> instance.
    ''' </summary>
    ''' <returns>The <see cref="T:System.Xml.Schema.XmlSchema" /> instance.</returns>
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
    Protected Overrides Function GetSchemaSerializable() As Global.System.Xml.Schema.XmlSchema
        Dim stream As Global.System.IO.MemoryStream = New Global.System.IO.MemoryStream()
        Me.WriteXmlSchema(New Global.System.Xml.XmlTextWriter(stream, Nothing))
        stream.Position = 0
        Return Global.System.Xml.Schema.XmlSchema.Read(New Global.System.Xml.XmlTextReader(stream), Nothing)
    End Function

    ''' <summary>
    ''' Initializes the vars.
    ''' </summary>
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
    Friend Overloads Sub InitVars()
        Me.InitVars(True)
    End Sub

    ''' <summary>
    ''' Initializes the vars.
    ''' </summary>
    ''' <param name="initTable">if set to <c>true</c> [initialize table].</param>
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
    Friend Overloads Sub InitVars(ByVal initTable As Boolean)
        Me.tableBlacklist = CType(MyBase.Tables("Blacklist"), BlacklistDataTable)
        If (initTable = True) Then
            If (Not (Me.tableBlacklist) Is Nothing) Then
                Me.tableBlacklist.InitVars()
            End If
        End If
        Me.tableRegisteredClients = CType(MyBase.Tables("RegisteredClients"), RegisteredClientsDataTable)
        If (initTable = True) Then
            If (Not (Me.tableRegisteredClients) Is Nothing) Then
                Me.tableRegisteredClients.InitVars()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Initializes the class.
    ''' </summary>
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
    Private Sub InitClass()
        Me.DataSetName = "ServerClientManagement2003DataSet"
        Me.Prefix = ""
        Me.Namespace = "http://tempuri.org/ServerClientManagement2003DataSet.xsd"
        Me.EnforceConstraints = True
        Me.SchemaSerializationMode = Global.System.Data.SchemaSerializationMode.IncludeSchema
        Me.tableBlacklist = New BlacklistDataTable()
        MyBase.Tables.Add(Me.tableBlacklist)
        Me.tableRegisteredClients = New RegisteredClientsDataTable()
        MyBase.Tables.Add(Me.tableRegisteredClients)
    End Sub

    ''' <summary>
    ''' Shoulds the serialize blacklist.
    ''' </summary>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
    Private Function ShouldSerializeBlacklist() As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Shoulds the serialize registered clients.
    ''' </summary>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
    Private Function ShouldSerializeRegisteredClients() As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Schemas the changed.
    ''' </summary>
    ''' <param name="sender">The sender.</param>
    ''' <param name="e">The <see cref="System.ComponentModel.CollectionChangeEventArgs"/> instance containing the event data.</param>
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
    Private Sub SchemaChanged(ByVal sender As Object, ByVal e As Global.System.ComponentModel.CollectionChangeEventArgs)
        If (e.Action = Global.System.ComponentModel.CollectionChangeAction.Remove) Then
            Me.InitVars()
        End If
    End Sub

    ''' <summary>
    ''' Gets the typed data set schema.
    ''' </summary>
    ''' <param name="xs">The xs.</param>
    ''' <returns>System.Xml.Schema.XmlSchemaComplexType.</returns>
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
    Public Shared Function GetTypedDataSetSchema(ByVal xs As Global.System.Xml.Schema.XmlSchemaSet) As Global.System.Xml.Schema.XmlSchemaComplexType
        Dim ds As ServerClientManagement2003DataSet = New ServerClientManagement2003DataSet()
        Dim type As Global.System.Xml.Schema.XmlSchemaComplexType = New Global.System.Xml.Schema.XmlSchemaComplexType()
        Dim sequence As Global.System.Xml.Schema.XmlSchemaSequence = New Global.System.Xml.Schema.XmlSchemaSequence()
        Dim any As Global.System.Xml.Schema.XmlSchemaAny = New Global.System.Xml.Schema.XmlSchemaAny()
        any.Namespace = ds.Namespace
        sequence.Items.Add(any)
        type.Particle = sequence
        Dim dsSchema As Global.System.Xml.Schema.XmlSchema = ds.GetSchemaSerializable
        If xs.Contains(dsSchema.TargetNamespace) Then
            Dim s1 As Global.System.IO.MemoryStream = New Global.System.IO.MemoryStream()
            Dim s2 As Global.System.IO.MemoryStream = New Global.System.IO.MemoryStream()
            Try
                Dim schema As Global.System.Xml.Schema.XmlSchema = Nothing
                dsSchema.Write(s1)
                Dim schemas As Global.System.Collections.IEnumerator = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator
                Do While schemas.MoveNext
                    schema = CType(schemas.Current, Global.System.Xml.Schema.XmlSchema)
                    s2.SetLength(0)
                    schema.Write(s2)
                    If (s1.Length = s2.Length) Then
                        s1.Position = 0
                        s2.Position = 0

                        Do While ((s1.Position <> s1.Length) _
                                    AndAlso (s1.ReadByte = s2.ReadByte))


                        Loop
                        If (s1.Position = s1.Length) Then
                            Return type
                        End If
                    End If

                Loop
            Finally
                If (Not (s1) Is Nothing) Then
                    s1.Close()
                End If
                If (Not (s2) Is Nothing) Then
                    s2.Close()
                End If
            End Try
        End If
        xs.Add(dsSchema)
        Return type
    End Function

    ''' <summary>
    ''' Delegate BlacklistRowChangeEventHandler
    ''' </summary>
    ''' <param name="sender">The sender.</param>
    ''' <param name="e">The e.</param>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
    Public Delegate Sub BlacklistRowChangeEventHandler(ByVal sender As Object, ByVal e As BlacklistRowChangeEvent)

    ''' <summary>
    ''' Delegate RegisteredClientsRowChangeEventHandler
    ''' </summary>
    ''' <param name="sender">The sender.</param>
    ''' <param name="e">The e.</param>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
    Public Delegate Sub RegisteredClientsRowChangeEventHandler(ByVal sender As Object, ByVal e As RegisteredClientsRowChangeEvent)

    ''' <summary>
    ''' Represents the strongly named DataTable class.
    ''' </summary>
    <Global.System.Serializable(),
     Global.System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")>
    Partial Public Class BlacklistDataTable
        Inherits Global.System.Data.TypedTableBase(Of BlacklistRow)

        ''' <summary>
        ''' The column identifier
        ''' </summary>
        Private columnID As Global.System.Data.DataColumn

        ''' <summary>
        ''' The columnip
        ''' </summary>
        Private columnip As Global.System.Data.DataColumn

        ''' <summary>
        ''' Initializes a new instance of the <see cref="BlacklistDataTable"/> class.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Sub New()
            MyBase.New
            Me.TableName = "Blacklist"
            Me.BeginInit()
            Me.InitClass()
            Me.EndInit()
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the <see cref="BlacklistDataTable"/> class.
        ''' </summary>
        ''' <param name="table">The table.</param>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Friend Sub New(ByVal table As Global.System.Data.DataTable)
            MyBase.New
            Me.TableName = table.TableName
            If (table.CaseSensitive <> table.DataSet.CaseSensitive) Then
                Me.CaseSensitive = table.CaseSensitive
            End If
            If (table.Locale.ToString <> table.DataSet.Locale.ToString) Then
                Me.Locale = table.Locale
            End If
            If (table.Namespace <> table.DataSet.Namespace) Then
                Me.Namespace = table.Namespace
            End If
            Me.Prefix = table.Prefix
            Me.MinimumCapacity = table.MinimumCapacity
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the <see cref="BlacklistDataTable"/> class.
        ''' </summary>
        ''' <param name="info">The information.</param>
        ''' <param name="context">The context.</param>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Protected Sub New(ByVal info As Global.System.Runtime.Serialization.SerializationInfo, ByVal context As Global.System.Runtime.Serialization.StreamingContext)
            MyBase.New(info, context)
            Me.InitVars()
        End Sub

        ''' <summary>
        ''' Gets the identifier column.
        ''' </summary>
        ''' <value>The identifier column.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public ReadOnly Property IDColumn() As Global.System.Data.DataColumn
            Get
                Return Me.columnID
            End Get
        End Property

        ''' <summary>
        ''' Gets the ip column.
        ''' </summary>
        ''' <value>The ip column.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public ReadOnly Property ipColumn() As Global.System.Data.DataColumn
            Get
                Return Me.columnip
            End Get
        End Property

        ''' <summary>
        ''' Gets the count.
        ''' </summary>
        ''' <value>The count.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.Browsable(False)>
        Public ReadOnly Property Count() As Integer
            Get
                Return Me.Rows.Count
            End Get
        End Property

        ''' <summary>
        ''' Gets the item.
        ''' </summary>
        ''' <param name="index">The index.</param>
        ''' <value>The item.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Default Public ReadOnly Property Item(ByVal index As Integer) As BlacklistRow
            Get
                Return CType(Me.Rows(index), BlacklistRow)
            End Get
        End Property

        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Event BlacklistRowChanging As BlacklistRowChangeEventHandler

        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Event BlacklistRowChanged As BlacklistRowChangeEventHandler

        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Event BlacklistRowDeleting As BlacklistRowChangeEventHandler

        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Event BlacklistRowDeleted As BlacklistRowChangeEventHandler

        ''' <summary>
        ''' Adds the blacklist row.
        ''' </summary>
        ''' <param name="row">The row.</param>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Overloads Sub AddBlacklistRow(ByVal row As BlacklistRow)
            Me.Rows.Add(row)
        End Sub

        ''' <summary>
        ''' Adds the blacklist row.
        ''' </summary>
        ''' <param name="ip">The ip.</param>
        ''' <returns>BlacklistRow.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Overloads Function AddBlacklistRow(ByVal ip As String) As BlacklistRow
            Dim rowBlacklistRow As BlacklistRow = CType(Me.NewRow, BlacklistRow)
            Dim columnValuesArray() As Object = New Object() {Nothing, ip}
            rowBlacklistRow.ItemArray = columnValuesArray
            Me.Rows.Add(rowBlacklistRow)
            Return rowBlacklistRow
        End Function

        ''' <summary>
        ''' Finds the by identifier.
        ''' </summary>
        ''' <param name="ID">The identifier.</param>
        ''' <returns>BlacklistRow.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Function FindByID(ByVal ID As Integer) As BlacklistRow
            Return CType(Me.Rows.Find(New Object() {ID}), BlacklistRow)
        End Function

        ''' <summary>
        ''' Clones the structure of the <see cref="T:System.Data.DataTable" />, including all <see cref="T:System.Data.DataTable" /> schemas and constraints.
        ''' </summary>
        ''' <returns>A new <see cref="T:System.Data.DataTable" /> with the same schema as the current <see cref="T:System.Data.DataTable" />.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Overrides Function Clone() As Global.System.Data.DataTable
            Dim cln As BlacklistDataTable = CType(MyBase.Clone, BlacklistDataTable)
            cln.InitVars()
            Return cln
        End Function

        ''' <summary>
        ''' Creates a new instance of <see cref="T:System.Data.DataTable" />.
        ''' </summary>
        ''' <returns>The new expression.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Protected Overrides Function CreateInstance() As Global.System.Data.DataTable
            Return New BlacklistDataTable()
        End Function

        ''' <summary>
        ''' Initializes the vars.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Friend Sub InitVars()
            Me.columnID = MyBase.Columns("ID")
            Me.columnip = MyBase.Columns("ip")
        End Sub

        ''' <summary>
        ''' Initializes the class.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Private Sub InitClass()
            Me.columnID = New Global.System.Data.DataColumn("ID", GetType(Integer), Nothing, Global.System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnID)
            Me.columnip = New Global.System.Data.DataColumn("ip", GetType(String), Nothing, Global.System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnip)
            Me.Constraints.Add(New Global.System.Data.UniqueConstraint("Constraint1", New Global.System.Data.DataColumn() {Me.columnID}, True))
            Me.columnID.AutoIncrement = True
            Me.columnID.AutoIncrementSeed = -1
            Me.columnID.AutoIncrementStep = -1
            Me.columnID.AllowDBNull = False
            Me.columnID.Unique = True
            Me.columnip.MaxLength = 255
        End Sub

        ''' <summary>
        ''' Creates new blacklistrow.
        ''' </summary>
        ''' <returns>BlacklistRow.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Function NewBlacklistRow() As BlacklistRow
            Return CType(Me.NewRow, BlacklistRow)
        End Function

        ''' <summary>
        ''' Creates a new row from an existing row.
        ''' </summary>
        ''' <param name="builder">A <see cref="T:System.Data.DataRowBuilder" /> object.</param>
        ''' <returns>A <see cref="T:System.Data.DataRow" /> derived class.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Protected Overrides Function NewRowFromBuilder(ByVal builder As Global.System.Data.DataRowBuilder) As Global.System.Data.DataRow
            Return New BlacklistRow(builder)
        End Function

        ''' <summary>
        ''' Gets the row type.
        ''' </summary>
        ''' <returns>The type of the <see cref="T:System.Data.DataRow" />.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Protected Overrides Function GetRowType() As Global.System.Type
            Return GetType(BlacklistRow)
        End Function

        ''' <summary>
        ''' Raises the <see cref="E:System.Data.DataTable.RowChanged" /> event.
        ''' </summary>
        ''' <param name="e">A <see cref="T:System.Data.DataRowChangeEventArgs" /> that contains the event data.</param>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Protected Overrides Sub OnRowChanged(ByVal e As Global.System.Data.DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.BlacklistRowChangedEvent) Is Nothing) Then
                RaiseEvent BlacklistRowChanged(Me, New BlacklistRowChangeEvent(CType(e.Row, BlacklistRow), e.Action))
            End If
        End Sub

        ''' <summary>
        ''' Raises the <see cref="E:System.Data.DataTable.RowChanging" /> event.
        ''' </summary>
        ''' <param name="e">A <see cref="T:System.Data.DataRowChangeEventArgs" /> that contains the event data.</param>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Protected Overrides Sub OnRowChanging(ByVal e As Global.System.Data.DataRowChangeEventArgs)
            MyBase.OnRowChanging(e)
            If (Not (Me.BlacklistRowChangingEvent) Is Nothing) Then
                RaiseEvent BlacklistRowChanging(Me, New BlacklistRowChangeEvent(CType(e.Row, BlacklistRow), e.Action))
            End If
        End Sub

        ''' <summary>
        ''' Raises the <see cref="E:System.Data.DataTable.RowDeleted" /> event.
        ''' </summary>
        ''' <param name="e">A <see cref="T:System.Data.DataRowChangeEventArgs" /> that contains the event data.</param>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Protected Overrides Sub OnRowDeleted(ByVal e As Global.System.Data.DataRowChangeEventArgs)
            MyBase.OnRowDeleted(e)
            If (Not (Me.BlacklistRowDeletedEvent) Is Nothing) Then
                RaiseEvent BlacklistRowDeleted(Me, New BlacklistRowChangeEvent(CType(e.Row, BlacklistRow), e.Action))
            End If
        End Sub

        ''' <summary>
        ''' Describes the type of access to user data for a user-defined method or function.
        ''' </summary>
        ''' <param name="e">The <see cref="System.Data.DataRowChangeEventArgs"/> instance containing the event data.</param>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Protected Overrides Sub OnRowDeleting(ByVal e As Global.System.Data.DataRowChangeEventArgs)
            MyBase.OnRowDeleting(e)
            If (Not (Me.BlacklistRowDeletingEvent) Is Nothing) Then
                RaiseEvent BlacklistRowDeleting(Me, New BlacklistRowChangeEvent(CType(e.Row, BlacklistRow), e.Action))
            End If
        End Sub

        ''' <summary>
        ''' Removes the blacklist row.
        ''' </summary>
        ''' <param name="row">The row.</param>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Sub RemoveBlacklistRow(ByVal row As BlacklistRow)
            Me.Rows.Remove(row)
        End Sub

        ''' <summary>
        ''' Gets the typed table schema.
        ''' </summary>
        ''' <param name="xs">The xs.</param>
        ''' <returns>System.Xml.Schema.XmlSchemaComplexType.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Shared Function GetTypedTableSchema(ByVal xs As Global.System.Xml.Schema.XmlSchemaSet) As Global.System.Xml.Schema.XmlSchemaComplexType
            Dim type As Global.System.Xml.Schema.XmlSchemaComplexType = New Global.System.Xml.Schema.XmlSchemaComplexType()
            Dim sequence As Global.System.Xml.Schema.XmlSchemaSequence = New Global.System.Xml.Schema.XmlSchemaSequence()
            Dim ds As ServerClientManagement2003DataSet = New ServerClientManagement2003DataSet()
            Dim any1 As Global.System.Xml.Schema.XmlSchemaAny = New Global.System.Xml.Schema.XmlSchemaAny()
            any1.Namespace = "http://www.w3.org/2001/XMLSchema"
            any1.MinOccurs = New Decimal(0)
            any1.MaxOccurs = Decimal.MaxValue
            any1.ProcessContents = Global.System.Xml.Schema.XmlSchemaContentProcessing.Lax
            sequence.Items.Add(any1)
            Dim any2 As Global.System.Xml.Schema.XmlSchemaAny = New Global.System.Xml.Schema.XmlSchemaAny()
            any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1"
            any2.MinOccurs = New Decimal(1)
            any2.ProcessContents = Global.System.Xml.Schema.XmlSchemaContentProcessing.Lax
            sequence.Items.Add(any2)
            Dim attribute1 As Global.System.Xml.Schema.XmlSchemaAttribute = New Global.System.Xml.Schema.XmlSchemaAttribute()
            attribute1.Name = "namespace"
            attribute1.FixedValue = ds.Namespace
            type.Attributes.Add(attribute1)
            Dim attribute2 As Global.System.Xml.Schema.XmlSchemaAttribute = New Global.System.Xml.Schema.XmlSchemaAttribute()
            attribute2.Name = "tableTypeName"
            attribute2.FixedValue = "BlacklistDataTable"
            type.Attributes.Add(attribute2)
            type.Particle = sequence
            Dim dsSchema As Global.System.Xml.Schema.XmlSchema = ds.GetSchemaSerializable
            If xs.Contains(dsSchema.TargetNamespace) Then
                Dim s1 As Global.System.IO.MemoryStream = New Global.System.IO.MemoryStream()
                Dim s2 As Global.System.IO.MemoryStream = New Global.System.IO.MemoryStream()
                Try
                    Dim schema As Global.System.Xml.Schema.XmlSchema = Nothing
                    dsSchema.Write(s1)
                    Dim schemas As Global.System.Collections.IEnumerator = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator
                    Do While schemas.MoveNext
                        schema = CType(schemas.Current, Global.System.Xml.Schema.XmlSchema)
                        s2.SetLength(0)
                        schema.Write(s2)
                        If (s1.Length = s2.Length) Then
                            s1.Position = 0
                            s2.Position = 0

                            Do While ((s1.Position <> s1.Length) _
                                        AndAlso (s1.ReadByte = s2.ReadByte))


                            Loop
                            If (s1.Position = s1.Length) Then
                                Return type
                            End If
                        End If

                    Loop
                Finally
                    If (Not (s1) Is Nothing) Then
                        s1.Close()
                    End If
                    If (Not (s2) Is Nothing) Then
                        s2.Close()
                    End If
                End Try
            End If
            xs.Add(dsSchema)
            Return type
        End Function
    End Class

    ''' <summary>
    ''' Represents the strongly named DataTable class.
    ''' </summary>
    <Global.System.Serializable(),
     Global.System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")>
    Partial Public Class RegisteredClientsDataTable
        Inherits Global.System.Data.TypedTableBase(Of RegisteredClientsRow)

        ''' <summary>
        ''' The column identifier
        ''' </summary>
        Private columnID As Global.System.Data.DataColumn

        ''' <summary>
        ''' The columnip
        ''' </summary>
        Private columnip As Global.System.Data.DataColumn

        ''' <summary>
        ''' The columnusername
        ''' </summary>
        Private columnusername As Global.System.Data.DataColumn

        ''' <summary>
        ''' Initializes a new instance of the <see cref="RegisteredClientsDataTable"/> class.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Sub New()
            MyBase.New
            Me.TableName = "RegisteredClients"
            Me.BeginInit()
            Me.InitClass()
            Me.EndInit()
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the <see cref="RegisteredClientsDataTable"/> class.
        ''' </summary>
        ''' <param name="table">The table.</param>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Friend Sub New(ByVal table As Global.System.Data.DataTable)
            MyBase.New
            Me.TableName = table.TableName
            If (table.CaseSensitive <> table.DataSet.CaseSensitive) Then
                Me.CaseSensitive = table.CaseSensitive
            End If
            If (table.Locale.ToString <> table.DataSet.Locale.ToString) Then
                Me.Locale = table.Locale
            End If
            If (table.Namespace <> table.DataSet.Namespace) Then
                Me.Namespace = table.Namespace
            End If
            Me.Prefix = table.Prefix
            Me.MinimumCapacity = table.MinimumCapacity
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the <see cref="RegisteredClientsDataTable"/> class.
        ''' </summary>
        ''' <param name="info">The information.</param>
        ''' <param name="context">The context.</param>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Protected Sub New(ByVal info As Global.System.Runtime.Serialization.SerializationInfo, ByVal context As Global.System.Runtime.Serialization.StreamingContext)
            MyBase.New(info, context)
            Me.InitVars()
        End Sub

        ''' <summary>
        ''' Gets the identifier column.
        ''' </summary>
        ''' <value>The identifier column.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public ReadOnly Property IDColumn() As Global.System.Data.DataColumn
            Get
                Return Me.columnID
            End Get
        End Property

        ''' <summary>
        ''' Gets the ip column.
        ''' </summary>
        ''' <value>The ip column.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public ReadOnly Property ipColumn() As Global.System.Data.DataColumn
            Get
                Return Me.columnip
            End Get
        End Property

        ''' <summary>
        ''' Gets the username column.
        ''' </summary>
        ''' <value>The username column.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public ReadOnly Property usernameColumn() As Global.System.Data.DataColumn
            Get
                Return Me.columnusername
            End Get
        End Property

        ''' <summary>
        ''' Gets the count.
        ''' </summary>
        ''' <value>The count.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.Browsable(False)>
        Public ReadOnly Property Count() As Integer
            Get
                Return Me.Rows.Count
            End Get
        End Property

        ''' <summary>
        ''' Gets the item.
        ''' </summary>
        ''' <param name="index">The index.</param>
        ''' <value>The item.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Default Public ReadOnly Property Item(ByVal index As Integer) As RegisteredClientsRow
            Get
                Return CType(Me.Rows(index), RegisteredClientsRow)
            End Get
        End Property

        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Event RegisteredClientsRowChanging As RegisteredClientsRowChangeEventHandler

        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Event RegisteredClientsRowChanged As RegisteredClientsRowChangeEventHandler

        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Event RegisteredClientsRowDeleting As RegisteredClientsRowChangeEventHandler

        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Event RegisteredClientsRowDeleted As RegisteredClientsRowChangeEventHandler

        ''' <summary>
        ''' Adds the registered clients row.
        ''' </summary>
        ''' <param name="row">The row.</param>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Overloads Sub AddRegisteredClientsRow(ByVal row As RegisteredClientsRow)
            Me.Rows.Add(row)
        End Sub

        ''' <summary>
        ''' Adds the registered clients row.
        ''' </summary>
        ''' <param name="ip">The ip.</param>
        ''' <param name="username">The username.</param>
        ''' <returns>RegisteredClientsRow.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Overloads Function AddRegisteredClientsRow(ByVal ip As String, ByVal username As String) As RegisteredClientsRow
            Dim rowRegisteredClientsRow As RegisteredClientsRow = CType(Me.NewRow, RegisteredClientsRow)
            Dim columnValuesArray() As Object = New Object() {Nothing, ip, username}
            rowRegisteredClientsRow.ItemArray = columnValuesArray
            Me.Rows.Add(rowRegisteredClientsRow)
            Return rowRegisteredClientsRow
        End Function

        ''' <summary>
        ''' Finds the by identifier.
        ''' </summary>
        ''' <param name="ID">The identifier.</param>
        ''' <returns>RegisteredClientsRow.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Function FindByID(ByVal ID As Integer) As RegisteredClientsRow
            Return CType(Me.Rows.Find(New Object() {ID}), RegisteredClientsRow)
        End Function

        ''' <summary>
        ''' Clones the structure of the <see cref="T:System.Data.DataTable" />, including all <see cref="T:System.Data.DataTable" /> schemas and constraints.
        ''' </summary>
        ''' <returns>A new <see cref="T:System.Data.DataTable" /> with the same schema as the current <see cref="T:System.Data.DataTable" />.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Overrides Function Clone() As Global.System.Data.DataTable
            Dim cln As RegisteredClientsDataTable = CType(MyBase.Clone, RegisteredClientsDataTable)
            cln.InitVars()
            Return cln
        End Function

        ''' <summary>
        ''' Creates a new instance of <see cref="T:System.Data.DataTable" />.
        ''' </summary>
        ''' <returns>The new expression.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Protected Overrides Function CreateInstance() As Global.System.Data.DataTable
            Return New RegisteredClientsDataTable()
        End Function

        ''' <summary>
        ''' Initializes the vars.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Friend Sub InitVars()
            Me.columnID = MyBase.Columns("ID")
            Me.columnip = MyBase.Columns("ip")
            Me.columnusername = MyBase.Columns("username")
        End Sub

        ''' <summary>
        ''' Initializes the class.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Private Sub InitClass()
            Me.columnID = New Global.System.Data.DataColumn("ID", GetType(Integer), Nothing, Global.System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnID)
            Me.columnip = New Global.System.Data.DataColumn("ip", GetType(String), Nothing, Global.System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnip)
            Me.columnusername = New Global.System.Data.DataColumn("username", GetType(String), Nothing, Global.System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnusername)
            Me.Constraints.Add(New Global.System.Data.UniqueConstraint("Constraint1", New Global.System.Data.DataColumn() {Me.columnID}, True))
            Me.columnID.AutoIncrement = True
            Me.columnID.AutoIncrementSeed = -1
            Me.columnID.AutoIncrementStep = -1
            Me.columnID.AllowDBNull = False
            Me.columnID.Unique = True
            Me.columnip.MaxLength = 255
            Me.columnusername.MaxLength = 255
        End Sub

        ''' <summary>
        ''' Creates new registeredclientsrow.
        ''' </summary>
        ''' <returns>RegisteredClientsRow.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Function NewRegisteredClientsRow() As RegisteredClientsRow
            Return CType(Me.NewRow, RegisteredClientsRow)
        End Function

        ''' <summary>
        ''' Creates a new row from an existing row.
        ''' </summary>
        ''' <param name="builder">A <see cref="T:System.Data.DataRowBuilder" /> object.</param>
        ''' <returns>A <see cref="T:System.Data.DataRow" /> derived class.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Protected Overrides Function NewRowFromBuilder(ByVal builder As Global.System.Data.DataRowBuilder) As Global.System.Data.DataRow
            Return New RegisteredClientsRow(builder)
        End Function

        ''' <summary>
        ''' Gets the row type.
        ''' </summary>
        ''' <returns>The type of the <see cref="T:System.Data.DataRow" />.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Protected Overrides Function GetRowType() As Global.System.Type
            Return GetType(RegisteredClientsRow)
        End Function

        ''' <summary>
        ''' Raises the <see cref="E:System.Data.DataTable.RowChanged" /> event.
        ''' </summary>
        ''' <param name="e">A <see cref="T:System.Data.DataRowChangeEventArgs" /> that contains the event data.</param>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Protected Overrides Sub OnRowChanged(ByVal e As Global.System.Data.DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.RegisteredClientsRowChangedEvent) Is Nothing) Then
                RaiseEvent RegisteredClientsRowChanged(Me, New RegisteredClientsRowChangeEvent(CType(e.Row, RegisteredClientsRow), e.Action))
            End If
        End Sub

        ''' <summary>
        ''' Raises the <see cref="E:System.Data.DataTable.RowChanging" /> event.
        ''' </summary>
        ''' <param name="e">A <see cref="T:System.Data.DataRowChangeEventArgs" /> that contains the event data.</param>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Protected Overrides Sub OnRowChanging(ByVal e As Global.System.Data.DataRowChangeEventArgs)
            MyBase.OnRowChanging(e)
            If (Not (Me.RegisteredClientsRowChangingEvent) Is Nothing) Then
                RaiseEvent RegisteredClientsRowChanging(Me, New RegisteredClientsRowChangeEvent(CType(e.Row, RegisteredClientsRow), e.Action))
            End If
        End Sub

        ''' <summary>
        ''' Raises the <see cref="E:System.Data.DataTable.RowDeleted" /> event.
        ''' </summary>
        ''' <param name="e">A <see cref="T:System.Data.DataRowChangeEventArgs" /> that contains the event data.</param>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Protected Overrides Sub OnRowDeleted(ByVal e As Global.System.Data.DataRowChangeEventArgs)
            MyBase.OnRowDeleted(e)
            If (Not (Me.RegisteredClientsRowDeletedEvent) Is Nothing) Then
                RaiseEvent RegisteredClientsRowDeleted(Me, New RegisteredClientsRowChangeEvent(CType(e.Row, RegisteredClientsRow), e.Action))
            End If
        End Sub

        ''' <summary>
        ''' Describes the type of access to user data for a user-defined method or function.
        ''' </summary>
        ''' <param name="e">The <see cref="System.Data.DataRowChangeEventArgs"/> instance containing the event data.</param>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Protected Overrides Sub OnRowDeleting(ByVal e As Global.System.Data.DataRowChangeEventArgs)
            MyBase.OnRowDeleting(e)
            If (Not (Me.RegisteredClientsRowDeletingEvent) Is Nothing) Then
                RaiseEvent RegisteredClientsRowDeleting(Me, New RegisteredClientsRowChangeEvent(CType(e.Row, RegisteredClientsRow), e.Action))
            End If
        End Sub

        ''' <summary>
        ''' Removes the registered clients row.
        ''' </summary>
        ''' <param name="row">The row.</param>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Sub RemoveRegisteredClientsRow(ByVal row As RegisteredClientsRow)
            Me.Rows.Remove(row)
        End Sub

        ''' <summary>
        ''' Gets the typed table schema.
        ''' </summary>
        ''' <param name="xs">The xs.</param>
        ''' <returns>System.Xml.Schema.XmlSchemaComplexType.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Shared Function GetTypedTableSchema(ByVal xs As Global.System.Xml.Schema.XmlSchemaSet) As Global.System.Xml.Schema.XmlSchemaComplexType
            Dim type As Global.System.Xml.Schema.XmlSchemaComplexType = New Global.System.Xml.Schema.XmlSchemaComplexType()
            Dim sequence As Global.System.Xml.Schema.XmlSchemaSequence = New Global.System.Xml.Schema.XmlSchemaSequence()
            Dim ds As ServerClientManagement2003DataSet = New ServerClientManagement2003DataSet()
            Dim any1 As Global.System.Xml.Schema.XmlSchemaAny = New Global.System.Xml.Schema.XmlSchemaAny()
            any1.Namespace = "http://www.w3.org/2001/XMLSchema"
            any1.MinOccurs = New Decimal(0)
            any1.MaxOccurs = Decimal.MaxValue
            any1.ProcessContents = Global.System.Xml.Schema.XmlSchemaContentProcessing.Lax
            sequence.Items.Add(any1)
            Dim any2 As Global.System.Xml.Schema.XmlSchemaAny = New Global.System.Xml.Schema.XmlSchemaAny()
            any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1"
            any2.MinOccurs = New Decimal(1)
            any2.ProcessContents = Global.System.Xml.Schema.XmlSchemaContentProcessing.Lax
            sequence.Items.Add(any2)
            Dim attribute1 As Global.System.Xml.Schema.XmlSchemaAttribute = New Global.System.Xml.Schema.XmlSchemaAttribute()
            attribute1.Name = "namespace"
            attribute1.FixedValue = ds.Namespace
            type.Attributes.Add(attribute1)
            Dim attribute2 As Global.System.Xml.Schema.XmlSchemaAttribute = New Global.System.Xml.Schema.XmlSchemaAttribute()
            attribute2.Name = "tableTypeName"
            attribute2.FixedValue = "RegisteredClientsDataTable"
            type.Attributes.Add(attribute2)
            type.Particle = sequence
            Dim dsSchema As Global.System.Xml.Schema.XmlSchema = ds.GetSchemaSerializable
            If xs.Contains(dsSchema.TargetNamespace) Then
                Dim s1 As Global.System.IO.MemoryStream = New Global.System.IO.MemoryStream()
                Dim s2 As Global.System.IO.MemoryStream = New Global.System.IO.MemoryStream()
                Try
                    Dim schema As Global.System.Xml.Schema.XmlSchema = Nothing
                    dsSchema.Write(s1)
                    Dim schemas As Global.System.Collections.IEnumerator = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator
                    Do While schemas.MoveNext
                        schema = CType(schemas.Current, Global.System.Xml.Schema.XmlSchema)
                        s2.SetLength(0)
                        schema.Write(s2)
                        If (s1.Length = s2.Length) Then
                            s1.Position = 0
                            s2.Position = 0

                            Do While ((s1.Position <> s1.Length) _
                                        AndAlso (s1.ReadByte = s2.ReadByte))


                            Loop
                            If (s1.Position = s1.Length) Then
                                Return type
                            End If
                        End If

                    Loop
                Finally
                    If (Not (s1) Is Nothing) Then
                        s1.Close()
                    End If
                    If (Not (s2) Is Nothing) Then
                        s2.Close()
                    End If
                End Try
            End If
            xs.Add(dsSchema)
            Return type
        End Function
    End Class

    ''' <summary>
    ''' Represents strongly named DataRow class.
    ''' </summary>
    Partial Public Class BlacklistRow
        Inherits Global.System.Data.DataRow

        ''' <summary>
        ''' The table blacklist
        ''' </summary>
        Private tableBlacklist As BlacklistDataTable

        ''' <summary>
        ''' Initializes a new instance of the <see cref="BlacklistRow"/> class.
        ''' </summary>
        ''' <param name="rb">The rb.</param>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Friend Sub New(ByVal rb As Global.System.Data.DataRowBuilder)
            MyBase.New(rb)
            Me.tableBlacklist = CType(Me.Table, BlacklistDataTable)
        End Sub

        ''' <summary>
        ''' Gets or sets the identifier.
        ''' </summary>
        ''' <value>The identifier.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Property ID() As Integer
            Get
                Return CType(Me(Me.tableBlacklist.IDColumn), Integer)
            End Get
            Set
                Me(Me.tableBlacklist.IDColumn) = Value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the ip.
        ''' </summary>
        ''' <value>The ip.</value>
        ''' <exception cref="System.Data.StrongTypingException">The value for column 'ip' in table 'Blacklist' is DBNull.</exception>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Property ip() As String
            Get
                Try
                    Return CType(Me(Me.tableBlacklist.ipColumn), String)
                Catch e As Global.System.InvalidCastException
                    Throw New Global.System.Data.StrongTypingException("The value for column 'ip' in table 'Blacklist' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableBlacklist.ipColumn) = Value
            End Set
        End Property

        ''' <summary>
        ''' Isips the null.
        ''' </summary>
        ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Function IsipNull() As Boolean
            Return Me.IsNull(Me.tableBlacklist.ipColumn)
        End Function

        ''' <summary>
        ''' Setips the null.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Sub SetipNull()
            Me(Me.tableBlacklist.ipColumn) = Global.System.Convert.DBNull
        End Sub
    End Class

    ''' <summary>
    ''' Represents strongly named DataRow class.
    ''' </summary>
    Partial Public Class RegisteredClientsRow
        Inherits Global.System.Data.DataRow

        ''' <summary>
        ''' The table registered clients
        ''' </summary>
        Private tableRegisteredClients As RegisteredClientsDataTable

        ''' <summary>
        ''' Initializes a new instance of the <see cref="RegisteredClientsRow"/> class.
        ''' </summary>
        ''' <param name="rb">The rb.</param>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Friend Sub New(ByVal rb As Global.System.Data.DataRowBuilder)
            MyBase.New(rb)
            Me.tableRegisteredClients = CType(Me.Table, RegisteredClientsDataTable)
        End Sub

        ''' <summary>
        ''' Gets or sets the identifier.
        ''' </summary>
        ''' <value>The identifier.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Property ID() As Integer
            Get
                Return CType(Me(Me.tableRegisteredClients.IDColumn), Integer)
            End Get
            Set
                Me(Me.tableRegisteredClients.IDColumn) = Value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the ip.
        ''' </summary>
        ''' <value>The ip.</value>
        ''' <exception cref="System.Data.StrongTypingException">The value for column 'ip' in table 'RegisteredClients' is DBNull.</exception>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Property ip() As String
            Get
                Try
                    Return CType(Me(Me.tableRegisteredClients.ipColumn), String)
                Catch e As Global.System.InvalidCastException
                    Throw New Global.System.Data.StrongTypingException("The value for column 'ip' in table 'RegisteredClients' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableRegisteredClients.ipColumn) = Value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the username.
        ''' </summary>
        ''' <value>The username.</value>
        ''' <exception cref="System.Data.StrongTypingException">The value for column 'username' in table 'RegisteredClients' is DBNull.</exception>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Property username() As String
            Get
                Try
                    Return CType(Me(Me.tableRegisteredClients.usernameColumn), String)
                Catch e As Global.System.InvalidCastException
                    Throw New Global.System.Data.StrongTypingException("The value for column 'username' in table 'RegisteredClients' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableRegisteredClients.usernameColumn) = Value
            End Set
        End Property

        ''' <summary>
        ''' Isips the null.
        ''' </summary>
        ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Function IsipNull() As Boolean
            Return Me.IsNull(Me.tableRegisteredClients.ipColumn)
        End Function

        ''' <summary>
        ''' Setips the null.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Sub SetipNull()
            Me(Me.tableRegisteredClients.ipColumn) = Global.System.Convert.DBNull
        End Sub

        ''' <summary>
        ''' Isusernames the null.
        ''' </summary>
        ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Function IsusernameNull() As Boolean
            Return Me.IsNull(Me.tableRegisteredClients.usernameColumn)
        End Function

        ''' <summary>
        ''' Setusernames the null.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Sub SetusernameNull()
            Me(Me.tableRegisteredClients.usernameColumn) = Global.System.Convert.DBNull
        End Sub
    End Class

    ''' <summary>
    ''' Row event argument class
    ''' </summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
    Public Class BlacklistRowChangeEvent
        Inherits Global.System.EventArgs

        ''' <summary>
        ''' The event row
        ''' </summary>
        Private eventRow As BlacklistRow

        ''' <summary>
        ''' The event action
        ''' </summary>
        Private eventAction As Global.System.Data.DataRowAction

        ''' <summary>
        ''' Initializes a new instance of the <see cref="BlacklistRowChangeEvent"/> class.
        ''' </summary>
        ''' <param name="row">The row.</param>
        ''' <param name="action">The action.</param>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Sub New(ByVal row As BlacklistRow, ByVal action As Global.System.Data.DataRowAction)
            MyBase.New
            Me.eventRow = row
            Me.eventAction = action
        End Sub

        ''' <summary>
        ''' Gets the row.
        ''' </summary>
        ''' <value>The row.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public ReadOnly Property Row() As BlacklistRow
            Get
                Return Me.eventRow
            End Get
        End Property

        ''' <summary>
        ''' Gets the action.
        ''' </summary>
        ''' <value>The action.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public ReadOnly Property Action() As Global.System.Data.DataRowAction
            Get
                Return Me.eventAction
            End Get
        End Property
    End Class

    ''' <summary>
    ''' Row event argument class
    ''' </summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
    Public Class RegisteredClientsRowChangeEvent
        Inherits Global.System.EventArgs

        ''' <summary>
        ''' The event row
        ''' </summary>
        Private eventRow As RegisteredClientsRow

        ''' <summary>
        ''' The event action
        ''' </summary>
        Private eventAction As Global.System.Data.DataRowAction

        ''' <summary>
        ''' Initializes a new instance of the <see cref="RegisteredClientsRowChangeEvent"/> class.
        ''' </summary>
        ''' <param name="row">The row.</param>
        ''' <param name="action">The action.</param>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Sub New(ByVal row As RegisteredClientsRow, ByVal action As Global.System.Data.DataRowAction)
            MyBase.New
            Me.eventRow = row
            Me.eventAction = action
        End Sub

        ''' <summary>
        ''' Gets the row.
        ''' </summary>
        ''' <value>The row.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public ReadOnly Property Row() As RegisteredClientsRow
            Get
                Return Me.eventRow
            End Get
        End Property

        ''' <summary>
        ''' Gets the action.
        ''' </summary>
        ''' <value>The action.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public ReadOnly Property Action() As Global.System.Data.DataRowAction
            Get
                Return Me.eventAction
            End Get
        End Property
    End Class
End Class

Namespace ServerClientManagement2003DataSetTableAdapters

    ''' <summary>
    ''' Represents the connection and commands used to retrieve and save data.
    ''' </summary>
    <Global.System.ComponentModel.DesignerCategoryAttribute("code"),
     Global.System.ComponentModel.ToolboxItem(True),
     Global.System.ComponentModel.DataObjectAttribute(True),
     Global.System.ComponentModel.DesignerAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner" &
        ", Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"),
     Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")>
    Partial Public Class BlacklistTableAdapter
        Inherits Global.System.ComponentModel.Component

        ''' <summary>
        ''' The adapter
        ''' </summary>
        Private WithEvents _adapter As Global.System.Data.OleDb.OleDbDataAdapter

        ''' <summary>
        ''' The connection
        ''' </summary>
        Private _connection As Global.System.Data.OleDb.OleDbConnection

        ''' <summary>
        ''' The transaction
        ''' </summary>
        Private _transaction As Global.System.Data.OleDb.OleDbTransaction

        ''' <summary>
        ''' The command collection
        ''' </summary>
        Private _commandCollection() As Global.System.Data.OleDb.OleDbCommand

        ''' <summary>
        ''' The clear before fill
        ''' </summary>
        Private _clearBeforeFill As Boolean

        ''' <summary>
        ''' Initializes a new instance of the <see cref="BlacklistTableAdapter"/> class.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Sub New()
            MyBase.New
            Me.ClearBeforeFill = True
        End Sub

        ''' <summary>
        ''' Gets the adapter.
        ''' </summary>
        ''' <value>The adapter.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Protected Friend ReadOnly Property Adapter() As Global.System.Data.OleDb.OleDbDataAdapter
            Get
                If (Me._adapter Is Nothing) Then
                    Me.InitAdapter()
                End If
                Return Me._adapter
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the connection.
        ''' </summary>
        ''' <value>The connection.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Friend Property Connection() As Global.System.Data.OleDb.OleDbConnection
            Get
                If (Me._connection Is Nothing) Then
                    Me.InitConnection()
                End If
                Return Me._connection
            End Get
            Set
                Me._connection = Value
                If (Not (Me.Adapter.InsertCommand) Is Nothing) Then
                    Me.Adapter.InsertCommand.Connection = Value
                End If
                If (Not (Me.Adapter.DeleteCommand) Is Nothing) Then
                    Me.Adapter.DeleteCommand.Connection = Value
                End If
                If (Not (Me.Adapter.UpdateCommand) Is Nothing) Then
                    Me.Adapter.UpdateCommand.Connection = Value
                End If
                Dim i As Integer = 0
                Do While (i < Me.CommandCollection.Length)
                    If (Not (Me.CommandCollection(i)) Is Nothing) Then
                        CType(Me.CommandCollection(i), Global.System.Data.OleDb.OleDbCommand).Connection = Value
                    End If
                    i = (i + 1)
                Loop
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the transaction.
        ''' </summary>
        ''' <value>The transaction.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Friend Property Transaction() As Global.System.Data.OleDb.OleDbTransaction
            Get
                Return Me._transaction
            End Get
            Set
                Me._transaction = Value
                Dim i As Integer = 0
                Do While (i < Me.CommandCollection.Length)
                    Me.CommandCollection(i).Transaction = Me._transaction
                    i = (i + 1)
                Loop
                If ((Not (Me.Adapter) Is Nothing) _
                            AndAlso (Not (Me.Adapter.DeleteCommand) Is Nothing)) Then
                    Me.Adapter.DeleteCommand.Transaction = Me._transaction
                End If
                If ((Not (Me.Adapter) Is Nothing) _
                            AndAlso (Not (Me.Adapter.InsertCommand) Is Nothing)) Then
                    Me.Adapter.InsertCommand.Transaction = Me._transaction
                End If
                If ((Not (Me.Adapter) Is Nothing) _
                            AndAlso (Not (Me.Adapter.UpdateCommand) Is Nothing)) Then
                    Me.Adapter.UpdateCommand.Transaction = Me._transaction
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the command collection.
        ''' </summary>
        ''' <value>The command collection.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Protected ReadOnly Property CommandCollection() As Global.System.Data.OleDb.OleDbCommand()
            Get
                If (Me._commandCollection Is Nothing) Then
                    Me.InitCommandCollection()
                End If
                Return Me._commandCollection
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a value indicating whether [clear before fill].
        ''' </summary>
        ''' <value><c>true</c> if [clear before fill]; otherwise, <c>false</c>.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Property ClearBeforeFill() As Boolean
            Get
                Return Me._clearBeforeFill
            End Get
            Set
                Me._clearBeforeFill = Value
            End Set
        End Property

        ''' <summary>
        ''' Initializes the adapter.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Private Sub InitAdapter()
            Me._adapter = New Global.System.Data.OleDb.OleDbDataAdapter()
            Dim tableMapping As Global.System.Data.Common.DataTableMapping = New Global.System.Data.Common.DataTableMapping()
            tableMapping.SourceTable = "Table"
            tableMapping.DataSetTable = "Blacklist"
            tableMapping.ColumnMappings.Add("ID", "ID")
            tableMapping.ColumnMappings.Add("ip", "ip")
            Me._adapter.TableMappings.Add(tableMapping)
            Me._adapter.DeleteCommand = New Global.System.Data.OleDb.OleDbCommand()
            Me._adapter.DeleteCommand.Connection = Me.Connection
            Me._adapter.DeleteCommand.CommandText = "DELETE FROM `Blacklist` WHERE ((`ID` = ?) AND ((? = 1 AND `ip` IS NULL) OR (`ip` " &
                "= ?)))"
            Me._adapter.DeleteCommand.CommandType = Global.System.Data.CommandType.Text
            Me._adapter.DeleteCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_ID", Global.System.Data.OleDb.OleDbType.[Integer], 0, Global.System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ID", Global.System.Data.DataRowVersion.Original, False, Nothing))
            Me._adapter.DeleteCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("IsNull_ip", Global.System.Data.OleDb.OleDbType.[Integer], 0, Global.System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ip", Global.System.Data.DataRowVersion.Original, True, Nothing))
            Me._adapter.DeleteCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_ip", Global.System.Data.OleDb.OleDbType.VarWChar, 0, Global.System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ip", Global.System.Data.DataRowVersion.Original, False, Nothing))
            Me._adapter.InsertCommand = New Global.System.Data.OleDb.OleDbCommand()
            Me._adapter.InsertCommand.Connection = Me.Connection
            Me._adapter.InsertCommand.CommandText = "INSERT INTO `Blacklist` (`ip`) VALUES (?)"
            Me._adapter.InsertCommand.CommandType = Global.System.Data.CommandType.Text
            Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("ip", Global.System.Data.OleDb.OleDbType.VarWChar, 0, Global.System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ip", Global.System.Data.DataRowVersion.Current, False, Nothing))
            Me._adapter.UpdateCommand = New Global.System.Data.OleDb.OleDbCommand()
            Me._adapter.UpdateCommand.Connection = Me.Connection
            Me._adapter.UpdateCommand.CommandText = "UPDATE `Blacklist` SET `ip` = ? WHERE ((`ID` = ?) AND ((? = 1 AND `ip` IS NULL) O" &
                "R (`ip` = ?)))"
            Me._adapter.UpdateCommand.CommandType = Global.System.Data.CommandType.Text
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("ip", Global.System.Data.OleDb.OleDbType.VarWChar, 0, Global.System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ip", Global.System.Data.DataRowVersion.Current, False, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_ID", Global.System.Data.OleDb.OleDbType.[Integer], 0, Global.System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ID", Global.System.Data.DataRowVersion.Original, False, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("IsNull_ip", Global.System.Data.OleDb.OleDbType.[Integer], 0, Global.System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ip", Global.System.Data.DataRowVersion.Original, True, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_ip", Global.System.Data.OleDb.OleDbType.VarWChar, 0, Global.System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ip", Global.System.Data.DataRowVersion.Original, False, Nothing))
        End Sub

        ''' <summary>
        ''' Initializes the connection.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Private Sub InitConnection()
            Me._connection = New Global.System.Data.OleDb.OleDbConnection()
            Me._connection.ConnectionString = Global.LumiereServer.My.MySettings.Default.ServerClientManagement2003ConnectionString
        End Sub

        ''' <summary>
        ''' Initializes the command collection.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Private Sub InitCommandCollection()
            Me._commandCollection = New Global.System.Data.OleDb.OleDbCommand(0) {}
            Me._commandCollection(0) = New Global.System.Data.OleDb.OleDbCommand()
            Me._commandCollection(0).Connection = Me.Connection
            Me._commandCollection(0).CommandText = "SELECT ID, ip FROM Blacklist"
            Me._commandCollection(0).CommandType = Global.System.Data.CommandType.Text
        End Sub

        ''' <summary>
        ''' Fills the specified data table.
        ''' </summary>
        ''' <param name="dataTable">The data table.</param>
        ''' <returns>System.Int32.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"),
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Fill, True)>
        Public Overridable Overloads Function Fill(ByVal dataTable As ServerClientManagement2003DataSet.BlacklistDataTable) As Integer
            Me.Adapter.SelectCommand = Me.CommandCollection(0)
            If (Me.ClearBeforeFill = True) Then
                dataTable.Clear()
            End If
            Dim returnValue As Integer = Me.Adapter.Fill(dataTable)
            Return returnValue
        End Function

        ''' <summary>
        ''' Gets the data.
        ''' </summary>
        ''' <returns>ServerClientManagement2003DataSet.BlacklistDataTable.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"),
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], True)>
        Public Overridable Overloads Function GetData() As ServerClientManagement2003DataSet.BlacklistDataTable
            Me.Adapter.SelectCommand = Me.CommandCollection(0)
            Dim dataTable As ServerClientManagement2003DataSet.BlacklistDataTable = New ServerClientManagement2003DataSet.BlacklistDataTable()
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function

        ''' <summary>
        ''' Updates the specified data table.
        ''' </summary>
        ''' <param name="dataTable">The data table.</param>
        ''' <returns>System.Int32.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")>
        Public Overridable Overloads Function Update(ByVal dataTable As ServerClientManagement2003DataSet.BlacklistDataTable) As Integer
            Return Me.Adapter.Update(dataTable)
        End Function

        ''' <summary>
        ''' Updates the specified data set.
        ''' </summary>
        ''' <param name="dataSet">The data set.</param>
        ''' <returns>System.Int32.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")>
        Public Overridable Overloads Function Update(ByVal dataSet As ServerClientManagement2003DataSet) As Integer
            Return Me.Adapter.Update(dataSet, "Blacklist")
        End Function

        ''' <summary>
        ''' Updates the specified data row.
        ''' </summary>
        ''' <param name="dataRow">The data row.</param>
        ''' <returns>System.Int32.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")>
        Public Overridable Overloads Function Update(ByVal dataRow As Global.System.Data.DataRow) As Integer
            Return Me.Adapter.Update(New Global.System.Data.DataRow() {dataRow})
        End Function

        ''' <summary>
        ''' Updates the specified data rows.
        ''' </summary>
        ''' <param name="dataRows">The data rows.</param>
        ''' <returns>System.Int32.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")>
        Public Overridable Overloads Function Update(ByVal dataRows() As Global.System.Data.DataRow) As Integer
            Return Me.Adapter.Update(dataRows)
        End Function

        ''' <summary>
        ''' Deletes the specified original identifier.
        ''' </summary>
        ''' <param name="Original_ID">The original identifier.</param>
        ''' <param name="Original_ip">The original ip.</param>
        ''' <returns>System.Int32.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"),
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Delete, True)>
        Public Overridable Overloads Function Delete(ByVal Original_ID As Integer, ByVal Original_ip As String) As Integer
            Me.Adapter.DeleteCommand.Parameters(0).Value = CType(Original_ID, Integer)
            If (Original_ip Is Nothing) Then
                Me.Adapter.DeleteCommand.Parameters(1).Value = CType(1, Object)
                Me.Adapter.DeleteCommand.Parameters(2).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.DeleteCommand.Parameters(1).Value = CType(0, Object)
                Me.Adapter.DeleteCommand.Parameters(2).Value = CType(Original_ip, String)
            End If
            Dim previousConnectionState As Global.System.Data.ConnectionState = Me.Adapter.DeleteCommand.Connection.State
            If ((Me.Adapter.DeleteCommand.Connection.State And Global.System.Data.ConnectionState.Open) _
                        <> Global.System.Data.ConnectionState.Open) Then
                Me.Adapter.DeleteCommand.Connection.Open()
            End If
            Try
                Dim returnValue As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery
                Return returnValue
            Finally
                If (previousConnectionState = Global.System.Data.ConnectionState.Closed) Then
                    Me.Adapter.DeleteCommand.Connection.Close()
                End If
            End Try
        End Function

        ''' <summary>
        ''' Inserts the specified ip.
        ''' </summary>
        ''' <param name="ip">The ip.</param>
        ''' <returns>System.Int32.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"),
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Insert, True)>
        Public Overridable Overloads Function Insert(ByVal ip As String) As Integer
            If (ip Is Nothing) Then
                Me.Adapter.InsertCommand.Parameters(0).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.InsertCommand.Parameters(0).Value = CType(ip, String)
            End If
            Dim previousConnectionState As Global.System.Data.ConnectionState = Me.Adapter.InsertCommand.Connection.State
            If ((Me.Adapter.InsertCommand.Connection.State And Global.System.Data.ConnectionState.Open) _
                        <> Global.System.Data.ConnectionState.Open) Then
                Me.Adapter.InsertCommand.Connection.Open()
            End If
            Try
                Dim returnValue As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery
                Return returnValue
            Finally
                If (previousConnectionState = Global.System.Data.ConnectionState.Closed) Then
                    Me.Adapter.InsertCommand.Connection.Close()
                End If
            End Try
        End Function

        ''' <summary>
        ''' Updates the specified ip.
        ''' </summary>
        ''' <param name="ip">The ip.</param>
        ''' <param name="Original_ID">The original identifier.</param>
        ''' <param name="Original_ip">The original ip.</param>
        ''' <returns>System.Int32.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"),
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Update, True)>
        Public Overridable Overloads Function Update(ByVal ip As String, ByVal Original_ID As Integer, ByVal Original_ip As String) As Integer
            If (ip Is Nothing) Then
                Me.Adapter.UpdateCommand.Parameters(0).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.UpdateCommand.Parameters(0).Value = CType(ip, String)
            End If
            Me.Adapter.UpdateCommand.Parameters(1).Value = CType(Original_ID, Integer)
            If (Original_ip Is Nothing) Then
                Me.Adapter.UpdateCommand.Parameters(2).Value = CType(1, Object)
                Me.Adapter.UpdateCommand.Parameters(3).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.UpdateCommand.Parameters(2).Value = CType(0, Object)
                Me.Adapter.UpdateCommand.Parameters(3).Value = CType(Original_ip, String)
            End If
            Dim previousConnectionState As Global.System.Data.ConnectionState = Me.Adapter.UpdateCommand.Connection.State
            If ((Me.Adapter.UpdateCommand.Connection.State And Global.System.Data.ConnectionState.Open) _
                        <> Global.System.Data.ConnectionState.Open) Then
                Me.Adapter.UpdateCommand.Connection.Open()
            End If
            Try
                Dim returnValue As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery
                Return returnValue
            Finally
                If (previousConnectionState = Global.System.Data.ConnectionState.Closed) Then
                    Me.Adapter.UpdateCommand.Connection.Close()
                End If
            End Try
        End Function
    End Class

    ''' <summary>
    ''' Represents the connection and commands used to retrieve and save data.
    ''' </summary>
    <Global.System.ComponentModel.DesignerCategoryAttribute("code"),
     Global.System.ComponentModel.ToolboxItem(True),
     Global.System.ComponentModel.DataObjectAttribute(True),
     Global.System.ComponentModel.DesignerAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner" &
        ", Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"),
     Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")>
    Partial Public Class RegisteredClientsTableAdapter
        Inherits Global.System.ComponentModel.Component

        ''' <summary>
        ''' The adapter
        ''' </summary>
        Private WithEvents _adapter As Global.System.Data.OleDb.OleDbDataAdapter

        ''' <summary>
        ''' The connection
        ''' </summary>
        Private _connection As Global.System.Data.OleDb.OleDbConnection

        ''' <summary>
        ''' The transaction
        ''' </summary>
        Private _transaction As Global.System.Data.OleDb.OleDbTransaction

        ''' <summary>
        ''' The command collection
        ''' </summary>
        Private _commandCollection() As Global.System.Data.OleDb.OleDbCommand

        ''' <summary>
        ''' The clear before fill
        ''' </summary>
        Private _clearBeforeFill As Boolean

        ''' <summary>
        ''' Initializes a new instance of the <see cref="RegisteredClientsTableAdapter"/> class.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Sub New()
            MyBase.New
            Me.ClearBeforeFill = True
        End Sub

        ''' <summary>
        ''' Gets the adapter.
        ''' </summary>
        ''' <value>The adapter.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Protected Friend ReadOnly Property Adapter() As Global.System.Data.OleDb.OleDbDataAdapter
            Get
                If (Me._adapter Is Nothing) Then
                    Me.InitAdapter()
                End If
                Return Me._adapter
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the connection.
        ''' </summary>
        ''' <value>The connection.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Friend Property Connection() As Global.System.Data.OleDb.OleDbConnection
            Get
                If (Me._connection Is Nothing) Then
                    Me.InitConnection()
                End If
                Return Me._connection
            End Get
            Set
                Me._connection = Value
                If (Not (Me.Adapter.InsertCommand) Is Nothing) Then
                    Me.Adapter.InsertCommand.Connection = Value
                End If
                If (Not (Me.Adapter.DeleteCommand) Is Nothing) Then
                    Me.Adapter.DeleteCommand.Connection = Value
                End If
                If (Not (Me.Adapter.UpdateCommand) Is Nothing) Then
                    Me.Adapter.UpdateCommand.Connection = Value
                End If
                Dim i As Integer = 0
                Do While (i < Me.CommandCollection.Length)
                    If (Not (Me.CommandCollection(i)) Is Nothing) Then
                        CType(Me.CommandCollection(i), Global.System.Data.OleDb.OleDbCommand).Connection = Value
                    End If
                    i = (i + 1)
                Loop
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the transaction.
        ''' </summary>
        ''' <value>The transaction.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Friend Property Transaction() As Global.System.Data.OleDb.OleDbTransaction
            Get
                Return Me._transaction
            End Get
            Set
                Me._transaction = Value
                Dim i As Integer = 0
                Do While (i < Me.CommandCollection.Length)
                    Me.CommandCollection(i).Transaction = Me._transaction
                    i = (i + 1)
                Loop
                If ((Not (Me.Adapter) Is Nothing) _
                            AndAlso (Not (Me.Adapter.DeleteCommand) Is Nothing)) Then
                    Me.Adapter.DeleteCommand.Transaction = Me._transaction
                End If
                If ((Not (Me.Adapter) Is Nothing) _
                            AndAlso (Not (Me.Adapter.InsertCommand) Is Nothing)) Then
                    Me.Adapter.InsertCommand.Transaction = Me._transaction
                End If
                If ((Not (Me.Adapter) Is Nothing) _
                            AndAlso (Not (Me.Adapter.UpdateCommand) Is Nothing)) Then
                    Me.Adapter.UpdateCommand.Transaction = Me._transaction
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the command collection.
        ''' </summary>
        ''' <value>The command collection.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Protected ReadOnly Property CommandCollection() As Global.System.Data.OleDb.OleDbCommand()
            Get
                If (Me._commandCollection Is Nothing) Then
                    Me.InitCommandCollection()
                End If
                Return Me._commandCollection
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a value indicating whether [clear before fill].
        ''' </summary>
        ''' <value><c>true</c> if [clear before fill]; otherwise, <c>false</c>.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Property ClearBeforeFill() As Boolean
            Get
                Return Me._clearBeforeFill
            End Get
            Set
                Me._clearBeforeFill = Value
            End Set
        End Property

        ''' <summary>
        ''' Initializes the adapter.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Private Sub InitAdapter()
            Me._adapter = New Global.System.Data.OleDb.OleDbDataAdapter()
            Dim tableMapping As Global.System.Data.Common.DataTableMapping = New Global.System.Data.Common.DataTableMapping()
            tableMapping.SourceTable = "Table"
            tableMapping.DataSetTable = "RegisteredClients"
            tableMapping.ColumnMappings.Add("ID", "ID")
            tableMapping.ColumnMappings.Add("ip", "ip")
            tableMapping.ColumnMappings.Add("username", "username")
            Me._adapter.TableMappings.Add(tableMapping)
            Me._adapter.DeleteCommand = New Global.System.Data.OleDb.OleDbCommand()
            Me._adapter.DeleteCommand.Connection = Me.Connection
            Me._adapter.DeleteCommand.CommandText = "DELETE FROM `RegisteredClients` WHERE ((`ID` = ?) AND ((? = 1 AND `ip` IS NULL) O" &
                "R (`ip` = ?)) AND ((? = 1 AND `username` IS NULL) OR (`username` = ?)))"
            Me._adapter.DeleteCommand.CommandType = Global.System.Data.CommandType.Text
            Me._adapter.DeleteCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_ID", Global.System.Data.OleDb.OleDbType.[Integer], 0, Global.System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ID", Global.System.Data.DataRowVersion.Original, False, Nothing))
            Me._adapter.DeleteCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("IsNull_ip", Global.System.Data.OleDb.OleDbType.[Integer], 0, Global.System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ip", Global.System.Data.DataRowVersion.Original, True, Nothing))
            Me._adapter.DeleteCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_ip", Global.System.Data.OleDb.OleDbType.VarWChar, 0, Global.System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ip", Global.System.Data.DataRowVersion.Original, False, Nothing))
            Me._adapter.DeleteCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("IsNull_username", Global.System.Data.OleDb.OleDbType.[Integer], 0, Global.System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "username", Global.System.Data.DataRowVersion.Original, True, Nothing))
            Me._adapter.DeleteCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_username", Global.System.Data.OleDb.OleDbType.VarWChar, 0, Global.System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "username", Global.System.Data.DataRowVersion.Original, False, Nothing))
            Me._adapter.InsertCommand = New Global.System.Data.OleDb.OleDbCommand()
            Me._adapter.InsertCommand.Connection = Me.Connection
            Me._adapter.InsertCommand.CommandText = "INSERT INTO `RegisteredClients` (`ip`, `username`) VALUES (?, ?)"
            Me._adapter.InsertCommand.CommandType = Global.System.Data.CommandType.Text
            Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("ip", Global.System.Data.OleDb.OleDbType.VarWChar, 0, Global.System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ip", Global.System.Data.DataRowVersion.Current, False, Nothing))
            Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("username", Global.System.Data.OleDb.OleDbType.VarWChar, 0, Global.System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "username", Global.System.Data.DataRowVersion.Current, False, Nothing))
            Me._adapter.UpdateCommand = New Global.System.Data.OleDb.OleDbCommand()
            Me._adapter.UpdateCommand.Connection = Me.Connection
            Me._adapter.UpdateCommand.CommandText = "UPDATE `RegisteredClients` SET `ip` = ?, `username` = ? WHERE ((`ID` = ?) AND ((?" &
                " = 1 AND `ip` IS NULL) OR (`ip` = ?)) AND ((? = 1 AND `username` IS NULL) OR (`u" &
                "sername` = ?)))"
            Me._adapter.UpdateCommand.CommandType = Global.System.Data.CommandType.Text
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("ip", Global.System.Data.OleDb.OleDbType.VarWChar, 0, Global.System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ip", Global.System.Data.DataRowVersion.Current, False, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("username", Global.System.Data.OleDb.OleDbType.VarWChar, 0, Global.System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "username", Global.System.Data.DataRowVersion.Current, False, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_ID", Global.System.Data.OleDb.OleDbType.[Integer], 0, Global.System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ID", Global.System.Data.DataRowVersion.Original, False, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("IsNull_ip", Global.System.Data.OleDb.OleDbType.[Integer], 0, Global.System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ip", Global.System.Data.DataRowVersion.Original, True, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_ip", Global.System.Data.OleDb.OleDbType.VarWChar, 0, Global.System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ip", Global.System.Data.DataRowVersion.Original, False, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("IsNull_username", Global.System.Data.OleDb.OleDbType.[Integer], 0, Global.System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "username", Global.System.Data.DataRowVersion.Original, True, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_username", Global.System.Data.OleDb.OleDbType.VarWChar, 0, Global.System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "username", Global.System.Data.DataRowVersion.Original, False, Nothing))
        End Sub

        ''' <summary>
        ''' Initializes the connection.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Private Sub InitConnection()
            Me._connection = New Global.System.Data.OleDb.OleDbConnection()
            Me._connection.ConnectionString = Global.LumiereServer.My.MySettings.Default.ServerClientManagement2003ConnectionString
        End Sub

        ''' <summary>
        ''' Initializes the command collection.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Private Sub InitCommandCollection()
            Me._commandCollection = New Global.System.Data.OleDb.OleDbCommand(0) {}
            Me._commandCollection(0) = New Global.System.Data.OleDb.OleDbCommand()
            Me._commandCollection(0).Connection = Me.Connection
            Me._commandCollection(0).CommandText = "SELECT ID, ip, username FROM RegisteredClients"
            Me._commandCollection(0).CommandType = Global.System.Data.CommandType.Text
        End Sub

        ''' <summary>
        ''' Fills the specified data table.
        ''' </summary>
        ''' <param name="dataTable">The data table.</param>
        ''' <returns>System.Int32.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"),
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Fill, True)>
        Public Overridable Overloads Function Fill(ByVal dataTable As ServerClientManagement2003DataSet.RegisteredClientsDataTable) As Integer
            Me.Adapter.SelectCommand = Me.CommandCollection(0)
            If (Me.ClearBeforeFill = True) Then
                dataTable.Clear()
            End If
            Dim returnValue As Integer = Me.Adapter.Fill(dataTable)
            Return returnValue
        End Function

        ''' <summary>
        ''' Gets the data.
        ''' </summary>
        ''' <returns>ServerClientManagement2003DataSet.RegisteredClientsDataTable.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"),
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], True)>
        Public Overridable Overloads Function GetData() As ServerClientManagement2003DataSet.RegisteredClientsDataTable
            Me.Adapter.SelectCommand = Me.CommandCollection(0)
            Dim dataTable As ServerClientManagement2003DataSet.RegisteredClientsDataTable = New ServerClientManagement2003DataSet.RegisteredClientsDataTable()
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function

        ''' <summary>
        ''' Updates the specified data table.
        ''' </summary>
        ''' <param name="dataTable">The data table.</param>
        ''' <returns>System.Int32.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")>
        Public Overridable Overloads Function Update(ByVal dataTable As ServerClientManagement2003DataSet.RegisteredClientsDataTable) As Integer
            Return Me.Adapter.Update(dataTable)
        End Function

        ''' <summary>
        ''' Updates the specified data set.
        ''' </summary>
        ''' <param name="dataSet">The data set.</param>
        ''' <returns>System.Int32.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")>
        Public Overridable Overloads Function Update(ByVal dataSet As ServerClientManagement2003DataSet) As Integer
            Return Me.Adapter.Update(dataSet, "RegisteredClients")
        End Function

        ''' <summary>
        ''' Updates the specified data row.
        ''' </summary>
        ''' <param name="dataRow">The data row.</param>
        ''' <returns>System.Int32.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")>
        Public Overridable Overloads Function Update(ByVal dataRow As Global.System.Data.DataRow) As Integer
            Return Me.Adapter.Update(New Global.System.Data.DataRow() {dataRow})
        End Function

        ''' <summary>
        ''' Updates the specified data rows.
        ''' </summary>
        ''' <param name="dataRows">The data rows.</param>
        ''' <returns>System.Int32.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")>
        Public Overridable Overloads Function Update(ByVal dataRows() As Global.System.Data.DataRow) As Integer
            Return Me.Adapter.Update(dataRows)
        End Function

        ''' <summary>
        ''' Deletes the specified original identifier.
        ''' </summary>
        ''' <param name="Original_ID">The original identifier.</param>
        ''' <param name="Original_ip">The original ip.</param>
        ''' <param name="Original_username">The original username.</param>
        ''' <returns>System.Int32.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"),
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Delete, True)>
        Public Overridable Overloads Function Delete(ByVal Original_ID As Integer, ByVal Original_ip As String, ByVal Original_username As String) As Integer
            Me.Adapter.DeleteCommand.Parameters(0).Value = CType(Original_ID, Integer)
            If (Original_ip Is Nothing) Then
                Me.Adapter.DeleteCommand.Parameters(1).Value = CType(1, Object)
                Me.Adapter.DeleteCommand.Parameters(2).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.DeleteCommand.Parameters(1).Value = CType(0, Object)
                Me.Adapter.DeleteCommand.Parameters(2).Value = CType(Original_ip, String)
            End If
            If (Original_username Is Nothing) Then
                Me.Adapter.DeleteCommand.Parameters(3).Value = CType(1, Object)
                Me.Adapter.DeleteCommand.Parameters(4).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.DeleteCommand.Parameters(3).Value = CType(0, Object)
                Me.Adapter.DeleteCommand.Parameters(4).Value = CType(Original_username, String)
            End If
            Dim previousConnectionState As Global.System.Data.ConnectionState = Me.Adapter.DeleteCommand.Connection.State
            If ((Me.Adapter.DeleteCommand.Connection.State And Global.System.Data.ConnectionState.Open) _
                        <> Global.System.Data.ConnectionState.Open) Then
                Me.Adapter.DeleteCommand.Connection.Open()
            End If
            Try
                Dim returnValue As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery
                Return returnValue
            Finally
                If (previousConnectionState = Global.System.Data.ConnectionState.Closed) Then
                    Me.Adapter.DeleteCommand.Connection.Close()
                End If
            End Try
        End Function

        ''' <summary>
        ''' Inserts the specified ip.
        ''' </summary>
        ''' <param name="ip">The ip.</param>
        ''' <param name="username">The username.</param>
        ''' <returns>System.Int32.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"),
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Insert, True)>
        Public Overridable Overloads Function Insert(ByVal ip As String, ByVal username As String) As Integer
            If (ip Is Nothing) Then
                Me.Adapter.InsertCommand.Parameters(0).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.InsertCommand.Parameters(0).Value = CType(ip, String)
            End If
            If (username Is Nothing) Then
                Me.Adapter.InsertCommand.Parameters(1).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.InsertCommand.Parameters(1).Value = CType(username, String)
            End If
            Dim previousConnectionState As Global.System.Data.ConnectionState = Me.Adapter.InsertCommand.Connection.State
            If ((Me.Adapter.InsertCommand.Connection.State And Global.System.Data.ConnectionState.Open) _
                        <> Global.System.Data.ConnectionState.Open) Then
                Me.Adapter.InsertCommand.Connection.Open()
            End If
            Try
                Dim returnValue As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery
                Return returnValue
            Finally
                If (previousConnectionState = Global.System.Data.ConnectionState.Closed) Then
                    Me.Adapter.InsertCommand.Connection.Close()
                End If
            End Try
        End Function

        ''' <summary>
        ''' Updates the specified ip.
        ''' </summary>
        ''' <param name="ip">The ip.</param>
        ''' <param name="username">The username.</param>
        ''' <param name="Original_ID">The original identifier.</param>
        ''' <param name="Original_ip">The original ip.</param>
        ''' <param name="Original_username">The original username.</param>
        ''' <returns>System.Int32.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"),
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Update, True)>
        Public Overridable Overloads Function Update(ByVal ip As String, ByVal username As String, ByVal Original_ID As Integer, ByVal Original_ip As String, ByVal Original_username As String) As Integer
            If (ip Is Nothing) Then
                Me.Adapter.UpdateCommand.Parameters(0).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.UpdateCommand.Parameters(0).Value = CType(ip, String)
            End If
            If (username Is Nothing) Then
                Me.Adapter.UpdateCommand.Parameters(1).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.UpdateCommand.Parameters(1).Value = CType(username, String)
            End If
            Me.Adapter.UpdateCommand.Parameters(2).Value = CType(Original_ID, Integer)
            If (Original_ip Is Nothing) Then
                Me.Adapter.UpdateCommand.Parameters(3).Value = CType(1, Object)
                Me.Adapter.UpdateCommand.Parameters(4).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.UpdateCommand.Parameters(3).Value = CType(0, Object)
                Me.Adapter.UpdateCommand.Parameters(4).Value = CType(Original_ip, String)
            End If
            If (Original_username Is Nothing) Then
                Me.Adapter.UpdateCommand.Parameters(5).Value = CType(1, Object)
                Me.Adapter.UpdateCommand.Parameters(6).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.UpdateCommand.Parameters(5).Value = CType(0, Object)
                Me.Adapter.UpdateCommand.Parameters(6).Value = CType(Original_username, String)
            End If
            Dim previousConnectionState As Global.System.Data.ConnectionState = Me.Adapter.UpdateCommand.Connection.State
            If ((Me.Adapter.UpdateCommand.Connection.State And Global.System.Data.ConnectionState.Open) _
                        <> Global.System.Data.ConnectionState.Open) Then
                Me.Adapter.UpdateCommand.Connection.Open()
            End If
            Try
                Dim returnValue As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery
                Return returnValue
            Finally
                If (previousConnectionState = Global.System.Data.ConnectionState.Closed) Then
                    Me.Adapter.UpdateCommand.Connection.Close()
                End If
            End Try
        End Function
    End Class

    ''' <summary>
    ''' TableAdapterManager is used to coordinate TableAdapters in the dataset to enable Hierarchical Update scenarios
    ''' </summary>
    <Global.System.ComponentModel.DesignerCategoryAttribute("code"),
     Global.System.ComponentModel.ToolboxItem(True),
     Global.System.ComponentModel.DesignerAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerDesigner, Microsoft.VSD" &
        "esigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"),
     Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapterManager")>
    Partial Public Class TableAdapterManager
        Inherits Global.System.ComponentModel.Component

        ''' <summary>
        ''' The update order
        ''' </summary>
        Private _updateOrder As UpdateOrderOption

        ''' <summary>
        ''' The blacklist table adapter
        ''' </summary>
        Private _blacklistTableAdapter As BlacklistTableAdapter

        ''' <summary>
        ''' The registered clients table adapter
        ''' </summary>
        Private _registeredClientsTableAdapter As RegisteredClientsTableAdapter

        ''' <summary>
        ''' The backup data set before update
        ''' </summary>
        Private _backupDataSetBeforeUpdate As Boolean

        ''' <summary>
        ''' The connection
        ''' </summary>
        Private _connection As Global.System.Data.IDbConnection

        ''' <summary>
        ''' Gets or sets the update order.
        ''' </summary>
        ''' <value>The update order.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Property UpdateOrder() As UpdateOrderOption
            Get
                Return Me._updateOrder
            End Get
            Set
                Me._updateOrder = Value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the blacklist table adapter.
        ''' </summary>
        ''' <value>The blacklist table adapter.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.EditorAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microso" &
            "ft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3" &
            "a", "System.Drawing.Design.UITypeEditor")>
        Public Property BlacklistTableAdapter() As BlacklistTableAdapter
            Get
                Return Me._blacklistTableAdapter
            End Get
            Set
                Me._blacklistTableAdapter = Value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the registered clients table adapter.
        ''' </summary>
        ''' <value>The registered clients table adapter.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.EditorAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microso" &
            "ft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3" &
            "a", "System.Drawing.Design.UITypeEditor")>
        Public Property RegisteredClientsTableAdapter() As RegisteredClientsTableAdapter
            Get
                Return Me._registeredClientsTableAdapter
            End Get
            Set
                Me._registeredClientsTableAdapter = Value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a value indicating whether [backup data set before update].
        ''' </summary>
        ''' <value><c>true</c> if [backup data set before update]; otherwise, <c>false</c>.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Property BackupDataSetBeforeUpdate() As Boolean
            Get
                Return Me._backupDataSetBeforeUpdate
            End Get
            Set
                Me._backupDataSetBeforeUpdate = Value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the connection.
        ''' </summary>
        ''' <value>The connection.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.Browsable(False)>
        Public Property Connection() As Global.System.Data.IDbConnection
            Get
                If (Not (Me._connection) Is Nothing) Then
                    Return Me._connection
                End If
                If ((Not (Me._blacklistTableAdapter) Is Nothing) _
                            AndAlso (Not (Me._blacklistTableAdapter.Connection) Is Nothing)) Then
                    Return Me._blacklistTableAdapter.Connection
                End If
                If ((Not (Me._registeredClientsTableAdapter) Is Nothing) _
                            AndAlso (Not (Me._registeredClientsTableAdapter.Connection) Is Nothing)) Then
                    Return Me._registeredClientsTableAdapter.Connection
                End If
                Return Nothing
            End Get
            Set
                Me._connection = Value
            End Set
        End Property

        ''' <summary>
        ''' Gets the table adapter instance count.
        ''' </summary>
        ''' <value>The table adapter instance count.</value>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0"),
         Global.System.ComponentModel.Browsable(False)>
        Public ReadOnly Property TableAdapterInstanceCount() As Integer
            Get
                Dim count As Integer = 0
                If (Not (Me._blacklistTableAdapter) Is Nothing) Then
                    count = (count + 1)
                End If
                If (Not (Me._registeredClientsTableAdapter) Is Nothing) Then
                    count = (count + 1)
                End If
                Return count
            End Get
        End Property

        ''' <summary>
        ''' Update rows in top-down order.
        ''' </summary>
        ''' <param name="dataSet">The data set.</param>
        ''' <param name="allChangedRows">All changed rows.</param>
        ''' <param name="allAddedRows">All added rows.</param>
        ''' <returns>System.Int32.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Private Function UpdateUpdatedRows(ByVal dataSet As ServerClientManagement2003DataSet, ByVal allChangedRows As Global.System.Collections.Generic.List(Of Global.System.Data.DataRow), ByVal allAddedRows As Global.System.Collections.Generic.List(Of Global.System.Data.DataRow)) As Integer
            Dim result As Integer = 0
            If (Not (Me._blacklistTableAdapter) Is Nothing) Then
                Dim updatedRows() As Global.System.Data.DataRow = dataSet.Blacklist.Select(Nothing, Nothing, Global.System.Data.DataViewRowState.ModifiedCurrent)
                updatedRows = Me.GetRealUpdatedRows(updatedRows, allAddedRows)
                If ((Not (updatedRows) Is Nothing) _
                            AndAlso (0 < updatedRows.Length)) Then
                    result = (result + Me._blacklistTableAdapter.Update(updatedRows))
                    allChangedRows.AddRange(updatedRows)
                End If
            End If
            If (Not (Me._registeredClientsTableAdapter) Is Nothing) Then
                Dim updatedRows() As Global.System.Data.DataRow = dataSet.RegisteredClients.Select(Nothing, Nothing, Global.System.Data.DataViewRowState.ModifiedCurrent)
                updatedRows = Me.GetRealUpdatedRows(updatedRows, allAddedRows)
                If ((Not (updatedRows) Is Nothing) _
                            AndAlso (0 < updatedRows.Length)) Then
                    result = (result + Me._registeredClientsTableAdapter.Update(updatedRows))
                    allChangedRows.AddRange(updatedRows)
                End If
            End If
            Return result
        End Function

        ''' <summary>
        ''' Insert rows in top-down order.
        ''' </summary>
        ''' <param name="dataSet">The data set.</param>
        ''' <param name="allAddedRows">All added rows.</param>
        ''' <returns>System.Int32.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Private Function UpdateInsertedRows(ByVal dataSet As ServerClientManagement2003DataSet, ByVal allAddedRows As Global.System.Collections.Generic.List(Of Global.System.Data.DataRow)) As Integer
            Dim result As Integer = 0
            If (Not (Me._blacklistTableAdapter) Is Nothing) Then
                Dim addedRows() As Global.System.Data.DataRow = dataSet.Blacklist.Select(Nothing, Nothing, Global.System.Data.DataViewRowState.Added)
                If ((Not (addedRows) Is Nothing) _
                            AndAlso (0 < addedRows.Length)) Then
                    result = (result + Me._blacklistTableAdapter.Update(addedRows))
                    allAddedRows.AddRange(addedRows)
                End If
            End If
            If (Not (Me._registeredClientsTableAdapter) Is Nothing) Then
                Dim addedRows() As Global.System.Data.DataRow = dataSet.RegisteredClients.Select(Nothing, Nothing, Global.System.Data.DataViewRowState.Added)
                If ((Not (addedRows) Is Nothing) _
                            AndAlso (0 < addedRows.Length)) Then
                    result = (result + Me._registeredClientsTableAdapter.Update(addedRows))
                    allAddedRows.AddRange(addedRows)
                End If
            End If
            Return result
        End Function

        ''' <summary>
        ''' Delete rows in bottom-up order.
        ''' </summary>
        ''' <param name="dataSet">The data set.</param>
        ''' <param name="allChangedRows">All changed rows.</param>
        ''' <returns>System.Int32.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Private Function UpdateDeletedRows(ByVal dataSet As ServerClientManagement2003DataSet, ByVal allChangedRows As Global.System.Collections.Generic.List(Of Global.System.Data.DataRow)) As Integer
            Dim result As Integer = 0
            If (Not (Me._registeredClientsTableAdapter) Is Nothing) Then
                Dim deletedRows() As Global.System.Data.DataRow = dataSet.RegisteredClients.Select(Nothing, Nothing, Global.System.Data.DataViewRowState.Deleted)
                If ((Not (deletedRows) Is Nothing) _
                            AndAlso (0 < deletedRows.Length)) Then
                    result = (result + Me._registeredClientsTableAdapter.Update(deletedRows))
                    allChangedRows.AddRange(deletedRows)
                End If
            End If
            If (Not (Me._blacklistTableAdapter) Is Nothing) Then
                Dim deletedRows() As Global.System.Data.DataRow = dataSet.Blacklist.Select(Nothing, Nothing, Global.System.Data.DataViewRowState.Deleted)
                If ((Not (deletedRows) Is Nothing) _
                            AndAlso (0 < deletedRows.Length)) Then
                    result = (result + Me._blacklistTableAdapter.Update(deletedRows))
                    allChangedRows.AddRange(deletedRows)
                End If
            End If
            Return result
        End Function

        ''' <summary>
        ''' Remove inserted rows that become updated rows after calling TableAdapter.Update(inserted rows) first
        ''' </summary>
        ''' <param name="updatedRows">The updated rows.</param>
        ''' <param name="allAddedRows">All added rows.</param>
        ''' <returns>System.Data.DataRow().</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Private Function GetRealUpdatedRows(ByVal updatedRows() As Global.System.Data.DataRow, ByVal allAddedRows As Global.System.Collections.Generic.List(Of Global.System.Data.DataRow)) As Global.System.Data.DataRow()
            If ((updatedRows Is Nothing) _
                        OrElse (updatedRows.Length < 1)) Then
                Return updatedRows
            End If
            If ((allAddedRows Is Nothing) _
                        OrElse (allAddedRows.Count < 1)) Then
                Return updatedRows
            End If
            Dim realUpdatedRows As Global.System.Collections.Generic.List(Of Global.System.Data.DataRow) = New Global.System.Collections.Generic.List(Of Global.System.Data.DataRow)()
            Dim i As Integer = 0
            Do While (i < updatedRows.Length)
                Dim row As Global.System.Data.DataRow = updatedRows(i)
                If (allAddedRows.Contains(row) = False) Then
                    realUpdatedRows.Add(row)
                End If
                i = (i + 1)
            Loop
            Return realUpdatedRows.ToArray
        End Function

        ''' <summary>
        ''' Update all changes to the dataset.
        ''' </summary>
        ''' <param name="dataSet">The data set.</param>
        ''' <returns>System.Int32.</returns>
        ''' <exception cref="System.ArgumentNullException">dataSet</exception>
        ''' <exception cref="System.ArgumentException">All TableAdapters managed by a TableAdapterManager must use the same connection s"& _ 
        '''                         "tring.</exception>
        ''' <exception cref="System.ArgumentException">All TableAdapters managed by a TableAdapterManager must use the same connection s"& _ 
        '''                         "tring.</exception>
        ''' <exception cref="System.ApplicationException">TableAdapterManager contains no connection information. Set each TableAdapterMana"& _ 
        '''                         "ger TableAdapter property to a valid TableAdapter instance.</exception>
        ''' <exception cref="System.ApplicationException">The transaction cannot begin. The current data connection does not support transa"& _ 
        '''                         "ctions or the current state is not allowing the transaction to begin.</exception>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Overridable Function UpdateAll(ByVal dataSet As ServerClientManagement2003DataSet) As Integer
            If (dataSet Is Nothing) Then
                Throw New Global.System.ArgumentNullException("dataSet")
            End If
            If (dataSet.HasChanges = False) Then
                Return 0
            End If
            If ((Not (Me._blacklistTableAdapter) Is Nothing) _
                        AndAlso (Me.MatchTableAdapterConnection(Me._blacklistTableAdapter.Connection) = False)) Then
                Throw New Global.System.ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection s" &
                        "tring.")
            End If
            If ((Not (Me._registeredClientsTableAdapter) Is Nothing) _
                        AndAlso (Me.MatchTableAdapterConnection(Me._registeredClientsTableAdapter.Connection) = False)) Then
                Throw New Global.System.ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection s" &
                        "tring.")
            End If
            Dim workConnection As Global.System.Data.IDbConnection = Me.Connection
            If (workConnection Is Nothing) Then
                Throw New Global.System.ApplicationException("TableAdapterManager contains no connection information. Set each TableAdapterMana" &
                        "ger TableAdapter property to a valid TableAdapter instance.")
            End If
            Dim workConnOpened As Boolean = False
            If ((workConnection.State And Global.System.Data.ConnectionState.Broken) _
                        = Global.System.Data.ConnectionState.Broken) Then
                workConnection.Close()
            End If
            If (workConnection.State = Global.System.Data.ConnectionState.Closed) Then
                workConnection.Open()
                workConnOpened = True
            End If
            Dim workTransaction As Global.System.Data.IDbTransaction = workConnection.BeginTransaction
            If (workTransaction Is Nothing) Then
                Throw New Global.System.ApplicationException("The transaction cannot begin. The current data connection does not support transa" &
                        "ctions or the current state is not allowing the transaction to begin.")
            End If
            Dim allChangedRows As Global.System.Collections.Generic.List(Of Global.System.Data.DataRow) = New Global.System.Collections.Generic.List(Of Global.System.Data.DataRow)()
            Dim allAddedRows As Global.System.Collections.Generic.List(Of Global.System.Data.DataRow) = New Global.System.Collections.Generic.List(Of Global.System.Data.DataRow)()
            Dim adaptersWithAcceptChangesDuringUpdate As Global.System.Collections.Generic.List(Of Global.System.Data.Common.DataAdapter) = New Global.System.Collections.Generic.List(Of Global.System.Data.Common.DataAdapter)()
            Dim revertConnections As Global.System.Collections.Generic.Dictionary(Of Object, Global.System.Data.IDbConnection) = New Global.System.Collections.Generic.Dictionary(Of Object, Global.System.Data.IDbConnection)()
            Dim result As Integer = 0
            Dim backupDataSet As Global.System.Data.DataSet = Nothing
            If Me.BackupDataSetBeforeUpdate Then
                backupDataSet = New Global.System.Data.DataSet()
                backupDataSet.Merge(dataSet)
            End If
            Try
                '---- Prepare for update -----------
                '
                If (Not (Me._blacklistTableAdapter) Is Nothing) Then
                    revertConnections.Add(Me._blacklistTableAdapter, Me._blacklistTableAdapter.Connection)
                    Me._blacklistTableAdapter.Connection = CType(workConnection, Global.System.Data.OleDb.OleDbConnection)
                    Me._blacklistTableAdapter.Transaction = CType(workTransaction, Global.System.Data.OleDb.OleDbTransaction)
                    If Me._blacklistTableAdapter.Adapter.AcceptChangesDuringUpdate Then
                        Me._blacklistTableAdapter.Adapter.AcceptChangesDuringUpdate = False
                        adaptersWithAcceptChangesDuringUpdate.Add(Me._blacklistTableAdapter.Adapter)
                    End If
                End If
                If (Not (Me._registeredClientsTableAdapter) Is Nothing) Then
                    revertConnections.Add(Me._registeredClientsTableAdapter, Me._registeredClientsTableAdapter.Connection)
                    Me._registeredClientsTableAdapter.Connection = CType(workConnection, Global.System.Data.OleDb.OleDbConnection)
                    Me._registeredClientsTableAdapter.Transaction = CType(workTransaction, Global.System.Data.OleDb.OleDbTransaction)
                    If Me._registeredClientsTableAdapter.Adapter.AcceptChangesDuringUpdate Then
                        Me._registeredClientsTableAdapter.Adapter.AcceptChangesDuringUpdate = False
                        adaptersWithAcceptChangesDuringUpdate.Add(Me._registeredClientsTableAdapter.Adapter)
                    End If
                End If
                '
                '---- Perform updates -----------
                '
                If (Me.UpdateOrder = UpdateOrderOption.UpdateInsertDelete) Then
                    result = (result + Me.UpdateUpdatedRows(dataSet, allChangedRows, allAddedRows))
                    result = (result + Me.UpdateInsertedRows(dataSet, allAddedRows))
                Else
                    result = (result + Me.UpdateInsertedRows(dataSet, allAddedRows))
                    result = (result + Me.UpdateUpdatedRows(dataSet, allChangedRows, allAddedRows))
                End If
                result = (result + Me.UpdateDeletedRows(dataSet, allChangedRows))
                '
                '---- Commit updates -----------
                '
                workTransaction.Commit()

                If (0 < allAddedRows.Count) Then
                    Dim rows((allAddedRows.Count) - 1) As Global.System.Data.DataRow
                    allAddedRows.CopyTo(rows)
                    Dim i As Integer = 0
                    Do While (i < rows.Length)
                        Dim row As Global.System.Data.DataRow = rows(i)
                        row.AcceptChanges()
                        i = (i + 1)
                    Loop
                End If
                If (0 < allChangedRows.Count) Then
                    Dim rows((allChangedRows.Count) - 1) As Global.System.Data.DataRow
                    allChangedRows.CopyTo(rows)
                    Dim i As Integer = 0
                    Do While (i < rows.Length)
                        Dim row As Global.System.Data.DataRow = rows(i)
                        row.AcceptChanges()
                        i = (i + 1)
                    Loop
                End If
            Catch ex As Global.System.Exception
                workTransaction.Rollback()
                '---- Restore the dataset -----------
                If Me.BackupDataSetBeforeUpdate Then
                    Global.System.Diagnostics.Debug.Assert((Not (backupDataSet) Is Nothing))
                    dataSet.Clear()
                    dataSet.Merge(backupDataSet)
                Else
                    If (0 < allAddedRows.Count) Then
                        Dim rows((allAddedRows.Count) - 1) As Global.System.Data.DataRow
                        allAddedRows.CopyTo(rows)
                        Dim i As Integer = 0
                        Do While (i < rows.Length)
                            Dim row As Global.System.Data.DataRow = rows(i)
                            row.AcceptChanges()
                            row.SetAdded()
                            i = (i + 1)
                        Loop
                    End If
                End If
                Throw ex
            Finally
                If workConnOpened Then
                    workConnection.Close()
                End If
                If (Not (Me._blacklistTableAdapter) Is Nothing) Then
                    Me._blacklistTableAdapter.Connection = CType(revertConnections(Me._blacklistTableAdapter), Global.System.Data.OleDb.OleDbConnection)
                    Me._blacklistTableAdapter.Transaction = Nothing
                End If
                If (Not (Me._registeredClientsTableAdapter) Is Nothing) Then
                    Me._registeredClientsTableAdapter.Connection = CType(revertConnections(Me._registeredClientsTableAdapter), Global.System.Data.OleDb.OleDbConnection)
                    Me._registeredClientsTableAdapter.Transaction = Nothing
                End If
                If (0 < adaptersWithAcceptChangesDuringUpdate.Count) Then
                    Dim adapters((adaptersWithAcceptChangesDuringUpdate.Count) - 1) As Global.System.Data.Common.DataAdapter
                    adaptersWithAcceptChangesDuringUpdate.CopyTo(adapters)
                    Dim i As Integer = 0
                    Do While (i < adapters.Length)
                        Dim adapter As Global.System.Data.Common.DataAdapter = adapters(i)
                        adapter.AcceptChangesDuringUpdate = True
                        i = (i + 1)
                    Loop
                End If
            End Try
            Return result
        End Function

        ''' <summary>
        ''' Sorts the self reference rows.
        ''' </summary>
        ''' <param name="rows">The rows.</param>
        ''' <param name="relation">The relation.</param>
        ''' <param name="childFirst">if set to <c>true</c> [child first].</param>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Protected Overridable Sub SortSelfReferenceRows(ByVal rows() As Global.System.Data.DataRow, ByVal relation As Global.System.Data.DataRelation, ByVal childFirst As Boolean)
            Global.System.Array.Sort(Of Global.System.Data.DataRow)(rows, New SelfReferenceComparer(relation, childFirst))
        End Sub

        ''' <summary>
        ''' Matches the table adapter connection.
        ''' </summary>
        ''' <param name="inputConnection">The input connection.</param>
        ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Protected Overridable Function MatchTableAdapterConnection(ByVal inputConnection As Global.System.Data.IDbConnection) As Boolean
            If (Not (Me._connection) Is Nothing) Then
                Return True
            End If
            If ((Me.Connection Is Nothing) _
                        OrElse (inputConnection Is Nothing)) Then
                Return True
            End If
            If String.Equals(Me.Connection.ConnectionString, inputConnection.ConnectionString, Global.System.StringComparison.Ordinal) Then
                Return True
            End If
            Return False
        End Function

        ''' <summary>
        ''' Update Order Option
        ''' </summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Public Enum UpdateOrderOption

            ''' <summary>
            ''' The insert update delete
            ''' </summary>
            InsertUpdateDelete = 0

            ''' <summary>
            ''' The update insert delete
            ''' </summary>
            UpdateInsertDelete = 1
        End Enum

        ''' <summary>
        ''' Used to sort self-referenced table's rows
        ''' </summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
        Private Class SelfReferenceComparer
            Inherits Object
            Implements Global.System.Collections.Generic.IComparer(Of Global.System.Data.DataRow)

            ''' <summary>
            ''' The relation
            ''' </summary>
            Private _relation As Global.System.Data.DataRelation

            ''' <summary>
            ''' The child first
            ''' </summary>
            Private _childFirst As Integer

            ''' <summary>
            ''' Initializes a new instance of the <see cref="SelfReferenceComparer"/> class.
            ''' </summary>
            ''' <param name="relation">The relation.</param>
            ''' <param name="childFirst">if set to <c>true</c> [child first].</param>
            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
             Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
            Friend Sub New(ByVal relation As Global.System.Data.DataRelation, ByVal childFirst As Boolean)
                MyBase.New
                Me._relation = relation
                If childFirst Then
                    Me._childFirst = -1
                Else
                    Me._childFirst = 1
                End If
            End Sub

            ''' <summary>
            ''' Gets the root.
            ''' </summary>
            ''' <param name="row">The row.</param>
            ''' <param name="distance">The distance.</param>
            ''' <returns>System.Data.DataRow.</returns>
            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
             Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
            Private Function GetRoot(ByVal row As Global.System.Data.DataRow, ByRef distance As Integer) As Global.System.Data.DataRow
                Global.System.Diagnostics.Debug.Assert((Not (row) Is Nothing))
                Dim root As Global.System.Data.DataRow = row
                distance = 0

                Dim traversedRows As Global.System.Collections.Generic.IDictionary(Of Global.System.Data.DataRow, Global.System.Data.DataRow) = New Global.System.Collections.Generic.Dictionary(Of Global.System.Data.DataRow, Global.System.Data.DataRow)()
                traversedRows(row) = row

                Dim parent As Global.System.Data.DataRow = row.GetParentRow(Me._relation, Global.System.Data.DataRowVersion.[Default])

                Do While ((Not (parent) Is Nothing) _
                            AndAlso (traversedRows.ContainsKey(parent) = False))
                    distance = (distance + 1)
                    root = parent
                    traversedRows(parent) = parent
                    parent = parent.GetParentRow(Me._relation, Global.System.Data.DataRowVersion.[Default])

                Loop

                If (distance = 0) Then
                    traversedRows.Clear()
                    traversedRows(row) = row
                    parent = row.GetParentRow(Me._relation, Global.System.Data.DataRowVersion.Original)

                    Do While ((Not (parent) Is Nothing) _
                                AndAlso (traversedRows.ContainsKey(parent) = False))
                        distance = (distance + 1)
                        root = parent
                        traversedRows(parent) = parent
                        parent = parent.GetParentRow(Me._relation, Global.System.Data.DataRowVersion.Original)

                    Loop
                End If

                Return root
            End Function

            ''' <summary>
            ''' Compares the specified row1.
            ''' </summary>
            ''' <param name="row1">The row1.</param>
            ''' <param name="row2">The row2.</param>
            ''' <returns>System.Int32.</returns>
            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
             Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")>
            Public Function Compare(ByVal row1 As Global.System.Data.DataRow, ByVal row2 As Global.System.Data.DataRow) As Integer Implements Global.System.Collections.Generic.IComparer(Of Global.System.Data.DataRow).Compare
                If Object.ReferenceEquals(row1, row2) Then
                    Return 0
                End If
                If (row1 Is Nothing) Then
                    Return -1
                End If
                If (row2 Is Nothing) Then
                    Return 1
                End If

                Dim distance1 As Integer = 0
                Dim root1 As Global.System.Data.DataRow = Me.GetRoot(row1, distance1)

                Dim distance2 As Integer = 0
                Dim root2 As Global.System.Data.DataRow = Me.GetRoot(row2, distance2)

                If Object.ReferenceEquals(root1, root2) Then
                    Return (Me._childFirst * distance1.CompareTo(distance2))
                Else
                    Global.System.Diagnostics.Debug.Assert(((Not (root1.Table) Is Nothing) _
                                    AndAlso (Not (root2.Table) Is Nothing)))
                    If (root1.Table.Rows.IndexOf(root1) < root2.Table.Rows.IndexOf(root2)) Then
                        Return -1
                    Else
                        Return 1
                    End If
                End If
            End Function
        End Class
    End Class
End Namespace
