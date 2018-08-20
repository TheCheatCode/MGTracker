using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongPressEdit : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    [SerializeField]
    private GameObject EditPrompt;
    [SerializeField]
    private InputField InputBox;
    [SerializeField]
    private Dropdown DropMedicine;

    [SerializeField]
    private UnityEvent onLongClick;

    private bool held;
    private float heldTimer;

    public float timeToHold;

    public void OnPointerDown(PointerEventData eventData)
    {
        held = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Release();
    }

    private void Release()
    {
        held = false;
        heldTimer = 0;
    }

	private void Update () {
		if (held)
        {
            heldTimer += Time.deltaTime;
            if (heldTimer >= timeToHold)
            {
                if (onLongClick != null)
                {
                    onLongClick.Invoke();
                }
                Release();
            }
        }
	}

    public void SaveChanges()
    {
        DropMedicine.options[DropMedicine.value].text = InputBox.text;
        DropMedicine.RefreshShownValue();
        EditPrompt.SetActive(false);
    }

    public void CancelChanges()
    {
        EditPrompt.SetActive(false);
    }

    public void DisplayPrompt()
    {
        EditPrompt.SetActive(true);
        InputBox.text = DropMedicine.options[DropMedicine.value].text;
    }

    public void AddNew(int index)
    {
        List<Dropdown.OptionData> options = DropMedicine.options;
        if (index == options.Count - 1)
        {
            // Prompt user for input, save input as new DropDown option before "Add New"
            options.Insert(options.Count - 1, new Dropdown.OptionData("New"));
            DropMedicine.value = options.Count - 2;
            DisplayPrompt();
        }
    }
}
