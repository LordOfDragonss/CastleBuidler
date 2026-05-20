using UnityEngine;

[CreateAssetMenu(fileName = "Sleep", menuName = "ScriptableObjects/Jobs/Sleep", order = 1)]
public class Sleep : Job
{
    public int TimeToSleep;
    public override void Execute(NPCController npc)
    {
        npc.DoSleep(TimeToSleep);
    }
}
