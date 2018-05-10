using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Microsoft.Bot.Sample.SimpleEchoBot
{
    [Serializable]
    public class EchoDialog : IDialog<object>
    {
        protected int count = 1;

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;

            if (message.Text == "reset")
            {
                PromptDialog.Confirm(
                    context,
                    AfterResetAsync,
                    "Are you sure you want to reset the count?",
                    "Didn't get that!",
                    promptStyle: PromptStyle.Auto);
            }
            else
            {
                var logicappsUrl = "[Logic Apps で生成された URL]";
                //メッセージを編集する Logic Apps を呼び出す
                var msg = "";
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content =  new StringContent(JsonConvert.SerializeObject(message), System.Text.Encoding.UTF8, "application/json");
                //Logic Apps の HTTP Request コネクタで生成される URL を指定して呼び出す
                var response = await client.PostAsync(logicappsUrl,content);
                 if (response.IsSuccessStatusCode)
                 {
                     //呼出が成功した場合、結果を文字列として取得する
                      msg = await response.Content.ReadAsStringAsync();
                 }else{
                     msg = message.Text;
                 }
                 //結果を返却する
                await context.PostAsync($"{this.count++}: You said {msg}");
                context.Wait(MessageReceivedAsync);
            }
        }

        public async Task AfterResetAsync(IDialogContext context, IAwaitable<bool> argument)
        {
            var confirm = await argument;
            if (confirm)
            {
                this.count = 1;
                await context.PostAsync("Reset count.");
            }
            else
            {
                await context.PostAsync("Did not reset count.");
            }
            context.Wait(MessageReceivedAsync);
        }

    }
}
