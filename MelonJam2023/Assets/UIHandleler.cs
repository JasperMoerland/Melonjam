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
   
}

