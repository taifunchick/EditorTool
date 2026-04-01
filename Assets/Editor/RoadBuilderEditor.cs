using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoadBuilderComponent))]
public class RoadBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        RoadBuilderComponent builder = (RoadBuilderComponent)target;

        GUILayout.Space(10);
        
        if (GUILayout.Button("🌲 Arrange the trees", GUILayout.Height(30)))
        {
            PlaceTreesAlongRoad(builder);
        }

        GUILayout.Space(5);
        
        if (GUILayout.Button("🗑 Delete all trees", GUILayout.Height(30)))
        {
            ClearTrees();
        }
    }

    void PlaceTreesAlongRoad(RoadBuilderComponent builder)
    {
        Undo.SetCurrentGroupName("Расстановка деревьев");
        int undoGroup = Undo.GetCurrentGroup();

        GameObject treeParent = new GameObject("Trees");
        Undo.RegisterCreatedObjectUndo(treeParent, "Create a container of trees");

        for (int i = 0; i < builder.treeCount; i++)
        {
            float t = (float)i / (builder.treeCount - 1);
            Vector3 position = GetPointOnRoad(t, builder.roadPoints);

            position += new Vector3(
                Random.Range(-builder.randomOffset, builder.randomOffset),
                0,
                Random.Range(-builder.randomOffset, builder.randomOffset)
            );

            GameObject tree = Instantiate(builder.treePrefab, position, Quaternion.identity);
            tree.transform.SetParent(treeParent.transform);
            Undo.RegisterCreatedObjectUndo(tree, "Create a tree");
        }

        Undo.CollapseUndoOperations(undoGroup);
        Debug.Log($"Placed {builder.treeCount} trees along the road");
    }

    Vector3 GetPointOnRoad(float t, Transform[] roadPoints)
    {
        int segmentCount = roadPoints.Length - 1;
        float segmentT = t * segmentCount;
        int segmentIndex = Mathf.FloorToInt(segmentT);
        float segmentNormT = segmentT - segmentIndex;

        if (segmentIndex >= roadPoints.Length - 1)
        {
            segmentIndex = roadPoints.Length - 2;
            segmentNormT = 1f;
        }

        return Vector3.Lerp(
            roadPoints[segmentIndex].position,
            roadPoints[segmentIndex + 1].position,
            segmentNormT
        );
    }

    void ClearTrees()
    {
        GameObject treeParent = GameObject.Find("Trees");
        if (treeParent != null)
        {
            Undo.SetCurrentGroupName("Delete trees");
            Undo.RegisterFullObjectHierarchyUndo(treeParent, "Delete trees");
            Undo.DestroyObjectImmediate(treeParent);
        }
    }
}