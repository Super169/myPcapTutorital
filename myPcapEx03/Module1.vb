Imports PcapDotNet.Core
Imports PcapDotNet.Packets

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
            Dim device As LivePacketDevice = allDevice.Item(i)
            Console.Write((i + 1) & ". " & device.Name)
            If (device.Description > "") Then
                Console.WriteLine(" (" & device.Description & ")")
            Else
                Console.WriteLine(" (No description)")
            End If
            Console.WriteLine()
        Next

        Dim deviceIndex As Integer = 0

        Do While deviceIndex = 0
            Console.WriteLine()
            Console.Write("Enter the interface number (1-" & allDevice.Count & "): ")
            Dim deviceIndexString As String = Console.ReadLine
            If (Not Integer.TryParse(deviceIndexString, deviceIndex)) Or (deviceIndex < 1) Or (deviceIndex > allDevice.Count) Then
                deviceIndex = 0
            End If
            Console.WriteLine()

        Loop

        Dim selectDevice As PacketDevice = allDevice.Item(deviceIndex - 1)

        Dim communicator As PacketCommunicator = selectDevice.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000)

        Console.WriteLine("Listening on " & selectDevice.Name)

        communicator.ReceivePackets(0, AddressOf PacketHandler)

        Console.ReadLine()
    End Sub

    Private Sub PacketHandler(packet As Packet)
        Console.WriteLine(packet.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff") & " length:" & packet.Length)
    End Sub


End Module