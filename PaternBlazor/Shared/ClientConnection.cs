using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using PaternBlazor.Model;

namespace PaternBlazor.Shared
{
    public class ClientConnection : ComponentBase
    {
        [Inject]
        private HubConnection _hubConnections { get; set; }

        [Parameter]
        public User User { get; set; }

        [Parameter]
        public bool IsLogin { get; set; }

        protected override async Task OnInitializedAsync()
        {
            new ClientConnection();
            _hubConnections = new HubConnectionBuilder()
                .WithUrl("/dbHub", opt =>
                {
                    opt.SkipNegotiation = true;
                    opt.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets;
                }).Build();

            await _hubConnections.StartAsync();
        }
    
        public async Task<bool> Athorizations(string login, string password)
        {
            var user = await _hubConnections.InvokeAsync<User>("Authorizations", login, password);
            if (user == null)
            {
                return false;
            }

            return true;
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
