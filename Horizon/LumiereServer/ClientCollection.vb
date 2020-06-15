' ***********************************************************************
' Assembly         : LumiereServer
' Author           : rezni
' Created          : 06-12-2020
'
' Last Modified By : rezni
' Last Modified On : 06-11-2020
' ***********************************************************************
' <copyright file="ClientCollection.vb" company="LumiereSombre | HorizonDova">
'     Copyright ©  LumiereSombre Inc. 2020
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.Collections.ObjectModel

''' <summary>
''' Class ClientCollectionSource_.
''' Holds a list of connected clients. Syncs with ui device.
''' Implements the <see cref="System.Collections.ObjectModel.ObservableCollection(Of LumiereServer.ClientWrapper)" />
''' </summary>
''' <seealso cref="System.Collections.ObjectModel.ObservableCollection(Of LumiereServer.ClientWrapper)" />
Public Class ClientCollectionSource_
    Inherits ObservableCollection(Of ClientWrapper)
End Class
