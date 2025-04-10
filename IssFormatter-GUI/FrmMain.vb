Imports System.IO
Imports System.Reflection
Imports System.Text

''' <summary>
''' Main form of the ISS Formatter tool. Handles loading, formatting, and saving of Inno Setup scripts.
''' </summary>
Public Class FrmMain

    ' Path to the INI configuration file
    Dim IniPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.ini")

    ' INI handler instance for reading and writing configuration
    Dim IniController As New INIHandler(IniPath)

    ' Formatting options
    Dim IndentSpaces As Integer = 2

    Dim IndentTry As Boolean = True
    Dim IndentIf As Boolean = True
    Dim IndentCase As Boolean = True
    Dim IndentOnlyBegin As Boolean = False

    ''' <summary>
    ''' Capitalization type:
    ''' 0 = Do not apply
    ''' 1 = lowercase
    ''' 2 = UPPERCASE
    ''' 3 = Capitalize first letter
    ''' </summary>
    Dim CapitalType As Integer = 0

    ''' <summary>
    ''' Formats the current script using the specified formatting options.
    ''' </summary>
    Private Sub BtnFormat(sender As Object, e As EventArgs) Handles BtnFormatISS.Click
        Dim FormattedText As String = IssFormatter.IssFormatter.FormatIssToString(
            RtbISSScript.Text, IndentSpaces, IndentIf, IndentTry, IndentCase, IndentOnlyBegin, CapitalType)

        RtbISSScript.Clear()
        RtbISSScript.Text = FormattedText
    End Sub

    ''' <summary>
    ''' Loads formatting settings from the INI file on form load.
    ''' </summary>
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not File.Exists(IniPath) Then
            File.Create(IniPath)
        Else
            IndentSpaces = IniController.ReadInteger("Formatter Options", "Indent Spaces", 2)
            IndentTry = IniController.ReadBoolean("Formatter Options", "Indent Try", True)
            IndentIf = IniController.ReadBoolean("Formatter Options", "Indent If", True)
            IndentCase = IniController.ReadBoolean("Formatter Options", "Indent Case", True)
            IndentOnlyBegin = IniController.ReadBoolean("Formatter Options", "Indent Only Begin", False)
            CapitalType = IniController.ReadInteger("Formatter Options", "Capital Type", 0)
        End If
    End Sub

    ''' <summary>
    ''' Opens a .iss file and loads its content into the editor.
    ''' </summary>
    Private Sub MsiOpen_Click(sender As Object, e As EventArgs) Handles MsiOpen.Click
        Using ofd As New OpenFileDialog()
            ofd.Title = "Select a file"
            ofd.Filter = "Inno Setup Script|*.iss"

            If ofd.ShowDialog() = DialogResult.OK Then
                RtbISSScript.Text = File.ReadAllText(ofd.FileName, Encoding.UTF8)
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Opens the formatting options dialog and saves the updated settings.
    ''' </summary>
    Private Sub MsiOptions_Click(sender As Object, e As EventArgs) Handles MsiOptions.Click
        Dim ISSFormatterOptions As New FrmOptions
        ISSFormatterOptions.NudIndentSpaces.Value = IndentSpaces
        ISSFormatterOptions.ChkIndentTry.Checked = IndentTry
        ISSFormatterOptions.ChkIndentIf.Checked = IndentIf
        ISSFormatterOptions.ChkIndentCase.Checked = IndentCase
        ISSFormatterOptions.ChkIndentOnlyBegin.Checked = IndentOnlyBegin
        ISSFormatterOptions.CbxCapitalType.SelectedIndex = CapitalType
        ISSFormatterOptions.ShowDialog()

        If ISSFormatterOptions.DialogResult = DialogResult.OK Then
            IndentSpaces = ISSFormatterOptions.NudIndentSpaces.Value
            IndentTry = ISSFormatterOptions.ChkIndentTry.Checked
            IndentIf = ISSFormatterOptions.ChkIndentIf.Checked
            IndentCase = ISSFormatterOptions.ChkIndentCase.Checked
            IndentOnlyBegin = ISSFormatterOptions.ChkIndentOnlyBegin.Checked
            CapitalType = ISSFormatterOptions.CbxCapitalType.SelectedIndex

            IniController.WriteInteger("Formatter Options", "Indent Spaces", IndentSpaces)
            IniController.WriteBoolean("Formatter Options", "Indent Try", IndentTry)
            IniController.WriteBoolean("Formatter Options", "Indent If", IndentIf)
            IniController.WriteBoolean("Formatter Options", "Indent Case", IndentCase)
            IniController.WriteBoolean("Formatter Options", "Indent Only Begin", IndentOnlyBegin)
            IniController.WriteInteger("Formatter Options", "Capital Type", CapitalType)
        End If
    End Sub

    ''' <summary>
    ''' Formats and overwrites an external .iss file with current settings.
    ''' </summary>
    Private Sub MniFormatFile_Click(sender As Object, e As EventArgs) Handles MniFormatFile.Click
        Using ofd As New OpenFileDialog()
            ofd.Title = "Select a file"
            ofd.Filter = "Inno Setup Script|*.iss"

            If ofd.ShowDialog() = DialogResult.OK Then
                IssFormatter.IssFormatter.FormatIssToString(
                    File.ReadAllText(ofd.FileName, Encoding.UTF8),
                    IndentSpaces, IndentIf, IndentTry, IndentCase, IndentOnlyBegin, CapitalType,
                    ofd.FileName)

                MessageBox.Show("File saved to: " & ofd.FileName)
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Handles application shutdown when the user selects the Exit menu option.
    ''' </summary>
    Private Sub MsiExit_Click(sender As Object, e As EventArgs) Handles MsiExit.Click
        Me.Close()
    End Sub

End Class