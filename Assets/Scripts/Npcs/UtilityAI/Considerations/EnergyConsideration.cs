using UnityEngine;

[CreateAssetMenu(fileName = "EnergyConsideration", menuName = "ScriptableObjects/Consideration/Energy Consideration", order = 1)]
public class EnergyConsideration : Consideration
{
    [SerializeField] private AnimationCurve responseCurve;
    public override float ScoreConsideration(NPCController npc)
    {
        score = responseCurve.Evaluate(Mathf.Clamp01(npc.needs.energy / 100f));
        return score;
    }
}