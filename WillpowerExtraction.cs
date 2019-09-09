using RBot;

public class Script {

	//Inventory space required: 22
	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		bot.Options.SkipCutsenes = true;
		bot.Options.ExitCombatBeforeQuest = true;
		
		bot.Skills.StartTimer();
		
		bot.Player.LoadBank();
		bot.Inventory.BankAllCoinItems();
		
		bot.Bank.ToInventory("Shadow Lich");
		bot.Bank.ToInventory("DragonFire of Nulgath");
		bot.Bank.ToInventory("Unidentified 19");
		bot.Bank.ToInventory("Essence of Nulgath");
		bot.Bank.ToInventory("Mystic Tribal Sword");
		bot.Bank.ToInventory("Doomatter");
		bot.Bank.ToInventory("Necrot");
		bot.Bank.ToInventory("Chaoroot");
		bot.Bank.ToInventory("Archfiend's Favor");
		bot.Bank.ToInventory("Mortality Cape of Revontheus");
		bot.Bank.ToInventory("King Klunk's Crown");
		bot.Bank.ToInventory("Facebreaker of Nulgath");
		bot.Bank.ToInventory("SightBlinder Axe of Nulgath");
		bot.Bank.ToInventory("Voucher of Nulgath (non-mem)");
        bot.Bank.ToInventory("Voucher of Nulgath");
        bot.Bank.ToInventory("Gem of Nulgath");
        bot.Bank.ToInventory("Dark Crystal Shard");
        bot.Bank.ToInventory("Tainted Gem");
        bot.Bank.ToInventory("Totem of Nulgath");
        bot.Bank.ToInventory("Diamond of Nulgath");
        bot.Bank.ToInventory("Unidentified 10");
        bot.Bank.ToInventory("Unidentified 13");
        bot.Bank.ToInventory("Unidentified 26");
        
