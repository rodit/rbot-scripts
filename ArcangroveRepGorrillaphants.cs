using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		
		bot.Skills.StartTimer();
		
		bot.Player.Join("arcangrove");
		while(!bot.ShouldExit()){
			bot.Quests.EnsureAccept(795);
			
			bot.Player.HuntForItem("Gorillaphant", "Slain Gorillaphant", 7, true);
			
			bot.Quests.EnsureComplete(795);
		}
	}
}
