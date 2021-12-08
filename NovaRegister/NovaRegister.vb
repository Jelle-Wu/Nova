Public Class NovaRegister
    Private Sub NovaRegisterButton_Click(sender As Object, e As EventArgs) Handles NovaRegisterButton.Click
        Dim uuid As String = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Cryptography", False).GetValue("MachineGuid").ToString
        Dim uuidg = uuid.Split("-")
        Dim value As Int64 = 0
        For Each items In uuidg
            value = value + Convert.ToInt64(items, 16)
        Next
        Dim reg_code As Long
        If NovaRegisterTextBox.Text.ToUpper = "UUDDLRLRBABA" Then
            reg_code = value + 19831220000000
        Else
            reg_code = CLng(Format(DateTime.Now.AddDays(7), "yyyyMMddhhmmss")) + value
        End If
        NovaRegisterTextBox.Text = Convert.ToString(reg_code, 16)
        NovaRegisterButton.Enabled = False
    End Sub
End Class
