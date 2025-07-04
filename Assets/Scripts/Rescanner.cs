using System.Collections;
using UnityEngine;

public class Rescanner : MonoBehaviour
{
    public static bool SCANDONE = false;
    private void Update()
    {
        if (DungeonGeneration.FIRSTSTAGEDONE)
        {
            StartCoroutine(SetupScan());
        }
    }
    IEnumerator SetupScan()
    {
        yield return new WaitForEndOfFrame();
        if (!SCANDONE)
        {
            Debug.Log(" Rescanning path");
            AstarPath.active.Scan();
            SCANDONE = true;
        }
    }

}
