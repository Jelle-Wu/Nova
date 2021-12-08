Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.IO
Imports System.Threading
Imports System.Net.NetworkInformation
Imports IWshRuntimeLibrary
Imports Newtonsoft.Json.Linq
Imports Microsoft.Win32
Imports Microsoft.VisualBasic

Public Class Nova_Form
    Dim s As Socket = Nothing
    Dim t As Thread
    Dim realclose As Boolean = False
    Dim isrunning As Boolean = False
    Dim ishide As Boolean = False
    Dim Nova_expire As Boolean = True
    ''Dim kb_dic = System.Windows.Forms.Keys
    Delegate Sub SetOutputBack(ByVal tag As String, ByVal stdout As String)
    Declare Sub keybd_event Lib "user32" (bVk As Byte, bScan As Byte, dwFlags As Long, dwExtraInfo As Long)
    Declare Sub mouse_event Lib "user32" (dwFlags As Integer, dx As Integer, dy As Integer, cButtons As Integer, dwExtraInfo As Integer)
    Declare Function SetCursorPos Lib "user32" (ByVal x As Long, ByVal y As Long) As Long
    Private Function Local_Hostname() As String
        Local_Hostname = Dns.GetHostName()
        Return Local_Hostname
    End Function
    Private Function Local_IP() As String
        Dim hostname = Local_Hostname()
        Dim IPv4_address = GetHostEntryIPv4(hostname).AddressList(0).ToString
        Return IPv4_address
    End Function
    Public Function GetHostEntryIPv4(ByVal addr As String) As IPHostEntry
        Dim ipHostInfo As IPHostEntry = Dns.GetHostEntry(addr)
        If Not IsNothing(ipHostInfo) Then
            ipHostInfo.AddressList = Array.FindAll(ipHostInfo.AddressList, Function(n As IPAddress) n.AddressFamily = AddressFamily.InterNetwork)
        End If
        GetHostEntryIPv4 = ipHostInfo
    End Function
    Private Function Get_GUID(ByVal m_days As Integer, ByVal guidonly As Boolean) As String
        Dim uuid As String = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Cryptography", False).GetValue("MachineGuid").ToString
        Dim uuidg = uuid.Split("-")
        Dim value As Int64 = 0
        For Each items In uuidg
            value = value + Convert.ToInt64(items, 16)
        Next
        Dim return_val As Long
        If guidonly Then
            return_val = value
        Else
            return_val = CLng(Format(DateTime.Now.AddDays(m_days), "yyyyMMddhhmmss")) + value
        End If
        Return return_val
    End Function
    Private Sub CheckLicense()
        Dim lkey As String = My.Computer.Registry.CurrentUser.GetValue("Microsoft")
        If IsNothing(lkey) Then
            Dim licensekey As Long = Get_GUID(7, False)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER", "Microsoft", licensekey)
            Nova_Output("I", "New User for 7 Days Free")
            Nova_expire = False
        Else
            Dim expire_data = Convert.ToInt64(lkey)
            Dim current_data = Convert.ToInt64(Get_GUID(0, False))
            Dim NA_license = Convert.ToInt64(Get_GUID(0, True)) + 19831220000000
            If expire_data > current_data Then
                Dim machine_id = Convert.ToInt64(Get_GUID(0, True))
                Dim margin_days = DateTime.ParseExact((expire_data - machine_id).ToString, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat).Subtract(DateTime.ParseExact((current_data - machine_id).ToString, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat)).Days
                If margin_days >= 0 And margin_days <= 7 Then
                    Nova_expire = False
                End If
            End If
            If expire_data = NA_license Then
                Nova_expire = False
            End If
        End If
    End Sub

    Private Sub Nova_Output(ByVal tag As String, ByVal stdout As String)
        If Nova_ListBox.InvokeRequired Then
            Dim stg As SetOutputBack = New SetOutputBack(AddressOf Nova_Output)
            Invoke(stg, New Object() {tag, stdout})
        Else
            stdout = Format(DateTime.Now, "yyyy-MM-dd hh:mm:ss") + " [" + tag + "] " + stdout
            Nova_ListBox.Items.Insert(0, stdout)
        End If
    End Sub
    Private Sub Nova_Start()
        isrunning = True
        Dim ipProperties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim ipEndTcpPoints() As IPEndPoint = ipProperties.GetActiveTcpListeners
        Dim portisused As Boolean = False
        For Each endPoint As IPEndPoint In ipEndTcpPoints
            If endPoint.Port = 12306 Then
                portisused = True
            End If
        Next endPoint
        If portisused Then
            Nova_Output("E", "PORT 12306 ALREADY IN USED")
            Nova_Stop_Button.Enabled = False
        Else
            t = New Thread(AddressOf Wait_Data)
            t.Start()
            Nova_Output("I", "Nova Started")
            Nova_Output("I", "IP->" + Local_IP())
            Nova_Output("I", "Port->12306")
            Nova_Start_Button.Enabled = False
            Nova_Stop_Button.Enabled = True
        End If
    End Sub
    Private Sub Nova_Stop()
        Try
            s.Close()
            t.Abort()
        Catch
        Finally
            isrunning = False
            Nova_Output("I", "Nova Stoped")
            Nova_Start_Button.Enabled = True
            Nova_Stop_Button.Enabled = False
        End Try
    End Sub
    Private Sub Nova_Start_Button_Click(sender As Object, e As EventArgs) Handles Nova_Start_Button.Click
        Nova_Start()
    End Sub
    Private Sub Nova_Stop_Button_Click(sender As Object, e As EventArgs) Handles Nova_Stop_Button.Click
        Nova_Stop()
    End Sub
    Private Sub Nova_Check_Box_CheckedChanged(sender As Object, e As EventArgs) Handles Nova_Check_Box.CheckedChanged
        Dim Novaname = My.Application.Info.CompanyName & My.Application.Info.ProductName
        Dim startuppath = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
        Dim Novastartupfile As FileInfo = New FileInfo(startuppath + "\" & Novaname & ".lnk")
        If Nova_Check_Box.Checked Then
            If Not Novastartupfile.Exists Then
                Dim shell = New WshShell()
                Dim shortcut = CType(shell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\" & Novaname & ".lnk"), IWshShortcut)
                shortcut.WorkingDirectory = System.Environment.CurrentDirectory
                shortcut.WindowStyle = 1
                shortcut.Description = Novaname
                shortcut.IconLocation = Application.ExecutablePath
                shortcut.TargetPath = Application.StartupPath + "\" + My.Application.Info.AssemblyName & ".exe "
                shortcut.Save()
            End If
        Else
            If Novastartupfile.Exists Then
                Novastartupfile.Delete()
            End If
        End If
    End Sub
    Private Sub Nova_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Text = "Nova" + "   " + Local_IP() + "   " + Local_Hostname()
        Dim Novaname = My.Application.Info.CompanyName & My.Application.Info.ProductName
        Dim startuppath = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
        Dim Novastartupfile As FileInfo = New FileInfo(startuppath + "\" & Novaname & ".lnk")
        If Novastartupfile.Exists Then
            Nova_Check_Box.Checked = True
        End If
        CheckLicense()
        If Not Nova_expire Then
            Nova_License.Visible = False
            Nova_Separator.Visible = False
            Nova_Start()
        Else
            Nova_Output("E", "NOVA EXPIRED")
        End If
    End Sub
    Private Sub Nova_NotifyIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Nova_NotifyIcon.MouseDoubleClick
        Show()
        ishide = False
    End Sub
    Private Sub Nova_Form_FormClosed(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        If realclose Then
            If isrunning Then
                Nova_Stop()
            End If
            Dispose()
            Application.Exit()
        Else
            Hide()
            ishide = True
            Notifiction_Message("Nova Notice", "Nova Still On Working")
            e.Cancel = True
        End If
    End Sub
    Private Sub Notifiction_Message(ByVal title As String, ByVal msg As String)
        Nova_NotifyIcon.BalloonTipTitle = title
        Nova_NotifyIcon.BalloonTipText = Format(DateTime.Now, "yyyy-MM-dd hh:mm:ss") + vbCrLf + msg
        Nova_NotifyIcon.ShowBalloonTip(500)
    End Sub
    Private Sub Nova_Exit(sender As Object, e As EventArgs) Handles Nova_ToolStripMenu_Exit.Click
        realclose = True
        Close()
    End Sub
    Private Sub Wait_Data()
        s = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        Dim localEndPoint As New IPEndPoint(IPAddress.Parse(Local_IP()), 12306) 'port 12306
        s.Bind(localEndPoint)
        s.Listen(100)
        While (True)
            Dim rec_bytes(1024) As Byte
            Dim ss As Socket = s.Accept()
            ss.Receive(rec_bytes)
            Dim rec_string = Encoding.UTF8.GetString(rec_bytes).Replace(Convert.ToChar(0), "")
            Nova_Output("R", rec_string)
            If ishide Then
                Notifiction_Message("Nova Recieved", rec_string)
            End If
            Dim send_string As String = Command_Analysis(rec_string)
            ss.Send(Encoding.UTF8.GetBytes(send_string))
            Nova_Output("S", send_string)
        End While
    End Sub
    Private Sub License_ToolStripTextBox_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles License_ToolStripTextBox.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim input As String = License_ToolStripTextBox.Text
            Dim input_license As Long
            Try
                input_license = Convert.ToInt64(input, 16)
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER", "Microsoft", input_license)
                Dim expire_date = DateTime.ParseExact((input_license - Convert.ToInt64(Get_GUID(0, True))).ToString, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat)
                Nova_Output("I", "Expire day " + Format(expire_date, "yyyy-MM-dd hh:mm:ss").ToString)
                Nova_expire = False
                Nova_License.Visible = False
                Nova_Separator.Visible = False
            Catch ex As Exception
                Nova_Output("E", "INPUT LICENSE ERROR")
            End Try
        End If
    End Sub
    Private Function Command_Analysis(command As String)
        Dim v_return As String
        If Nova_expire Then
            v_return = command
        Else
            Dim input_json As JObject = JObject.Parse(command)
            Dim cmds As String = input_json.SelectToken("cmd")
            Dim waits As String = input_json.SelectToken("wait")
            If cmds Is Nothing Then
                v_return = command
            Else
                If cmds.Substring(0, 3).ToUpper = "LC " Or cmds.Substring(0, 3).ToUpper = "RC " Or cmds.Substring(0, 3).ToUpper = "KB " Then
                    v_return = Input_Simulator(cmds.Trim(), waits)
                Else
                    v_return = Excute_Command(cmds.Trim(), waits)
                End If
            End If
        End If
        Return v_return
    End Function
    Private Function Excute_Command(cmds As String, waits As String)
        Dim startInfo As ProcessStartInfo = New ProcessStartInfo("cmd.exe")
        Dim processStartInfo As ProcessStartInfo = startInfo
        processStartInfo.Arguments = "/C " + cmds
        processStartInfo.RedirectStandardError = True
        processStartInfo.RedirectStandardOutput = True
        processStartInfo.UseShellExecute = False
        processStartInfo.CreateNoWindow = True
        Dim p As Process = Process.Start(startInfo)
        Dim pid, stdOut, stderr As String
        If waits = "1" Then
            pid = p.Id.ToString()
            If pid = String.Empty Then
                stdOut = "FAIL"
                stderr = "start process failed"
            Else
                stdOut = "SUCCESS"
                stderr = ""
            End If
        ElseIf waits = "2" Then
            p.WaitForExit()
            stdOut = p.StandardOutput.ReadToEnd()
            stderr = p.StandardError.ReadToEnd()
            pid = p.Id.ToString()
        Else
            pid = p.Id.ToString()
            stdOut = p.StandardOutput.ReadToEnd()
            stderr = p.StandardError.ReadToEnd()
        End If
        Dim result, output As String
        If stderr = String.Empty Then
            result = "SUCCESS"
            output = stdOut
        Else
            result = "FAIL"
            output = stderr
        End If
        Return "{""result"":""" + result + """, ""pid"":""" + pid + """,""output"":""" + output + """}"
    End Function
    Private Function Input_Simulator(cmds As String, waits As String)
        Try
            Dim command_type = cmds.Substring(0, 2).ToLower
            Dim command_list = cmds.Substring(2, cmds.Length - 2).Trim.Split(",")
            SetCursorPos(CInt(command_list(0)), CInt(command_list(1)))
            If command_type = "rc" Then
                For i = 0 To CInt(command_list(2))
                    mouse_event(8, 0, 0, 0, 0)
                    Thread.Sleep(50)
                    mouse_event(16, 0, 0, 0, 0)
                    Thread.Sleep(50)
                    i += 1
                Next
            ElseIf command_type = "lc" Then
                For i = 0 To CInt(command_list(2))
                    mouse_event(2, 0, 0, 0, 0)
                    Thread.Sleep(50)
                    mouse_event(4, 0, 0, 0, 0)
                    Thread.Sleep(50)
                    i += 1
                Next
            ElseIf command_type = "kb" Then
                mouse_event(2, 0, 0, 0, 0)
                Thread.Sleep(50)
                mouse_event(4, 0, 0, 0, 0)
                Thread.Sleep(50)
                Dim kb_list = command_list(2).Split("|")
                For Each kys As String In kb_list
                    Dim kys_code = kys.Replace("+", "").Replace("-", "")
                    If InStr(kys, "+") Then
                        keybd_event(16, 0, 0, 0)
                    End If
                    keybd_event(CInt(kys_code), 0, 0, 0)
                    ''Thread.Sleep(50)
                    keybd_event(CInt(kys_code), 0, 2, 0)
                    ''Thread.Sleep(50)
                    If InStr(kys, "-") Then
                        keybd_event(16, 0, 2, 0)
                    End If
                Next
            End If
            Return "{""result"":""PASS"", ""x"":""" + command_list(0) + """,""y"":""" + command_list(1) + """,""comment"":""" + command_type + "->" + command_list(2) + """}"
        Catch ex As Exception
            Return "{""result"":""FAIL"", ""error"":""" + ex.Message + """}"
        End Try
    End Function
End Class
