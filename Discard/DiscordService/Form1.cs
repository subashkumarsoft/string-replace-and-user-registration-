using DiscordMessenger;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public class Datum
        {
            public List<string> edit_history_tweet_ids { get; set; }
            public string text { get; set; }
            public string id { get; set; }
            public DateTime created_at { get; set; }
        }

        public class Meta
        {
            public string next_token { get; set; }
            public int result_count { get; set; }
            public string newest_id { get; set; }
            public string oldest_id { get; set; }
        }

        public class Root
        {
            public List<Datum> data { get; set; }
            public Meta meta { get; set; }
        }


        public static void sendDisWebook(string URL, String json)
        {
            var wr = WebRequest.Create(URL);
            wr.Timeout = 60;
            wr.ContentType = "application/x-www-urlencoded";
            wr.Method = "POST";
            using (var sw = new StreamWriter(wr.GetRequestStream()))
                sw.Write(json);
            wr.GetResponse();


        }

        public static string wsdata()
        {

            try
            {

                var handler = new HttpClientHandler();
                using (var client = new HttpClient(handler))
                {

                    var url = "https://api.twitter.com/2/users/44196397/tweets?tweet.fields=created_at&user.fields=description,entities,id,name,username";


                    var httpRequest = (HttpWebRequest)WebRequest.Create(url);

                    httpRequest.Accept = "application/json";
                    httpRequest.Headers["Authorization"] = "Bearer AAAAAAAAAAAAAAAAAAAAAErkjQEAAAAA5EmYzuRNTQKrbAG%2BcwSErdsI53I%3DA8mW4EfTJyYdwlCkX4H6nKjoP2sY8H10NqHRgvdEMz47rdL85T";

                    var result = "";
                    var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();
                        return result;
                    }

                    Console.WriteLine(httpResponse.StatusCode);

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public static string GetResponseContent(HttpResponseMessage response)
        {
            HttpContent stream = response.Content;
            var data = stream.ReadAsStringAsync();
            string dataString = data.Result.ToString();
            return dataString;
        }

        public static async Task PostAsync(string test)
        {
            DiscordMessage discord = new DiscordMessage();
            discord.SetAvatar("")
          .AddEmbed()
          .SetTimestamp(DateTime.Now)
          .SetTitle("Alert")
          .SetAuthor("Baskarn.K")
          .SetDescription(test)
          //.SetColor((int)discordColor)
          //.SetFooter("Footer Text Here")
          .Build()
          .SendMessage("https://discord.com/api/webhooks/1043975042347835513/DV50HjPlxd05GeDaxd6EmG5ugOWtMoKjOJg4FL8fzFM-JUnTVX9HSXAj2ZHMy7h4Ag5I");
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

            var ws_result = wsdata();

            try
            {

                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(ws_result);
                var tweets = myDeserializedClass.data;


                for (int i = 1; tweets.Count > i; i++)
                {

                    int timeout = 1000;
                    var task = PostAsync(tweets[i].text);
                    if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
                    {
                        // task completed within timeout
                    }
                    else
                    {
                        // timeout logic
                    }

                }
            }
            catch (Exception ex)
            {

            }

            var message = new DiscordMessage
            {
                Content = "Alert",
                Embeds = new List<Embed>()
                {
                    new Embed
                    {
                        Description="Alert"
                    }
                }
            };
        }
    }
}
