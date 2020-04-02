Skills
======
It is recommended you load skills from an XML skills file created from the Skills form. If you would like to manually manage skills in your script, you can do this through `ScriptInterface#Skills`. Manual management is overridden by the UI by default (there is a checkbox to disable this override in the UI).

#### Methods
The following methods can be used to programatically manage skills. The method's return types are ommitted is they are all void.

`StartTimer()` - Starts the skill timer thread. This must be called for the bot to use skills whether you are using the skills form or manually managing skills (see example below). If the thread is already running, this method does nothing but replace the currently loaded skills with the UI override skills if they are set.

`StopTimer()` - Kills the skill timer thread if it is running. This will stop the bot from using any skills.

`Add(int index, float useThresh)` - Adds the skill with the given index to the timer. This skill will only be used when the player's health is below `useThresh`, where `useThresh` is a fraction of the player's health over the player's maximum health. A `useThresh` of `1f` indicates that the skill can always be used.

`Add(int index, UseRule rule)` - Adds the skill with the given index to ther timer to only be used when the given `UseRule` allows. See below about use rules.

`Remove(int index)` - Removex the skill with the given index from the timer. This skill will no longer be used unless it is added again.

`Clear()` - Clears all skills from the timer.

`LoadSkills(string xml)` - Loads a skill definition XML file which was created by the UI. `xml` is the path to the definition file which can be absolute or relative to the running directory of the bot.

`StartSkills(string xml)` - Loads a skill definition XML file and then restarts the skill timer.

#### Properties
The following properties can be modified to change the behaviour of the skill timer thread:

`int SkillTimer` - The time period in ms at which the timer cycles through skills and tries to use them. The default is 500ms.

#### Skill Use Rules
If you would like finer grained control over when skills are used, you can apply a `UseRule` to a skill at the given index. There are 3 rules which can be used in the UI:

1. `HealthUseRule` - Specifies a minimum and maximum health at which the skill can be used.
2. `ManaUseRule` - Specifies a minimum and maximum mana at which the skill can be used.
3. `CombinedUseRule` - Combines any number of other rules with the specified logical operator.

These are very simply understood using the UI skills editor.

You can also create your own use rules using a script. To do this, create a class that extends `UseRule` and override the `UseRule#ShouldUse` method. For example:

```csharp
using RBot;
using System;

public class Script
{
	public void ScriptMain(ScriptInterface bot)
	{
        bot.Skills.Add(1, new ExampleUseRule());
        // ...add other skills
        bot.Skills.StartTimer();

        // ...other bot code
	}

    public class ExampleUseRule : UseRule
    {
        public int Interval { get; set; } = 2000;

        private int lastUse = 0;

        public override bool ShouldUse(ScriptInterface bot)
        {
            if(Environment.TickCount - lastUse > Interval)
            {
                lastUse = Environment.TickCount;
                return true;
            }
            return false;
        }
    }
}
```

This allows the skill at index `1` to only be used every 2 seconds. In this example, `Interval` is configurable to change this 2 seconds to any other time.