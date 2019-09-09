using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.RestPackets = false;
		bot.Player.Join("mysteriousdungeon-48e71");
		while(!bot.ShouldExit()){
			while(!bot.Inventory.ContainsTempItem("Escape")){
				bot.SendPacket("%xt%zm%getMapItem%0%4818%");
				bot.Sleep(800);
			}
			bot.SendPacket("%xt%zm%tryQuestComplete%0%5438%-1%false%wvz%");
			bot.Sleep(800);
		}
	}
}
