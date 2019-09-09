using RBot;
using System.Linq;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		
		bot.Skills.StartTimer();
		
		bot.Player.LoadBank();
		bot.Inventory.BankAllCoinItems();
		bot.Bank.ToInventory("Essence of Nulgath");
		bot.Bank.ToInventory("Totem of Nulgath");
		
		Totems(bot, 30);
	}
	
	public void Totems(ScriptInterface bot, int amount){
		if(bot.Map.Name != "tercessuinotlim"){
	        bot.Player.Join("citadel", "m22", "Right");
            bot.Player.Join("tercessuinotlim", "Enter", "Spawn");
        }
        bool makai = true;
        bot.RegisterHandler(10, (a) => {
        	if(!makai)
        		return;
			int aliveCount = bot.Monsters.CurrentMonsters.Sum(x => x.HP > 0 ? 1 : 0);
			if(aliveCount == 0){
				bot.Wait.ForCombatExit();
				if(bot.Player.Cell == "m2")
					bot.Player.Jump("m1", "Right");
				else
					bot.Player.Jump("m2", "Center");
			}
		});
        bot.Player.Jump("m2", "Center");
        bot.Player.SetSpawnPoint();
		while(!bot.Inventory.Contains("Totem of Nulgath", amount) && !bot.ShouldExit()){
			bot.Quests.EnsureAccept(726);
			
			makai = true;
			bot.Player.Jump("m2", "Center");
			bot.Player.KillForItem("Dark Makai", "Essence of Nulgath", 100, false, true);
			makai = false;
			
			bot.Player.Jump("m10C", "Right");
			bot.Player.KillForItem("Tainted Elemental", "Lesser Tainted Core", 1, true);
			
			bot.Quests.EnsureComplete(726);
			
			bot.Wait.ForPickup("Totem of Nulgath");
			bot.Player.Pickup("Totem of Nulgath");
		}
	}
}
