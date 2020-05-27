using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battlenet.Webapi.Hubs.Config
{
    public class TransactionHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections =
           new ConnectionMapping<string>();


        [HubMethodName("SendMessageToUser")]
        public Task DirectMessage(string user, string message)
        {
            return Clients.User(user).SendAsync("ReceiveMessage", message);
        }
        public Task SendMessage(string user, string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public void SendChatMessage(string who, string message)
        {
            var name = Context.User.Identity.Name;
            using (var db = new DataContext())
            {
                var user = db.Users.Find(who);
                if (user == null)
                {
                    Clients.Caller.SendAsync("Não foi encontrado o usuario.");
                }
                else
                {
                    db.Entry(user)
                        .Collection(u => u.Connections)
                        .Query()
                        .Where(c => c.Connected == true)
                        .Load();

                    if (user.Connections == null)
                    {
                        Clients.Caller.SendAsync("Usuario offline");
                    }
                    else
                    {
                        foreach (var connection in user.Connections)
                        {
                            Clients.Client(connection.ConnectionID).SendAsync(name + ": " + message);
                        }
                    }
                }
            }
        }
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("ReceiveMessage", string.Concat("Nova connexão estabelecida : ", Context.ConnectionId, "\n Clientes com conexão ativa ",_connections.Count));

            await Groups.AddToGroupAsync(Context.ConnectionId, "Online");
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("ReceiveMessage", string.Concat("Connexão do cliente : ", Context.ConnectionId, " encerrada \n"));


            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Online");
            await base.OnDisconnectedAsync(exception);
        }

        public Task ThrowException()
        {
            throw new HubException("Encontramos um problema, tente novamente mais tarde.");
        }
    }
}