Public Class INIHandler
    ' Funciones del API de Windows para ficheros INI
    Private Declare Ansi Function GetPrivateProfileString _
  Lib "kernel32.dll" Alias "GetPrivateProfileStringA" _
  (ByVal lpApplicationName As String,
  ByVal lpKeyName As String, ByVal lpDefault As String,
  ByVal lpReturnedString As System.Text.StringBuilder,
  ByVal nSize As Integer, ByVal lpFileName As String) _
  As Integer

    Private Declare Ansi Function WritePrivateProfileString _
  Lib "kernel32.dll" Alias "WritePrivateProfileStringA" _
  (ByVal lpApplicationName As String,
  ByVal lpKeyName As String, ByVal lpString As String,
  ByVal lpFileName As String) As Integer

    Private Declare Ansi Function GetPrivateProfileInt _
  Lib "kernel32.dll" Alias "GetPrivateProfileIntA" _
  (ByVal lpApplicationName As String,
  ByVal lpKeyName As String, ByVal nDefault As Integer,
  ByVal lpFileName As String) As Integer

    Private Declare Ansi Function FlushPrivateProfileString _
  Lib "kernel32.dll" Alias "WritePrivateProfileStringA" _
  (ByVal lpApplicationName As Integer,
  ByVal lpKeyName As Integer, ByVal lpString As Integer,
  ByVal lpFileName As String) As Integer

    Dim strFilename As String

    ' Constructor, para aceptar el fichero INI
    Public Sub New(ByVal Filename As String)
        strFilename = Filename
    End Sub

    'Propiedad sólo lectura con nombre de fichero
    ReadOnly Property FileName() As String
        Get
            Return strFilename
        End Get
    End Property

    'Función para leer cadena de texto (string) de fichero INI
    Public Function ReadString(ByVal Section As String,
  ByVal Key As String, ByVal [Default] As String) As String
        Dim intCharCount As Integer
        Dim objResult As New Text.StringBuilder(256)

        intCharCount = GetPrivateProfileString(Section, Key,
       [Default], objResult, objResult.Capacity, strFilename)
        If intCharCount > 0 Then
            ReadString = Left(objResult.ToString, intCharCount)
        Else
            ReadString = ""
        End If
    End Function

    'Función para leer un valor numérico del fichero INI
    Public Function ReadInteger(ByVal Section As String,
  ByVal Key As String, ByVal [Default] As Integer) As Integer
        Return GetPrivateProfileInt(Section, Key,
       [Default], strFilename)
    End Function

    'Función para leer un valor booleano de fichero INI
    Public Function ReadBoolean(ByVal Section As String,
  ByVal Key As String, ByVal [Default] As Boolean) As Boolean
        Dim intCharCount As Integer
        Dim objResult As New Text.StringBuilder(256)
        intCharCount = GetPrivateProfileString(Section, Key,
       [Default].ToString, objResult, objResult.Capacity, strFilename)
        Return Boolean.Parse(objResult.ToString)
    End Function

    'Función para escribir valor de cadena (string) en fichero INI
    Public Sub WriteString(ByVal Section As String,
  ByVal Key As String, ByVal Value As String)
        WritePrivateProfileString(Section, Key, Value, strFilename)
        Flush()
    End Sub

    'Función para escribir valor numérico en fichero INI
    Public Sub WriteInteger(ByVal Section As String,
  ByVal Key As String, ByVal Value As Integer)
        ' Writes an integer to your INI file
        WriteString(Section, Key, CStr(Value))
        Flush()
    End Sub

    'Función para escribir valor booleano en fichero INI
    Public Sub WriteBoolean(ByVal Section As String,
ByVal Key As String, ByVal Value As Boolean)
        ' Writes a boolean to your INI file
        WriteString(Section, Key, Value.ToString)
        Flush()
    End Sub

    'Guarda los cambios de la caché en fichero INI
    Private Sub Flush()
        FlushPrivateProfileString(0, 0, 0, strFilename)
    End Sub
    ' Gracias Victor!
End Class