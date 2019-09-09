using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		
		bot.Skills.StartTimer();
		
		bot.Player.Join("icestormarena", "r3c", "Left");
		while(!bot.ShouldExit()){
			bot.Player.Kill("Frost Spirit");
		}
	}
}
