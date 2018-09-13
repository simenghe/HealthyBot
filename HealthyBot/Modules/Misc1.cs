using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json.Linq;
using Discord.Audio;
using Discord;
using Discord.WebSocket;

namespace HealthyBot.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        private DiscordSocketClient client;
        public static bool CoinFlips()
        {
            //Flips the coin a 5050 CHANCE!
            int coinFlip = rng.Next(0, 2);
            switch (coinFlip)
            {
                case 0:
                    return true;
                case 1:
                    return false;
                default:
                    return false;
            }
        }
        static Random rng = new Random();
        string selectedCurrency = "USD";
        string canadianCurrency = "CAD";
        public async Task UserJoined(SocketGuildUser user)
        {
            var channel = client.GetChannel(Context.Channel.Id) as SocketTextChannel;
            await channel.SendMessageAsync("We welcome you to wez, " + Context.User.Id,true);
        }
        [Command("Waterloo")]
        public async Task Waterloo()
        {
            await Context.Channel.SendMessageAsync("Fortunately, I got an alternative offer to geomatics", true);
        }
        [Command("MOE")]
        public async Task Moe()
        {
            await Context.Channel.SendMessageAsync("Attempting to summon big moe", true);
        }
        [Command("WANG")]
        public async Task Wang()
        {
            await Context.Channel.SendMessageAsync("Attempting to summon wang jesse", true);
        }
        [Command("Banchode")]
        public async Task Banchode()
        {
            await Context.Channel.SendMessageAsync("Banchode banchode stop being styoobid", false);
        }
        [Command("Tilted")]
        public async Task Tilted()
        {
            await Context.Channel.SendMessageAsync("TILLLLLLLLLLLLLLLLLLLLTED", false);
        }
        [Command("Golems")]
        public async Task Golems ()
        {
            await Context.Channel.SendMessageAsync("Invincibility Golems are evident in all of our lives!", false);
        }
        [Command("Echo")]
        public async Task Echo([Remainder] string message)
        {
            //var embed = new EmbedBuilder();
            await Context.Channel.SendMessageAsync(message,false);
        }
        [Command("MultipleChoice")]
        public async Task MultipleChoice()
        {
            //var embed = new EmbedBuilder();
            await Context.Channel.SendMessageAsync("Pick C!", false);
        }
        [Command("CoinFlip")]
        public async Task CoinFlip()
        {
            if (CoinFlips())
            {
                await Context.Channel.SendMessageAsync("HEADS!", false);
            }
            else
            {
                await Context.Channel.SendMessageAsync("TAILS!", false);
            }
        }
        [Command("MyAverage")]
        public async Task MyAverage()
        {
            await Context.Channel.SendMessageAsync("Projected mark is : "+rng.Next(50,101), false);
        }
        [Command("Bust")]
        public async Task Bust()
        {
            await Context.Channel.SendMessageAsync("I BUST I BUST SORRY SORRY SORRY IM GAY",false);
        }
        [Command("Autism")]
        public async Task Autism()
        {
            await Context.Channel.SendMessageAsync("You have autism!",false);
        }
        [Command("Wez")]
        public async Task Wez()
        {
            await Context.Channel.SendMessageAsync("WEZZZZZZZZZZZZZZZZ YOU ARE PART OF WEZZZZZZZZZZZZZZZZZZZZZZZZ", false);
        }
        [Command("Nut")]
        public async Task Nut()
        {
            await Context.Channel.SendMessageAsync("TOUKA TOUKA TOUKA", false);
        }
        [Command("Hello")]
        public async Task Hello()
        {
            var embed = new EmbedBuilder();
            await Context.Channel.SendMessageAsync("Hello World");
        }
        [Command("Shabi")]
        public async Task ShaBi()
        {
            await Context.Channel.SendMessageAsync("You are a sha bi",false);
        }
        [Command("aCKROT")]
        public async Task Ackrot()
        {
            await Context.Channel.SendMessageAsync("NUT ACKROT BADAM SHALOM", false);
        }
        [Command("Work")]
        public async Task Work()
        {
            await Context.Channel.SendMessageAsync("League of legends", false);
        }
        [Command("Wait")]
        public async Task Wait()
        {
            await Context.Channel.SendMessageAsync("WAIT WAIT WAIT WAIT", false);
        }
        [Command("Alpha")]
        public async Task Alpha()
        {
            await Context.Channel.SendMessageAsync("ENGAGE ENGAGE ENGAGE BANCHODES STOP BEING BETA", false);
        }
        [Command("Beta")]
        public async Task Beta()
        {
            await Context.Channel.SendMessageAsync("hey guys fawad syed here gonna mute mic and cs like a beta", false);
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
        [Command("CanadianDollar")]
        public async Task CanadianDollar()
        {
            const string address = "https://api.fixer.io/latest?base=CAD";
            var client = new HttpClient();
            var goldJSON = await client.GetStringAsync(address);
            var goldObject = JObject.Parse(goldJSON);
            var goldPrice = (double)goldObject["rates"][selectedCurrency];
            await Context.Channel.SendMessageAsync("$1 Canadian is $" + goldPrice + " in USD");
        }
        [Command("CanadianDollar")]
        public async Task CanadianDollar(string currencyType)
        {
            if (currencyType == null || currencyType.Length == 0)
            {
                currencyType = "USD";
            }
            currencyType=currencyType.ToUpper();
            const string address = "https://api.fixer.io/latest?base=CAD";
            var client = new HttpClient();
            var goldJSON = await client.GetStringAsync(address);
            var goldObject = JObject.Parse(goldJSON);
            var goldPrice = (double)goldObject["rates"][currencyType];
            await Context.Channel.SendMessageAsync("$1 Canadian is " + goldPrice+" in "+currencyType);
        }
        [Command("Tesla")]
        public async Task Tesla()
        {
            const string address = "https://www.quandl.com/api/v3/datasets/SSE/TL0.json?api_key=NW6eAik2ebsCLuEgsEhA";
            var client = new HttpClient();
            var bitcoinJSON = await client.GetStringAsync(address);
            var bitcoinObject = JObject.Parse(bitcoinJSON);
            var bitcoinPrice = (double) bitcoinObject["data"]["2018-09-12"];
            await Context.Channel.SendMessageAsync("This is the current price of bitcoin in USD: " + bitcoinPrice);
        }

    }
}
