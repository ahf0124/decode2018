# WebChatBot との連携を行う LogicFlow

 WebChat で入力された文字列を LogicFlow に送信し、編集を行い結果を Bot からのメッセージとして連携する。<br />
 
 <a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fahf0124%2Fdecode2018%2Fmaster%2FSample1%2FWebChatLogicApps.json" target="_blank">		
     <img src="http://azuredeploy.net/deploybutton.png"/>		
 </a>		

上の Deploy ボタンをクリック、または新規に作成した Logic Apps で CodeView を開き、WebChatLogicApps.json ファイルの中身を貼り付けして LogicFlow を作成します。
 ![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample1/websample1_1.png)		

Web App Bot を新規に作成します。
ポータル上から「リソースの作成」をクリック、bot と入力して検索を行うと Web App Bot が表示されるので、それをクリックします。
![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample1/websample1_3.png)		
作成をクリックします。
![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample1/websample1_4.png)		
作成する Web App Bot の詳細設定を行います。注意が必要な点として、利用する料金プランは F0 の無償プランを選択すると開発中は費用が発生しません。実運用する際には、別プランへ切り替えることで無用な出費を抑えることが可能です。
![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample1/websample1_5.png)		
App Service Plan は新規に作成しても、既存のものを指定してもどちらでも大丈夫です。
![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample1/websample1_6.png)		
Web App Bot が作成されたら、メニューにある「ビルド」をクリックし、「オンライン コード エディターを開く」をクリックします。
![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample1/websample1_7.png)		
App Service Editor が起動しますので、Dialogs フォルダにある EchoDialog.cs ファイルをクリックします。表示されたコードのうち、赤枠で囲まれた箇所を書き換えます。
![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample1/websample1_2.png)		
コードを書き替えたら、ビルドを行います。赤枠で囲まれたアイコンをクリックすると、コマンドラインが表示されますので、
build.cmd と入力して Enter を押します。
![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample1/websample1_8.png)		
![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample1/websample1_9.png)		
入力間違いがなければ、ビルドは成功し、Azure 上で実行できる状態となります。

Azure ポータルへ戻り、Web チャットでテストをクリックします。右側に Web チャットが表示されますので、何か文字を入力します。
![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample1/websample1_10.png)		
このように、入力した文字数が付与された形で返信があれば、正常に動作しています。
![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample1/websample1_11.png)		
