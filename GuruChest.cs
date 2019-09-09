using RBot;

public class Script {
	
	public void ScriptMain(ScriptInterface bot){
		bot.Options.RestPackets = true;
		bot.Options.SafeTimings = true;
		
		bot.Player.KillForItem("Guru Chest", "Pink Star Diamond of Nulgath", 1);
		bot.Player.Pickup("Pink Star Diamond of Nulgath");
	}
}