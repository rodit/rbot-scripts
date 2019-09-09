using RBot;
using System.Threading;
using System.Linq;
using System.Diagnostics;

public class Script {

	//This script will do the 'Only the strong survive today' quest (ID 2219) until 300 diamonds of nulgath have been obtained.
	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		
		bot.Player.LoadBank();
		bot.Inventory.BankAllCoinItems();
		bot.Bank.ToInventory("Unidentified 13");
		bot.Bank.ToInventory("Dessicated Heart");
		bot.Bank.ToInventory("Legion Blade");
		
		bot.Skills.StartTimer();
		
		Diamonds(bot, 300);
	}
	
	public void Diamonds(ScriptInterface bot, int amount){
		//The following items are added to the drop collector.
		//Since KillForItems (see below) can only kill for inventory items OR quest items (i.e. not both) at a time, we must have another mechanism for picking up the inventory items which are required for the quest.
		bot.Drops.Add("Dessicated Heart");
		bot.Drops.Add("Legion Blade");
		bot.Drops.Add("Diamond of Nulgath");
		//Reject other trash:
		bot.Drops.RejectElse = true;
		bot.Player.Join("evilwarnul", "r2", "Up");
		//Every 4 ticks (1 second), the number of living mosters (with HP > 0) is polled. If this number is 0, we move to a different cell to find enemies.
		bot.RegisterHandler(4, (a) => {
			int aliveCount = bot.Monsters.CurrentMonsters.Sum(x => x.HP > 0 ? 1 : 0);
			if(aliveCount == 0){
				bot.Wait.ForCombatExit();
				if(bot.Player.Cell == "r3")
					bot.Player.Jump("r2", "Up");
				else
					bot.Player.Jump("r3", "Right");
			}
		});
		//Accept quest, get quest items, and turn in quest until we have the correct number of diamonds (or until the user stops the script, hence the second condition '!bot.ShouldExit()').
		while(!bot.Bank.Contains("Diamond of Nulgath", amount) && !bot.ShouldExit()){
			bot.Quests.EnsureAccept(2219);
			bot.Drops.Start();
			
			bot.Player.Jump("r2", "Up");
			bot.Player.KillForItems("*", new string[] { "Legion Champion Medal", "Undead Skull", "Legion Helm" }, new int[] { 5, 3, 5 }, true, false);
			
			bot.Drops.Stop();
			bot.Player.KillForItems("*", new string[] { "Dessicated Heart", "Legion Blade" }, new int[] { 20, 1 });
			
			bot.Quests.EnsureComplete(2219);
			bot.Wait.ForDrop("Diamond of Nulgath");
			bot.Bank.StackGlitch("Diamond of Nulgath");
		}
		//Stop the drop grabber (we don't need it anymore).
		bot.Drops.Stop();
	}
}
