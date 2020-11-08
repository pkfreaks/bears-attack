using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float obsticleProbability = 0.7f;
    public float dollarProbability = 0.1f;

    public GameObject dollar;

    public GameObject tree;
    public GameObject rock;
    public GameObject bear;

    private float currentSpawnTime = 0.0f;
    public float spawnTime = 2.5f;

    void Update()
    {
        if (currentSpawnTime <= 0.0f)
        {
            currentSpawnTime = spawnTime;
            GenerateGameObjects();
        }
        else
        {
            currentSpawnTime -= Time.deltaTime;
        }
    }

    private void GenerateGameObjects()
    {
        ISet<int> positions = new HashSet<int>();

        MaybeGenerateDollars(1, ref positions);
        MaybeGenerateObsticles(2, ref positions);
    }

    private void MaybeGenerateDollars(int howManyDollars, ref ISet<int> positionsAlreadyInUse)
    {
        for (int i = 0; i < howManyDollars; ++i)
        {
            if (ShouldGenerateDollar())
            {
                int nextPosition = Random.Range(-1, 2);
                GameObject treeObject = Instantiate(dollar);

                while (positionsAlreadyInUse.Contains(nextPosition))
                {
                    nextPosition = Random.Range(-1, 2);
                }
                positionsAlreadyInUse.Add(nextPosition);
                treeObject.transform.position = new Vector2(transform.position.x, 3.5f * nextPosition);
            }
        }
    }

    private bool ShouldGenerateDollar()
    {
        return Random.Range(0.0f, 1.0f) <= dollarProbability;
    }

    private void MaybeGenerateObsticles(int howManyObsticles, ref ISet<int> positionsAlreadyInUse)
    {
        for (int i = 0; i < howManyObsticles; ++i)
        {
            if (ShouldGenerateObsticle())
            {
                int nextPosition = Random.Range(-1, 2);
                GameObject treeObject = Instantiate(GetObsticle());

                while (positionsAlreadyInUse.Contains(nextPosition))
                {
                    nextPosition = Random.Range(-1, 2);
                }
                positionsAlreadyInUse.Add(nextPosition);
                treeObject.transform.position = new Vector2(transform.position.x, 3.5f * nextPosition);
            }
        }
    }

    private bool ShouldGenerateObsticle()
    {
        return Random.Range(0.0f, 1.0f) <= obsticleProbability;
    }

    private GameObject GetObsticle()
    {
        float random = Random.Range(0.0f, 1.0f);
        if (random <= 0.75f)
        {
            return tree;
        }
        else if (random <= 0.875f)
        {
            return rock;
        }
        else
        {
            return bear;
        }
    }
}
