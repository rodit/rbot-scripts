using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.ExitCombatBeforeQuest = true;
		
		bot.Skills.StartTimer();
		
		if(bot.Quests.IsDailyComplete(3596))
			return;
		
		bot.Player.LoadBank();
		bot.Bank.ToInventory("Dage's Scroll Fragment");
		
		if(bot.Bank.Contains("Dage's Scroll Fragment", 13))
			return;
		
		bot.Player.Join("mountdoomskull");
		bot.Quests.EnsureAccept(3596);
		
		bot.Player.HuntForItem("Chaos Drow|Chaos Spider|Chaos Warrior|Chaorrupted Mage", "Chaos Power Increased", 6, true);
		
		bot.Quests.EnsureComplete(3596);
		
		bot.Wait.ForDrop("Dage's Scroll Fragment");
		bot.Player.Pickup("Dage's Scroll Fragment");
	}
}
