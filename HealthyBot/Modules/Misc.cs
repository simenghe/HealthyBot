using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Discord.Audio;
using Discord;

namespace HealthyBot.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        string selectedCurrency = "USD";
        [Command("Echo")]
        public async Task Echo(string message)
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Big Nut:");
            embed.WithDescription(message);
            embed.WithColor(new Color(255, 0, 0));
            await Context.Channel.SendMessageAsync("",true,embed);
        }
        [Command("Autism")]
        public async Task Autism()
        {
            await Context.Channel.SendMessageAsync("You have autism!");
        }
        [Command("Hello")]
        public async Task Hello()
        {
            var embed = new EmbedBuilder();
            await Context.Channel.SendMessageAsync("Hello World");
        }
        [Command("Bitcoin")]
        public async Task UpdateBitcoinLabel()
        {
            const string bitcoinAddress = "https://api.coindesk.com/v1/bpi/currentprice.json";
            var client = new HttpClient();
            var bitcoinJSON = await client.GetStringAsync(bitcoinAddress);
            var bitcoinObject = JObject.Parse(bitcoinJSON);
            var bitcoinPrice = (double)bitcoinObject["bpi"][selectedCurrency]["rate_float"];
            await Context.Channel.SendMessageAsync("This is the current price of bitcoin in USD: " + bitcoinPrice);
        }

    }
}
