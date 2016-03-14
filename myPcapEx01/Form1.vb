Imports PcapDotNet.Core

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lvData.Columns.Add("#", 30, HorizontalAlignment.Right)
        lvData.Columns.Add("Name", 400, HorizontalAlignment.Left)
        lvData.Columns.Add("Description", 400, HorizontalAlignment.Left)
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Dim allDevices As IList(Of LivePacketDevice)
        Dim i As Integer

        allDevices = LivePacketDevice.AllLocalMachine
        If (allDevices.Count = 0) Then
            MsgBox("No interfaces found!")
            Return
        End If

        For i = 0 To allDevices.Count - 1
            Dim device As LivePacketDevice
            Dim str(3) As String
            Dim itm As ListViewItem
            device = allDevices.Item(i)
            str(0) = (i + 1).ToString
            str(1) = device.Name
            str(2) = device.Description
            itm = New ListViewItem(str)
            lvData.Items.Add(itm)
        Next
    End Sub

End Class
