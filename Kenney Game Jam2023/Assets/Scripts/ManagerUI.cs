using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
    public static ManagerUI Instance;
    public GameObject UIITEM;
    public GameObject PanelAgua;
    public TextMeshProUGUI TextoAguaRestante;
    public GameObject PanelRegar;

    [SerializeField] private Image ImagenData;
    [SerializeField] private TextMeshProUGUI NombreData;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
    }
    public void ActualizarUI(Sprite image, string Nombre)
    {
        ImagenData.sprite = image;
        NombreData.text = Nombre;
    }
    public void ActualizarTextoAgua(string Texto)
    {
        TextoAguaRestante.text = Texto;
    }
    public void ActivarPanelRegar()
    {
        PanelRegar.SetActive(true);
    }
    public void DesactivarPanelRegar()
    {
        PanelRegar.SetActive(false);
    }

    public void ActivarUIItem()
    {
        UIITEM.SetActive(true);
        PanelAgua.SetActive(true);
    }
    public void DesactivarUIItem()
    {
        UIITEM.SetActive(false);
        PanelAgua.SetActive(false);
    }
}
