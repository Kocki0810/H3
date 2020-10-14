Global $input = "Hello world word"

Run("C:\Program Files\Microsoft Office\root\Office16\WINWORD.EXE")
Sleep(2000)
Send("{ENTER}")
Sleep(500)
Send($input)
Send("^s")
Send("Hello world Word test")
Sleep(500)
Send("{ENTER}")
Sleep(500)
Send("{ENTER}")
