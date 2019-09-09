using RBot;
 
public class Script {
   
    public void ScriptMain(ScriptInterface bot){
        bot.Options.RestPackets = true;
        bot.Options.SafeTimings = true;
        
        bot.Skills.StartTimer();
 
        bot.Bank.ToInventory("Hydra Scale");
        bot.Player.Join("hydrachallenge");
        bot.Player.SetSpawnPoint();
        bot.Player.HuntForItem("Hydra Head 25|Hydra Head 35", "Hydra Scale", 300);
        bot.Inventory.ToBank("Hydra Scale");
        bot.Player.Join("Yulgar-1e21", "Enter", "Spawn");
    }
}