using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIHandleler : MonoBehaviour
{

    private GameObject Object;
    private Playerstats player;
    public GameObject[] HealthBarParts;
    public TextMeshProUGUI StrengthText;
    private int totalparts;
    private float oldhealth;
    void Start()
    {
        Object = GameObject.FindWithTag("player");
        player = Object.GetComponent<Playerstats>();
        totalparts = HealthBarParts.Length;
        oldhealth = player.Health;
    }

    // Update is called once per frame
    void Update()
    {
     if (oldhealth != player.Health)
        {
            oldhealth = player.Health;
            UpdateProgress();
        }
    }

    public void CLose(GameObject Closeobject)
    {

        Closeobject.SetActive(false);
        
    }


    public void Open(GameObject Openobject)
    {
       
            Openobject.SetActive(true);
       
    }


    
private void AbbreviateAndSetText(float value, TextMeshProUGUI textComponent, string prefix, int decimalPlaces)
{
    string abbreviatedValue = AbbreviateValue(value, decimalPlaces);
    textComponent.text = prefix + abbreviatedValue;
}

private string AbbreviateValue(float value, int decimalPlaces)
{
    string[] suffixes = { "", "K", "M", "B", "T", "Q", "QN", "SX", "SP", "OC", "INFINITIES" };
    int suffixIndex = 0;
    float sign = Mathf.Sign(value); // Extract the sign of the value

    // Work with the absolute value for abbreviation
    value = Mathf.Abs(value);

    while (value >= 1000 && suffixIndex < suffixes.Length - 1)
    {
        value /= 1000;
        suffixIndex++;
    }

    string formatString = "F" + decimalPlaces; // Construct the format string
    string formattedValue = value.ToString(formatString); // Format with the specified decimal places

    // Apply the sign to the formatted value
    formattedValue = (sign == -1) ? "-" + formattedValue : formattedValue;

    return formattedValue + suffixes[suffixIndex];
}
    void UpdateProgress()
    {
        
        float progressPercentage = (float)player.Health / player.MaxHealth;

        // Calculate the new amount based on the progress percentage
       int amount = Mathf.Clamp(Mathf.FloorToInt(progressPercentage * totalparts), 0, totalparts);

        // Activate the GameObjects up to the calculated index
        ActivateBaseParts(amount);
    }

    void ActivateBaseParts(int index)
    {
        // Deactivate all GameObjects in the array
        foreach (GameObject part in HealthBarParts)
        {
            part.SetActive(false);
        }

        // Activate the specific GameObjects up to the given index
        for (int i = 0; i < index; i++)
        {
            HealthBarParts[i].SetActive(true);
        }
    }
}

