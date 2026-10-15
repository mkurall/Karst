using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject boxPrefab;//Normalde null
    void Start()
    {
        InvokeRepeating("CreateBox", 0f, 1.5f);
    }

    private void CreateBox() //Bu metod yeni kutu oluşturur
    {
        GameObject box = Instantiate(boxPrefab,
            transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
