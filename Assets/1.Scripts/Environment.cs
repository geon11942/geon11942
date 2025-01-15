using UnityEngine;

public class Environment : MonoBehaviour
{
    public bool Action=false;
    public float RegenTime = 8f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool CheckAction()
    {
        return Action;
    }
}
