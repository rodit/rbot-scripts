using RBot;

public class Script {

	//Required inventory space: 26
	//Requires ownership of Voucher of Nulgath (non-mem), Nation Round 4 Medal
	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.ExitCombatBeforeQuest = true;
		
		bot.Skills.StartTimer();
		
		bot.Player.LoadBank();
		bot.Inventory.BankAllCoinItems();
		bot.Bank.ToInventory("Emblem of Nulgath");
		bot.Bank.ToInventory("Fiend Seal");
		bot.Bank.ToInventory("Gem of Domination");
			
		while(!bot.ShouldExit()){
			if(bot.Map.Name != "shadowblast")
				bot.Player.Join("shadowblast");
			
			bot.Quests.EnsureAccept(4748);
			
			bot.Player.HuntForItems("Legion Fenrir|Legion Cannon|Legion Airstrike|Paragon|DoomBringer|DoomKnight Prime|Draconic DoomKnight|Shadow Destroyer|Shadowrise Guard", new string[] { "Gem of Domination", "Fiend Seal" }, new int[] { 1, 25 });
			
			bot.Quests.EnsureComplete(4748);
			bot.Wait.ForDrop("Emblem of Nulgath");
			bot.Player.Pickup("Emblem of Nulgath");
		}
	}
}
