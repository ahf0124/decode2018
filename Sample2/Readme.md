# LINE との連携を行う LogicFlow

 LINE から送信された画像を ComputeVision API を用いて OCR（文字列解析）を行い、読み取った文字列を返信します。<br />


### 全体図
![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample2/linesample_0.png)		<br />

### 作成手順
1. ComputeVision API のアカウントを作成しキーとエンドポイント URL を取得します。</br>
![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample2/linesample_0_1.png)		<br />
Azure ポータルの左部メニューより Cognitive Services をクリックし、追加をクリックします。<br />

![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample2/linesample_0_3.png)		<br />
作成をクリックします。<br />

![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample2/linesample_0_4.png)		<br />
名称（適当で大丈夫です）、利用するサブスクリプション、リージョン、価格プラン、リソースグループを設定します。<br />
この際、価格プランは F0 の無償プランを利用するのが開発時の費用が発生しないので便利です。<br />
また、設定したリージョンは後で利用しますので控えておいてください。<br />

![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample2/linesample_0_5.png)		<br />
作成が完了すると上記のように通知が行われます。

![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample2/linesample_0_6.png)		<br />
作成した API を参照し、Overview に表示されているエンドポイント URL を控えておきます。<br />

![LogicFlow](https://github.com/ahf0124/decode2018/blob/master/Sample2/linesample_0_7.png)		<br />
Keys に表示されるキー情報を控えておきます。Key1、Key2 どちらか片方で大丈夫です。<br />

2.LINE DEVLOPER 	<br />
[参考資料](https://www.slideshare.net/TomoyukiObi/develop-linebot-with-logicflow)	<br />
LINE DEVELOPER アカウントを作成し、BOT 用のチャンネルを準備します。	<br />

3. LogicFlow をデプロイします。	<br />
 <a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fahf0124%2Fdecode2018%2Fmaster%2FSample2%2Fdecode2018samplelinebot.json" target="_blank">		
     <img src="http://azuredeploy.net/deploybutton.png"/>		
 </a>		
上の Deploy ボタンをクリックし LogicFlow を作成します。<br />
