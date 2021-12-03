using UnityEngine;

public class lighting : MonoBehaviour
{
    public static lighting Instance { get; private set; }
    public Transform view;

    private Vector3 lightdir;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        lightdir = new Vector3(50f, 0f, 0f);
    }

    void Update()
    {
        lightdir.y = view.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(lightdir);
    }
}
