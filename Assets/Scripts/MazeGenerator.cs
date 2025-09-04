using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]GameObject background;
    [SerializeField] GameObject Wall;
    [SerializeField] List<GameObject> walls = new List<GameObject>();
    
    BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Awake()
    {
        boxCollider = background.GetComponent<BoxCollider2D>();
        WallGenerator();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void WallGenerator()
    {
        for (int i = 0; i < walls.Count; i++)
        {
         Vector2 randomPosition = new Vector2(Random.Range(-2,2), Random.Range(-4,4));
         GameObject wallClone = Instantiate(walls[i], randomPosition, Quaternion.identity);
         wallClone.transform.parent = background.transform;
        }
    }


}
