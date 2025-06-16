using MelonLoader;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using SuperBoost;

[assembly: MelonInfo(typeof(SuperBoost.SuperBoost), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace SuperBoost;

public class SuperBoost : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<SuperBoost>("SuperBoost loaded!");
    }

    public override void OnNewGameModel(GameModel result)
    {
        base.OnNewGameModel(result);

        if (!Settings.ModEnabled) return;

        MelonLogger.Msg("Applying SuperBoost...");

        foreach (var engineer in result.GetTowersWithBaseId("EngineerMonkey"))
        {
            if (engineer.tiers[1] != 5) continue;
            
            var ability = engineer.GetAbility();
            if (ability != null)
            {
                PatchUboost(ability);
            }
        }
    }

    private static void PatchUboost(AbilityModel uboost)
    {
        var stackModel = uboost.GetBehavior<OverclockPermanentModel>();

        if (stackModel == null) return;
        
        uboost.cooldown = 0;
        uboost.Cooldown = 0;
        uboost.startOffCooldown = true;
        uboost.maxActivationsPerRound = int.MaxValue;

        stackModel.rateModifier = 0.6f;
        stackModel.villageRangeModifier = 1.25f;
        stackModel.maxStacks = 1;
    }
}