using RBot;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.RestPackets = true;
		bot.Options.SafeTimings = true;
		
		bot.Skills.StartTimer();
		
		bot.Inventory.BankAllCoinItems();
		bot.Bank.ToInventory("Roc Tongue");
		bot.Bank.ToInventory("Dragon Scale");
		bot.Bank.ToInventory("Courage Tonic");
		
		bot.Drops.Add("Roc Tongue");
		bot.Drops.Add("Dragon Scale");
		bot.Drops.Add("Courage Tonic");
		bot.Drops.RejectElse = true;
		bot.Drops.Start();
		while(!bot.ShouldExit()){
			while(!bot.Inventory.Contains("Roc Tongue", 5)){
				bot.Player.Join("roc-9911e11");
				bot.Player.Kill("Rock Roc");
				bot.Sleep(800);
			}
			while(!bot.Inventory.Contains("Dragon Scale", 5)){
				if(bot.Map.Name != "lair")
					bot.Player.Join("lair-9991e11");
				bot.Player.Jump("Hole", "Center");
				bot.Player.Kill("*");
				bot.Player.Kill("*");
				bot.Player.Kill("*");
				bot.Player.Jump("Bridge", "Center");
				bot.Player.Kill("*");
				bot.Player.Kill("*");
				bot.Player.Kill("*");
				bot.Player.Jump("Ledge", "Center");
				bot.Player.Kill("*");
				bot.Player.Kill("*");
				bot.Player.Kill("*");
			}
			/*
			bot.Player.Join("alchemy");
			for(int i = 0; i < 5; i++){
				bot.SendPacket("%xt%zm%crafting%1%checkAlchComplete%11475%11471%false%Mix Complete%Dragon Scale%Roc Tongue%Jera%End%");
				bot.Sleep(1200);
			}
			*/
		}
	}
}
