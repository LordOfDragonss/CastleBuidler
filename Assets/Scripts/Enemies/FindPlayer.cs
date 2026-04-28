using Pathfinding;
using UnityEngine;

public class FindPlayer : MonoBehaviour
{
    public AIDestinationSetter Destination;

    public SecondDimensionPlayerController player;

    private void Start()
    {
    }

    private void Update()
    {
        if (Destination.target == null && DungeonGeneration.READYFORPLAYER) {

            player = FindAnyObjectByType<SecondDimensionPlayerController>();
            Destination.target = player.transform;
        }
    }
}
