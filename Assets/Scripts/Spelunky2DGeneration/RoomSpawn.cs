using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
    public GameObject[] rooms;
    bool flag = false;
    // Update is called once per frame
    void Update()
    {
        if(DungeonGeneration.FIRSTSTAGEDONE && !flag)
        {
            flag = true;
            //generate room
            int r = Random.Range(0, rooms.Length);
            Instantiate(rooms[r], transform);
        }
    }
}
