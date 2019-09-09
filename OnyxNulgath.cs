using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.InfiniteRange = true;
		
		bot.Player.Join("citadel", "m22", "Right");
		bot.Player.Join("tercessuinotlim", "Enter", "Spawn");
		bot.Player.Jump("m4", "Center");
		
		bot.Player.KillForItem("Shadow of Nulgath", "Hadean Onyx of Nulgath", 1);
	}
}
