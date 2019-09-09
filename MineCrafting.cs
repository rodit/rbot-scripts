using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		
		bot.Skills.StartTimer();
		
		bot.Player.Join("stalagbite");
		bot.Drops.Add("Axe of the Prospector");
		bot.Drops.Add("Aluminium");
		bot.Drops.Add("Barium");
		bot.Drops.Add("Gold");
		bot.Drops.Add("Iron");
		bot.Drops.Add("Copper");
		bot.Drops.Add("Silver");
		bot.Drops.Add("Platinum");
		bot.Drops.RejectElse = true;
		bot.Drops.Start();
		while(!bot.ShouldExit()){
			bot.Quests.EnsureAccept(2091);
			
			bot.Player.HuntForItem("Balboa", "Raw Ore", 30, true, false);
			bot.Player.HuntForItem("Balboa", "Axe of the Prospector", 1, false, false);
			
			bot.Quests.EnsureComplete(2091);
		}
		bot.Drops.Stop();
	}
}