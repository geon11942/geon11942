using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField]
    private GameObject ImageObject;
    void Start()
    {
        ImageObject = transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        ImageObject.transform.position=Camera.main.WorldToScreenPoint(new Vector3( transform.position.x, transform.position.y+4, transform.position.z));
    }
}
