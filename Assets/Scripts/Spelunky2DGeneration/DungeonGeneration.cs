using Pathfinding;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGeneration : MonoBehaviour
{
    public int length, height;

    public int scale;

    public GameObject[] startingRooms;
    public GameObject[] pathrooms; //0:LR 1:LRB, 2: LRT, 3: LRBT
    public GameObject[] fillerrooms;
    public GameObject[] endRooms;
    public GameObject edgeroom;

    private LayerManager layerManager;


    public GameObject[,] roomArray;
    public List<Vector2> loadedRooms;
    public int delayTime;

    [HideInInspector]
    public static bool FIRSTSTAGEDONE = false;
    public static bool READYFORPLAYER = false;

    int direction; //0 & 1 = right, 2 & 3 = left, 4 = down
    int delay = 0;

    [SerializeField]
    public static int seed;
    public bool randomizeSeed;

    private void Start()
    {
        layerManager = LayerManager.Instance;
        FIRSTSTAGEDONE = false;
        if (randomizeSeed && layerManager.IsNewLayer(layerManager.CurrentLayer))
            seed = Random.Range(0, 9999999);
        else if (!layerManager.IsNewLayer(layerManager.CurrentLayer))
        {
            seed = layerManager.GetCurrentLayerSeed();
        }
        roomArray = new GameObject[length, height];
        Random.InitState(seed);
        transform.position = new Vector2(Random.Range(0, length), 0);
        CreateRoom(startingRooms[0]);
        if (transform.position.x == 0)
            direction = 0;
        else if (transform.position.x == length - 1)
            direction = 2;
        else
            direction = Random.Range(0, 4);
    }

    private void Update()
    {
        if (!FIRSTSTAGEDONE && delay >= delayTime)
        {
            delay = 0;
            if (direction == 0 || direction == 1) // right
            {
                if (transform.position.x < length - 1)
                {
                    transform.position += Vector3.right;
                    int r = 0;
                    CreateRoom(pathrooms[r]);
                    direction = Random.Range(0, 5);
                    if (direction == 2)
                        direction = 1;
                    else if (direction == 3)
                        direction = 4;
                }
                else
                    direction = 4;
            }
            else if (direction == 2 || direction == 3)// left
            {
                if (transform.position.x > 0)
                {
                    transform.position += Vector3.left;
                    int r = 0;
                    CreateRoom(pathrooms[r]);
                    direction = Random.Range(0, 5);
                    if (direction == 0)
                    {
                        direction = 2;
                    }
                    else if (direction == 1)
                    {
                        direction = 4;
                    }
                }
                else
                    direction = 4;
            }
            else if (direction == 4)//down
            {
                if (transform.position.y > -height + 1)
                {
                    Destroy(GetRoom(transform.position));
                    int r = (Random.Range(0, 2) == 0) ? 1 : 3;
                    CreateRoom(pathrooms[r]);
                    transform.position += Vector3.down;
                    int rand = Random.Range(0, 4);
                    if (rand == 0)
                    {
                        if (transform.position.y > -height + 1)
                        {
                            CreateRoom(pathrooms[3]);
                            transform.position += Vector3.down;
                        }
                        else
                        {
                            direction = 4;
                            return;
                        }
                    }
                    int r1 = Random.Range(2, 4);
                    CreateRoom(pathrooms[r1]);
                    if (transform.position.x == 0)
                        direction = 0;
                    else if (transform.position.x == length - 1)
                        direction = 2;
                    else
                        direction = Random.Range(0, 4);
                }
                else
                {
                    Destroy(GetRoom(transform.position));
                    CreateRoom(endRooms[0]);
                    FillMap();
                    FillEdge();
                    FIRSTSTAGEDONE = true;

                    if (LayerManager.Instance.IsNewLayer(LayerManager.Instance.CurrentLayer))
                        layerManager.layers.Add(new Layer(layerManager.CurrentLayer, seed));
                    READYFORPLAYER = true;
                    Rescanner.SCANDONE = false;
                }
            }
        }
        else
        {
            delay++;
        }
    }



    void CreateRoom(GameObject room)
    {
        GameObject tempRoom = Instantiate(room, transform.position * scale, Quaternion.identity,transform);
        int x = (int)transform.position.x;
        int y = -(int)transform.position.y;
        roomArray[x, y] = tempRoom;
        loadedRooms.Add(new Vector2(x, y));
    }
    GameObject GetRoom(Vector2 pos)
    {
        return roomArray[(int)pos.x, -(int)pos.y];
    }

    void FillMap()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < length; x++)
            {
                if (!loadedRooms.Contains(new Vector2(x, y)))
                {
                    int r = Random.Range(0, fillerrooms.Length);
                    transform.position = new Vector2(x, -y);
                    CreateRoom(fillerrooms[r]);
                }
            }
        }
    }

    void FillEdge()
    {
        for (int y = 0; y < height; y++)
        {
            transform.position = new Vector2(length, -y);
            Instantiate(edgeroom, transform.position * scale, Quaternion.identity, transform);
            transform.position = new Vector2(-1, -y);
            Instantiate(edgeroom, transform.position * scale, Quaternion.identity, transform);
        }

        for (int x = 0; x < length; x++)
        {
            transform.position = new Vector2(x, -height);
            Instantiate(edgeroom, transform.position * scale, Quaternion.identity, transform);
            transform.position = new Vector2(x, 1);
            Instantiate(edgeroom, transform.position * scale, Quaternion.identity, transform);
        }
    }
}
