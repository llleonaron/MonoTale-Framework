using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoTale.Core.Components.Battle;

internal class Enemy
{
    private string EnemyName { get; set; }

    private double EnemyHealth { get; set; }
    private double EnemyHealthMax { get; set; }

    private float EnemyAttack { get; set; }
    private float EnemyDefense { get; set; }
    private float EnemyEnergy { get; set; }

    private int[] EnemyPostBattleReward { get; set; }

    private Texture2D EnemySprite { get; set; }
    private Texture2D EnemyHurtSprite { get; set; }

    private Texture2D[] EnemySpriteParts { get; set; }

    private bool EnemyCanSpare  { get; set; }
    private bool EnemyCanFakeSpare { get; set; }
    private bool EnemyCanFlee { get; set; }
    private bool EnemyCanDisplayHealthBar { get; set; }
    
    private bool EnemyCanDodge { get; set; }
    
    private bool EnemyInvulnerable { get; set; }
    
    private bool EnemySpared { get; set; }
    private bool EnemyFallen { get; set; }
    
    private List<int> EnemyActionList { get; set; }
    private List<int> EnemyActionSceneList { get; set; }

    private void MakeEnemyInvulnerable()
    {
        if (EnemyInvulnerable)
        {
            EnemyHealth = double.PositiveInfinity;
            EnemyHealthMax = double.PositiveInfinity;
        }
    }

    private int EnemyMercyResistance { get; set; }
    private int EnemyMercyResistanceMax { get; set; }

    private int EnemyMercyResistancePercentage => ((EnemyMercyResistanceMax / EnemyMercyResistance) * 100);
}