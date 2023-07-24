using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaController : MonoBehaviour
{
    public Planta data;
    private SpriteRenderer spr;
    public GameObject Borde;
    public int VecesRegado;
    bool CanPresed;
    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        spr.sprite = data.sprites[0];
        VecesRegado = 0;
        CanPresed = false;
        Borde.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && CanPresed)
        {
            if (VecesRegado == 2)
            {
                return;
            }
            ManagerUI.Instance.ActivarPanelRegar();
            ManagerUI.Instance.ActualizarUI(data.sprites[2],data.NombrePlanta);
        }
    }
    public void Regar()
    {
        if (VecesRegado == 0)
        {
            VecesRegado++;
            spr.sprite = data.sprites[1];
            AudioManager.instance.Play("LOGRO");
            GameManager.instance.SumarPunto();
            GameManager.instance.ActualizarTextoPuntos();
        }
        else if (VecesRegado == 1)
        {
            VecesRegado++;
            spr.sprite = data.sprites[2];
            AudioManager.instance.Play("LOGROFINAL");
            GameManager.instance.PuntosDobles();
            GameManager.instance.ActualizarTextoPuntos();
            ManagerUI.Instance.DesactivarPanelRegar();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       Borde.SetActive(true);
        CanPresed = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Borde.SetActive(false);
        CanPresed = false;
        ManagerUI.Instance.DesactivarPanelRegar();
    }
}
