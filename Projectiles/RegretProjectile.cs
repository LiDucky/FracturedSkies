using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FracturedSkies;

namespace Fracturedskies.Projectiles
{
	public class RegretProjectile : ModProjectile
	{
		public override void SetDefaults()
        {
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.timeLeft = 600;
			projectile.tileCollide = true;
            projectile.aiStyle = 1;
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
			projectile.Kill();
			return true;
		}
        public override void Kill(int timeLeft)
        {
            FracturedSkies.FracturedSkiesWorld.oreComet((int)(projectile.position.X/16), (int)(projectile.position.Y/16));
        }
    }
}