Imports PcapDotNet.Core
Imports PcapDotNet.Packets

Module Module1

    Sub Main()

        If (Environment.GetCommandLineArgs.Length <> 2) Then
            Console.WriteLine("usage: " & Environment.GetCommandLineArgs()(0) & " <filename>")
            Return
        End If

        Dim selectedDevice As OfflinePacketDevice = New OfflinePacketDevice(Environment.GetCommandLineArgs()(1))

        Dim communicator As PacketCommunicator = selectedDevice.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000)

        communicator.ReceivePackets(0, AddressOf DispatcherHandler)

    End Sub

    Private Sub DispatcherHandler(packet As Packet)
        Console.WriteLine(packet.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff") & " length:" & packet.Length)

        Const LineLength As Integer = 64

        Dim i As Integer = 0
        Do While (i < packet.Length)
            Console.Write(packet.Item(i).ToString("X2"))
            i += 1
            If ((i Mod LineLength) = 0) Then
                Console.WriteLine()
            End If
        Loop

        Console.WriteLine()
        Console.WriteLine()

    End Sub

End Module
