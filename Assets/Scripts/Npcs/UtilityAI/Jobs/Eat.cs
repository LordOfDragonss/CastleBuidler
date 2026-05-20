using UnityEngine;

[CreateAssetMenu(fileName = "Eat", menuName = "ScriptableObjects/Jobs/Eat", order = 1)]
public class Eat : Job
{
    public override void Execute(NPCController npc)
    {
        Debug.Log("I ate some food, Now I'm not hungry anymore!");
        npc.needs.hunger -= 30;
        npc.needs.money -= 10;
        npc.OnFinishedJob();
    }
}
