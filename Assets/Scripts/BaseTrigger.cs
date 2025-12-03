using Unity.VisualScripting;
using UnityEngine;

public class BaseTrigger : MonoBehaviour
{
    private string cubeTag;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch (gameObject.tag)
        {
            case "BaseR":
                cubeTag = "R";
                    break;
            case "BaseG":
                cubeTag = "G";
                    break;
            case "BaseB":
                cubeTag = "B";
                    break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(cubeTag))
        {
            setState(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(cubeTag))
        {
            setState(false);
        }    
    }

    private void setState(bool state)
    {
        switch (gameObject.tag)
        {
            case "BaseR":
                Stage1Manager.isRed = state;
                break;
            case "BaseG":
                Stage1Manager.isGreen = state;
                break;
            case "BaseB":
                Stage1Manager.isBlue = state;
                break;
        }
    }
}
