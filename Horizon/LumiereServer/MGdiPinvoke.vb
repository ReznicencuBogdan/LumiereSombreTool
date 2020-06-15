' ***********************************************************************
' Assembly         : LumiereServer
' Author           : rezni
' Created          : 06-12-2020
'
' Last Modified By : rezni
' Last Modified On : 06-11-2020
' ***********************************************************************
' <copyright file="MGdiPinvoke.vb" company="LumiereSombre | HorizonDova">
'     Copyright ©  LumiereSombre Inc. 2020
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.Runtime.InteropServices

''' <summary>
''' Holds GDI Pinvoke Fast drawing methods.
''' </summary>
Public Module MGdiPinvoke

    ''' <summary>
    ''' Selects the object.
    ''' </summary>
    ''' <param name="hdc">The HDC.</param>
    ''' <param name="hObject">The h object.</param>
    ''' <returns>IntPtr.</returns>
    <DllImport("Gdi32.dll")>
    Private Function SelectObject(ByVal hdc As IntPtr, ByVal hObject As IntPtr) As IntPtr
    End Function

    ''' <summary>
    ''' Deletes the object.
    ''' </summary>
    ''' <param name="hObject">The h object.</param>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    <DllImport("gdi32.dll")>
    Private Function DeleteObject(hObject As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function
    ''' <summary>
    ''' Deletes the dc.
    ''' </summary>
    ''' <param name="hdc">The HDC.</param>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    <DllImport("gdi32.dll")>
    Private Function DeleteDC(hdc As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    ''' <summary>
    ''' Creates the compatible bitmap.
    ''' </summary>
    ''' <param name="hdc">The HDC.</param>
    ''' <param name="nWidth">Width of the n.</param>
    ''' <param name="nHeight">Height of the n.</param>
    ''' <returns>IntPtr.</returns>
    <DllImport("gdi32.dll")>
    Private Function CreateCompatibleBitmap(hdc As IntPtr, nWidth As Integer, nHeight As Integer) As IntPtr
    End Function
    ''' <summary>
    ''' Creates the compatible dc.
    ''' </summary>
    ''' <param name="hRefDC">The h reference dc.</param>
    ''' <returns>IntPtr.</returns>
    <DllImport("gdi32.dll", SetLastError:=True)>
    Private Function CreateCompatibleDC(ByVal hRefDC As IntPtr) As IntPtr
    End Function

    ''' <summary>
    ''' Sets the stretch BLT mode.
    ''' </summary>
    ''' <param name="hdc">The HDC.</param>
    ''' <param name="iStretchMode">The i stretch mode.</param>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    <DllImport("gdi32.dll")>
    Private Function SetStretchBltMode(hdc As IntPtr, iStretchMode As Integer) As Boolean
    End Function

    ''' <summary>
    ''' Stretches the di bits.
    ''' </summary>
    ''' <param name="hdc">The HDC.</param>
    ''' <param name="XDest">The x dest.</param>
    ''' <param name="YDest">The y dest.</param>
    ''' <param name="nDestWidth">Width of the n dest.</param>
    ''' <param name="nDestHeight">Height of the n dest.</param>
    ''' <param name="XSrc">The x source.</param>
    ''' <param name="YSrc">The y source.</param>
    ''' <param name="nSrcWidth">Width of the n source.</param>
    ''' <param name="nSrcHeight">Height of the n source.</param>
    ''' <param name="lpBits">The lp bits.</param>
    ''' <param name="lpBitsInfo">The lp bits information.</param>
    ''' <param name="iUsage">The i usage.</param>
    ''' <param name="dwRop">The dw rop.</param>
    ''' <returns>System.Int32.</returns>
    <DllImport("gdi32.dll")>
    Private Function StretchDIBits(ByVal hdc As IntPtr, ByVal XDest As Integer, ByVal YDest As Integer, ByVal nDestWidth As Integer, ByVal nDestHeight As Integer, ByVal XSrc As Integer, ByVal YSrc As Integer, ByVal nSrcWidth As Integer, ByVal nSrcHeight As Integer, ByVal lpBits As Byte(),
<[In]> ByRef lpBitsInfo As BITMAPINFO, ByVal iUsage As UInteger, ByVal dwRop As UInteger) As Integer
    End Function

    ''' <summary>
    ''' Struct RGBQUAD
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)>
    Structure RGBQUAD
        ''' <summary>
        ''' The RGB blue
        ''' </summary>
        Public rgbBlue As Byte
        ''' <summary>
        ''' The RGB green
        ''' </summary>
        Public rgbGreen As Byte
        ''' <summary>
        ''' The RGB red
        ''' </summary>
        Public rgbRed As Byte
        ''' <summary>
        ''' The RGB reserved
        ''' </summary>
        Public rgbReserved As Byte
    End Structure

    ''' <summary>
    ''' Class BITMAPINFOHEADER.
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)>
    Class BITMAPINFOHEADER
        ''' <summary>
        ''' The bi size
        ''' </summary>
        Public biSize As Int32
        ''' <summary>
        ''' The bi width
        ''' </summary>
        Public biWidth As Int32
        ''' <summary>
        ''' The bi height
        ''' </summary>
        Public biHeight As Int32
        ''' <summary>
        ''' The bi planes
        ''' </summary>
        Public biPlanes As Int16
        ''' <summary>
        ''' The bi bit count
        ''' </summary>
        Public biBitCount As Int16
        ''' <summary>
        ''' The bi compression
        ''' </summary>
        Public biCompression As Int32
        ''' <summary>
        ''' The bi size image
        ''' </summary>
        Public biSizeImage As Int32
        ''' <summary>
        ''' The bi x pels per meter
        ''' </summary>
        Public biXPelsPerMeter As Int32
        ''' <summary>
        ''' The bi y pels per meter
        ''' </summary>
        Public biYPelsPerMeter As Int32
        ''' <summary>
        ''' The bi color used
        ''' </summary>
        Public biClrUsed As Int32
        ''' <summary>
        ''' The bi color important
        ''' </summary>
        Public biClrImportant As Int32
    End Class

    ''' <summary>
    ''' Struct BITMAPINFO
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)>
    Structure BITMAPINFO
        ''' <summary>
        ''' The bmiheader
        ''' </summary>
        Dim bmiheader As BITMAPINFOHEADER
        ''' <summary>
        ''' The bmi colors
        ''' </summary>
        Dim bmiColors() As RGBQUAD
    End Structure
    ''' <summary>
    ''' The dib RGB colors
    ''' </summary>
    Const DIB_RGB_COLORS As Integer = 0
    ''' <summary>
    ''' The srccopy
    ''' </summary>
    Const SRCCOPY As Integer = 13369376
    ''' <summary>
    ''' The halftone
    ''' </summary>
    Dim HALFTONE As Integer = 4


    ''' <summary>
    ''' Holds a frame data
    ''' </summary>
    Public Class FrameData
        ''' <summary>
        ''' The picturebox component
        ''' </summary>
        Public pic As PictureBox
        Public internalFrameHDC As IntPtr, internalFrameBMP As IntPtr
        ''' <summary>
        ''' Graphics component
        ''' </summary>
        Public picGraphics As Graphics
        ''' <summary>
        ''' HDC
        ''' </summary>
        Public picHDC As IntPtr
        Public maxWidth As Integer, maxHeight As Integer
        ''' <summary>
        ''' The old object
        ''' </summary>
        Public oldSelectObject As IntPtr

        ''' <summary>
        ''' Destroys this instance.
        ''' </summary>
        Public Sub destroy()
            Try
                picGraphics.ReleaseHdc(picHDC)
                picGraphics.Dispose()
            Catch ex As Exception

            End Try

            Try
                SelectObject(internalFrameHDC, oldSelectObject)

                DeleteDC(internalFrameHDC)
                DeleteObject(internalFrameBMP)
            Catch ex As Exception

            End Try

        End Sub
    End Class



    ''' <summary>
    ''' Use this function to dynamically resize the array and write the output DIRECTLY on the picturebox skipping the internal buffer
    ''' If you use this function you must not use 'updatePictureHDC'
    ''' </summary>
    ''' <param name="data">The framedata.</param>
    ''' <param name="arr">The byte array.</param>
    ''' <param name="bmi">The bitmpainfo.</param>
    ''' <param name="frameShift">The frame shift.</param>
    Public Sub updateDirectFrame(data As FrameData, ByRef arr As Byte(), ByRef bmi As BITMAPINFO, frameShift As Integer)
        Dim relativeShift = frameShift / data.maxHeight * data.pic.Height
        Dim relativeHeight = bmi.bmiheader.biHeight / data.maxHeight * data.pic.Height

        Dim a As Integer = StretchDIBits(data.picHDC, 0, relativeShift, data.pic.Width, relativeHeight, 0, 0, bmi.bmiheader.biWidth, bmi.bmiheader.biHeight, arr, bmi, 0, SRCCOPY)
    End Sub


    ''' <summary>
    ''' Initializes the internal frame.
    ''' </summary>
    ''' <param name="pic">The pic.</param>
    ''' <param name="maxWidth">The maximum width.</param>
    ''' <param name="maxHeight">The maximum height.</param>
    ''' <returns>FrameData.</returns>
    Public Function initInternalFrame(pic As PictureBox, maxWidth As Integer, maxHeight As Integer) As FrameData
        Dim g As Graphics
        Dim picHDC As IntPtr

        Try
            Dim res As New FrameData


            g = pic.CreateGraphics()
            picHDC = g.GetHdc()
            res.pic = pic
            res.picHDC = picHDC
            res.internalFrameHDC = CreateCompatibleDC(picHDC)
            res.internalFrameBMP = CreateCompatibleBitmap(picHDC, maxWidth, maxHeight)
            res.oldSelectObject = SelectObject(res.internalFrameHDC, res.internalFrameBMP)
            res.picGraphics = g
            res.maxWidth = maxWidth
            res.maxHeight = maxHeight

            SetStretchBltMode(picHDC, HALFTONE)

            Return res

        Catch ex As Exception
            Return Nothing
        End Try


    End Function

End Module
