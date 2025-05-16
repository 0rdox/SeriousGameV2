using UnityEngine;
using UnityEngine.UI;

public class EnergyBarController : MonoBehaviour
{
    public ServiceLocator serviceLocator;
    private GameManager _gameManager;
    
    private Slider _energyBar;
    
    void Start()
    {
        _gameManager = serviceLocator.GetGameManager();

        _energyBar = GetComponent<Slider>();
        _energyBar.maxValue = _gameManager.collectedEnergy;
        _energyBar.value = _gameManager.collectedEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        _energyBar.value = _gameManager.collectedEnergy;
    }
}
