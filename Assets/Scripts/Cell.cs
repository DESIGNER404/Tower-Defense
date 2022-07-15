using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    public Material MainMaterial, CanMaterial, CantMaterial;
    public bool CanBuild;
    public GameObject TowerPrefab;

    private Resources rs;

    void Start()
    {
        rs = FindObjectOfType<Resources>();
    }

    private void OnMouseUp()
    {
        if (CanBuild && rs.Gold >= rs.TowerCost)
        {
            Instantiate(TowerPrefab, transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0));
            CanBuild = false;
            rs.Build();
        }
    }

    private void OnMouseOver()
    {
        if (CanBuild)
        {
            GetComponent<Renderer>().material = CanMaterial;
        }
        else
        {
            GetComponent<Renderer>().material = CantMaterial;
        }
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material = MainMaterial;
    }
}
