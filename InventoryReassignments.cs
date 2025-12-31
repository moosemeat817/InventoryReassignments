using MelonLoader;
using MelonLoader.Utils;

namespace InventoryReassignments
{
    public class Main : MelonMod
    {

        public override void OnInitializeMelon()
        {
            MelonLogger.Msg("InventoryReassignments is online.");
            Settings.OnLoad();    // ModSettings
        }


    }
}
