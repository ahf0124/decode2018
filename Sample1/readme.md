# WebChatBot との連携を行う LogicFlow

 WebChat で入力された文字列を LogicFlow に送信し、編集を行い結果を Bot からのメッセージとして連携する。<br />

### 全体図
 ![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample1/websample1_1.png)		<br />

### 作成手順
Web App Bot を新規に作成します。<br />
ポータル上から「リソースの作成」をクリック、bot と入力して検索を行うと Web App Bot が表示されるので、それをクリックします。<br />
![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample1/websample1_3.png)		<br />
作成をクリックします。<br />
![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample1/websample1_4.png)		<br />
作成する Web App Bot の詳細設定を行います。注意が必要な点として、利用する料金プランは F0 の無償プランを選択すると開発中は費用が発生しません。実運用する際には、別プランへ切り替えることで無用な出費を抑えることが可能です。<br />
![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample1/websample1_5.png)		<br />
App Service Plan は新規に作成しても、既存のものを指定してもどちらでも大丈夫です。<br />
![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample1/websample1_6.png)		<br />
Web App Bot が作成されたら、メニューにある「ビルド」をクリックし、「オンライン コード エディターを開く」をクリックします。<br />
![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample1/websample1_7.png)		<br />
App Service Editor が起動しますので、Dialogs フォルダにある EchoDialog.cs ファイルをクリックします。表示されたコードのうち、赤枠で囲まれた箇所を書き換えます。<br />
![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample1/websample1_2.png)		<br />
コードを書き替えたら、ビルドを行います。赤枠で囲まれたアイコンをクリックすると、コマンドラインが表示されますので、
build.cmd と入力して Enter を押します。<br />
![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample1/websample1_8.png)		<br />
![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample1/websample1_9.png)		<br />
入力間違いがなければ、ビルドは成功し、Azure 上で実行できる状態となります。<br />
<br />
 <a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fahf0124%2Fdecode2018%2Fmaster%2FSample1%2FWebChatLogicApps.json" target="_blank">		
     <img src="http://azuredeploy.net/deploybutton.png"/>		
 </a>		<br />
上の Deploy ボタンをクリックし LogicFlow を作成します。<br />
<br />
LogicFlow が作成されたら Azure ポータルへ戻り、Web チャットでテストをクリックします。右側に Web チャットが表示されますので、何か文字を入力します。<br />
![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample1/websample1_10.png)		<br />
このように、入力した文字数が付与された形で返信があれば、正常に動作しています。<br />
![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample1/websample1_11.png)		<br />
