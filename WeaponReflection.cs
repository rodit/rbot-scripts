using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		
		bot.Skills.StartTimer();
		
		bot.Player.Join("nostalgiaquest");
		while(!bot.ShouldExit()){
			bot.Quests.EnsureAccept(5518);
			
			bot.Player.HuntForItems("Skeletal Warrior|Skeletal Viking", new string[] { "Reflected Glory", "Divided Light" }, new int[] { 5, 5 }, true);
			
			bot.Quests.EnsureComplete(5518);
			bot.Wait.ForDrop("Weapon Reflection");
			bot.Player.Pickup("Weapon Reflection");
		}
	}
}
