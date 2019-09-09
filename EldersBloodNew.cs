using RBot;
using System.Windows.Forms;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Quests.EnsureAccept(802);
		if(bot.Quests.IsDailyComplete(802))
			MessageBox.Show("Daily quest has already been completed!");
		else{
			bot.Skills.StartTimer();
			bot.Options.RestPackets = true;
			
			bot.Player.Join("arcangrove", "Right", "Right");
			
			while(!bot.Inventory.ContainsTempItem("Slain Gorillaphant", 50)){
				bot.Player.Kill("Gorillaphant");
			}
			
			bot.Player.Jump("Back", "Right");//Get out of combat before turning in quest.
			
			bot.Quests.EnsureComplete(802);
			
			bot.Wait.ForDrop("Elder's Blood");
			bot.Player.Pickup("Elder's Blood");
		}
	}
}
