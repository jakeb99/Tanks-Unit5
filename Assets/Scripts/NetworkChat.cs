using Unity.Netcode;
using System;

public class NetworkChat : NetworkBehaviour
{
    public Action<string> OnMessageReceived;

    public void SendMessageToChat(string messageRecieved)
    {
        string whoSent = (IsOwner) ? "Host" : "Client"; 
        SendMessageRpc(messageRecieved, whoSent);    
    }

    [Rpc(SendTo.Everyone)]
    public void SendMessageRpc(string messageRecieved, String userName)
    {

        OnMessageReceived?.Invoke(userName + ": " + messageRecieved);
    }
}
