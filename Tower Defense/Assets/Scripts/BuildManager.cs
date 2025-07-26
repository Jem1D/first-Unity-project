using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static BuildManager instance;
    void Awake()
    {
        instance = this;
    }
    public GameObject standardTurretPrefab;
    void Start()
    {
        turretToBuild = standardTurretPrefab;
    }
    private GameObject turretToBuild;

    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }
}
