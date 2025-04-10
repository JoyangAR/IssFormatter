Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Module IssFormatter

    Sub Main(args As String())
        If args.Length < 2 Then
            Console.WriteLine("Usage:")
            Console.WriteLine("  IssFormatter.exe ""<input.iss>"" ""<output.iss>"" [IndentSpaces] [CapitalType] [IndentIf] [IndentTry] [IndentCase] [IndentOnlyBegin]")
            Console.WriteLine()
            Console.WriteLine("Note: If the file paths contain spaces, wrap them in double quotes.")
            Console.WriteLine()
            Console.WriteLine("Example:")
            Console.WriteLine("  IssFormatter.exe ""C:\Scripts\input script.iss"" ""C:\Output\formatted.iss"" 2 0 true true true false")
            Return
        End If

        Dim inputPath As String = args(0)
        Dim outputPath As String = args(1)
        Dim indentSpaces As Integer = If(args.Length > 2, Integer.Parse(args(2)), 2)
        Dim capitalType As Integer = If(args.Length > 3, Integer.Parse(args(3)), 0)
        Dim indentIf As Boolean = If(args.Length > 4, Boolean.Parse(args(4)), True)
        Dim indentTry As Boolean = If(args.Length > 5, Boolean.Parse(args(5)), True)
        Dim indentCase As Boolean = If(args.Length > 6, Boolean.Parse(args(6)), True)
        Dim indentOnlyBegin As Boolean = If(args.Length > 7, Boolean.Parse(args(7)), False)

        If Not File.Exists(inputPath) Then
            Console.WriteLine("Error: Input file not found: " & inputPath)
            Return
        End If

        Dim originalScript As String = File.ReadAllText(inputPath)

        Dim formatted As String = IssFormatter.FormatIssToString(
        IssScript:=originalScript,
        IndentSpaces:=indentSpaces,
        IndentIf:=indentIf,
        IndentTry:=indentTry,
        IndentCase:=indentCase,
        IndentOnlyBegin:=indentOnlyBegin,
        CapitalType:=capitalType,
        OutputFilePath:=outputPath
    )

        Console.WriteLine("Inno Setup Script formatted and saved to: " & outputPath)
    End Sub

    ''' <summary>
    ''' Formats an Inno Setup script with indentation and optional keyword capitalization.
    ''' </summary>
    ''' <param name="IssScript">The original script as a string.</param>
    ''' <param name="IndentSpaces">The number of spaces to use for each indentation level.</param>
    ''' <param name="IndentIf">Whether to indent inside IF-THEN blocks without BEGIN.</param>
    ''' <param name="IndentTry">Whether to indent TRY/EXCEPT/FINALLY blocks.</param>
    ''' <param name="IndentCase">Whether to indent CASE/OF blocks.</param>
    ''' <param name="IndentOnlyBegin">If True, only BEGIN/END blocks increase indentation.</param>
    ''' <param name="OutputFilePath">Optional. If provided, the formatted result will be saved to this path.</param>
    ''' <param name="CapitalType">Optional. Controls keyword capitalization:
    ''' 0 = do not modify, 1 = lowercase, 2 = UPPERCASE, 3 = Capitalize first letter.</param>
    ''' <returns>The formatted script as a string.</returns>
    Function FormatIssToString(IssScript As String, IndentSpaces As Integer, IndentIf As Boolean, IndentTry As Boolean, IndentCase As Boolean, IndentOnlyBegin As Boolean, Optional CapitalType As Integer = 0, Optional OutputFilePath As String = "") As String
        Dim Lines As List(Of String) = IssScript.Split({Environment.NewLine}, StringSplitOptions.None).ToList()
        Dim FormattedData As New StringBuilder()
        Dim IndentLevel As Integer = 0
        Dim I As Integer = 0
        Dim IfIndentLevel As Integer = 0
        Dim IndentUntilThen As Boolean = False
        Dim InsideThenWithoutBegin As Boolean = False
        Dim IndentUntilSemicolon As Boolean = False
        Dim IfLineIndex As Integer = -1
        Dim AdjustElseIndent As Boolean = False

        While I < Lines.Count
            Dim OriginalLine As String = Lines(I)
            If String.IsNullOrWhiteSpace(OriginalLine) Then
                FormattedData.AppendLine()
                I += 1
                Continue While
            End If

            Dim Line As String = OriginalLine.TrimEnd()
            Dim TrimmedLower As String = Line.Trim().ToLowerInvariant()

            ' Detect IF
            If TrimmedLower.StartsWith("if ") Then
                IfIndentLevel = IndentLevel
                IfLineIndex = I
                InsideThenWithoutBegin = False
                IndentUntilSemicolon = False
                IndentUntilThen = Not TrimmedLower.Contains(" then")

                If TrimmedLower.Contains(" then") Then
                    IndentUntilSemicolon = True
                End If
                AdjustElseIndent = True
            End If

            ' THEN separated
            If IndentUntilThen AndAlso TrimmedLower.Contains("then") Then
                IndentUntilThen = False
                InsideThenWithoutBegin = Not TrimmedLower.Contains(" then begin")
                IndentUntilSemicolon = Not TrimmedLower.EndsWith(";")
            End If

            ' ELSE aligned to IF
            If AdjustElseIndent AndAlso TrimmedLower = "else" Then
                FormattedData.AppendLine(New String(" "c, IfIndentLevel * IndentSpaces) & ApplyCapitalization(Line.TrimStart(), CapitalType))
                AdjustElseIndent = False
                I += 1
                Continue While
            End If

            ' Continue indentation after THEN without BEGIN
            If InsideThenWithoutBegin OrElse IndentUntilSemicolon Then
                Dim L = Line.Trim().ToLowerInvariant()
                If L.StartsWith("begin") OrElse L.EndsWith(";") Then
                    InsideThenWithoutBegin = False
                    IndentUntilSemicolon = False
                    IfLineIndex = -1
                End If
            End If

            ' PreProcessor
            Dim IsPreprocessorDirective As Boolean = False
            If TrimmedLower.StartsWith("#ifdef") OrElse TrimmedLower.StartsWith("#ifndef") OrElse TrimmedLower.StartsWith("#if") Then
                IsPreprocessorDirective = True
            ElseIf TrimmedLower = "#endif" Then
                IndentLevel = Math.Max(IndentLevel - 1, 0)
                IsPreprocessorDirective = True
            End If

            ' Count Blocks
            Dim BeginCount As Integer = CountExact(Line, "begin")
            Dim EndCount As Integer = CountExact(Line, "end")
            Dim TryCount As Integer = If(IndentTry, CountExact(Line, "try"), 0)
            Dim ExceptCount As Integer = CountExact(Line, "except")
            Dim FinallyCount As Integer = CountExact(Line, "finally")
            Dim OpensRepeat As Boolean = TrimmedLower = "repeat"
            Dim ClosesRepeat As Boolean = TrimmedLower.StartsWith("until")
            Dim OpensCase As Boolean = If(IndentCase, TrimmedLower.Contains("case") AndAlso TrimmedLower.Contains("of"), False)

            If Not IndentOnlyBegin Then
                BeginCount += TryCount + ExceptCount + FinallyCount
            End If
            EndCount += ExceptCount + FinallyCount
            If OpensRepeat Then BeginCount += 1
            If ClosesRepeat Then EndCount += 1
            If OpensCase Then BeginCount += 1

            ' Temporal Indent
            Dim TempIndentLevel As Integer = IndentLevel
            If Regex.IsMatch(TrimmedLower, "^end\b.*(;)?(\s*//.*)?$") OrElse
               TrimmedLower = "except" OrElse TrimmedLower = "finally" OrElse ClosesRepeat Then
                TempIndentLevel = Math.Max(IndentLevel - 1, 0)
            ElseIf (IndentUntilThen OrElse InsideThenWithoutBegin OrElse IndentUntilSemicolon) AndAlso I <> IfLineIndex Then
                TempIndentLevel = IfIndentLevel + 1
            End If

            ' Apply Capitalization
            Dim ProcessedLine As String = ApplyCapitalization(Line.TrimStart(), CapitalType)
            FormattedData.AppendLine(New String(" "c, TempIndentLevel * IndentSpaces) & ProcessedLine)

            ' Real indentation adjustment
            IndentLevel += BeginCount - EndCount
            If IsPreprocessorDirective AndAlso Not TrimmedLower.StartsWith("#endif") Then
                IndentLevel += 1
            End If
            If IndentLevel < 0 Then IndentLevel = 0

            I += 1
        End While

        Dim Result As String = FormattedData.ToString()

        If Not String.IsNullOrWhiteSpace(OutputFilePath) Then
            Dim Utf8WithoutBom As New UTF8Encoding(False)
            File.WriteAllText(OutputFilePath, Result, Utf8WithoutBom)
        End If

        Return Result
    End Function

    ''' <summary>
    ''' Counts the exact occurrences of a keyword in a line.
    ''' </summary>
    ''' <param name="line">The line of text.</param>
    ''' <param name="keyword">The keyword to count.</param>
    ''' <returns>The number of occurrences.</returns>
    Function CountExact(line As String, keyword As String) As Integer
        Return Regex.Matches(line, $"\b{keyword}\b", RegexOptions.IgnoreCase).Count
    End Function

    ''' <summary>
    ''' Applies capitalization rules to recognized Inno Setup keywords in a line of code.
    ''' </summary>
    ''' <param name="line">The input line to process.</param>
    ''' <param name="mode">Capitalization mode:
    ''' 0 = no change, 1 = lowercase, 2 = UPPERCASE, 3 = Capitalize first letter.</param>
    ''' <returns>The line with keywords capitalized according to the selected mode.</returns>
    Function ApplyCapitalization(line As String, mode As Integer) As String
        If mode = 0 Then Return line

        Dim keywords As String() = {
            "if", "then", "else", "begin", "end", "try", "except", "finally", "repeat", "until", "case", "of", "while", "do", "for", "to", "downto", "break", "continue", "exit", "with", "function", "procedure", "const", "var", "type", "label", "goto"
        }

        Return Regex.Replace(line, "\b(" & String.Join("|", keywords) & ")\b", Function(m)
                                                                                   Select Case mode
                                                                                       Case 1 ' LowerCase
                                                                                           Return m.Value.ToLowerInvariant()
                                                                                       Case 2 ' UpperCase
                                                                                           Return m.Value.ToUpperInvariant()
                                                                                       Case 3 ' Capitalize
                                                                                           Return Char.ToUpperInvariant(m.Value(0)) & m.Value.Substring(1).ToLowerInvariant()
                                                                                       Case Else
                                                                                           Return m.Value
                                                                                   End Select
                                                                               End Function, RegexOptions.IgnoreCase)
    End Function

    ''' <summary>
    ''' Formats an Inno Setup script and returns the result as a UTF-8 encoded memory stream (without BOM).
    ''' </summary>
    ''' <param name="IssScript">The input script text.</param>
    ''' <param name="IndentSpaces">Number of spaces for indentation.</param>
    ''' <param name="IndentIf">Indent IF statements.</param>
    ''' <param name="IndentTry">Indent TRY statements.</param>
    ''' <param name="IndentCase">Indent CASE statements.</param>
    ''' <param name="IndentOnlyBegin">Indent only BEGIN blocks.</param>
    ''' <returns>Returns a <see cref="MemoryStream"/> containing the formatted script in UTF-8 encoding (without BOM).</returns>
    Function FormatIssToStream(IssScript As String, IndentSpaces As Integer, IndentIf As Boolean, IndentTry As Boolean, IndentCase As Boolean, IndentOnlyBegin As Boolean) As MemoryStream
        Dim FormattedText As String = FormatIssToString(IssScript, IndentSpaces, IndentIf, IndentTry, IndentCase, IndentOnlyBegin)
        Dim Utf8WithoutBom As New UTF8Encoding(False)
        Dim Bytes As Byte() = Utf8WithoutBom.GetBytes(FormattedText)
        Return New MemoryStream(Bytes)
    End Function

End Module
