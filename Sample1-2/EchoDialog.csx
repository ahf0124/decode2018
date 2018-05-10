using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

// For more information about this template visit http://aka.ms/azurebots-csharp-basic
[Serializable]
public class EchoDialog : IDialog<object>
{
    protected int count = 1;

    public Task StartAsync(IDialogContext context)
    {
        try
        {
            context.Wait(MessageReceivedAsync);
        }
        catch (OperationCanceledException error)
        {
            return Task.FromCanceled(error.CancellationToken);
        }
        catch (Exception error)
        {
            return Task.FromException(error);
        }

        return Task.CompletedTask;
    }

    public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
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
            //var logicappsUrl = "[Logic Apps で生成された URL]";
            var logicappsUrl = "https://prod-31.westcentralus.logic.azure.com:443/workflows/c73c2cf351864f58a28dc4d33b70ba15/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=4oH6NWgNaIZtuet9od1b9KxKu9dhS2V3AenUN9f2B9w";
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