        while(!bot.ShouldExit()){
        	bot.Quests.EnsureAccept(5258);
        	
			bot.Bank.ToInventory("Void Highlord");
			bot.Player.EquipItem("Void Highlord");
			bot.Skills.LoadSkills("Skills/VoidHighlord.xml");
		
			if(!bot.Inventory.Contains("Shadow Lich")){
				bot.Player.Join("shadowfall", "Inside", "Left");
				bot.Shops.Load(89);
				bot.Shops.BuyItem(89, "Shadow Lich");
			}
			
			if(!bot.Inventory.Contains("Mystic Tribal Sword")){
				bot.Player.Join("arcangrove");
				bot.Shops.Load(214);
				bot.Shops.BuyItem(214, "Mystic Tribal Sword");
			}
			
			if(!bot.Inventory.Contains("DragonFire of Nulgath")){
				bot.Quests.EnsureAccept(765);
				
				FarmNulgath(bot, "Totem of Nulgath", 3);
				bot.Player.Join("underworld");
				bot.Player.HuntForItem("Skull Warrior", "Nulgath Rune 4", 1, true);
				bot.Player.AddTempItem(15391, 1000);
				
				bot.Quests.EnsureComplete(765, 1316);
				bot.Wait.ForDrop("DragonFire of Nulgath");
				bot.Player.Pickup("DragonFire of Nulgath");
			}
			
			/*
			Supplies to Spin The Wheel
			bot.Player.EquipItem("Chaos Slayer Mystic");
			bot.Skills.LoadSkills("Skills/ChaosSlayer.xml");
			bot.Player.Join("escherion");
			while(!bot.Inventory.Contains("Unidentified 19")){
				bot.Quests.EnsureAccept(2857);
				bot.Player.HuntForItem("Escherion", "Escherion's Helm", 1);
				bot.Quests.EnsureComplete(2857, 4747);
				bot.Wait.ForDrop("Unidentified 10");
				bot.Player.Pickup("Unidentified 19", "Tainted Gem", "Dark Crystal Shard", "Diamond of Nulgath", "Voucher of Nulgath", "Voucher of Nulgath (non-mem)");
				bot.Player.RejectExcept("Unidentified 19", "Tainted Gem", "Dark Crystal Shard", "Diamond of Nulgath", "Voucher of Nulgath", "Voucher of Nulgath (non-mem)");
			}
			bot.Bank.ToInventory("Void Highlord");
			bot.Player.EquipItem("Void Highlord");
			bot.Skills.LoadSkills("Skills/VoidHighlord.xml");
			*/
			
			bot.Quests.EnsureAccept(2859);
			bot.Player.Join("underworld", "r2", "Left");
			bot.Player.HuntForItem("Legion Fenrir", "Nulgath Rune 3", 1, true);
			bot.Player.AddTempItem(15390, 100000);
			bot.Player.Join("yulgar");
			bot.Shops.Load(16);
			while(!bot.Inventory.Contains("Unidentified 19")){
				if(bot.Player.Gold < 500000){
					bot.Player.Join("greenguardwest");
					bot.Quests.EnsureAccept(236);
					bot.Player.HuntForItem("Big Bad Boar", "Were Egg", 1, true);
					bot.Player.AddTempItem(1051, 100000);
					while(bot.Player.Gold < 500000){
						bot.Quests.EnsureAccept(236);
						bot.Quests.EnsureComplete(236);
						bot.Wait.ForDrop("Berserker Bunny");
						bot.Player.Pickup("Berserker Bunny");
						bot.Shops.SellItem("Berserker Bunny");
					}
					bot.Player.Join("yulgar");
				}
				while(bot.Player.Gold >= 100000 && !bot.Inventory.Contains("Unidentified 19")){
					if(!bot.Inventory.Contains("Blood Cloak"))
						bot.Shops.BuyItem(16, "Blood Cloak");
					bot.Quests.EnsureAccept(2859);
					bot.Quests.EnsureComplete(2859);
					bot.Wait.ForDrop("DuckStick2000");
					bot.Player.Pickup("Unidentified 19", "Tainted Gem", "Dark Crystal Shard", "Diamond of Nulgath", "Voucher of Nulgath (non-mem)", "Unidentified 26");
					bot.Player.RejectExcept("Unidentified 19", "Tainted Gem", "Dark Crystal Shard", "Diamond of Nulgath", "Voucher of Nulgath (non-mem)", "Unidentified 26");
				}
			}
			
			bot.Player.Join("hydra");
			bot.Player.HuntForItem("Hydra Head", "Chaoroot", 5);
			
			bot.Player.Join("deathsrealm");
			bot.Player.HuntForItem("Skeleton Fighter", "Necrot", 5);
			
			bot.Player.Join("vordredboss");
			bot.Player.HuntForItem("Vordred|Ultra Vordred|Enraged Vordred", "Doomatter", 5);
			
			bot.Player.Join("underworld");
			
			if(!bot.Inventory.Contains("Mortality Cape of Revontheus")){
				bot.Shops.Load(452);
				bot.Player.HuntForItem("Blade Master|Skull Warrior|Legion Fenrir|Undead Bruiser|Undead Infantry", "Archfiend's Favor", 40, false);
				bot.Player.Jump("r11", "Left");
				bot.Shops.BuyItem(452, "Mortality Cape of Revontheus");
			}
			
			bot.Player.HuntForItem("Blade Master|Skull Warrior|Legion Fenrir|Undead Bruiser|Undead Infantry", "Archfiend's Favor", 50, false);
			bot.Player.RejectExcept("Archfiend's Favor", "King Klunk's Crown");
			
			bot.Player.HuntForItem("Legion Fenrir|Laken", "King Klunk's Crown", 1);
			
			if(!bot.Inventory.Contains("Essence of Nulgath", 10)){
				if(bot.Map.Name != "tercessuinotlim"){
			        bot.Player.Join("citadel", "m22", "Right");
		            bot.Player.Join("tercessuinotlim", "Enter", "Spawn");
	            }
	            
	            bot.Player.HuntForItem("Dark Makai", "Essence of Nulgath", 10);
			}
			
			while(!bot.Inventory.Contains("Facebreaker of Nulgath")){
				//Kindness of nulgath quest
				bot.Quests.EnsureAccept(3046);
				
				bot.Player.Join("citadel");
				bot.Player.HuntForItem("Grand Inquisitor", "Golden Shadow Breaker", 1);
				
				bot.Player.Join("battleundera");
				bot.Player.HuntForItem("Bone Terror", "Shadow Terror Axe", 1);
				
				FarmNulgath(bot, "Unidentified 13", 1);
				FarmNulgath(bot, "Tainted Gem", 5);
				FarmNulgath(bot, "Dark Crystal Shard", 5);
				FarmNulgath(bot, "Diamond of Nulgath", 1);
				
				bot.Quests.EnsureComplete(3046);
				
				bot.Sleep(5000);
				bot.Player.Pickup("Facebreaker of Nulgath", "SightBlinder Axe of Nulgath");
				bot.Sleep(5000);
			}
			
			bot.Quests.EnsureComplete(5258);
			bot.Wait.ForDrop("Unidentified 34");
			bot.Player.Pickup("Unidentified 34");
		}
		
	}
	
	public void FarmNulgath(ScriptInterface bot, string item, int quantity){
		bot.Bank.ToInventory(item);
		if(bot.Inventory.Contains(item, quantity))
			return;
        
        bot.Quests.EnsureAccept(2566);
        bot.Player.Join("gilead");
        bot.Player.HuntForItem("Mana Elemental", "Charged Mana Energy for Nulgath", 1, true);
        bot.Player.Join("elemental");
        bot.Player.HuntForItem("Mana Golem", "Mana Energy for Nulgath", 1, true);
        bot.Player.AddTempItem(6135, 100000);
        bot.Player.AddTempItem(15385, 100000);
        bot.Player.Jump("Enter", "Spawn");
        
        int accum = 0;
        while(!bot.Inventory.Contains(item, quantity)){
            bot.Quests.EnsureAccept(2566);
            bot.Quests.EnsureComplete(2566);
            
            accum++;
            if(accum == 10){
            	accum = 0;
            	bot.Player.Pickup("Unidentified 13", "Voucher of Nulgath (non-mem)", "Voucher of Nulgath", "Gem of Nulgath", "Dark Crystal Shard", "Tainted Gem", "Totem of Nulgath", "Unidentified 10", "Diamond of Nulgath");
            	bot.Player.RejectExcept("Unidentified 13", "Voucher of Nulgath (non-mem)", "Voucher of Nulgath", "Gem of Nulgath", "Dark Crystal Shard", "Tainted Gem", "Totem of Nulgath", "Unidentified 10", "Diamond of Nulgath");
            }
		}
	}
}
