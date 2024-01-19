## Universal Market Manager for Unity v1.1.0


### Step 1 - Import package:
Import latest unity package from [releases](https://github.com/salehb02/cafe-bazaar-intents/releases) section.

<img src="https://github.com/salehb02/cafe-bazaar-intents/blob/main/Media/import.png?raw=true"/><br/><br/>

### Step 2 - Setup fields:
Setup package in 'UMM -> Market Settings'.<br>
<b>Don't foget to select market you wanna build for.</b>

<img src="https://github.com/salehb02/cafe-bazaar-intents/blob/main/Media/setup.png?raw=true"/><br/><br/>

### Step 3 - Use it:
Include 'UMM' namespace to your code and call these:
```c#
CafeIntents.OpenAppInBazaar();
CafeIntents.OpenComments();
CafeIntents.OpenDeveloperApps();
CafeIntents.OpenBazaarLogin();
```
<br>

<img src="https://github.com/salehb02/cafe-bazaar-intents/blob/main/Media/use.png?raw=true"/>

<br>
<b>Or</b>
<br>
<br>

You can just put IntentButton.cs next to your button component. It'll call your wanted method automatically!

<img src="https://github.com/salehb02/cafe-bazaar-intents/blob/main/Media/button use.png?raw=true"/>

<b>Done!</b>
