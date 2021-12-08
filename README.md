# Nova
Nova is a simple client for control remote windows PC by command.
It support system command,mouse event and keyboard input.



Samples of command send to Nova:

Nova('127.0.0.1','ipconfig').SendMessage() #excute command 'ipconfig'

Nova('127.0.0.1','notepad no wait').SendMessage() #open notepad without wait

Nova('127.0.0.1','notepad wait').SendMessage() #open notepad and wait

Nova('127.0.0.1','rc 100,100,2').SendMessage() #right click 2 times at 100,100

Nova('127.0.0.1','lc 200,100,1').SendMessage() #left click 1 time at 200,100

Nova('127.0.0.1','kb 720,1046,72|69|76|76|79|32|87|79|82|76|68').SendMessage() #send keyboard 'hello word' at 720,1046 

Nova('127.0.0.1','kb 720,1046,+72|69|76|76|79-|32|87|79|82|76|68').SendMessage() #send keyboard 'HELLO word' at 720,1046 

