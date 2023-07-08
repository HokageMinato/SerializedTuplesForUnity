using SerializedTuples;
using SerializedTuples.Runtime;
using UnityEngine;

public class SerializedTupleDemo : MonoBehaviour
{

    //Using Lables to define inspector fields.
    [SerializedTupleLabels("MoveSpeed", "BasePower", "EnemyClass", "PrefabObject")]
    public SerializedTuple<float, int, string, GameObject, double> EnemyData = new (0,4,"Random",null,343);

    //Data access demo
    public void Start()
    {
        //Access by name property. (Includes tiny overhead for string lookup and boxcast)
        float moveSpeed = EnemyData.GetValue<float>("MoveSpeed");
        Debug.Log($"{nameof(moveSpeed)}:{moveSpeed}");

        // Accessing by index. (Includes tiny overhead for boxcast) (index starts from 1)
        int basePower = EnemyData.GetPropertyValueByIdx<int>(2);
        Debug.Log($"{nameof(basePower)}:{basePower}");

        // Accessing directly. No overhead of any kind.
        string enemyCategory = EnemyData.v3;                       
        GameObject enemyPrefab = EnemyData.v4;
        Debug.Log($"{nameof(enemyCategory)}:{enemyCategory}  -- {nameof(enemyPrefab)}" +
            $" Name: {enemyPrefab.name}");

        //Value holder with no labels dont get displayed in inspector,
        //but are useful as data holders and accessible via prop only.
        double lastVal = EnemyData.v5;
        Debug.Log($"{nameof(lastVal)}:{lastVal}");

    }


}
