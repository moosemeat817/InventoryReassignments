using ModSettings;

namespace InventoryReassignments
{
    public class InventoryReassignments : JsonModSettings
    {

        [Name("Reassign Flasks")]
        [Description("Default is Tools")]
        [Choice("Default", "FirstAid", "Food", "FirstAid and Tools", "Food and Tools", "FirstAid, Food and Tools")]
        public int flasksMove = 0;

        [Name("Reassign Teas, Coffees and their ingredients")]
        [Description("Default is all over the place")]
        [Choice("Default", "FirstAid", "Food", "FirstAid and Food")]
        public int teasMove = 0;

        [Name("Reassign Accelerants")]
        [Description("Default is Tools")]
        [Choice("Default", "FireStarting", "Tools and FireStarting")]
        public int accelerrantsMove = 0;

    }

    internal static class Settings
    {
        public static InventoryReassignments options;

        public static void OnLoad()
        {
            options = new InventoryReassignments();
            options.AddToModSettings("Inventory Reassignments", MenuType.Both);
        }
    }

}