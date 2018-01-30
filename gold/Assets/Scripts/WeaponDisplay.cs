using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{

    public ArrowKeyMovement akm;
    Text text_component;
    string Weapon;

    // Use this for initialization
    void Start()
    {

        text_component = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (akm.weapon_nums == 0)
        {
            Weapon = "Bow";
        }
        if (akm.weapon_nums == 1)
        {
            Weapon = "Boomrang";
        }
        if (akm.weapon_nums == 2)
        {
            Weapon = "Bomb";

        }
        if (text_component != null)
            text_component.text = "Weapon(Z):" + Weapon + "(use C to change it)";
    }
}
