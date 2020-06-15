' ***********************************************************************
' Assembly         : LumiereServer
' Author           : rezni
' Created          : 06-12-2020
'
' Last Modified By : rezni
' Last Modified On : 06-11-2020
' ***********************************************************************
' <copyright file="Tokenizer.vb" company="LumiereSombre | HorizonDova">
'     Copyright ©  LumiereSombre Inc. 2020
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.Security.Cryptography

''' <summary>
''' Class Tokenizer. Token generator.
''' </summary>
Public Class Tokenizer

    ''' <summary>
    ''' The RSA engine.
    ''' </summary>
    Dim RSA As RSACryptoServiceProvider

    ''' <summary>
    ''' The salt size
    ''' </summary>
    Private salt_size As Integer = 10
    ''' <summary>
    ''' A random generator
    ''' </summary>
    Private random_generator As Random
    ''' <summary>
    ''' The allowed timestamp difference
    ''' </summary>
    Private allowed_timestamp_difference As Integer = 2
    ''' <summary>
    ''' The magic key
    ''' </summary>
    Private magic_key() As Byte = {12, 56, 3, 23}
    ''' <summary>
    ''' The magic key length
    ''' </summary>
    Private magic_key_len As Integer = magic_key.Length

    ''' <summary>
    ''' Initializes a new instance of the <see cref="Tokenizer"/> class.
    ''' </summary>
    Public Sub New()
        '''' Declare a new instance of the rsa service provider
        RSA = New RSACryptoServiceProvider()

        '''' Declare a new randomizer instance
        random_generator = New Random()

        '''' Create a random salt size
        salt_size = random_generator.Next(2, 8)
    End Sub

    ''' <summary>
    ''' On destruction, destroy the RSA engine
    ''' </summary>
    Protected Overrides Sub Finalize()
        RSA.Clear()
    End Sub



    ''' <summary>
    ''' Generate token.
    ''' </summary>
    ''' <returns>System.String.</returns>
    Public Function token_generate() As String
        Dim salt(salt_size) As Byte

        random_generator.NextBytes(salt)

        Dim time() As Byte = BitConverter.GetBytes(DateTime.UtcNow.ToBinary())

        Dim stream_output() As Byte = rsa_encrypt(salt.Concat(magic_key).Concat(time).Concat(salt).ToArray(), RSA)

        Return Convert.ToBase64String(stream_output)
    End Function

    ''' <summary>
    ''' Is this token valid ?
    ''' </summary>
    ''' <param name="token">The token.</param>
    ''' <returns><c>true</c> if valid, <c>false</c> otherwise.</returns>
    Public Function token_is_valid(ByVal token As String) As Boolean
        Dim stream_output() As Byte = rsa_decrypt(Convert.FromBase64String(token), RSA)

        '''' First check against nulls
        If stream_output Is Nothing Then Return False

        '''' Second check
        For i As Integer = salt_size + 1 To salt_size + magic_key_len - 1
            If Not stream_output(i) = magic_key(i - salt_size - 1) Then Return False
        Next

        ' How old is this token ?
        Dim time_stamp As DateTime = DateTime.FromBinary(BitConverter.ToInt64(stream_output, salt_size + magic_key_len + 1))

        If (time_stamp < DateTime.UtcNow.AddSeconds(-allowed_timestamp_difference)) Then

            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Encrypt using RSA
    ''' </summary>
    ''' <param name="buffer">The buffer.</param>
    ''' <param name="RSC">The RSC.</param>
    ''' <returns>System.Byte().</returns>
    Private Function rsa_encrypt(ByVal buffer() As Byte, ByVal RSC As RSACryptoServiceProvider) As Byte()

        Try
            Return RSC.Encrypt(buffer, False)
        Catch ex As Exception
            '''' Returning from exception cases is expensive
        End Try

        Return Nothing
    End Function

    ''' <summary>
    ''' RSAs the decrypt.
    ''' </summary>
    ''' <param name="buffer">The buffer.</param>
    ''' <param name="RSC">The RSC.</param>
    ''' <returns>System.Byte().</returns>
    Private Function rsa_decrypt(ByVal buffer() As Byte, ByVal RSC As RSACryptoServiceProvider) As Byte()

        Try
            Return RSC.Decrypt(buffer, False)
        Catch ex As Exception
            '''' Returning from exception cases is expensive
        End Try

        Return Nothing
    End Function
End Class
