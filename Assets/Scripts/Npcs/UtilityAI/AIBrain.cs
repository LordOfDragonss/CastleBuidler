using System;
using UnityEngine;

public class AIBrain : MonoBehaviour
{
    public Job BestJob { get; set; }
    private NPCController controller;
    public bool finishedDeciding;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<NPCController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(BestJob == null)
        {
            DecideBestJob(controller.JobsAvailable);
        }
    }
    public void DecideBestJob(Job[] jobsAvailable)
    {
        float score = 0f;
        int nextBestJobIndex = 0;
        for (int i = 0; i < jobsAvailable.Length; i++)
        {
            if (ScoreJob(jobsAvailable[i]) > score)
            {
                nextBestJobIndex = i;
                score = jobsAvailable[i].score;
            }
        }

        BestJob = jobsAvailable[nextBestJobIndex];
        finishedDeciding = true;
    }

    public float ScoreJob(Job job)
    {
        float score = 1f;
        float modFactor = 1 - (1 / job.considerations.Length);
        for (int i = 0; i < job.considerations.Length; i++)
        {
            float considerationScore = job.considerations[i].ScoreConsideration(controller);
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
