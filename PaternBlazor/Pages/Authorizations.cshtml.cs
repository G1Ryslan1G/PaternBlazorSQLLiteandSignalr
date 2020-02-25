using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR.Client;
using PaternBlazor.Model;

namespace PaternBlazor.Pages
{
    public class AuthorizationsModel : PageModel
    {
        private HubConnection _hubConnections { get; set; }

        public User _user { get; set; }

        public AuthorizationsModel()
        {
            _hubConnections = new HubConnectionBuilder()
                .WithUrl("/dbHub", opt =>
                    {
                        opt.SkipNegotiation = true;
                        opt.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets;
                    }).Build();
            _hubConnections.StartAsync();
        }

        public lo
    }
}
