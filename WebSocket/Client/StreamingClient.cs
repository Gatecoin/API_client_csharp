using System;
using System.Net.Http;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace GatecoinServiceInterface.WebSocket.Client
{
    internal sealed class StreamingClient<TDto> : IStreamingClient<TDto>
    {
        private const string ApiPublicKey = "API_PUBLIC_KEY";
        private const string ApiRequestSignature = "API_REQUEST_SIGNATURE";
        private const string ApiRequestDate = "API_REQUEST_DATE";

        private readonly HubConnection _connection;
        private readonly HttpMessageHandler _httpMessageHandler;
        private readonly ILogger _logger;

        internal StreamingClient(
            string url,
            AccessToken token = null,
            HttpMessageHandler httpMessageHandler = null,
            ILoggerFactory loggerFactory = null)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("Url cannot be null", nameof(url));
            }

            _httpMessageHandler = httpMessageHandler;

            _logger = (loggerFactory ?? new NullLoggerFactory()).CreateLogger(GetType());

            url = url.TrimEnd('/');

            var urlHub = $"{url}{Channels.GetChannelHub<TDto>()}";

            _connection = new HubConnectionBuilder()
                .WithUrl(
                    urlHub,
                    options =>
                    {
                        if (httpMessageHandler != null)
                        {
                            options.HttpMessageHandlerFactory = _ => httpMessageHandler;
                        }

                        if (token != null && !IsTokenValid(token))
                        {
                            throw new ArgumentException("If AccessToken is passed as a parameter, all the fields should be valid");
                        }

                        if (token != null)
                        {
                            options.Headers.Add(ApiPublicKey, token.PublicKey);
                            options.Headers.Add(ApiRequestSignature, token.SignedMessage);
                            options.Headers.Add(ApiRequestDate, token.DateTime.ToUnixTimeString());
                        }
                    })
                .AddJsonProtocol()
                .Build();
        }

        [Pure]
        [PublicAPI]
        public IDisposable Subscribe(string currencyPair, Action<TDto> handler)
        {
            if (handler == null)
            {
                throw new ArgumentException("Handler cannot be null", nameof(handler));
            }

            return _connection.On<TDto>(
                currencyPair,
                arg =>
                {
                    try
                    {
                        handler(arg);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.ToString());
                        throw;
                    }
                });
        }

        [Pure]
        [PublicAPI]
        public IDisposable SubscribeAll(Action<TDto> handler)
        {
            if (handler == null)
            {
                throw new ArgumentException("Handler cannot be null", nameof(handler));
            }

            return _connection.On<TDto>(
                EventTypes.BroadcastMessage,
                arg =>
                {
                    try
                    {
                        handler(arg);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.ToString());
                        throw;
                    }
                });
        }

        [PublicAPI]
        public async Task<IStreamingClient<TDto>> Start()
        {
            await _connection.StartAsync();
            _logger.Log(LogLevel.Information, "Connection started");
            return this;
        }

        public void Dispose()
        {
            // TODO: I don't like this, but in the time scope we need to put it off
            _connection?.StopAsync().Wait();
            _connection?.DisposeAsync().Wait();
            _httpMessageHandler?.Dispose();
        }

        private static bool IsTokenValid(AccessToken token)
        {
            return
                !string.IsNullOrWhiteSpace(token.PublicKey) &&
                !string.IsNullOrWhiteSpace(token.SignedMessage) &&
                token.DateTime != default(DateTime);
        }
    }
}