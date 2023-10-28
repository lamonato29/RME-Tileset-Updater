/**
 * Developed by Lamonato29
 * https://github.com/lamonato29
 */
namespace GeneralParser
{
    public static class URLService
    {
        private static string mainURL = @"https://tibia.fandom.com/wiki/";
        public static Dictionary<string,string> GetCategoryLinks(string enumTypeName)
        {
            string type = "GeneralParser.URLService+" + enumTypeName;
            Type enumType = Type.GetType(type);
            if (enumType == null || !enumType.IsEnum)
            {
                throw new ArgumentException("Invalid enum type name");
            }

            var categories = Enum.GetValues(enumType);
            var categoryLinks = new Dictionary<string, string>();

            foreach (var category in categories)
            {
                categoryLinks.Add(mainURL + category.ToString(), category.ToString());
            }

            return categoryLinks;
        }
        public static List<string> GetAllCategories()
        {
            List<string> allCat = new();
            allCat.AddRange(Enum.GetNames(typeof(BodyEquipment)).ToList());
            allCat.AddRange(Enum.GetNames(typeof(Weapons)).ToList());
            allCat.AddRange(Enum.GetNames(typeof(Household)).ToList());
            allCat.AddRange(Enum.GetNames(typeof(CreatureProducts)).ToList());
            allCat.AddRange(Enum.GetNames(typeof(Food)).ToList());
            allCat.AddRange(Enum.GetNames(typeof(Liquids)).ToList());
            allCat.AddRange(Enum.GetNames(typeof(Plants)).ToList());
            allCat.AddRange(Enum.GetNames(typeof(Others)).ToList());
            return allCat;
        }
        public enum Categories
        {
            BodyEquipment,
            Weapons,
            Household,
            CreatureProducts,
            Food,
            Liquids,
            Plants,
            Others
        }
        public enum BodyEquipment
        {
            Amulets,
            Rings,
            Helmets,
            Armors,
            Legs,
            Boots,
            Shields,
            Spellbooks,
            Quivers
        }
        public enum Weapons
        {
            Axe_Weapons,
            Club_Weapons,
            Sword_Weapons,
            Rods,
            Wands,
            Distance_Weapons,
            Ammunition
        }
        public enum Household
        {
            Books,
            Carpets,
            Containers,
            Contest_Prizes,
            Fansite_Items,
            Decorations,
            Documents_and_Papers,
            Dolls_and_Bears,
            Furniture,
            Kitchen_Tools,
            Musical_Instruments,
            Trophies
        }
        public enum CreatureProducts
        {
            Creature_Products
        }
        public enum Food
        {
            Food
        }
        public enum Liquids
        {
            Liquids
        }
        public enum Plants
        {
            Plants
        }
        public enum Others
        {
            Keys,
            Tools,
            Light_Sources,
            Taming_Items,
            Clothing_Accessories,
            Enchanted_Items,
            Game_Tokens,
            Valuables,
            Magical_Items,
            Metals,
            Party_Items,
            Blessing_Charms,
            Quest_Items,
            Rubbish,
            Runes
        }

        
    }
}