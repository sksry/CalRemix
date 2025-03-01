using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.UI.CalamitasEnchants;
using CalRemix.CrossCompatibility.OutboundCompatibility;
using CalRemix.NPCs;
using CalRemix.NPCs.Minibosses;
using CalRemix.NPCs.Bosses;
using CalRemix.NPCs.Bosses.Wulfwyrm;
using CalRemix.Items.Accessories;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ModLoader;
using Terraria.Localization;
using ReLogic.Content;
using Terraria.GameContent;
using ReLogic;
using Terraria.ID;
using Microsoft.Xna.Framework;
using CalRemix.Backgrounds.Plague;
using Terraria.Audio;
using Terraria.Graphics.Effects;
using Microsoft.Xna.Framework.Graphics;
using CalamityMod.Items.Materials;
using CalRemix.Retheme;
using CalRemix.Items.Placeables;
using CalamityMod.Items.Pets;

namespace CalRemix
{
    public class CalRemix : Mod
    {
        public static CalRemix instance;
        public static int CosmiliteCoinCurrencyId;
        public static int KlepticoinCurrencyId;
        public Mod VeinMiner;

        public static List<int> oreList = new List<int>
        {
            TileID.Copper,
            TileID.Tin,
            TileID.Iron,
            TileID.Lead,
            TileID.Silver,
            TileID.Tungsten,
            TileID.Gold,
            TileID.Platinum
        };

