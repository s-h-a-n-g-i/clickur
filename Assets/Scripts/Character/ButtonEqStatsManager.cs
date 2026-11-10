using UnityEngine;

public class ButtonEqStatsManager : MonoBehaviour
{
    [SerializeField] private GameObject stats;
    [SerializeField] private GameObject Eq;

    public void ButtonEq()
    {
        Eq.SetActive(true);
        stats.SetActive(false);
    }
    public void ButtonStats()
    {
        stats.SetActive(true);
        Eq.SetActive(false);
    }

}
