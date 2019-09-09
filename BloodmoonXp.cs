using RBot;
using System.Linq;

public class Script {

	public void ScriptMain(ScriptInterface bot){
		bot.Options.SafeTimings = true;
		bot.Options.RestPackets = true;
		
		bot.Skills.StartTimer();
		
		bot.Player.Join("bloodmoon", "r3", "Left");
		int room = 3;
		while(!bot.ShouldExit()){
			room = room == 3 ? 2 : 3;
			bot.Player.Jump("r" + room, "Left");
			while(bot.Monsters.CurrentMonsters.Sum(x => x.HP) > 0)
				bot.Player.Kill("Darkness");
		}
	}
}
