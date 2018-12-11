﻿using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace GatecoinServiceInterface.WebSocket.Client
{
    public interface IStreamingClient<TDto> : IDisposable
    {
        /// <summary>
        /// Starts connection
        /// </summary>
        /// <returns>Returns the current IStreamingClient instance</returns>
        [PublicAPI]
        Task<IStreamingClient<TDto>> Start();

        /// <summary>
        /// Stop the connection
        /// </summary>
        /// <returns>Returns the current IStreamingClient instance</returns>
        [PublicAPI]
        [Pure]
        Task<IStreamingClient<TDto>> Stop();

        /// <summary>
        /// Registers a handler that will be invoked with all events.
        /// </summary>
        /// <param name="handler">The handler that will be raised when the hub method is invoked.</param>
        /// <returns>A subscription that can be disposed to unsubscribe from the hub method.</returns>
        [PublicAPI]
        [Pure]
        IDisposable SubscribeAll([NotNull] Action<TDto> handler);


        /// <summary>
        /// Registers a handler that will be invoked when the hub method with the specified method name is invoked.
        /// </summary>
        /// <param name="currencyPair">A name for event with specified currency pair</param>
        /// <param name="handler">The handler that will be raised when the hub method is invoked.</param>
        /// <returns>A subscription that can be disposed to unsubscribe from the hub method.</returns>
        [PublicAPI]
        [Pure]
        IDisposable Subscribe([NotNull] string currencyPair, [NotNull] Action<TDto> handler);

        /// <summary>
        /// Event that will be triggered when the connection ends.
        /// </summary>
        event EventHandler<DisconnectEventArgs<TDto>> Disconnected;
    }
}