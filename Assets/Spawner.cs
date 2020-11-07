using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject tree;
    public GameObject dollar;

    public float dollarProbability = 0.1f;
    public float treeProbability = 0.5f;

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

        int firstPosition = Random.Range(-1, 2);
        positions.Add(firstPosition);

        if (ShouldGenerateDollar())
        {
            GameObject dollarObject = Instantiate(dollar);
            dollarObject.transform.position = new Vector2(transform.position.x, 3.5f * firstPosition);
        }
        
        for (int i = 0; i < 2; ++i)
        {
            if (ShouldGenerateTree())
            {
                int nextPosition = Random.Range(-1, 2);
                GameObject treeObject = Instantiate(tree);

                while (positions.Contains(nextPosition))
                {
                    nextPosition = Random.Range(-1, 2);
                }
                treeObject.transform.position = new Vector2(transform.position.x, 3.5f * nextPosition);
            }
        }

    }

    private bool ShouldGenerateDollar()
    {
        return Random.Range(0.0f, 1.0f) <= dollarProbability;
    }

    private bool ShouldGenerateTree()
    {
        return Random.Range(0.0f, 1.0f) <= treeProbability;
    }
}
