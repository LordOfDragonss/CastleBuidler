using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class NPCController : MonoBehaviour
{
    public enum State
    {
        decide,
        move,
        execute
    }
    public MoveController mover { get; set; }
    public AIBrain aiBrain { get; set; }
    public NPCNeeds needs;
    public NPCDestinations destinations { get; set; }
    private bool hasStartedAction;
    private State currentstate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mover = GetComponentInChildren<MoveController>();
        destinations = GetComponent<NPCDestinations>();
        aiBrain = GetComponent<AIBrain>();
        needs = GetComponent<NPCNeeds>();
    }
    // Update is called once per frame
    void Update()
    {

        //if (aiBrain.finishedDeciding)
        //{
        //    aiBrain.finishedDeciding = false;
        //    aiBrain.BestJob.Execute(this);
        //}
        needs.UpdateEnergy();
        needs.UpdateHunger();
        FSMTick();
    }

    public void FSMTick()
    {
        if (currentstate == State.decide)
        {
            aiBrain.DecideBestJob();
            if (IsAtRequiredDestination(aiBrain.BestJob))
            {
                currentstate = State.execute;
            }
            else
            {
                currentstate = State.move;
            }
        }
        else if (currentstate == State.move)
        {
            if (IsAtRequiredDestination(aiBrain.BestJob))
            {
                currentstate = State.execute;
            }
        }
        else if (currentstate == State.execute)
        {
            if (!aiBrain.finishedExecutingBestAction && !hasStartedAction)
            {
                hasStartedAction = true;
                aiBrain.BestJob.Execute(this);
            }
            else if (aiBrain.finishedExecutingBestAction)
            {
                hasStartedAction = false;
                currentstate = State.decide;
            }
        }
    }

    public bool IsAtRequiredDestination(Job job)
    {
        if (Vector3.Distance(job.RequiredDestination.position, mover.transform.position) < 2f)
        {
            return true;
        }
        else
        {
            return false;
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


        aiBrain.finishedExecutingBestAction = true;
        yield break;

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
        needs.energy += 5;
        aiBrain.finishedExecutingBestAction = true;
        yield break;
    }
    #endregion
}
