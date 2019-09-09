using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
	
		bot.Skills.StartTimer();
		
		bot.Player.LoadBank();
		bot.Inventory.BankAllCoinItems();
		bot.Bank.ToInventory("Astral Ephemerite Essence");
		bot.Bank.ToInventory("Belrot the Fiend Essence");
		bot.Bank.ToInventory("Black Knight Essence");
		bot.Bank.ToInventory("Tiger Leech Essence");
		bot.Bank.ToInventory("Carnax Essence");
		bot.Bank.ToInventory("Chaos Vordred Essence");
		bot.Bank.ToInventory("Dai Tengu Essence");
		bot.Bank.ToInventory("Unending Avatar Essence");
		bot.Bank.ToInventory("Void Dragon Essence");
		bot.Bank.ToInventory("Creature Creation Essence");
		
		while(!bot.ShouldExit()){
			bot.Quests.EnsureAccept(4432);
			
			bot.Player.Join("timespace");
			bot.Player.HuntForItem("Astral Ephemerite", "Astral Ephemerite Essence", 20);
			
			bot.Player.Join("citadel");
			bot.Player.HuntForItem("Belrot the Fiend", "Belrot the Fiend Essence", 20);
			
			bot.Player.Join("greenguardwest");
			bot.Player.HuntForItem("Black Knight", "Black Knight Essence", 20);
			
			bot.Player.Join("mudluk");
			bot.Player.HuntForItem("Tiger Leech", "Tiger Leech Essence", 20);
			
			bot.Player.Join("aqlesson");
			bot.Player.HuntForItem("Carnax", "Carnax Essence", 20);
			
			bot.Player.Join("necrocavern");
			bot.Player.HuntForItem("Chaos Vordred", "Chaos Vordred Essence", 20);
			
			bot.Player.Join("hachiko");
			bot.Player.HuntForItem("Dai Tengu", "Dai Tengu Essence", 20);
			
			bot.Player.Join("timevoid");
			bot.Player.HuntForItem("Unending Avatar", "Unending Avatar Essence", 20);
			
			bot.Player.Join("dragonchallenge");
			bot.Player.HuntForItem("Void Dragon", "Void Dragon Essence", 20);
			
			bot.Player.Join("maul");
			bot.Player.HuntForItem("Creature Creation", "Creature Creation Essence", 20);
			
			bot.Quests.EnsureComplete(4432);
			
			bot.Wait.ForDrop("Void Aura");
			bot.Player.Pickup("Void Aura");
		}
	}
}
