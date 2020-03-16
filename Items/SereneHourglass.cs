using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace FracturedSkies.Items
{
    public class SereneHourglass : ModItem
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.mana = 100;
            item.useTurn = true;
            item.useAnimation = 20;
            item.useTime = 20;
            item.autoReuse = false;
            item.maxStack = 1;
            item.consumable = false;
            item.width = 12;
            item.height = 12;
            item.value = 3000;
        }
        public override bool UseItem(Player player)
        {
            if (!Main.dayTime) {
                Main.time = 32400;
                return true;
            }
            return false;
        }
    }
}
