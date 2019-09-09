using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		
		bot.Skills.StartTimer();
		
		bot.Player.Join("ultradrakath");
		
		bot.Player.HuntForItem("Champion of Chaos", "Face of Chaos", 1);
	}
}
