using GameNetcodeStuff;
using HarmonyLib;
using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace TzpHealth.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    public class TzpeqHealth
    {
        static float delay = 0.3f;
        static float ltah;

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        private static void TzpequalsHealth(PlayerControllerB __instance)
        {
            if (__instance.health < 99) {
                if(__instance.drunkness > 0.00001)
                {
                    if(Time.time > ltah + delay)
                    {
                        float healthaddfloat = 1 + __instance.drunkness;
                        int healthadd = (int)Math.Round(healthaddfloat);
                        __instance.health += healthadd;
                        __instance.DamagePlayerClientRpc(-healthadd, __instance.health);
                        HUDManager.Instance.UpdateHealthUI(__instance.health, false);
                        ltah = Time.time;
                    }

                }
            }

        }

    }
}