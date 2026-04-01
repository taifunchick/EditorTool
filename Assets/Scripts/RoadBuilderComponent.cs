using UnityEngine;

// Этот скрипт можно вешать на объекты в сцене
public class RoadBuilderComponent : MonoBehaviour
{
    [Header("Settings")]
    public GameObject treePrefab;
    public int treeCount = 50;
    public float spacing = 2f;
    public float randomOffset = 1f;

    [Header("Road's points")]
    public Transform[] roadPoints;
}