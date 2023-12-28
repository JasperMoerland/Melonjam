using UnityEngine;
using UnityEngine.SceneManagement;
public class Playerstats : MonoBehaviour
{
    public float Health;
    public float MaxHealth;
    public float Damage;
    public string EquipedCharm;
    public float Mana;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //HEALING
        if (timer >= 0.1f)
        {
            if (Health + (MaxHealth / 200) <= MaxHealth)
            {
                Health += (MaxHealth / 200);
            }
            timer = 0;
            
        }
        //dying, run any code here you want!
        if (Health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        }
    }
    public void DamageTEst()
    {
        Health -= 10;
    }
}