using System;
using UnityEngine;

[CreateAssetMenu(fileName = "HungerConsideration", menuName = "ScriptableObjects/Consideration/Hunger Consideration", order = 1)]
public class HungerConsideration : Consideration
{
    [SerializeField] private AnimationCurve responseCurve;
    public override float ScoreConsideration(NPCController npc)
    {
        score = responseCurve.Evaluate(Mathf.Clamp01(npc.needs.hunger / 100f));
        return score;
    }
}
