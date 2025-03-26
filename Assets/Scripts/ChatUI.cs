using UnityEngine;
using TMPro;

public class ChatUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField messageInputField;
    [SerializeField] private TextMeshProUGUI messageDisplay;
    NetworkChat chat;

    public void InitalizeChatUI()
    {
        chat = FindAnyObjectByType<NetworkChat>();
        chat.OnMessageReceived += RecieveMessageText;
    }

    public void Btn_SendMessage()
    {
        string messageToSend = messageInputField.text;

        // send to network
        if (!chat)
        {
            InitalizeChatUI();
        }

        chat.SendMessageToChat(messageToSend);
    }

    public void RecieveMessageText(string messageRecieved)
    {
        messageDisplay.text += "\n" + messageRecieved;
    }

}
