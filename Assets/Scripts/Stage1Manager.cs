using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Stage1Manager : MonoBehaviour
{
    public static bool isRed;
    public static bool isGreen;
    public static bool isBlue;

    public Animator DoorAnimator;

    public UnityEvent onDoorOpen;
    public UnityEvent onDoorClose;

    private bool isDoorOpened = false;

    [SerializeField] private bool currentRed = false;
    [SerializeField] private bool currentGreen =false;
    [SerializeField] private bool currentBlue = false;

    private void Start()
    {
        isDoorOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
       currentRed = isRed;
       currentGreen = isGreen;
       currentBlue = isBlue;

       if (currentRed == true && currentGreen == true && currentBlue == true)
        {
            if (!isDoorOpened)
            {
                Open();
            }
        }
        else
        {
            if (isDoorOpened)
            {
                Close();
            }
        }

    void Open()
        {
            DoorAnimator.Play("Open");
            isDoorOpened = true;
            onDoorOpen?.Invoke();
        }

    void Close()
        {
            DoorAnimator.Play("Close");
            isDoorOpened = false;
            onDoorClose?.Invoke();
        }
    }
}
