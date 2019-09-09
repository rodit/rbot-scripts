using RBot;
using System;

public class Script{

	public void ScriptMain(ScriptInterface bot){
		bot.Skills.StartTimer();
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		
		bot.Player.LoadBank();
		bot.Inventory.BankAllCoinItems();
		
		bot.Player.Join("evilwarnul", "r2", "Up");
		
		bot.Bank.ToInventory("Archfiend's Favor");
		bot.Bank.ToInventory("Nulgath's Approval");
		
		bot.Player.HuntForItems("Legion Fenrir|Skull Warrior|Skeletal Warrior|Undead Bruiser|Undead Infantry", new string[] { "Nulgath's Approval", "Archfiend's Favor" }, new int[] { 1000, 5000 });
	}
}