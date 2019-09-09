using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.ExitCombatBeforeQuest = true;
		
		bot.Skills.StartTimer();
		
		bot.Inventory.BankAllCoinItems();
		bot.Bank.ToInventory("Bright Aura");
		bot.Bank.ToInventory("Spirit Orb");
		bot.Bank.ToInventory("Brilliant Aura");
		bot.Bank.ToInventory("Bone Dust");
		bot.Bank.ToInventory("Undead Essence");
		bot.Bank.ToInventory("Blinding Light Fragments");
		bot.Bank.ToInventory("Blinding Broadsword of Destiny");
		bot.Bank.ToInventory("Blinding Aura");
		
		bot.Player.Join("battleunderb");
		
		while(!bot.ShouldExit()){
			bot.Quests.EnsureAccept(2178);
        	bot.Quests.EnsureAccept(2082);
        	bot.Quests.EnsureAccept(2083);
			
			bot.Player.HuntForItems("Skeleton Warrior|Skeleton Fighter", new string[] { "Blinding Light Fragments", "Bone Dust", "Undead Essence" }, new int[] { 10, 1, 1 });
			
			bot.Sleep(500);
        	
        	while(bot.Quests.CanComplete(2082)){
        		bot.Quests.EnsureComplete(2082);
        		bot.Quests.EnsureAccept(2082);
        	}
        	
        	while(bot.Quests.CanComplete(2083)){
        		bot.Quests.EnsureComplete(2083);
        		bot.Quests.EnsureAccept(2083);
        	}
			bot.Quests.EnsureComplete(2178);
			
			bot.Wait.ForDrop("Bright Aura");
			bot.Player.Pickup("Bright Aura", "Spirit Orb", "Brilliant Aura", "Blinding Aura");
		}
	}
}
