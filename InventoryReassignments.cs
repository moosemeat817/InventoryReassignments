using MelonLoader;
using MelonLoader.Utils;
using ComplexLogger;

namespace InventoryReassignments
{
    public class Main : MelonMod
    {
        internal static ComplexLogger<Main> Logger = new();
        public override void OnInitializeMelon()
        {
            Logger.Log("Improved Flasks is online.", FlaggedLoggingLevel.None);
            Settings.OnLoad();    // ModSettings
        }


    }
}
