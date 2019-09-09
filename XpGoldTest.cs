using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		
		while(!bot.ShouldExit()){
			bot.Quests.Accept(4601);
			bot.Quests.Complete(4601);
		}
	}
}
