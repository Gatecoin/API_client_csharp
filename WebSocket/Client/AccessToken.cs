using System;

namespace GatecoinServiceInterface.WebSocket.Client
{
    /// <summary>
    /// AccessToken passed with header parameters
    /// </summary>
    public class AccessToken
    {
        /// <summary>
        /// Public Key
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>
        /// Encrypted Message
        /// </summary>
        public string SignedMessage { get; set; }

        /// <summary>
        /// RequestDate
        /// </summary>
        public DateTime DateTime { get; set; }
    }
}
