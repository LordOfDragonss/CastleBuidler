using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class NPCController : MonoBehaviour
{
    public MoveController mover { get; set; }
    public AIBrain aiBrain { get; set; }
    public Job[] JobsAvailable;
    public NPCNeeds needs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mover = GetComponent<MoveController>();
        aiBrain = GetComponent<AIBrain>();
        needs = GetComponent<NPCNeeds>();
    }
    // Update is called once per frame
    void Update()
    {
        needs.UpdateEnergy();
        needs.UpdateHunger();
        if (aiBrain.finishedDeciding)
        {
            aiBrain.finishedDeciding = false;
            aiBrain.BestJob.Execute(this);
        }
    }
    #region Coroutines
    public void DoWork(int time)
    {
        StartCoroutine(WorkCoroutine(time));
    }
    public void DoSleep(int time)
    {
        StartCoroutine(SleepCoroutine(time));
    }

    IEnumerator WorkCoroutine(int time)
    {
        int counter = time;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }

        Debug.Log("I am working");
        needs.money += 1;


        OnFinishedJob();

    }

    IEnumerator SleepCoroutine(int time)
    {
        int counter = time;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }

        Debug.Log("i just Sleeped and gained energy");
        needs.energy += 1;
        OnFinishedJob();
    }
    #endregion
    public void OnFinishedJob()
    {
        aiBrain.DecideBestJob(JobsAvailable);
    }
}
