using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.Collections;

public class KeypadControl : MonoBehaviour
{

    public List<int> correctPassword = new List<int>();
    private List<int> inputPasswordList = new List<int>();
    [SerializeField] private TMP_InputField codeDisplay;
    [SerializeField] private float displayReset = 2f;
    [SerializeField] private string successText;

    public Animator DoorAnimator;

    public UnityEvent onDoorOpen;
    public UnityEvent onDoorClose;

    private bool isDoorOpened;

    public UnityEvent onCorrectPassword;
    public UnityEvent onInCorrectPassword;

    public bool allowMultipleActivations;
    private bool hasUsedCorrectCode;

    public bool HasUsedCorrectCode {  get { return hasUsedCorrectCode; } }

    public void UserNumberEntry(int selectedNum)
    {
        if (inputPasswordList.Count >= 4)
            return;

        inputPasswordList.Add(selectedNum);

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        codeDisplay.text = null;
        for (int i = 0; i < inputPasswordList.Count; i++)
        {
            codeDisplay.text += inputPasswordList[i];
        }
    }

    public void PasswordDelete()
    {
        if (inputPasswordList.Count <= 0)
            return;

        var listposition = inputPasswordList.Count - 1;
        inputPasswordList.RemoveAt(listposition);

        UpdateDisplay();
    }

    public void PasswordEnter()
    {
       CheckPassword();
    }
    
    private void CheckPassword()
    {
        for (int i = 0; i < correctPassword.Count;i++)
        {
            if (inputPasswordList[i] != correctPassword[i])
            {
                IncorrectPassword();
                return;
            }
        }

        correctInputPassword();
    }

    private void correctInputPassword()
    {
        if(allowMultipleActivations)
        {
            onCorrectPassword.Invoke();
            StartCoroutine(ResetKeyCode());
        }
        else if (!allowMultipleActivations && !hasUsedCorrectCode)
        {
            onCorrectPassword.Invoke();
            hasUsedCorrectCode = true;
            codeDisplay.text = successText;

            Open();
        }
    }
    
    private void IncorrectPassword()
    {
        onInCorrectPassword.Invoke();
        StartCoroutine(ResetKeyCode());
    }

    IEnumerator ResetKeyCode()
    {
        yield return new WaitForSeconds(displayReset);

        inputPasswordList.Clear();
        codeDisplay.text = "Wrong Password!";
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
