using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using PaternBlazor.Model;

namespace PaternBlazor.Shared
{
    public class ClientConnection
    {
        [Inject]
        private HubConnection _hubConnections { get; set; }

        [Parameter]
        public bool IsLogin { get; set; }

        public ClientConnection()
        {
            new ClientConnection();
            _hubConnections = new HubConnectionBuilder()
                .WithUrl("/dbHub", opt =>
                {
                    opt.SkipNegotiation = true;
                    opt.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets;
                }).Build();
            IsLogin = false;
        }

        public static async Task<ClientConnection> CreateClientConnection()
        {
            var client = new ClientConnection();
            await client._hubConnections.StartAsync();
            return client;
        }
    
        public Task<User> Athorizations(string login, string password)
        {
            return _hubConnections.InvokeAsync<User>("Authorizations", login, password);
        }

        public  Task<Movie[]> Movies()
        {
            return _hubConnections.InvokeAsync<Movie[]>("GetMoives");
            //return _hubConnections.InvokeAsync<Movie[]>("GetMoives", _user);
        }

        string login { get; set; }
        String password { get; set; }
    }
}
