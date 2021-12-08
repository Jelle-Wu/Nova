# Nova
Nova is a simple client for remote windows PC control.

sample of sender:

Nova('131.101.156.125','dir c:\\').SendMessage()

Nova('131.101.156.125','ipconfig ').SendMessage()

Nova('131.101.156.125','notepad no wait').SendMessage()

Nova('131.101.156.125','whoami').SendMessage()

Nova('131.101.156.125','rc 417,627,1').SendMessage()

Nova('131.101.156.125','kb 288,1677,72|69|76|76|79|32|87|79|82|76|68').SendMessage()

Nova('131.101.156.125','kb 288,1677,+72|69-|76|76|79|32|87|79|82|+76|68-').SendMessage()
