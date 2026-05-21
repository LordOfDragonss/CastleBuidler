using UnityEngine;

[CreateAssetMenu(fileName = "MoneyConsideration", menuName = "ScriptableObjects/Consideration/Money Consideration", order = 1)]
public class MoneyConsideration : Consideration
{
    [SerializeField] private AnimationCurve responseCurve;
    public override float ScoreConsideration(NPCController npc)
    {
        score = responseCurve.Evaluate(Mathf.Clamp01(npc.needs.money / 100f));
        return score;
    }
}
