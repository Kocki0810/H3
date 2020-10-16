#include <MsgBoxConstants.au3> ; Message box toturial - https://www.autoitscript.com/autoit3/docs/tutorials/helloworld/helloworld.htm
; ReadMe:
; Hvis scriptet stopper ved "Bekræft Gem som" vindue.
; Så start et notepad op og gem en fil i dokumenter før du prøver igen.
; Det gør at defualt stien bliver ændret.


Global $notepad_win = "Untitled - Notepad" ; Engelsk version "Untitled - Notepad"
Global $save_win = "Notepad" ; Engelsk version "Notepad"
Global $save_as_win = "Save As"
Global $save_button = "&Save"
Global $filename = "Helloworld.txt"

Local $input = InputBox("Select a File", "Write your file destination here")
Local $function = InputBox("Function", "Write the function you want to do - Delete or Create a file")
if $function == "Delete" Then
	FileDelete($input)
	MsgBox($MB_ICONINFORMATION, "Debug", "Succes, deleted at " & $input)
ElseIf $function == "Create" Then
	Local $text = InputBox("Input", "Write to the file")
	Run("Notepad.exe")
	WinWaitActive($notepad_win)
	Send($text)
	WinClose("*" & $notepad_win)
	ControlClick($save_win, "", "&Save")
	WinWaitActive($save_as_win)
	Send($input)
	ControlClick($save_as_win, "", "&Save")
	if FileExists($input) Then
		local $confirm_win = "Confirm Save As"
		WinWaitActive($confirm_win)
		ControlClick($confirm_win, "", "&Yes")
	EndIf
EndIf





