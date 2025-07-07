using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{

    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private Transform platesVisualPrefab;
    [SerializeField] private PlatesCounter platesCounter;
    float plateOffsetY = .1f;

    private List<GameObject> plateVisualGameObjectList;


    private void Awake()
    {
        plateVisualGameObjectList = new List<GameObject>();
    }

    // Start is called before the first frame update
   private void Start()
    {
        platesCounter.OnPlateSpawn += PlatesCounter_OnPlateSpawned;
        platesCounter.OnPlateTaken += PlatesCounter_OnPlateTaken;
    }


    private void PlatesCounter_OnPlateTaken(object sender, System.EventArgs e)
    {
        GameObject plateGameObject = plateVisualGameObjectList[plateVisualGameObjectList.Count - 1];
        plateVisualGameObjectList.Remove(plateGameObject);
        Destroy(plateGameObject);
    }

    private void PlatesCounter_OnPlateSpawned(object sender , System.EventArgs e )
    {
        Transform plateVisualTransform =  Instantiate(platesVisualPrefab, counterTopPoint );
        plateVisualTransform.localPosition = new Vector3(0,plateOffsetY * plateVisualGameObjectList.Count, 0);

        plateVisualGameObjectList.Add(plateVisualTransform.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
