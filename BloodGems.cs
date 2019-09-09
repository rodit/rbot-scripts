using RBot;
using System.Threading;
using System.Windows.Forms;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Events.PlayerDeath += (a) => { ScriptManager.RestartScript(); };
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.ExitCombatBeforeQuest = true;
		
		bot.Skills.StartTimer();
		
		bot.Player.LoadBank();
		bot.Inventory.BankAllCoinItems();
		
		bot.Bank.ToInventory("Fragment of Chaos");
		bot.Bank.ToInventory("Essence of Nulgath");
		bot.Bank.ToInventory("Archfiend's Favor");
		bot.Bank.ToInventory("Nulgath's Approval");
		bot.Bank.ToInventory("Blood Gem of the Archfiend");
		bot.Bank.ToInventory("Tendurrr the Assistant");
		
		while(!bot.ShouldExit()){
			bot.Quests.EnsureAccept(3743);
			
			if(bot.Map.Name != "northlands")
				bot.Player.Join("northlands", "r2", "Left");
			
			bot.Player.HuntForItem("Chaos Gemrald|Frostwyrm Rider|Water Draconian", "Fragment of Chaos", 80);
				
			bot.Player.Jump("Enter", "Spawn");
			
			if(!bot.Inventory.Contains("Tendurrr the Assistant")){
				if(bot.Map.Name != "tercessuinotlim"){
					bot.Player.Join("citadel", "m22", "Right");
					bot.Player.Join("tercessuinotlim", "Enter", "Spawn");
				}

				bot.Player.HuntForItems("Dark Makai", new string[] { "Tendurrr the Assistant", "Essence of Nulgath" }, new int[] { 1, 1 });
				
				bot.Player.Jump("Enter", "Spawn");
			}
			
			
			while(!bot.Inventory.ContainsTempItem("Broken Betrayal Blade", 8)){
				if(bot.Map.Name != "evilwarnul")
					bot.Player.Join("evilwarnul", "r12", "Left");
				bot.Player.HuntForItem("Legion Fenrir", "Broken Betrayal Blade", 1, true);
				bot.Player.AddTempItem(25183, 1000000);
			}
			
			bot.Quests.EnsureComplete(3743);
			
			bot.Wait.ForDrop("Blood Gem of the Archfiend");
			bot.Player.Pickup("Blood Gem of the Archfiend");
			bot.Player.RejectExcept("Blood Gem of the Archfiend");
		}
	}
}