using RBot;
using System.Windows.Forms;

public class Script {

	private const int COUNT = 1;
	
	int iterations = 0;

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.ExitCombatBeforeQuest = true;
		
		bot.Player.LoadBank();
		
		bot.Skills.StartTimer();
        
        while(!bot.ShouldExit()){
        	
	        DefeatedMakai(bot, COUNT * 50);
	        bot.Player.Jump("Enter", "Spawn");
	        bot.Sleep(2000);
	        EscherionChain(bot, COUNT);
	        bot.Player.Jump("Portal", "Right");
	        bot.Log("Escherion's Chain: Done");
	        bot.Sleep(2000);
	        OdokuroTooth(bot, COUNT);
	        bot.Player.Jump("Enter", "Spawn");
            bot.Log("O-Dokuru's Tooth: Done");
	        bot.Sleep(2000);
	        VathHair(bot, COUNT);
	        bot.Player.Jump("Quest", "Left");
            bot.Log("Vath's Hair: Done");
	        bot.Sleep(2000);
	        AracaraFang(bot, COUNT);
	        bot.Player.Jump("Enter", "Spawn");
	        bot.Log("Aracara's Fang: Done");
	        bot.Sleep(2000);
	        HydraScale(bot, COUNT);
	        bot.Player.Jump("Enter", "Spawn");
	        bot.Log("Hydra Scale: Done");
	        bot.Sleep(2000);
	        
	        bot.Bank.ToInventory("Defeated Makai");
	        bot.Bank.ToInventory("Escherion's Chain");
	        bot.Bank.ToInventory("O-dokuro's Tooth");
	        bot.Bank.ToInventory("Strand of Vath's Hair");
	        bot.Bank.ToInventory("Aracara's Fang");
	        bot.Bank.ToInventory("Hydra Scale");
	        
	        for(int i = 0; i < COUNT; i++){
        		bot.Quests.EnsureAccept(570);
        		
        		if(bot.Map.Name != "djinn")
        			bot.Player.Join("djinn", "r5", "Center");
        			
        		bot.Player.HuntForItem("Tibicenas", "Tibicenas' Chain", 1, true);
        		
		        bot.Quests.EnsureComplete(570);
		        	
		        bot.Wait.ForDrop("Dark Crystal Shard", 10);
		       	bot.Bank.StackGlitch("Dark Crystal Shard");
	        }
	        iterations++;
	        Application.OpenForms[0].Text = "RBot - Done " + iterations;
        }
	}
	
	public void DefeatedMakai(ScriptInterface bot, int count){
		if(bot.Bank.Contains("Defeated Makai", count))
			return;
		bot.Inventory.BankAllCoinItems();
		if(bot.Map.Name != "tercessuinotlim"){
	        bot.Player.Join("citadel", "m22", "Right");
            bot.Player.Join("tercessuinotlim", "Enter", "Spawn");
        }
       	bot.Bank.ToInventory("Defeated Makai");
        
        bot.Player.SetSpawnPoint();
        
        bot.Player.HuntForItem("Dark Makai", "Defeated Makai", 50);
        
        bot.Player.Jump("Enter", "Spawn1");
	}
	
	public void EscherionChain(ScriptInterface bot, int count){
		if(bot.Bank.Contains("Escherion's Chain", count))
			return;
		bot.Player.Join("escherion", "Boss", "Left");
		bot.Player.SetSpawnPoint();
		bot.Inventory.BankAllCoinItems();
		
		bot.Player.HuntForItem("Escherion", "Escherion's Chain", 1);
	}
	
	public void OdokuroTooth(ScriptInterface bot, int count){
		if(bot.Bank.Contains("O-dokuro's Tooth", count))
			return;
		bot.Player.Join("yokaiwar", "Boss", "Left");
		bot.Player.SetSpawnPoint();
		bot.Inventory.BankAllCoinItems();
		
		bot.Player.HuntForItem("O-Dokuro's Head", "O-dokuro's Tooth", 1);
	}
	
	public void VathHair(ScriptInterface bot, int count){
		if(bot.Bank.Contains("Strand of Vath's Hair", count))
			return;
		bot.Player.Join("stalagbite", "r2", "Center");
		bot.Player.SetSpawnPoint();
		bot.Inventory.BankAllCoinItems();
		
		bot.Player.HuntForItem("Vath", "Strand of Vath's Hair", 1);
	}
	
	public void AracaraFang(ScriptInterface bot, int count){
		if(bot.Bank.Contains("Aracara's Fang", count))
			return;
		bot.Player.Join("faerie", "TopRock", "Center");
		bot.Player.SetSpawnPoint();
		bot.Inventory.BankAllCoinItems();
		
		bot.Player.HuntForItem("Aracara", "Aracara's Fang", 1);
	}
	
	public void HydraScale(ScriptInterface bot, int count){
		if(bot.Bank.Contains("Hydra Scale", count))
			return;
		bot.Player.Join("hydra", "Boss", "Left");
		bot.Player.SetSpawnPoint();
		bot.Inventory.BankAllCoinItems();
		
		bot.Player.HuntForItem("Hydra Head", "Hydra Scale", 1);
	}
}
