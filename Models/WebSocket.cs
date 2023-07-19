using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace trendyolGO.Models;
public class WebSocket
{
    static async Task Main(string[] args)
    {
        using (ClientWebSocket clientWebSocket = new ClientWebSocket())
        {
            Uri serverUri = new Uri("wss://echo.websocket.org"); // Replace with your WebSocket server URI

            try
            {
                await clientWebSocket.ConnectAsync(serverUri, CancellationToken.None);

                Console.WriteLine("WebSocket connected!");

                // Send a message to the server
                string message = "Hello, WebSocket!";
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                await clientWebSocket.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Text, true, CancellationToken.None);

                // Receive messages from the server
                byte[] receiveBuffer = new byte[1024];
                while (true)
                {
                    WebSocketReceiveResult result = await clientWebSocket.ReceiveAsync(new ArraySegment<byte>(receiveBuffer), CancellationToken.None);
                    string receivedMessage = Encoding.UTF8.GetString(receiveBuffer, 0, result.Count);
                    Console.WriteLine("Received: " + receivedMessage);

                    if (result.EndOfMessage)
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("WebSocket error: " + ex.Message);
            }
            finally
            {
                if (clientWebSocket.State == WebSocketState.Open)
                    await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
            }
        }
    }
}

