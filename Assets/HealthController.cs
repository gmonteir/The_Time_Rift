using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public ProgressBar pb;

    // Start is called before the first frame update
    void Start()
    {
        pb.BarValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        pb.BarValue = pb.BarValue - 1;

    }
}
