' ***********************************************************************
' Assembly         : LumiereServer
' Author           : rezni
' Created          : 06-12-2020
'
' Last Modified By : rezni
' Last Modified On : 06-11-2020
' ***********************************************************************
' <copyright file="WindowVideo.vb" company="LumiereSombre | HorizonDova">
'     Copyright ©  LumiereSombre Inc. 2020
' </copyright>
' <summary></summary>
' ***********************************************************************
''' <summary>
''' Class WindowVideo.
''' Implements the <see cref="System.Windows.Forms.Form" />
''' </summary>
''' <seealso cref="System.Windows.Forms.Form" />
Public Class WindowVideo
    Private sync1 As New Object(), sync2 As New Object(), sync3 As New Object(), sync4 As New Object(), sync5 As New Object()
    Private framesCountValue As UInt32 = 10, rowHeightValue As UInt32 = 100, fpsTimeDelay As Double = 0
    Private enableMouseSync As Boolean = False, screenPos As New Point
    ''' <summary>
    ''' The click event
    ''' </summary>
    Private clickEvent As Integer

    ''' <summary>
    ''' Gets the get frames count value.
    ''' </summary>
    ''' <value>The get frames count value.</value>
    Public ReadOnly Property getFramesCountValue As UInt32
        Get
            SyncLock sync1
                Return framesCountValue
            End SyncLock
        End Get
    End Property
    ''' <summary>
    ''' Gets the get row height value.
    ''' </summary>
    ''' <value>The get row height value.</value>
    Public ReadOnly Property getRowHeightValue As UInt32
        Get
            SyncLock sync2
                Return rowHeightValue
            End SyncLock
        End Get
    End Property
    ''' <summary>
    ''' Sets the set FPS.
    ''' </summary>
    ''' <value>The set FPS.</value>
    Public WriteOnly Property setFPS As Double
        Set(value As Double)
            SyncLock sync3
                fpsTimeDelay = value
            End SyncLock
        End Set
    End Property
    ''' <summary>
    ''' Gets the get live mouse.
    ''' </summary>
    ''' <value>The get live mouse.</value>
    Public ReadOnly Property getLiveMouse As Point
        Get
            SyncLock sync4
                If enableMouseSync Then
                    Dim temp As Point = screenPos
                    screenPos = New Point With {.X = -1, .Y = -1}

                    Return temp
                Else
                    Return New Point With {.X = -1, .Y = -1}
                End If
            End SyncLock
        End Get
    End Property


    ''' <summary>
    ''' Gets the get live click. 0 -nothing; 1 left click; 2 right click
    ''' </summary>
    ''' <value>The get live click.</value>
    Public ReadOnly Property getLiveClick As Integer
        Get
            SyncLock sync5
                Dim temp As Integer = clickEvent
                clickEvent = 0

                Return temp
            End SyncLock
        End Get
    End Property



    ''' <summary>
    ''' Gets the canvas instance.
    ''' </summary>
    ''' <returns>PictureBox.</returns>
    Public Function getCanvasInstance() As PictureBox
        Return frameBuffer
    End Function

    ''' <summary>
    ''' Handles the Scroll event of the rowHeightControl control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub rowHeightControl_Scroll(sender As Object, e As EventArgs) Handles rowHeightControl.Scroll
        SyncLock sync2
            rowHeightValue = rowHeightControl.Value
            Label2.Text = "Row height: " + rowHeightControl.Value.ToString
        End SyncLock
    End Sub

    ''' <summary>
    ''' Handles the Click event of the Button1 control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SyncLock sync4
            enableMouseSync = Not enableMouseSync
        End SyncLock

        If enableMouseSync Then
            Button1.BackColor = Color.Red
        Else
            Button1.BackColor = SystemColors.Control
        End If
    End Sub

    ''' <summary>
    ''' Handles the Scroll event of the framesCountControl control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub framesCountControl_Scroll(sender As Object, e As EventArgs) Handles framesCountControl.Scroll
        SyncLock sync1
            framesCountValue = framesCountControl.Value
            Label1.Text = "Frames count: " + framesCountControl.Value.ToString
        End SyncLock
    End Sub




    ''' <summary>
    ''' Handles the Load event of the WindowVideo control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub WindowVideo_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Default values
        framesCountControl.Value = framesCountValue
        rowHeightControl.Value = rowHeightValue

        Label1.Text = "Frames count: " + framesCountControl.Value.ToString
        Label2.Text = "Row height: " + rowHeightControl.Value.ToString
    End Sub

    ''' <summary>
    ''' Handles the Tick event of the ReadFPSTimer control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub ReadFPSTimer_Tick(sender As Object, e As EventArgs) Handles ReadFPSTimer.Tick
        Label3.Text = Math.Round(1000 / fpsTimeDelay).ToString
    End Sub

    ''' <summary>
    ''' Handles the MouseMove event of the frameBuffer control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
    Private Sub frameBuffer_MouseMove(sender As Object, e As MouseEventArgs) Handles frameBuffer.MouseMove
        SyncLock sync4
            screenPos.X = e.X
            screenPos.Y = e.Y
        End SyncLock

    End Sub

    ''' <summary>
    ''' Handles the MouseClick event of the frameBuffer control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
    Private Sub frameBuffer_MouseClick(sender As Object, e As MouseEventArgs) Handles frameBuffer.MouseClick
        SyncLock sync5
            If e.Button = MouseButtons.Left Then
                clickEvent = 1
            Else
                clickEvent = 2
            End If
        End SyncLock
    End Sub
End Class