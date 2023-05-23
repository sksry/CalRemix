﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent;
using ReLogic.Content;
using Terraria.Graphics.Shaders;
using CalamityMod.DataStructures;
using CalamityMod;

namespace CalRemix.Projectiles.Accessories
{
    public class MarniteOrb : ModProjectile
    {
        public override string Texture => "CalamityMod/Projectiles/Magic/AsteroidMolten";
        internal PrimitiveTrail TrailDrawer;
        NPC target;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Orb");
        }

        public override void SetDefaults()
        {
            Projectile.width = 60;
            Projectile.height = 60;
            Projectile.friendly = true;
            Projectile.penetrate = 5;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 600;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, 0.6f, 0.2f, 0.7f);
            Projectile.ai[0]++;
            Projectile.rotation = Projectile.velocity.ToRotation();
            if (target == null || target.active == false || target.dontTakeDamage)
            {
                target = Projectile.Center.ClosestNPCAt(1200f, true);
            }
            else
            {
                if (Projectile.ai[0] >= 30)
                {
                    CalamityMod.CalamityUtils.HomeInOnNPC(Projectile, false, 1200, 20, 1);
                }
            }
        }
        internal Color ColorFunction(float completionRatio)
        {
            return Color.Lerp(Color.Blue, Color.LightBlue, 0.8f) * 0.8f;
        }

        internal float WidthFunction(float completionRatio)
        {
            float expansionCompletion = (float)Math.Pow(1 - completionRatio, 1);
            return MathHelper.Lerp(0f, 20 * Projectile.scale, expansionCompletion);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D tex = ModContent.Request<Texture2D>(Texture).Value;
            Main.EntitySpriteDraw(tex, Projectile.Center - Main.screenPosition, null, Color.Blue, Projectile.rotation, tex.Size() / 2f, Projectile.scale, SpriteEffects.None, 0);

            if (TrailDrawer is null)
                TrailDrawer = new PrimitiveTrail(WidthFunction, ColorFunction, specialShader: GameShaders.Misc["CalamityMod:TrailStreak"]);

            GameShaders.Misc["CalamityMod:TrailStreak"].SetShaderTexture(ModContent.Request<Texture2D>("CalamityMod/ExtraTextures/Trails/ScarletDevilStreak"));
            TrailDrawer.Draw(Projectile.oldPos, Projectile.Size * 1f - Main.screenPosition, 10);


            return false;
        }
    }
}
