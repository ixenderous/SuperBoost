using BTD_Mod_Helper.Api.Data;
using BTD_Mod_Helper.Api.ModOptions;

namespace SuperBoost;

public class Settings : ModSettings
{
    public static readonly ModSettingBool ModEnabled = new(true)
    {
        description = "When enabled, replaces Ultraboost stacks with 1 big stack that does the same thing and removes Ultraboost ability cooldown. Only works in sandbox. Must be enabled when joining a sandbox match."
    };
}