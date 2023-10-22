using UnityEngine;

namespace ReqRep
{
    public class Client : MonoBehaviour
    {
        [SerializeField] private string host;
        [SerializeField] private string port;
        [SerializeField] private Data data;
        public static Listener _listener;

        private void Start()
        {
            host = data.ipAddress;
            _listener = new Listener(host, port, HandleMessage);
            // EventManager.Instance.onSendRequest.AddListener(OnClientRequest);
        }

        // private void OnClientRequest()
        // {
        //     EventManager.Instance.onClientBusy.Invoke();
        //     _listener.RequestMessage();
        //     EventManager.Instance.onClientFree.Invoke();
        // }

        private void HandleMessage(string message)
        {
            Debug.Log(message);
        }
    }
}