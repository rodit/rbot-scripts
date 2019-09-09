using RBot;

public class Script {
	
	public void ScriptMain(ScriptInterface bot){
		bot.Options.RestPackets = true;
		
		bot.Skills.Clear();
		bot.Skills.Add(2, 1f);
		bot.Skills.Add(3, 1f);
		bot.Skills.Add(2, 1f);
		bot.Skills.Add(4, 1f);
		bot.Skills.StartTimer();
		
		while(!bot.ShouldExit()){
			bot.Player.Kill("*");
		}
	}
}