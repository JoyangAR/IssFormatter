# IssFormatter

## A simple Inno Setup script formatter with basic options. This solution includes:

### IssFormatterDll: the core library that handles the formatting logic.

### IssFormatterBash: a console application to run the formatter via command-line.

### IssFormatter-GUI: a graphical interface to make formatting easier for users.

# Usage

## Console:
```
IssFormatterBash.exe "input.iss" "output.iss" [IndentSpaces] [CapitalType] [IndentIf] [IndentTry] [IndentCase] [IndentOnlyBegin]
```
### Example:
```
IssFormatterBash.exe "script.iss" "formatted.iss" 4 2 true true true false
```
Defaults:

IndentSpaces: 4

CapitalType: 0 (no capitalization)

IndentIf: true

IndentTry: true

IndentCase: true

IndentOnlyBegin: false

## GUI:

Run IssFormatter-GUI.exe to open a simple window. You can select the input file, choose your preferences, and format the script easily with a few clicks.

# Disclaimer

This is a basic tool and might not handle all edge cases. It's still under improvement. Use it at your own risk.
