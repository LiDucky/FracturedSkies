using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace FracturedSkies.Items.Weapons
{
	public class Regret : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shoot an arrow that can eliminate anything...");
		}

		public override void SetDefaults() {
			item.damage = 40;
			item.noMelee = true;
			item.magic = true;
			item.mana = 50;
			item.rare = 5;
			item.width = 28;
			item.height = 30;
			item.useTime = 20;
			item.UseSound = SoundID.Item13;
			item.useStyle = 5;
			item.shootSpeed = 14f;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("RegretProjectile");
			item.value = Item.sellPrice(silver: 3);
		}
	}
}