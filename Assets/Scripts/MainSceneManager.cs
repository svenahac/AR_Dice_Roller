using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class MainSceneManager : MonoBehaviour
{

    [SerializeField]
    private GameObject prefabD4;
    [SerializeField]
    private GameObject prefabD6;
    [SerializeField]
    private GameObject prefabD8;
    [SerializeField]
    private GameObject prefabD10;
    [SerializeField]
    private GameObject prefabD12;
    [SerializeField]
    private GameObject prefabD20;

    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public List<GameObject> aliveDice = new List<GameObject>();

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
    }

    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
    }

    public void refreshDice()
    {
        foreach (GameObject die in aliveDice)
        {
            Destroy(die);
        }

        aliveDice = new List<GameObject>();

        for (int die = 0; die < 6; die++)
        {
            for (int i = 0; i < DiceChooserManager.dices[die]; i++)
            {
                Vector2 centerPos = new Vector2(
                    Screen.width / 2 + Random.Range(-250,250),
                    Screen.height / 2 + Random.Range(-250, 250)
                    );

                if (raycastManager.Raycast(centerPos, hits, TrackableType.PlaneWithinPolygon))
                {
                    foreach (ARRaycastHit hit in hits)
                    {
                        Pose pose = hits[0].pose;
                        GameObject obj;

                        switch (die)
                        {
                            case 0:
                                obj = Instantiate(prefabD4, pose.position, pose.rotation);
                                break;
                            case 1:
                                obj = Instantiate(prefabD6, pose.position, pose.rotation);
                                break;
                            case 2:
                                obj = Instantiate(prefabD8, pose.position, pose.rotation);
                                break;
                            case 3:
                                obj = Instantiate(prefabD10, pose.position, pose.rotation);
                                break;
                            case 4:
                                obj = Instantiate(prefabD12, pose.position, pose.rotation);
                                break;
                            case 5:
                                obj = Instantiate(prefabD20, pose.position, pose.rotation);
                                break;
                            default:
                                obj = Instantiate(prefabD6, pose.position, pose.rotation);
                                break;
                        }

                        aliveDice.Add(obj);
                    }
                }
            }
        }
    }

    public void rollDice()
    {
        
    }

}
