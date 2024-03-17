## Universal Market Manager


### Step 1 - Import package:
Import latest unity package from [releases](https://github.com/salehb02/cafe-bazaar-intents/releases) section.

<img src="https://github.com/salehb02/cafe-bazaar-intents/blob/main/Media/import.png?raw=true"/><br/><br/>

### Step 2 - Setup fields:
Setup package in 'UMM -> Market Settings'.<br>
<b>\* 'Bazaar Developer ID' is optional. Fill it if you wanted to use OpenDeveloperApps method.</b>

<img src="https://github.com/salehb02/cafe-bazaar-intents/blob/main/Media/setup.png?raw=true"/><br/><br/>

### Step 3 - Use it:
Include 'UMM' namespace to your code and call these:
```c#
MarketIntents.OpenAppDetails();
MarketIntents.OpenRating();
MarketIntents.OpenDeveloperApps();
MarketIntents.OpenMarketLogin();
```
<br>

<img src="https://github.com/salehb02/cafe-bazaar-intents/blob/main/Media/use.png?raw=true"/>

<br>
<b>Or</b>
<br>
<br>

You can just put IntentButton.cs next to your button component. It'll call your wanted method automatically!

<img src="https://github.com/salehb02/cafe-bazaar-intents/blob/main/Media/button use.png?raw=true"/>

### Step 4 - Build:
Now use 'UMM/Build!' to build for supported markets at once!<br><br>
### - Currently supported markets: -
```
Myket
Cafe Bazaar
```
<br>
<br>

<b>Done!</b>
