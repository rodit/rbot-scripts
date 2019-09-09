using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		
		bot.Skills.StartTimer();
		
		bot.Player.Join("finalbattle");
		
		bot.Player.HuntForItem("Drakath", "Face of Chaos", 1);
	}
}
