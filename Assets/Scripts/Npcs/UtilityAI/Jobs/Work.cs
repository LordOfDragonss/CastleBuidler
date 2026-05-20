using UnityEngine;

[CreateAssetMenu(fileName = "Work", menuName = "ScriptableObjects/Jobs/Work", order = 1)]
public class Work : Job
{
    public int TimeToDoWork;
    public override void Execute(NPCController npc)
    {
        npc.DoWork(TimeToDoWork);
    }
}
