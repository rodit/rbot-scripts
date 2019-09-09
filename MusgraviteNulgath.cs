using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		
		bot.Skills.StartTimer();
		
		bot.Player.Join("timelibrary", "Frame9", "Left");
		bot.Player.KillForItem("Ancient Chest", "Musgravite of Nulgath", 2);
	}
}