        public override void PostSetupContent()
        {
            Mod cal = ModLoader.GetMod("CalamityMod");
            cal.Call("RegisterModCooldowns", this);
            cal.Call("DeclareMiniboss", ModContent.NPCType<LifeSlime>());
            cal.Call("DeclareMiniboss", ModContent.NPCType<Clamitas>());
            cal.Call("DeclareMiniboss", ModContent.NPCType<OnyxKinsman>());
            cal.Call("DeclareMiniboss", ModContent.NPCType<CyberDraedon>());
            cal.Call("DeclareMiniboss", ModContent.NPCType<PlagueEmperor>());
            cal.Call("DeclareMiniboss", ModContent.NPCType<YggdrasilEnt>());
            cal.Call("DeclareMiniboss", ModContent.NPCType<KingMinnowsPrime>());
            cal.Call("MakeItemExhumable", ModContent.ItemType<YharimsGift>(), ModContent.ItemType<YharimsCurse>());
            /*cal.Call("DeclareOneToManyRelationshipForHealthBar", ModContent.NPCType<DerellectBoss>(), ModContent.NPCType<SignalDrone>());
            cal.Call("DeclareOneToManyRelationshipForHealthBar", ModContent.NPCType<DerellectBoss>(), ModContent.NPCType<DerellectPlug>());
			{
				Mod bossChecklist;
				ModLoader.TryGetMod("BossChecklist", out bossChecklist);
				if (bossChecklist != null)
				{
					bossChecklist.Call(new object[12]
				{
				"AddBoss",
				12.5f,
				ModContent.NPCType<NPCs.Bosses.DerellectBoss>(),
				this,
				"The Derellect",
				(Func<bool>)(() => CalRemixWorld.downedDerellect),
				ModContent.ItemType<CalamityMod.Items.Pets.BloodyVein>(),
				null,
				new List<int>
				{
					ModLoader.GetMod("CalamityMod").Find<ModItem>("BloodyVein").Type
				},
				$"Damage the Mechanical Worm using a [i:{ModContent.ItemType<CalamityMod.Items.Pets.BloodyVein>()}]. But why would you do that?",
				"The Derellect returns to the scrap heap...",
				null
				});
				}
			}*/
            ModLoader.TryGetMod("BossChecklist", out Mod bossChecklist);
            if (bossChecklist != null)
            {
                Action<SpriteBatch, Rectangle, Color> portrait = (SpriteBatch sb, Rectangle rect, Color color) => {
                    Texture2D texture = ModContent.Request<Texture2D>("CalRemix/NPCs/Bosses/Wulfwyrm/WulfwyrmBossChecklist").Value;
                    Vector2 centered = new Vector2(rect.Center.X - (texture.Width / 2), rect.Center.Y - (texture.Height / 2));
                    sb.Draw(texture, centered, null, color, 0, Vector2.Zero, 0.8f, SpriteEffects.None, 0);
                };
                bossChecklist.Call("LogBoss", this, "WulfrumExcavator", 0.22f, () => CalRemixWorld.downedExcavator, ModContent.NPCType<WulfwyrmHead>(), new Dictionary<string, object>()
                {
                    ["spawnItems"] = ModContent.ItemType<EnergyCore>(),
                    ["customPortrait"] = portrait
                });
                bossChecklist.Call("LogMiniBoss", this, "Clamitas", 6.8f, () => CalRemixWorld.downedClamitas, ModContent.NPCType<Clamitas>(), new Dictionary<string, object>());
                Action<SpriteBatch, Rectangle, Color> cdPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
                    Texture2D texture = ModContent.Request<Texture2D>("CalRemix/NPCs/Minibosses/CyberDraedon").Value;
                    Vector2 centered = new Vector2(rect.Center.X - (texture.Width / 2), rect.Center.Y - (texture.Height / 2));
                    sb.Draw(texture, centered, null, new Color(0, 255, 255, 125), 0, Vector2.Zero, 0.8f, SpriteEffects.None, 0);
                };
                bossChecklist.Call("LogMiniBoss", this, "CyberDraedon", 3.99999f, () => CalRemixWorld.downedCyberDraedon, ModContent.NPCType<CyberDraedon>(), new Dictionary<string, object>()
                {
                    ["spawnItems"] = ModContent.ItemType<BloodyVein>(),
                    ["customPortrait"] = cdPortrait
                });
                bossChecklist.Call("LogMiniBoss", this, "KingMinnowsPrime", 18.1f, () => CalRemixWorld.downedKingMinnowsPrime, ModContent.NPCType<KingMinnowsPrime>(), new Dictionary<string, object>());
                bossChecklist.Call("LogMiniBoss", this, "LaRuga", 20.2f, () => CalRemixWorld.downedLaRuga, ModContent.NPCType<LaRuga>(), new Dictionary<string, object>());
                bossChecklist.Call("LogMiniBoss", this, "LifeSlime", 16.7f, () => CalRemixWorld.downedLifeSlime, ModContent.NPCType<LifeSlime>(), new Dictionary<string, object>());
                bossChecklist.Call("LogMiniBoss", this, "OnyxKinsman", 7.5f, () => CalRemixWorld.downedOnyxKinsman, ModContent.NPCType<OnyxKinsman>(), new Dictionary<string, object>());
                bossChecklist.Call("LogMiniBoss", this, "PlagueEmperor", 21.5f, () => CalRemixWorld.downedPlagueEmperor, ModContent.NPCType<PlagueEmperor>(), new Dictionary<string, object>());
                bossChecklist.Call("LogMiniBoss", this, "YggdrasilEnt", 18.2f, () => CalRemixWorld.downedYggdrasilEnt, ModContent.NPCType<YggdrasilEnt>(), new Dictionary<string, object>());
            }
            ModLoader.TryGetMod("Wikithis", out Mod wikithis);
            if (wikithis != null && !Main.dedServ)
            {
                wikithis.Call("AddModURL", this, "https://terrariamods.wiki.gg/wiki/Calamity_Community_Remix/{}");
            }
            LocalizedText fallacious = Language.GetOrRegister($"Mods.{nameof(CalRemix)}.Enchantments.Fallacious.Name");
            LocalizedText fallaciousDesc = Language.GetOrRegister($"Mods.{nameof(CalRemix)}.Enchantments.Fallacious.Description");
            cal.Call("CreateEnchantment", fallacious, fallaciousDesc, 156, new Predicate<Item>(Enchantable), "CalRemix/ExtraTextures/Enchantments/EnchantmentRuneFallacious", delegate (Player player)
            {
                player.GetModPlayer<CalRemixPlayer>().amongusEnchant = true;
            });
            List<(int, int, Action<int>, int, bool, float, int[], int[])> brEntries = (List<(int, int, Action<int>, int, bool, float, int[], int[])>)cal.Call("GetBossRushEntries");
            int[] excIDs = { ModContent.NPCType<WulfwyrmBody>(), ModContent.NPCType<WulfwyrmTail>() };
            int[] headID = { ModContent.NPCType<WulfwyrmHead>() };
            Action<int> pr = delegate (int npc)
            {
                NPC.SpawnOnPlayer(CalamityMod.Events.BossRushEvent.ClosestPlayerToWorldCenter, ModContent.NPCType<WulfwyrmHead>());
            };
            brEntries.Insert(0, (ModContent.NPCType<WulfwyrmHead>(), -1, pr, 180, false, 0f, excIDs, headID));
            cal.Call("SetBossRushEntries", brEntries);

