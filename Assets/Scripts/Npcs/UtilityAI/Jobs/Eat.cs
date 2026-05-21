using UnityEngine;

[CreateAssetMenu(fileName = "Eat", menuName = "ScriptableObjects/Jobs/Eat", order = 1)]
public class Eat : Job
{
    public override void Execute(NPCController npc)
    {
        Debug.Log("I ate some food");
        npc.needs.hunger -= 30;
        npc.needs.money -= 10;
        npc.aiBrain.finishedExecutingBestAction = true;
    }

    public override void SetRequiredDestination(NPCController npc)
    {
        RequiredDestination = npc.destinations.EatingChairDestination;
        npc.mover.MoveTo(RequiredDestination.position);
    }
}
