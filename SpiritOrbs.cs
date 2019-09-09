using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.InfiniteRange = true;
		
		bot.Player.LoadBank();
		bot.Inventory.BankAllCoinItems();
		bot.Bank.ToInventory("Undead Energy");
		bot.Bank.ToInventory("Undead Essence");
		bot.Bank.ToInventory("Bone Dust");
		bot.Bank.ToInventory("Spirit Orb");
		
		bot.Skills.StartTimer();
        
        while(!bot.ShouldExit()){
        	if(bot.Map.Name != "battleunderb")
        		bot.Player.Join("battleunderb");
        	bot.Player.Jump("Enter", "Right");
        	
        	bot.Quests.EnsureAccept(2082);
        	bot.Quests.EnsureAccept(2083);
        	
        	bot.Player.HuntForItems("Skeleton Warrior|Skeleton Fighter", new string[] { "Bone Dust", "Undead Essence", "Undead Energy", "Spirit Orb" }, new int[] { 40, 25, 1, 1 });
        	bot.Player.Jump("Enter", "Right");
        	
        	bot.Sleep(500);
        	
        	while(bot.Quests.CanComplete(2082)){
        		bot.Quests.EnsureComplete(2082);
        		bot.Quests.EnsureAccept(2082);
        	}
        	
        	while(bot.Quests.CanComplete(2083)){
        		bot.Quests.EnsureComplete(2083);
        		bot.Quests.EnsureAccept(2083);
        	}
        	
        	bot.Wait.ForDrop("Spirit Orb");
        	bot.Player.Pickup("Spirit Orb");
        }
	}
}
