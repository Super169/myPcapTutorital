Imports PcapDotNet.Core

Module Module1

    Sub Main()
        Dim allDevice As IList(Of LivePacketDevice) = LivePacketDevice.AllLocalMachine
        Dim i As Integer

        If (allDevice.Count = 0) Then
            Console.WriteLine("No device found.")
            Return
        End If

        Console.WriteLine("List of devices: ")
        Console.WriteLine("=================")
        Console.WriteLine()

        For i = 0 To allDevice.Count - 1
            DevicePrint(allDevice.Item(i))
        Next

        Console.ReadLine()
    End Sub

    Private Sub DevicePrint(device As IPacketDevice)


        Console.WriteLine(device.Name)
        If (device.Description > "") Then Console.WriteLine("Description: " & device.Description)
        Console.WriteLine("Loopback: " & IIf(device.Attributes And DeviceAttributes.Loopback = DeviceAttributes.Loopback, "yes", "No"))

        For Each address As DeviceAddress In device.Addresses
            Console.WriteLine("")
            Console.WriteLine("  Address Family:" & address.Address.Family.ToString)
            If (address.Address IsNot Nothing) Then Console.WriteLine("  Address:" & address.Address.ToString)
            If (address.Netmask IsNot Nothing) Then Console.WriteLine("  Netmask:" & address.Netmask.ToString)
            If (address.Broadcast IsNot Nothing) Then Console.WriteLine("  Broadcast Address:" & address.Broadcast.ToString)
            If (address.Destination IsNot Nothing) Then Console.WriteLine("  Destination Address:" & address.Destination.ToString)

        Next

        Console.WriteLine()

    End Sub

End Module