            /* I hate enchantments
            EnchantmentManager.EnchantmentList.Add(new Enchantment("Fallacious", "Greatly increases critical strike damage but critical strike chance is reduced. Critical hits also hurt you.\nDoes nothing for now.", 156, "CalRemix/ExtraTextures/Enchantments/EnchantmentRuneFallacious", null, delegate (Player player)
            {
                player.GetModPlayer<CalRemixPlayer>().amongusEnchant = true;
            }, (Item item) => item.IsEnchantable() && item.damage > 0 && !item.CountsAsClass<SummonDamageClass>() && !item.IsWhip()));
            EnchantmentManager.EnchantmentList.Add(new Enchantment("Defiant", "Dealing damage increases defense and damage but defense damage taken is increased.\nDoes nothing for now.", 157, "CalRemix/ExtraTextures/Enchantments/EnchantmentRuneDefiant", null, delegate (Player player)
            {
                player.GetModPlayer<CalRemixPlayer>().earthEnchant = true;
            }, (Item item) => item.IsEnchantable() && item.damage > 0 && !item.CountsAsClass<SummonDamageClass>() && !item.IsWhip()));
			*/
            if (Main.netMode != NetmodeID.Server)
            {
                Main.QueueMainThreadAction(() =>
                {
                    cal.Call("LoadParticleInstances", instance);
                });
            }
        }

        public override void Load()
        {
            instance = this;
            PlagueGlobalNPC.PlagueHelper = new PlagueJungleHelper();

            if (!Main.dedServ)
            {
                Filters.Scene["CalRemix:PlagueBiome"] = new Filter(new PlagueSkyData("FilterMiniTower").UseColor(Color.Green).UseOpacity(0.15f), EffectPriority.VeryHigh);
                SkyManager.Instance["CalRemix:PlagueBiome"] = new PlagueSky();
            }
            CosmiliteCoinCurrencyId = CustomCurrencyManager.RegisterCurrency(new Items.CosmiliteCoinCurrency(ModContent.ItemType<Items.CosmiliteCoin>(), 100L, "Mods.CalRemix.Currencies.CosmiliteCoinCurrency"));
            KlepticoinCurrencyId = CustomCurrencyManager.RegisterCurrency(new Items.KlepticoinCurrency(ModContent.ItemType<Items.Klepticoin>(), 100L, "Mods.CalRemix.Currencies.Klepticoin"));
            ModLoader.TryGetMod("OreExcavator", out VeinMiner);
        }
        public override void Unload()
        {
            PlagueGlobalNPC.PlagueHelper = null;
            instance = null;
            VeinMiner = null;
        }

        public static bool Enchantable(Item item)
        {
            return item.IsEnchantable() && item.damage > 0 && !item.CountsAsClass<SummonDamageClass>() && !item.IsWhip();
        }
        // Defer mod call handling to the extraneous mod call manager.
        public override object Call(params object[] args) => ModCallManager.Call(args);
        public static void AddToShop(int type, int price, ref Chest shop, ref int nextSlot, bool condition = true, int specialMoney = 0)
        {
            if (!condition || shop is null) return;
            shop.item[nextSlot].SetDefaults(type);
            shop.item[nextSlot].shopCustomPrice = price > 0 ? price : shop.item[nextSlot].value;
            if (specialMoney == 1) shop.item[nextSlot].shopSpecialCurrency = CosmiliteCoinCurrencyId;
            else if (specialMoney == 2) shop.item[nextSlot].shopSpecialCurrency = KlepticoinCurrencyId;
            nextSlot++;
        }
    }
}