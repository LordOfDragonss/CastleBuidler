using System;
using UnityEngine;

public class AIBrain : MonoBehaviour
{
    public Job BestJob { get; set; }
    private NPCController npc;
    public bool finishedDeciding;
    public bool finishedExecutingBestAction;
    public Job[] JobsAvailable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        npc = GetComponent<NPCController>();
        finishedDeciding = false;
        finishedExecutingBestAction = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void DecideBestJob()
    {
        finishedExecutingBestAction = false;
        float score = 0f;
        int nextBestJobIndex = 0;
        for (int i = 0; i < JobsAvailable.Length; i++)
        {
            if (ScoreJob(JobsAvailable[i]) > score)
            {
                nextBestJobIndex = i;
                score = JobsAvailable[i].score;
            }
        }

        BestJob = JobsAvailable[nextBestJobIndex];
        BestJob.SetRequiredDestination(npc);
        finishedDeciding = true;
    }

    public float ScoreJob(Job job)
    {
        float score = 1f;
        float modFactor = 1 - (1 / job.considerations.Length);
        for (int i = 0; i < job.considerations.Length; i++)
        {
            float considerationScore = job.considerations[i].ScoreConsideration(npc);
            float makeupValue = (1 - considerationScore) * modFactor;
            float finalScore = considerationScore + makeupValue * considerationScore;
            score *= finalScore;


            if (score == 0f)
            {
                job.score = 0f;
                return job.score;
            }
        }



        return job.score = score;
    }
}
