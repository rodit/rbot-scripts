Packets
======
#### Sending to Server
Packets can be sent from the client to the server easily through `ScriptInterface#SendPacket`. For example, to send the rest packet, you can use:

```csharp
bot.SendPacket("%xt%zm%restRequest%1%%");
```

#### Simulating Server Packets
You can also simulate packets being sent from the server to the client